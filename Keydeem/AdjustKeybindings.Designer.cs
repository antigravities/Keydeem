using System;

namespace Keydeem {
    partial class AdjustKeybindings {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdjustKeybindings));
            this.selectedKeybinding = new System.Windows.Forms.ComboBox();
            this.modifierSuper = new System.Windows.Forms.CheckBox();
            this.modifierCtrl = new System.Windows.Forms.CheckBox();
            this.modifierAlt = new System.Windows.Forms.CheckBox();
            this.modifierShift = new System.Windows.Forms.CheckBox();
            this.key = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // selectedKeybinding
            // 
            this.selectedKeybinding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectedKeybinding.FormattingEnabled = true;
            this.selectedKeybinding.Location = new System.Drawing.Point(12, 12);
            this.selectedKeybinding.Name = "selectedKeybinding";
            this.selectedKeybinding.Size = new System.Drawing.Size(217, 21);
            this.selectedKeybinding.TabIndex = 0;
            this.selectedKeybinding.SelectedIndexChanged += new System.EventHandler(this.selectedKeybinding_SelectedIndexChanged);
            // 
            // modifierSuper
            // 
            this.modifierSuper.AutoSize = true;
            this.modifierSuper.Location = new System.Drawing.Point(12, 39);
            this.modifierSuper.Name = "modifierSuper";
            this.modifierSuper.Size = new System.Drawing.Size(63, 17);
            this.modifierSuper.TabIndex = 1;
            this.modifierSuper.Text = "SUPER";
            this.modifierSuper.UseVisualStyleBackColor = true;
            this.modifierSuper.CheckedChanged += new System.EventHandler(this.modifierSuper_CheckedChanged);
            // 
            // modifierCtrl
            // 
            this.modifierCtrl.AutoSize = true;
            this.modifierCtrl.Location = new System.Drawing.Point(12, 62);
            this.modifierCtrl.Name = "modifierCtrl";
            this.modifierCtrl.Size = new System.Drawing.Size(54, 17);
            this.modifierCtrl.TabIndex = 2;
            this.modifierCtrl.Text = "CTRL";
            this.modifierCtrl.UseVisualStyleBackColor = true;
            this.modifierCtrl.CheckedChanged += new System.EventHandler(this.modifierCtrl_CheckedChanged);
            // 
            // modifierAlt
            // 
            this.modifierAlt.AutoSize = true;
            this.modifierAlt.Location = new System.Drawing.Point(12, 85);
            this.modifierAlt.Name = "modifierAlt";
            this.modifierAlt.Size = new System.Drawing.Size(46, 17);
            this.modifierAlt.TabIndex = 3;
            this.modifierAlt.Text = "ALT";
            this.modifierAlt.UseVisualStyleBackColor = true;
            this.modifierAlt.CheckedChanged += new System.EventHandler(this.modifierAlt_CheckedChanged);
            // 
            // modifierShift
            // 
            this.modifierShift.AutoSize = true;
            this.modifierShift.Location = new System.Drawing.Point(12, 108);
            this.modifierShift.Name = "modifierShift";
            this.modifierShift.Size = new System.Drawing.Size(57, 17);
            this.modifierShift.TabIndex = 4;
            this.modifierShift.Text = "SHIFT";
            this.modifierShift.UseVisualStyleBackColor = true;
            this.modifierShift.CheckedChanged += new System.EventHandler(this.modifierShift_CheckedChanged);
            // 
            // key
            // 
            this.key.Location = new System.Drawing.Point(129, 39);
            this.key.Name = "key";
            this.key.Size = new System.Drawing.Size(100, 20);
            this.key.TabIndex = 5;
            this.key.KeyUp += new System.Windows.Forms.KeyEventHandler(this.key_KeyUp);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 32);
            this.label1.TabIndex = 6;
            this.label1.Text = "Changes save automatically, but will not take affect until Keydeem is restarted.";
            // 
            // AdjustKeybindings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 169);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.key);
            this.Controls.Add(this.modifierShift);
            this.Controls.Add(this.modifierAlt);
            this.Controls.Add(this.modifierCtrl);
            this.Controls.Add(this.modifierSuper);
            this.Controls.Add(this.selectedKeybinding);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdjustKeybindings";
            this.Text = "Adjust Keybindings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox selectedKeybinding;
        private System.Windows.Forms.CheckBox modifierSuper;
        private System.Windows.Forms.CheckBox modifierCtrl;
        private System.Windows.Forms.CheckBox modifierAlt;
        private System.Windows.Forms.CheckBox modifierShift;
        private System.Windows.Forms.TextBox key;
        private System.Windows.Forms.Label label1;
    }
}