using Microsoft.Win32;
using MyProgrammableTenkey.AppCommon;
using MyProgrammableTenkey.Func;
using MyProgrammableTenkey.KeyData;
using MyProgrammableTenkey.Repo;
using MyProgrammableTenkey.UI.KeyMapping;
using OsnCsLib.Common;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace MyProgrammableTenkey.UI.Main {
    public partial class MyProgrammableNumericKeypadMain : Component {

        #region Declaration
        private HotKeyHelper _helper = null;
        private AppSettingDataRepo _setting = null;
        private List<List<KeyItem>> _keyMapping = new List<List<KeyItem>>();
        private readonly SendKeys _sendKeys = new SendKeys();
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
                this.OnObserveClick();
            } else if (this.MainMenuLoadKeymapping == e.ClickedItem) {
                this.OnLoadKeyMappingClick();
            } else if (this.MainMenuShowKeymapping == e.ClickedItem) {
                this.OnShowKeymappingClick();
            } else if (this.MainMenuQuit == e.ClickedItem) {
                this.OnQuitClick();
            }
        }
        #endregion

        #region Public Method
        /// <summary>
        /// set pu
        /// </summary>
        /// <param name="helper"></param>
        public void SetUp(HotKeyHelper helper) {
            // set instance
            this._helper = helper;

            // get and set app version
            this.Notify.Text = Util.GetVersion(System.Reflection.Assembly.GetExecutingAssembly().Location);

            // load app setting data
            this._setting = AppSettingDataRepo.Init(Constants.SettingsFile);

            // parse key mapping if exists
            if (0 < this._setting.KeyMappingFile.Length) {
                this.LoadKeyMappingFile();
            }

            // set menu enabled
            this.MainMenuObserve.Enabled = (0 < this._keyMapping.Count);

            // if observe flg is true, register hot key
            if (0 < this._keyMapping.Count && this._setting.IsObserved) {
                this.MainMenuObserve.Checked = true;
                this.RegisterHotKeys();
            }
        }
        #endregion


        #region Private Method
        /// <summary>
        /// register hot keys
        /// </summary>
        private void RegisterHotKeys() {
            var keys = new Key[] { Key.NumPad0, Key.NumPad1, Key.NumPad2, Key.NumPad3, Key.NumPad4, Key.NumPad5, Key.NumPad6, Key.NumPad7, Key.NumPad8, Key.NumPad9 };
            this._helper.setup(this.MainMenu.Handle);
            for (int i = 0; i < keys.Length; i++) {
                this._helper.Register(ModifierKeys.None, keys[i],i, "", (_, e) => {
                    var args = e as HotkeyEventArgs;
                    this.SendKeysProc(args.IntTag); 
                });
            }
        }

        /// <summary>
        /// unregister all hot keys
        /// </summary>
        private void UnregisterHotKeys() {
            this._helper.UnregisterAll();
        }

        /// <summary>
        /// send key
        /// </summary>
        private void SendKeysProc(int index) {
            if (0 == this._keyMapping[index].Count) {
                return;
            }

            var modified = new List<KeyItem>();
            foreach(var item in this._keyMapping[index]) {
                this._sendKeys.SendKeyDown(item);
                if (item.IsModified) {
                    modified.Insert(0, item);
                } else {
                    this._sendKeys.SendKeyUp(item);
                }
            }
            foreach(var item in modified) {
                this._sendKeys.SendKeyUp(item);
            }

        }

        /// <summary>
        /// load key mapping file
        /// </summary>
        private void LoadKeyMappingFile() {
            var keyMappingrepo = new KeyMappingRepo();
            this._keyMapping = keyMappingrepo.Load(this._setting.KeyMappingFile);
        }

        /// <summary>
        /// start observe
        /// </summary>
        private void OnObserveClick() {
            this.MainMenuObserve.Checked = !this.MainMenuObserve.Checked;
            this._setting.IsObserved = this.MainMenuObserve.Checked;
            this._setting.Save();
            if (this.MainMenuObserve.Checked) {
                this.RegisterHotKeys();
            } else {
                this.UnregisterHotKeys();
            }
        }

        /// <summary>
        /// select key mapping file
        /// </summary>
        private void OnLoadKeyMappingClick() {
            // select mapping file
            var mappingFile = "";
            var dialog = new OpenFileDialog {
                Filter = "MappingFile(*.txt)|*.txt",
                FilterIndex = 0,
                FileName = this._setting.KeyMappingFile,
                Title = "辞書ファイルを選択",
                CheckFileExists = true
            };
            if (true == dialog.ShowDialog()) {
                mappingFile = dialog.FileName;
            }
            if (0 == mappingFile.Length) {
                return;
            }

            // load selected file
            var keyMappingrepo = new KeyMappingRepo();
            var result = keyMappingrepo.Load(mappingFile);
            if (0 == result.Count) {
                return;
            }

            this._setting.KeyMappingFile = mappingFile;
            this._setting.Save();
            this._keyMapping = result;
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnShowKeymappingClick() {
            new KeymapView().ShowDialog();
        }

        /// <summary>
        /// quit clicked
        /// </summary>
        private void OnQuitClick() {
            Application.Current.Shutdown();
        }
        #endregion

    }
}
