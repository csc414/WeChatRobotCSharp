using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using static WeChatRobotCSharp.InjectTools;

namespace WeChatRobotCSharp
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!CanRun())
            {
                MessageBox.Show("请勿重复运行!");
                return;
            }

            if (!InjectDll())
            {
                //注入dll失败
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var login = new LoginForm();
            if (login.ShowDialog() == DialogResult.OK)
                Application.Run(new MainForm());
        }

        /// <summary>
        /// 防多开
        /// </summary>
        /// <returns></returns>
        static bool CanRun()
        {
            new Mutex(false, "GuiShou", out var createNew);
            return createNew;
        }
    }
}
