using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Keydeem {
    public class Keybinding {
        public bool SHIFT { get; set; }
        public bool CTRL { get; set; }
        public bool ALT { get; set; }
        public bool SUPER { get; set; }

        public Keys Key { get; set; }

        public Keybinding() { }

        public Keybinding(KeyModifier modifiers, Keys key) {
            if(modifiers.HasFlag(KeyModifier.Shift)) SHIFT = true;
            if(modifiers.HasFlag(KeyModifier.Control)) CTRL = true;
            if(modifiers.HasFlag(KeyModifier.Alt)) ALT = true;
            if(modifiers.HasFlag(KeyModifier.Super)) SUPER = true;

            Key = key;
        }

        public KeyModifier GetModifiers() {
            KeyModifier modifier = KeyModifier.None;

            if(SHIFT) modifier = modifier | KeyModifier.Shift;
            if(CTRL) modifier = modifier | KeyModifier.Control;
            if(ALT) modifier = modifier | KeyModifier.Alt;
            if(SUPER) modifier = modifier | KeyModifier.Super;

            return modifier;
        }

        public override string ToString() {
            string fin = "";

            if(CTRL) fin += "CTRL + ";
            if(ALT) fin += "ALT + ";
            if(SUPER) fin += "SUPER + ";
            if(SHIFT) fin += "SHIFT + ";

            fin += Key;

            return fin;
        }
    }

    public class Keybindings {
        public Dictionary<string, Keybinding> bindings { get; internal set; } = new Dictionary<string, Keybinding>();

        private Keybindings() { }
        private Keybindings(Dictionary<string, Keybinding> bindings) { this.bindings = bindings; }

        internal static Keybindings Get(Dictionary<string, Keybinding> def) {
            if(File.Exists("keybindings.json")) return JsonConvert.DeserializeObject<Keybindings>(File.ReadAllText("keybindings.json"));
            else return new Keybindings(def);
        }

        internal static void Set(Keybindings k) {
            File.WriteAllText("keybindings.json", JsonConvert.SerializeObject(k));
        }
    }
}
