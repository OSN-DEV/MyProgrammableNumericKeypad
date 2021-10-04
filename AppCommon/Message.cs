using System.Collections.Generic;
using System.Windows;

namespace MyProgrammableTenkey.AppCommon {
    /// <summary>
    /// message util
    /// </summary>
    class Message {
        #region Declaration
        /// <summary>
        /// Error message id definition
        /// </summary>
        public enum ErrId {
            /// <summary>
            /// unknown error
            /// </summary>
            Err999,
        }
        private static Dictionary<ErrId, string> _errorMessages = new Dictionary<ErrId, string> {
            { ErrId.Err999, "unknown error" }
        };

        /// <summary>
        /// Information message id definition
        /// </summary>
        public enum InfoId {
            Info999
        }
        private static Dictionary<InfoId, string> _infoMessages = new Dictionary<InfoId, string> {
            { InfoId.Info999, "unknown information" }
        };

        /// <summary>
        /// Confirm message id definition
        /// </summary>
        public enum ConfirmId {
            Confirm999
        }
        private static Dictionary<ConfirmId, string> _confirmMessages = new Dictionary<ConfirmId, string> {
            { ConfirmId.Confirm999, "unknown comfirm" }
        };
        #endregion

        #region Public Method
        /// <summary>
        /// show information message
        /// </summary>
        /// <param name="id">message id</param>
        /// <param name="words">place holder</param>
        public static void ShowInfo(Window owner, InfoId id, params string[] words) {
            string message = _infoMessages[id];
            for (int i = 0; i < words.Length; i++) {
                message = message.Replace("{" + i + "}", words[i]);
            }
            ShowInfo(owner, message);
        }

        /// <summary>
        /// show information message
        /// </summary>
        /// <param name="message">message</param>
        public static void ShowInfo(Window owner, string message) {
            MessageBox.Show(owner, message, "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// show error message
        /// </summary>
        /// <param name="id">message id</param>
        /// <param name="text">place holder</param>
        public static void ShowError(Window owner, ErrId id, params string[] words) {
            string message = _errorMessages[id];
            for (int i = 0; i < words.Length; i++) {
                message = message.Replace("{" + i + "}", words[i]);
            }
            ShowError(owner, message);
        }

        /// <summary>
        /// show error message
        /// </summary>
        /// <param name="message">message</param>
        public static void ShowError(Window owner, string message) {
            if (null == owner) {
                MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            } else {
                MessageBox.Show(owner, message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        /// <summary>
        /// show information message
        /// </summary>
        /// <param name="message">message id</param>
        /// <param name="words">place holder</param>
        public static MessageBoxResult ShowConfirm(Window owner, ConfirmId id, params string[] words) {
            string message = _confirmMessages[id];
            for (int i = 0; i < words.Length; i++) {
                message = message.Replace("{" + i + "}", words[i]);
            }
            return MessageBox.Show(owner, message, "Confirm", MessageBoxButton.YesNoCancel, MessageBoxImage.Information);
        }
        #endregion
    }
}
