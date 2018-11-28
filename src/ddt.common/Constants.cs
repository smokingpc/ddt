using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddt.common
{
    public static class CONST
    {
        public static readonly string ExePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static readonly string ScriptPath = ExePath + @"\script";
        public static readonly string PythonPath = ExePath + @"\python_import";
        public static readonly string x64Python2Path = ExePath + @"\python_import\2.7_x64";
        public static readonly string x86Python2Path = ExePath + @"\python_import\2.7_x86";

        public static readonly string Python2DLL = "python27.dll";
        public static readonly string Python2RuntimeDLL = "Python.Runtime.dll";
    }
}
