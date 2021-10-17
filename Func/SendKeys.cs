using MyProgrammableTenkey.KeyData;
using System;

namespace MyProgrammableTenkey.Func {
    class SendKeys {

        #region Declaration
        private static class NativeMethods {
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            public static extern uint keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        private static class KeyEventF {
            public static uint KeyDown = 0x0000;
            public static uint KeyUp = 0x0002;
        }

        #endregion

        #region Constructor
        public SendKeys() {
        }
        #endregion

        #region Public Method
        /// <summary>
        /// send key down
        /// </summary>
        /// <param name="item"></param>
        public void SendKeyDown(KeyItem item) {
            System.Diagnostics.Debug.WriteLine(item.StringKey);
            NativeMethods.keybd_event(KeySetPair.VirtualKey(item.KeySet),       // Virtual Key
                                     0,                                         // Scan code
                                     KeyEventF.KeyDown,                         // option
                                     (UIntPtr)0);                               // additional data
        }

        /// <summary>
        /// send key up
        /// </summary>
        /// <param name="item"></param>
        public void SendKeyUp(KeyItem item) {
            System.Diagnostics.Debug.WriteLine(item.StringKey);
            NativeMethods.keybd_event(KeySetPair.VirtualKey(item.KeySet),       // Virtual Key
                                     0,                                         // Scan code
                                     KeyEventF.KeyUp,                           // option
                                     (UIntPtr)0);                               // additional data
        }
        #endregion


        #region Private Method
        #endregion
    }
}
