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
    public partial class AdjustKeybindings : Form {
        private Keybindings bindings;
        private Keybinding current;

        public AdjustKeybindings(ref Keybindings keybindings) {
            InitializeComponent();

            this.bindings = keybindings;

            foreach(string binding in keybindings.bindings.Keys) {
                selectedKeybinding.Items.Add(binding);
            }

            selectedKeybinding.SelectedIndex = 0;

            FormClosed += (a, b) => {
                Keybindings.Set(bindings);
            };
        }

        private void selectedKeybinding_SelectedIndexChanged(object sender, EventArgs e) {
            current = bindings.bindings[selectedKeybinding.SelectedItem.ToString()];

            Keybindings.Set(bindings);

            modifierShift.Checked = current.SHIFT;
            modifierCtrl.Checked = current.CTRL;
            modifierAlt.Checked = current.ALT;
            modifierSuper.Checked = current.SUPER;

            key.Text = current.Key.ToString();
        }

        private void modifierShift_CheckedChanged(object sender, EventArgs e) {
            current.SHIFT = modifierShift.Checked;
        }

        private void modifierCtrl_CheckedChanged(object sender, EventArgs e) {
            current.CTRL = modifierCtrl.Checked;
        }

        private void modifierAlt_CheckedChanged(object sender, EventArgs e) {
            current.ALT = modifierAlt.Checked;
        }

        private void modifierSuper_CheckedChanged(object sender, EventArgs e) {
            current.SUPER = modifierSuper.Checked;
        }

        private void key_KeyUp(object sender, KeyEventArgs e) {
            key.Text = e.KeyCode.ToString();
            current.Key = e.KeyCode;
        }
    }
}
