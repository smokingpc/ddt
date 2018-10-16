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

using Python.Runtime;

namespace IronPythonTest2
{
    public partial class frmMain : Form
    {
        private static string ScriptSource = 
@"
def Calculate(a, b):
    return a * b;
";

        public frmMain()
        {
            InitializeComponent();
        }

        //reference : 
        //https://www.cnblogs.com/wilber2013/p/4491297.html
        private void button1_Click(object sender, EventArgs e)
        {
            var engine = IronPython.Hosting.Python.CreateEngine();
            var scope = engine.CreateScope();
            
            //把C#的變數塞進python
            //name ==> python裡面你要這個變數叫什麼名字？
            //value ==> C# 變數
            int data1= int.Parse(textBox2.Text);
            int data2 = int.Parse(textBox3.Text);
            //把python編譯好
            var python_code = engine.CreateScriptSourceFromString(ScriptSource);
            //先跑一次
            python_code.Execute(scope);
            
            //取出需要的function => function name也被 IronPython視為是變數名稱的一種
            //同理，其實這樣也可以取出python的物件來用
            //只是取出的物件必須以 dynamic 型態來操作，coding時期debug相當困難
            var func = scope.GetVariable("Calculate");

            //執行
            var result = func(data1, data2);
            string msg = string.Format("IronPython運算結果 = {0}", result);
            textBox1.AppendText(msg);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ////python net啟動時要先呼叫GIL()去accquire整個python engine
            //using (Py.GIL())
            //{
            //    Python.Runtime.PythonEngine engine = new PythonEngine();
                
            //}
        }
    }
}
