namespace Keydeem {
    partial class GetLogonDetails {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetLogonDetails));
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelAccountName = new System.Windows.Forms.Label();
            this.inputAccountName = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.inputPassword = new System.Windows.Forms.TextBox();
            this.labelTwoFactor = new System.Windows.Forms.Label();
            this.inputSteamGuard = new System.Windows.Forms.TextBox();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(12, 9);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(81, 13);
            this.labelDescription.TabIndex = 0;
            this.labelDescription.Text = "Log in to Steam";
            // 
            // labelAccountName
            // 
            this.labelAccountName.AutoSize = true;
            this.labelAccountName.Location = new System.Drawing.Point(12, 36);
            this.labelAccountName.Name = "labelAccountName";
            this.labelAccountName.Size = new System.Drawing.Size(78, 13);
            this.labelAccountName.TabIndex = 1;
            this.labelAccountName.Text = "Account Name";
            // 
            // inputAccountName
            // 
            this.inputAccountName.Location = new System.Drawing.Point(133, 33);
            this.inputAccountName.Name = "inputAccountName";
            this.inputAccountName.Size = new System.Drawing.Size(114, 20);
            this.inputAccountName.TabIndex = 2;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(12, 62);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(53, 13);
            this.labelPassword.TabIndex = 3;
            this.labelPassword.Text = "Password";
            // 
            // inputPassword
            // 
            this.inputPassword.Location = new System.Drawing.Point(133, 59);
            this.inputPassword.Name = "inputPassword";
            this.inputPassword.PasswordChar = '•';
            this.inputPassword.Size = new System.Drawing.Size(114, 20);
            this.inputPassword.TabIndex = 4;
            // 
            // labelTwoFactor
            // 
            this.labelTwoFactor.AutoSize = true;
            this.labelTwoFactor.Location = new System.Drawing.Point(12, 88);
            this.labelTwoFactor.Name = "labelTwoFactor";
            this.labelTwoFactor.Size = new System.Drawing.Size(97, 13);
            this.labelTwoFactor.TabIndex = 5;
            this.labelTwoFactor.Text = "Steam Guard Code";
            // 
            // inputSteamGuard
            // 
            this.inputSteamGuard.Enabled = false;
            this.inputSteamGuard.Location = new System.Drawing.Point(133, 85);
            this.inputSteamGuard.Name = "inputSteamGuard";
            this.inputSteamGuard.Size = new System.Drawing.Size(114, 20);
            this.inputSteamGuard.TabIndex = 6;
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(12, 115);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(235, 23);
            this.buttonSubmit.TabIndex = 7;
            this.buttonSubmit.Text = "Log In";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // GetLogonDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 150);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.inputSteamGuard);
            this.Controls.Add(this.labelTwoFactor);
            this.Controls.Add(this.inputPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.inputAccountName);
            this.Controls.Add(this.labelAccountName);
            this.Controls.Add(this.labelDescription);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GetLogonDetails";
            this.Text = "Keydeem";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelAccountName;
        private System.Windows.Forms.TextBox inputAccountName;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox inputPassword;
        private System.Windows.Forms.Label labelTwoFactor;
        private System.Windows.Forms.TextBox inputSteamGuard;
        private System.Windows.Forms.Button buttonSubmit;
    }
}