using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProgrammableTenkey.UI.Main {
    public partial class MyProgrammableNumericKeypadMain : Component {

        #region Constructor
        public MyProgrammableNumericKeypadMain() {
            InitializeComponent();
        }

        public MyProgrammableNumericKeypadMain(IContainer container) {
            container.Add(this);

            InitializeComponent();
        }
        #endregion

    }
}
