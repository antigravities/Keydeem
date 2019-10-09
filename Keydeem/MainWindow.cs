using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Keydeem {
    public partial class MainWindow : Form {
        public MainWindow(string log) {
            InitializeComponent();

            textBoxLog.AppendText(log);
        }

        private void buttonOpenThirdparty_Click(object sender, EventArgs e) {
            new Process {
                StartInfo = new ProcessStartInfo {
                    FileName = "thirdparty.txt"
                }
            }.Start();
        }

        private void buttonKYR_Click(object sender, EventArgs e) {
            new Process {
                StartInfo = new ProcessStartInfo {
                    FileName = "license.txt"
                }
            }.Start();
        }

        internal void Log(string log) {
            textBoxLog.Invoke((Action) (() => textBoxLog.AppendText(log)));
        }
    }
}
