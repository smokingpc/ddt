using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

using ddt.common;
using Python.Runtime;

namespace ddt.python
{
    public static class PyDDT
    {
        //static constructor to initailize python engine and script modules.
        static PyDDT()
        {
            //LoadPythonRuntime();
            Utils.SetDllPathByPlatform(CONST.x86Python2Path, CONST.x64Python2Path);

            InitPythonEngine();
            InitScriptModules();
        }

        #region ======== Private Functions ========
        private static void InitPythonEngine()
        {
            //set PYTHONHOME variable to force python engine load python.dll from this path.
            if (Environment.Is64BitProcess)
                Environment.SetEnvironmentVariable("PYTHONHOME", CONST.x64Python2Path);
            else
                Environment.SetEnvironmentVariable("PYTHONHOME", CONST.x86Python2Path);
            
            PythonEngine.Initialize();
        }
        private static void InitScriptModules()
        {
        }

        //private static void LoadPythonRuntime()
        //{
            //string path = "";
            //if (Environment.Is64BitProcess)
            //    path = CONST.x64Python2Path;
            //else
            //    path = CONST.x86Python2Path;
            //Utils.SetDllPathByPlatform(CONST.x86Python2Path, CONST.x64Python2Path);
            

            //string src = string.Format("{0}\\{1}", path, CONST.Python2DLL);
            //string dst = string.Format("{0}\\{1}", CONST.ExePath, CONST.Python2DLL);
            //System.IO.File.Copy(src, dst, true);

            //src = string.Format("{0}\\{1}", path, CONST.Python2RuntimeDLL);
            //dst = string.Format("{0}\\{1}", CONST.ExePath, CONST.Python2RuntimeDLL);
            //System.IO.File.Copy(src, dst, true);
        //}
        #endregion
    }
}
