using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//DLR => 配合 scripting language
using System.Dynamic;
using IronPython;
using IronPython.Hosting;

namespace IronPythonTest1
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            //1.先裝IronPython
            //2.add Reference to IronPython.dll / IronPython.Modules.dll / Microsoft.Scripting.dll
            //3.加入 using 
            //enjoy it!
            var engine = IronPython.Hosting.Python.CreateEngine();

//因為python對縮排要求很嚴格，所以寫成這附鳥樣
            string script = 
@"
print ""Hello World""
raw_input()
";
            engine.Execute(script);
        }
    }
}
