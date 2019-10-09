using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Keydeem {
    static class Program {
        internal static KeydeemAppContext Context;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new KeydeemAppContext());
        }
    }

    class KeydeemAppContext : ApplicationContext {
        private NotifyIcon icon;
        private Steam steam;

        private Keybindings keybindings;
        private AdjustKeybindings kbwindow;
        private MainWindow window;

        StreamWriter logStream = new StreamWriter("keydeem.log", true) {
            AutoFlush = true
        };

        private string log = "";

        private Dictionary<string, MenuItem> items = new Dictionary<string, MenuItem>();

        public KeydeemAppContext() {
            Program.Context = this;

            items["Exit"] = new MenuItem("Exit", Exit);
            items["Keybindings"] = new MenuItem("Adjust keybindings...", AdjKeybindings);

            icon = new NotifyIcon() {
                Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location),
                ContextMenu = new ContextMenu(items.Values.ToArray()),
                Text = "Keydeem - Logging in to Steam...",
                Visible = true
            };

            icon.DoubleClick += (a,b) => {
                if(this.window != null) this.window.Activate();
                else {
                    this.window = new MainWindow(log);
                    window.Show();

                    window.FormClosed += (c,d) => window = null;
                }
            };

            keybindings = Keybindings.Get(new Dictionary<string, Keybinding> {
                { "Redeem Clipboard", new Keybinding(KeyModifier.Super | KeyModifier.Shift, Keys.R) },
                { "Force Redeem Clipboard", new Keybinding(KeyModifier.Super | KeyModifier.Shift | KeyModifier.Control, Keys.R) }
            });

            steam = new Steam(successfulLogon => {
                if(!successfulLogon) {
                    Exit(null, null);
                    return;
                }

                icon.Text = "Keydeem";

                icon.ShowBalloonTip(0, "Logged on to Steam", "Press " + keybindings.bindings["Redeem Clipboard"] + " to redeem keys on your clipboard.", ToolTipIcon.Info);
            }, (detail, item) => {
                if(item == null) Program.Context.icon.ShowBalloonTip(0, "Key redemption failed", "" + detail, ToolTipIcon.Error);
                else Program.Context.icon.ShowBalloonTip(0, "Key redemption successful", "You redeemed " + item, ToolTipIcon.Info);
            });

            NativeHot.Add(keybindings.bindings["Redeem Clipboard"].GetModifiers(), keybindings.bindings["Redeem Clipboard"].Key, () => {
                if(!steam.loggedOn) icon.ShowBalloonTip(0, "Not logged on to Steam", "Log on to Steam before redeeming keys.", ToolTipIcon.Error);
                else if(!Clipboard.ContainsText()) icon.ShowBalloonTip(0, "Clipboard does not contain text", "Copy your key and try again.", ToolTipIcon.Error);
                else {
                    MatchCollection matches = new Regex("(\\w{5}\\-\\w{5}\\-\\w{5})").Matches(Clipboard.GetText());

                    if(matches.Count == 0) {
                        icon.ShowBalloonTip(0, "Clipboard does not contain standard Steam keys", "Keydeem only supports standard 5-5-5 Steam keys. To force redemption, use " + keybindings.bindings["Force Redeem Clipboard"] + ".", ToolTipIcon.Error);
                    }

                    foreach(Match match in matches) {
                        steam.RedeemKey(match.Value);
                    }
                }
            });

            // I don't know why this is necessary
            Thread.Sleep(100);

            NativeHot.Add(keybindings.bindings["Force Redeem Clipboard"].GetModifiers(), keybindings.bindings["Force Redeem Clipboard"].Key, () => {
                if(!steam.loggedOn) icon.ShowBalloonTip(0, "Not logged on to Steam", "Log on to Steam before redeeming keys.", ToolTipIcon.Error);
                else if(!Clipboard.ContainsText()) icon.ShowBalloonTip(0, "Clipboard does not contain text", "Copy your key and try again.", ToolTipIcon.Error);
                else {
                    steam.RedeemKey(Clipboard.GetText());
                }
            });
        }

        private void Exit(object sender, EventArgs e) {
            Program.Context.Log("Shutting down...");

            icon.Visible = false;

            if(window != null) window.Dispose();
            if(steam != null) steam.Kill();
            if(kbwindow != null) kbwindow.Dispose();

            Program.Context.Log("Sayonara!");

            logStream.Dispose();

            Application.Exit();
        }

        private void AdjKeybindings(object sender, EventArgs e) {
            if(kbwindow != null) kbwindow.Activate();
            else {
                kbwindow = new AdjustKeybindings(ref keybindings);
                kbwindow.FormClosed += (a, b) => kbwindow = null;
                kbwindow.Show();
            }
        }

        internal string PadZero(int number) {
            if(number < 10) return "0" + number;
            else return "" + number;
        }

        internal void Log(string text) {
            text = "[" + PadZero(DateTime.Now.Month) + "/" + PadZero(DateTime.Now.Day) + "/" + PadZero(DateTime.Now.Year) + " " + PadZero(DateTime.Now.Hour) + ":" + PadZero(DateTime.Now.Minute) + ":" + PadZero(DateTime.Now.Second) + "] " + text;

            log += text + "\r\n";
            logStream.Write(text + "\n");

            if(window != null) window.Log(text + "\r\n");
        }
    }
}
