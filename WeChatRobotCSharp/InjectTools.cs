using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static WeChatRobotCSharp.NativeMethods;

namespace WeChatRobotCSharp
{
    public static class InjectTools
    {
        public const string WECHAT_PROCESS_NAME = "WeChat.exe";

        public const string DLLNAME = "WeChatHelper.dll";

        /// <summary>
        /// 注入Dll
        /// </summary>
        /// <returns></returns>
        public static bool InjectDll()
        {
            var dllPath = Path.Combine(Application.StartupPath, DLLNAME);
            //判断Dll是否存在
            if (!File.Exists(dllPath))
            {
                MessageBox.Show($"无法找到 {DLLNAME}!");
                return false;
            }

            var processes = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(WECHAT_PROCESS_NAME));

            Process wechatProcess;
            //判断微信是否已开启
            if (processes.Length == 0)
            {
                var registryKey = Registry.CurrentUser.OpenSubKey(@"Software\Tencent\WeChat");
                if (registryKey == null)
                {
                    MessageBox.Show("无法找到 微信安装路径!");
                    //注册表找不到微信安装路径
                    return false;
                }
                var installPath = registryKey.GetValue("InstallPath", "").ToString();
                var executablePath = Path.Combine(installPath, WECHAT_PROCESS_NAME);
                wechatProcess = Process.Start(executablePath);
            }
            else
                wechatProcess = processes[0];

            IntPtr hWechatMainForm = IntPtr.Zero;
            using(var cancelTokenSource = new CancellationTokenSource())
            {
                cancelTokenSource.CancelAfter(TimeSpan.FromSeconds(5));
                while (hWechatMainForm == IntPtr.Zero && !cancelTokenSource.IsCancellationRequested)
                {
                    hWechatMainForm = wechatProcess.MainWindowHandle;
                    Thread.Sleep(500);
                }
            }
            if(hWechatMainForm == IntPtr.Zero)
            {
                //已超时, 没有找到微信主窗口!
                MessageBox.Show("无法找到 微信主窗口句柄!");
                return false;
            }

            //检查是否已注入WechatHelper
            if(wechatProcess.Modules.Cast<ProcessModule>().Any(o => o.ModuleName == DLLNAME))
            {
                MessageBox.Show("Dll已经注入，请勿重复注入, 关闭微信重新运行");
                return false;
            }

            var hProcess = OpenProcess(PROCESS_ALL_ACCESS, false, wechatProcess.Id);
            if(hProcess == 0)
            {
                MessageBox.Show("进程打开失败");
                return false;
            }

            var pAddress = VirtualAllocEx(hProcess, 0, MAX_PATH, MEM_COMMIT, PAGE_EXECUTE_READWRITE);
            if(pAddress == 0)
            {
                MessageBox.Show("内存分配失败");
                return false;
            }

            if (!WriteProcessMemory(hProcess, pAddress, dllPath, MAX_PATH, 0))
            {
                MessageBox.Show("路径写入失败");
                return false;
            }

            var hModule = GetModuleHandle("kernel32.dll");
            var pLoadLibraryAddress = GetProcAddress(hModule, "LoadLibraryA");
            if(pLoadLibraryAddress == 0)
            {
                MessageBox.Show("获取LoadLibraryA函数地址失败");
                return false;
            }

            var hThread = CreateRemoteThread(hProcess, 0, 0, pLoadLibraryAddress, pAddress, 0, 0);
            if(hThread == 0)
            {
                MessageBox.Show("远程线程注入失败");
                return false;
            }
            CloseHandle(hThread);
            CloseHandle(hProcess);
            return true;
        }
    }
}
