using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SteamKit2;
using Newtonsoft.Json;
using System.Threading;
using SteamKit2.Internal;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Keydeem {
    class Steam : ClientMsgHandler {
        private SteamUser.LogOnDetails logOnDetails = new SteamUser.LogOnDetails();
        private SteamClient client;
        private CallbackManager mgr;
        private SteamUser user;
        private bool runCallbacks = true;

        private GetLogonDetails askForm;

        private Action<bool> onLogOn;
        private Action<EPurchaseResultDetail, string> onKeyRedeem;

        private EResult previousResult = EResult.OK;

        internal bool loggedOn { get; private set; } = false;

        public Steam(Action<bool> OnLogOn, Action<EPurchaseResultDetail, string> OnKeyRedeem) {
            this.onLogOn = OnLogOn;
            this.onKeyRedeem = OnKeyRedeem;

            if(File.Exists("auth.json")) {
                logOnDetails = JsonConvert.DeserializeObject<SteamUser.LogOnDetails>(File.ReadAllText("auth.json"));
            }
            
            if(logOnDetails.Username != null && (logOnDetails.Password != null || logOnDetails.LoginKey != null)) {
                EResult logInResult = AttemptLogIn();

                if(logInResult == EResult.OK) {
                    loggedOn = true;
                    OnLogOn(true);
                    return;
                } else Console.WriteLine(logInResult);
            }

            previousResult = EResult.OK;

            askForm = new GetLogonDetails(HandleFormResponse);
            askForm.Show();
        }

        private void HandleFormResponse(string accountName, string accountPassword, string steamGuardCode, bool userClosed) {
            if(userClosed) {
                onLogOn(false);
                return;
            }

            logOnDetails.Username = accountName;
            logOnDetails.Password = accountPassword;
            logOnDetails.ShouldRememberPassword = true;

            if(previousResult == EResult.AccountLogonDenied) logOnDetails.AuthCode = steamGuardCode;
            else if(previousResult == EResult.AccountLoginDeniedNeedTwoFactor) logOnDetails.TwoFactorCode = steamGuardCode;

            EResult res = AttemptLogIn();

            if(res == EResult.OK) {
                askForm.Dispose();
                askForm = null;

                logOnDetails.TwoFactorCode = null;
                logOnDetails.AuthCode = null;

                File.WriteAllText("auth.json", JsonConvert.SerializeObject(logOnDetails));

                loggedOn = true;

                onLogOn(true);
                return;
            }

            logOnDetails.LoginKey = null;
            logOnDetails.SentryFileHash = null;

            if(res == EResult.AccountLoginDeniedNeedTwoFactor || res == EResult.TwoFactorCodeMismatch) {
                askForm.Update(true, true, "Please enter your two-factor code below.");
                return;
            } else if(res == EResult.AccountLogonDenied) {
                askForm.Update(true, true, "Please enter your email code below.");
            } else {
                askForm.Update(true, false, "Error logging in: " + res);
            }
        }

        private EResult AttemptLogIn() {
            EResult result = EResult.Fail;

            client = new SteamClient();
            mgr = new CallbackManager(client);
            user = client.GetHandler<SteamUser>();

            bool runCallbacksLocally = true;

            mgr.Subscribe<SteamClient.ConnectedCallback>(callback => {
                user.LogOn(logOnDetails);
            });

            mgr.Subscribe<SteamUser.LoggedOnCallback>(callback => {
                result = callback.Result;

                if(callback.Result != EResult.OK) client.Disconnect();
                else {
                    new Thread(() => {
                        while(runCallbacks) mgr.RunWaitCallbacks(TimeSpan.FromSeconds(1));
                        client.Disconnect();
                    }).Start();
                }

                runCallbacksLocally = false;
            });

            mgr.Subscribe<SteamUser.UpdateMachineAuthCallback>(callback => {
                int size;
                byte[] sentryHash;

                using(FileStream stream = File.Open("sentry.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite)) {
                    stream.Seek(callback.Offset, SeekOrigin.Begin);
                    stream.Write(callback.Data, 0, callback.BytesToWrite);

                    size = (int) stream.Length;

                    stream.Seek(0, SeekOrigin.Begin);

                    using(SHA1 sha1 = SHA1.Create()) {
                        sentryHash = sha1.ComputeHash(stream);
                    }
                }

                user.SendMachineAuthResponse(new SteamUser.MachineAuthDetails {
                    JobID = callback.JobID,

                    FileName = callback.FileName,

                    BytesWritten = callback.BytesToWrite,
                    FileSize = size,
                    Offset = callback.Offset,

                    Result = EResult.OK,
                    LastError = 0,

                    OneTimePassword = callback.OneTimePassword,
                    SentryFileHash = sentryHash
                });

                logOnDetails.SentryFileHash = CryptoHelper.SHAHash(File.ReadAllBytes("sentry.bin"));

                File.WriteAllText("auth.json", JsonConvert.SerializeObject(logOnDetails));

                Console.WriteLine("saved sentry hash");
            });

            mgr.Subscribe<SteamUser.LoginKeyCallback>(callback => {
                Console.WriteLine("accepting new login key");

                logOnDetails.Password = null;
                logOnDetails.ShouldRememberPassword = true;
                logOnDetails.LoginKey = callback.LoginKey;

                File.WriteAllText("auth.json", JsonConvert.SerializeObject(logOnDetails));

                user.AcceptNewLoginKey(callback);
            });

            client.AddHandler(this);

            client.Connect();

            while(runCallbacksLocally) mgr.RunWaitCallbacks(TimeSpan.FromSeconds(1));

            previousResult = result;

            return result;
        }

        internal void Kill() {
            if(askForm != null) askForm.Dispose();
            runCallbacks = false;
        }

        internal void RedeemKey(string key) {
            client.Send(new ClientMsgProtobuf<CMsgClientRegisterKey>(EMsg.ClientRegisterKey) {
                SourceJobID = client.GetNextJobID(),
                Body = {
                    key = key
                }
            });
        }

        public override void HandleMsg(IPacketMsg msg) {
            if(msg.MsgType != EMsg.ClientPurchaseResponse) return;
            CMsgClientPurchaseResponse resp = new ClientMsgProtobuf<CMsgClientPurchaseResponse>(msg).Body;

            EResult result = (EResult) resp.eresult;

            if(result != EResult.OK) {
                onKeyRedeem((EPurchaseResultDetail) resp.purchase_result_details, null);
                
            } else {
                KeyValue receipt = new KeyValue();

                using(MemoryStream stream = new MemoryStream(resp.purchase_receipt_info)) {
                    if(!receipt.TryReadAsBinary(stream)) Console.WriteLine("Could not process key response");
                }

                string itemName = "No items added to account.";

                if(receipt["lineitems"].Children.Count > 0) {
                    List<string> items = new List<string>();

                    foreach(KeyValue item in receipt["lineitems"].Children) {
                        items.Add(item["ItemDescription"].Value + " (" + item["PackageID"].AsUnsignedInteger() + ")");
                    }

                    itemName = string.Join(",", items);
                }

                onKeyRedeem((EPurchaseResultDetail) resp.purchase_result_details, itemName);
            }
        }
    }
}
