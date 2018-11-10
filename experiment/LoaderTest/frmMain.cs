using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoaderTest
{
    public partial class frmMain : Form
    {
        public static string ExePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        public static string PyLibPath = ExePath + @"\Libs";
        public static string PyDLLPath = ExePath + @"\DLLs";
        public static string PyHomePath = ExePath ;

        //1.Distribution要把 C:\Python27\Lib , C:\Python27\Libs , C:\Python27\DLLs
        //  複製到想要指定的python home 路徑下
        //2.用Loader去判斷有沒有PythonHome變數，沒有的話指定到exe path
        //3.launch it!

        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.ProcessStartInfo startinfo = new System.Diagnostics.ProcessStartInfo();
            startinfo.EnvironmentVariables["PYTHONHOME"] = ExePath;
            string home = startinfo.EnvironmentVariables["PYTHONHOME"];

            startinfo.UseShellExecute = false;
            startinfo.WorkingDirectory = ExePath;
            startinfo.FileName = "PythonNetTest1.exe";
            System.Diagnostics.Process.Start(startinfo);
        }
    }
}
