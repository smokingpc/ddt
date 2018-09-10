using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MoonSharp;
using MoonSharp.Interpreter;

namespace moonsharp_test
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string script_text = @"
                    -- LUA的註解是這符號
                    -- n=10
                    -- n = n * 5
                    -- return (n)

                    my_data = true
                    return (my_data)
                    ";

            Script script = new Script();
            var result = script.DoString(script_text);

            //var data = Convert.ToInt32(result.Number);
            MessageBox.Show("LUA script execution result = " + result.Boolean.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Script script = new Script();
            var result = script.DoString(textBox1.Text);

            var data = Convert.ToInt32(result.Number);
            MessageBox.Show("LUA script execution result = " + data.ToString());
        }

        private void InitUI()
        {
            textBox1.Text =
@"
    data = 1234
    data = data + 7
    return data
";
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            InitUI();
        }
    }
}
