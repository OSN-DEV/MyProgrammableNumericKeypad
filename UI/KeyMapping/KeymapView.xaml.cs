using System.Windows;
using System.Windows.Input;

namespace MyProgrammableTenkey.UI.KeyMapping {
    /// <summary>
    /// KeymapView.xaml の相互作用ロジック
    /// </summary>
    public partial class KeymapView : Window {

        #region Declaration
        #endregion

        #region Constructor
        public KeymapView() {
            InitializeComponent();

            this.cData.DataContext = new KeyMappingViewModel();
        }
        #endregion

        #region Event
        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e) {
            if (e.Key == Key.Escape) {
                e.Handled = true;
                this.Close();
            }
        }
        #endregion
    }
}
