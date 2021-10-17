using MyProgrammableTenkey.KeyData;
using OsnCsLib.File;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace MyProgrammableTenkey.Repo {
    class KeyMappingRepo {

        #region Public Method
        /// <summary>
        /// load key mapping
        /// </summary>
        /// <returns></returns>
        public List<List<KeyItem>> Load(string file) {
            var list = new List<List<KeyItem>>();

            // 枠を作成
            for(int i=0; i<10; i++) {
                list.Add(new List<KeyItem>());
            }

            using (var op = new FileOperator(file)) {
                op.OpenForRead();
                while(!op.Eof) {
                    var line = op.ReadLine();
                    if (line.StartsWith("#")) {
                        continue;
                    }

                    var pair = line.Split(',');
                    if (2 != pair.Length) {
                        continue;
                    }

                    int index;
                    if (!int.TryParse(pair[0], out index)) {
                        continue;
                    }

                    var keyCombinations = pair[1].Split('+');
                    for (int i=0; i < keyCombinations.Length; i++) {
                        var item = KeyItem.GetKeyItem(keyCombinations[i].Trim().ToUpper());
                        if (null == item || 0 == item.StringKey.Length) {
                            MessageBox.Show("Fail to parse file");
                            return list;
                        }
                        list[index].Add(item);
                    }
                }
            }

            return list;
        }

        public ObservableCollection<KeyItem> GetKeyPairList(string file) {
            var list = new ObservableCollection<KeyItem>();

            using (var op = new FileOperator(file)) {
                op.OpenForRead();
                while (!op.Eof) {
                    var line = op.ReadLine();
                    if (line.StartsWith("#")) {
                        continue;
                    }

                    var pair = line.Split(',');
                    if (2 != pair.Length) {
                        continue;
                    }

                    var keyItem = new KeyItem();
                    keyItem.StringKey = $"{pair[0]} : ";
                    keyItem.KeyPair = pair[1].Trim();
                    list.Add(keyItem);
                }
            }

            return list;
        }
        #endregion
    }
}
