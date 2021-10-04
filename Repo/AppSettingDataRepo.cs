using OsnCsLib.Data;

namespace MyProgrammableTenkey.Repo {
    /// <summary>
    /// アプリ設定データ
    /// </summary>
    public class AppSettingDataRepo : AppDataBase<AppSettingDataRepo> {

        #region Declaration
        private static string _file;    // setting file
        #endregion

        #region Public Property
        /// <summary>
        /// Observe hotkey or not
        /// </summary>
        public bool IsObserved { set; get; } = false;

        /// <summary>
        /// Key mapping file
        /// </summary>
        public string KeyMappingFile { set; get; } = "";
        #endregion

        #region Public Method
        /// <summary>
        /// initialize repo
        /// </summary>
        /// <param name="file">setting file</param>
        /// <returns>instance</returns>
        public static AppSettingDataRepo Init(string file) {
            _file = file;
            GetInstanceBase(file);
            if (!System.IO.File.Exists(file)) {
                _instance.Save();
            }
            return _instance;
        }

        /// <summary>
        /// get instance
        /// </summary>
        /// <returns>instance</returns>
        public static AppSettingDataRepo GetInstance() {
            return GetInstanceBase();
        }

        /// <summary>
        /// save data
        /// </summary>
        public void Save() {
            GetInstanceBase().SaveToXml(_file);
        }
        #endregion
    }
}
