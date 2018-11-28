using System;
using System.Runtime.InteropServices;

namespace ddt.common
{
    public static class Utils
    {
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        private extern static IntPtr LoadLibrary(string libname);

        //用來動態處理 "該怎麼根據caller process來載入正確native unmanaged dll"
        //32bit process不能載入64bit DLL，同樣64bit process也不能載入32bit dll
        //但CSharp有混合模式 "ANYCPU" 這樣對 Dllimport native dll 會有困擾
        public static void PreloadDllByPlatform(string path, string x86file, string x64file)
        {
            var dllpath = "";

            if (Environment.Is64BitProcess)
                dllpath = string.Format("{0}\\{1}", path, x64file);
            else
                dllpath = string.Format("{0}\\{1}", path, x86file);

            LoadLibrary(dllpath);
        }

        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        private extern static bool SetDllDirectory(string path);
        public static void SetDllPathByPlatform(string x86_path, string x64_path)
        {
            var dllpath = "";

            if (Environment.Is64BitProcess)
                dllpath = x64_path;
            else
                dllpath = x86_path;

            SetDllDirectory(dllpath);
        }
    }
}
