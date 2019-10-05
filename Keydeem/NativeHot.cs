using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Keydeem {
    [Flags]
    internal enum KeyModifier {
        Alt = 1,
        Control = 2,
        Shift = 4,
        Super = 8
    }

    internal class NativeHot : NativeWindow {
        private static NativeHot window = null;
        private static Dictionary<int, Action> callbacks = new Dictionary<int, Action>();

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private NativeHot() {
            CreateHandle(new CreateParams());
        }

        protected override void WndProc(ref Message m) {
            if(m.Msg == 0x0312) {
                if(callbacks.ContainsKey(m.WParam.ToInt32())) {
                    callbacks[m.WParam.ToInt32()]();
                }
            }

            base.WndProc(ref m);
        }

        internal static int Add(KeyModifier modifiers, Keys key, Action callback) {
            if(window == null) window = new NativeHot();

            int id = new Random().Next();
            callbacks.Add(id, callback);

            RegisterHotKey(window.Handle, id, (int) modifiers, (int) key);

            return id;
        }

        internal static void Remove(int id) {
            callbacks.Remove(id);
            UnregisterHotKey(window.Handle, id);
        }

        internal static void Dispose() {
            if(window != null) window.DestroyHandle();
        }
    }
}
