using OsnCsLib.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProgrammableTenkey.UI.Main {
    public partial class MyProgrammableNumericKeypadMain : Component {

        #region Declaration
        private HotKeyHelper _helper = null;
        #endregion

        #region Constructor
        public MyProgrammableNumericKeypadMain() {
            InitializeComponent();
        }

        public MyProgrammableNumericKeypadMain(IContainer container) {
            container.Add(this);

            InitializeComponent();
        }
        #endregion

        #region Event
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMenu_ItemClicked(object sender, System.Windows.Forms.ToolStripItemClickedEventArgs e) {
            if (this.MainMenuObserve == e.ClickedItem) {

            } else if (this.MainMenuLoadKeymapping == e.ClickedItem) {

            } else if (this.MainMenuShowKeymapping == e.ClickedItem) {

            } else if (this.MainMenuQuit == e.ClickedItem) {

            }
        }
        #endregion

        #region Public Method
        /// <summary>
        /// set pu
        /// </summary>
        /// <param name="helper"></param>
        public void SetUp(HotKeyHelper helper) {
            //
            this._helper = helper;

            // get and set app version
            var ver = Util.GetVersion(System.Reflection.Assembly.GetExecutingAssembly().Location);
            this.Notify.Text = ver;

            // load app setting data

            // parse key mapping if exists

            // if observe flg is true, register hot key
        }
        #endregion


        #region Private Method
        private void RegisterHotKeys() {

        }

        private void UnregisterHotKeys() {

        }

        private void SendKeys() {

        }
        #endregion

    }
}
