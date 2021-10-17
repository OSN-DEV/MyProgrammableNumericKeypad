using MyProgrammableTenkey.UI.Main;
using OsnCsLib.Common;
using System.Windows;

namespace MyProgrammableTenkey {
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application {
        #region Declaration
        private AppLaunchChecker _launchChecker = new AppLaunchChecker("MyProgrammableTenkey", "MyProgrammableTenkey.UI.Main.App");
        private MyProgrammableNumericKeypadMain _controller;
        private HotKeyHelper _hotkey;
        #endregion

        #region Event
        /// <summary>
        /// System.Windows.Application.Startup
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            if (this._launchChecker.IsLaunched()) {
                this.Shutdown();
                return;
            }

            this.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            this._hotkey = new HotKeyHelper();
            this._controller = new MyProgrammableNumericKeypadMain();
            this._controller.SetUp(this._hotkey);
        }

        /// <summary>
        /// System.Windows.Application.Exit
        /// </summary>
        /// <param name="e"></param>
        protected override void OnExit(ExitEventArgs e) {
            base.OnExit(e);
            if (null != this._hotkey) {
                this._hotkey.Dispose();
            }
            if (null != this._controller) {
                this._controller.Dispose();
            }
        }
        #endregion
    }
}
