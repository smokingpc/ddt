using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Python.Runtime;

namespace PythonNetTest1
{
    public partial class frmMain : Form
    {
        public static string ExePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        public frmMain()
        {
            InitializeComponent();

            //必須在系統環境變數設定 PYTHONHOME ，指向python runtime目錄
            //不然後面沒法執行python code，如果不想裝一大包python，可以把
            // <%PYTHON_HOME%>\lib , <%PYTHON_HOME%>\libs , <%PYTHON_HOME%>\dlls 
            //三個目錄一起擺到exe path下，在process一開始時指定好環境變數，
            //Python Runtime Engine就會改變 PythonEngine.PythonHome 的指向位置
            Environment.SetEnvironmentVariable("PYTHONHOME", ExePath);
        }

        //官方 python for C# 套件要用pip安裝，再去 %PythonHome%\Lib\site-packages\ 目錄下
        //去 reference  "Python.Runtime.DLL"
        //注意：那dll一次只能裝一個arch，所以直接用x64版本吧
        //     C#主程式也要把 prefer 32bit選項拿掉，不然跑不動
        private void button1_Click(object sender, EventArgs e)
        {
            
            //指定以後再init就會變更預設lib路徑，看來是Lazy Init
            string home = PythonEngine.PythonHome;
            string path = PythonEngine.PythonPath;
            
            //MessageBox.Show(home);
            //Python執行前要啟動python engine...
            PythonEngine.Initialize();
            //PythonNet不是thread safe，要multithread就得用這個鎖住整個引擎
            var lock_handle = PythonEngine.AcquireLock();
            
            //這邊必須用dynamic，不然後面呼叫不到python function
            dynamic module = Py.Import("MyScript");
            int data1 = int.Parse(textBox2.Text);
            int data2 = int.Parse(textBox3.Text);

            //這邊function名稱要照python內宣告的名稱， case sensitive
            var py_result = module.Calculate(data1, data2);
            
            PythonEngine.ReleaseLock(lock_handle);
            PythonEngine.Shutdown();    //結束 python engine

            //把執行結果回傳值 cast 回 C# 的物件
            int result = (int)py_result.AsManagedObject(typeof(int));
            string msg = string.Format("IronPython運算結果 = {0}", result);
            textBox1.AppendText(msg);
        }
    }
}
