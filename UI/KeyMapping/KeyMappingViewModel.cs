using MyProgrammableTenkey.AppCommon;
using MyProgrammableTenkey.KeyData;
using MyProgrammableTenkey.Repo;
using OsnCsLib.WPFComponent.Bind;
using System.Collections.ObjectModel;

namespace MyProgrammableTenkey.UI.KeyMapping {
    class KeyMappingViewModel : BaseBindable {

        #region Declaration
        #endregion

        #region Public Property
        /// <summary>
        /// key pair list
        /// </summary>
        public ObservableCollection<KeyItem> KeyMappingList { set; get; }
        #endregion

        #region Constructor
        public KeyMappingViewModel() {
            var setting = AppSettingDataRepo.Init(Constants.SettingsFile);
            if (0 < setting.KeyMappingFile.Length) {
                var repo = new KeyMappingRepo();
                this.KeyMappingList = repo.GetKeyPairList(setting.KeyMappingFile);
            }
        }
        #endregion

        #region Public Method
        #endregion
    }
}
