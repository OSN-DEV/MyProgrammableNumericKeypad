using System.Collections.Generic;

namespace MyProgrammableTenkey.KeyData {
    class KeyItem {

        #region Declaration
        private static Dictionary<string, byte[]> _modified = new Dictionary<string, byte[]> {
            { "CTRL", KeySetPair.ControlL },
            { "SHIFT", KeySetPair.ShiftL },
            { "ALT", KeySetPair.AltL },
            { "WIN", KeySetPair.WinL },
        };

        private static Dictionary<string, byte[]> _key = new Dictionary<string, byte[]> {
            { "F1", KeySetPair.F1 },
            { "F2", KeySetPair.F2 },
            { "F3", KeySetPair.F3 },
            { "F4", KeySetPair.F4 },
            { "F5", KeySetPair.F5 },
            { "F6", KeySetPair.F6 },
            { "F7", KeySetPair.F7 },
            { "F8", KeySetPair.F8 },
            { "F9", KeySetPair.F9 },
            { "F10", KeySetPair.F10 },
            { "F11", KeySetPair.F11 },
            { "F12", KeySetPair.F12 },
            { "F13", KeySetPair.F13 },
            { "F14", KeySetPair.F14 },
            { "F15", KeySetPair.F15 },
            { "0", KeySetPair.Num0 },
            { "1", KeySetPair.Num1 },
            { "2", KeySetPair.Num2 },
            { "3", KeySetPair.Num3 },
            { "4", KeySetPair.Num4 },
            { "5", KeySetPair.Num5 },
            { "6", KeySetPair.Num6 },
            { "7", KeySetPair.Num7 },
            { "8", KeySetPair.Num8 },
            { "9", KeySetPair.Num9 },
            { "A", KeySetPair.A },
            { "B", KeySetPair.B },
            { "C", KeySetPair.C },
            { "D", KeySetPair.D },
            { "E", KeySetPair.E },
            { "F", KeySetPair.F },
            { "G", KeySetPair.G },
            { "H", KeySetPair.H },
            { "I", KeySetPair.I },
            { "J", KeySetPair.J },
            { "K", KeySetPair.K },
            { "L", KeySetPair.L },
            { "M", KeySetPair.M },
            { "N", KeySetPair.N },
            { "O", KeySetPair.O },
            { "P", KeySetPair.P },
            { "Q", KeySetPair.Q },
            { "R", KeySetPair.R },
            { "S", KeySetPair.S },
            { "T", KeySetPair.T },
            { "U", KeySetPair.U },
            { "V", KeySetPair.V },
            { "W", KeySetPair.W },
            { "X", KeySetPair.X },
            { "Y", KeySetPair.Y },
            { "Z", KeySetPair.Z },
            { "LEFT", KeySetPair.Left },
            { "UP", KeySetPair.Up },
            { "RIGHT", KeySetPair.Right },
            { "DOWN", KeySetPair.Down },
            { "PRN", KeySetPair.PrintScreen },
        };
        #endregion

        #region Property
        public bool IsModified {
            set; get;
        } = false;

        public string StringKey {
            set; get;
        } = "";

        public string KeyPair {
            set; get;
        } = "";

        public byte[] KeySet {
            set; get;
        } = null;

        public bool IsKeydown {
            set; get;
        } = true;
        #endregion

        #region Method
        /// <summary>
        /// get key item
        /// </summary>
        /// <param name="key">string key</param>
        /// <returns>key item. if invalid key, return null</returns>
        public static KeyItem GetKeyItem(string key) {
            if (!_modified.ContainsKey(key.ToUpper()) && !_key.ContainsKey(key.ToUpper())) {
                return null;
            }

            var item = new KeyItem();
            item.StringKey = key;
            item.IsModified = _modified.ContainsKey(key);
            if (item.IsModified) {
                item.KeySet = _modified[key.ToUpper()];
            } else {
                item.KeySet = _key[key.ToUpper()];
            }
            return item;
        }
        #endregion
    }
}
