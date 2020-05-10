using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace WeChatRobotCSharp
{
    public static class NativeMethods
    {
        public const int WM_COPYDATA = 0x004A;

        public const int MAX_PATH = 0x104;

        public const int MEM_COMMIT = 0x00001000;

        public const int PAGE_EXECUTE_READWRITE = 0x40;

        public const int PROCESS_ALL_ACCESS = 0x001F0FFF;

        [StructLayout(LayoutKind.Sequential)]
        public struct COPYDATASTRUCT
        {
            public int dwData;
            public int cbData;
            public IntPtr lpData;
        }

        [DllImport("kernel32.dll")]
        public static extern int OpenProcess(int dwDesiredAccess, bool fInherit, int processId);

        [DllImport("kernel32")]
        public static extern int VirtualAllocEx(int hProcess, int lpAddress, int dwSize, int flAllocationType, int flProtect);

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
        public static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress, string buffer, int size, [In, Out] int lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
        public static extern int GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
        public static extern int GetProcAddress(int hModule, string lpProcName);

        [DllImport("kernel32.dll")]
        public static extern int CreateRemoteThread(int hProcess, int lpThreadAttributes, int dwStackSize, int lpStartAddress, int lpParameter, int dwCreationFlags, [In, Out] int lpThreadId);

        [DllImport("kernel32.dll")]
        public extern static bool CloseHandle(int hHandle);

        [DllImport("user32.dll", CharSet = CharSet.Ansi)]
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, uint msg, int wParam, ref COPYDATASTRUCT lParam);
    }
}
