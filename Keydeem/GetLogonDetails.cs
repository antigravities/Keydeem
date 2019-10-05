using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Keydeem {
    public partial class GetLogonDetails : Form {
        Action<string, string, string, bool> callback;

        public GetLogonDetails(Action<string, string, string, bool> callback) {
            this.callback = callback;

            InitializeComponent();

            this.FormClosed += this.OnFormClosed;
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e) {
            callback(null, null, null, true);
        }

        private void buttonSubmit_Click(object sender, EventArgs e) {
            this.Invoke((Action) (() => this.Enabled = false));

            callback(inputAccountName.Text, inputPassword.Text, inputSteamGuard.Text, false);
        }

        public void Update(bool enableForm, bool enableSteamGuardCode, string description) {
            this.Invoke((Action) (() => this.Enabled = enableForm));
            this.inputSteamGuard.Invoke((Action) (() => this.inputSteamGuard.Enabled = enableSteamGuardCode));
            this.labelDescription.Invoke((Action) (() => this.labelDescription.Text = description));
            this.Invoke((Action) (() => this.Activate()));
        }
    }
}
