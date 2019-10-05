using Keydeem.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
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
        internal NotifyIcon icon;
        private Steam steam;

        private Dictionary<string, MenuItem> items = new Dictionary<string, MenuItem>();

        public KeydeemAppContext() {
            Program.Context = this;

            items["Exit"] = new MenuItem("Exit", Exit);

            icon = new NotifyIcon() {
                Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location),
                ContextMenu = new ContextMenu(items.Values.ToArray()),
                Text = "Keydeem - Logging in to Steam...",
                Visible = true
            };

            steam = new Steam((successfulLogon) => {
                if(!successfulLogon) {
                    Exit(null, null);
                    return;
                }

                icon.Text = "Keydeem";

                icon.ShowBalloonTip(0, "Logged on to Steam", "Press SUPER+SHIFT+R to redeem keys on your clipboard.", ToolTipIcon.Info);
            });

            NativeHot.Add(KeyModifier.Super | KeyModifier.Shift, Keys.R, () => {
                if(!steam.loggedOn) icon.ShowBalloonTip(0, "Not logged on to Steam", "Log on to Steam before redeeming keys.", ToolTipIcon.Error);
                else if(!Clipboard.ContainsText()) icon.ShowBalloonTip(0, "Clipboard does not contain text", "Try again.", ToolTipIcon.Error);
                else {
                    string key = Clipboard.GetText();
                    steam.RedeemKey(key);
                }
            });
        }

        void Exit(object sender, EventArgs e) {
            icon.Visible = false;

            if(steam != null) steam.Kill();
            Application.Exit();
        }
    }
}
