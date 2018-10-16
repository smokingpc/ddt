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
        public frmMain()
        {
            InitializeComponent();
        }

        //官方 python for C# 套件要用pip安裝，再去 %PythonHome%\Lib\site-packages\ 目錄下
        //去 reference  "Python.Runtime.DLL"
        //注意：那dll一次只能裝一個arch，所以直接用x64版本吧
        //     C#主程式也要把 prefer 32bit選項拿掉，不然跑不動
        private void button1_Click(object sender, EventArgs e)
        {
            //必須在系統環境變數設定 PYTHONHOME ，指向python runtime目錄
            //不然後面沒法執行python code
            string home = PythonEngine.PythonHome;
            string path = PythonEngine.PythonPath;

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
