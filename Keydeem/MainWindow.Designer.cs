namespace Keydeem {
    partial class MainWindow {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.labelAppTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOpenThirdparty = new System.Windows.Forms.Button();
            this.buttonKYR = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(13, 13);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.Size = new System.Drawing.Size(346, 324);
            this.textBoxLog.TabIndex = 0;
            // 
            // labelAppTitle
            // 
            this.labelAppTitle.AutoSize = true;
            this.labelAppTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAppTitle.Location = new System.Drawing.Point(12, 340);
            this.labelAppTitle.Name = "labelAppTitle";
            this.labelAppTitle.Size = new System.Drawing.Size(138, 33);
            this.labelAppTitle.TabIndex = 1;
            this.labelAppTitle.Text = "Keydeem";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 373);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Copyright © 2019 Cutie Café.";
            // 
            // buttonOpenThirdparty
            // 
            this.buttonOpenThirdparty.Location = new System.Drawing.Point(265, 340);
            this.buttonOpenThirdparty.Name = "buttonOpenThirdparty";
            this.buttonOpenThirdparty.Size = new System.Drawing.Size(94, 48);
            this.buttonOpenThirdparty.TabIndex = 3;
            this.buttonOpenThirdparty.Text = "Show open source licenses";
            this.buttonOpenThirdparty.UseVisualStyleBackColor = true;
            this.buttonOpenThirdparty.Click += new System.EventHandler(this.buttonOpenThirdparty_Click);
            // 
            // buttonKYR
            // 
            this.buttonKYR.Location = new System.Drawing.Point(167, 340);
            this.buttonKYR.Name = "buttonKYR";
            this.buttonKYR.Size = new System.Drawing.Size(94, 48);
            this.buttonKYR.TabIndex = 4;
            this.buttonKYR.Text = "Show Keydeem\'s license";
            this.buttonKYR.UseVisualStyleBackColor = true;
            this.buttonKYR.Click += new System.EventHandler(this.buttonKYR_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 400);
            this.Controls.Add(this.buttonKYR);
            this.Controls.Add(this.buttonOpenThirdparty);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelAppTitle);
            this.Controls.Add(this.textBoxLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Keydeem";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Label labelAppTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOpenThirdparty;
        private System.Windows.Forms.Button buttonKYR;
    }
}