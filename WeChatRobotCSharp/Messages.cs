using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static WeChatRobotCSharp.NativeMethods;

namespace WeChatRobotCSharp
{
    public static class Messages
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct UserInfo
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string userid;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string usernumber;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string userremark;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string usernickname;
        };

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct MessageInfo
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
            public string type;       //消息类型

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
            public string source;     //消息来源

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
            public string wxid;       //微信ID/群ID

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
            public string msgSender;  //消息发送者

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 200)]
            public string content;   //消息内容
        };

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct SendMessageInfo
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
            public string wxid;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
            public string content;
        };

        public const int WM_Login = 0;

        public const int WM_ShowQrPicture = 1;

        public const int WM_Logout = 2;

        public const int WM_GetFriendList = 3;

        public const int WM_ShowChatRecord = 4;

        public const int WM_SendTextMessage = 5;

        public const int WM_AlreadyLogin = 21;

        //窗口通讯的自定义消息
        public const int WM_USER = 0x0400;

        public const int WM_ShowFriendList = WM_USER + 100;

        public const int WM_ShowMessage = WM_USER + 101;

        /// <summary>
        /// 给 WechatHelper.dll 发送消息
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="data"></param>
        /// <param name="size"></param>
        public static void SendWechatHelper(int msg, IntPtr data = default, int size = 0)
        {
            var hwnd = FindWindow(null, "WeChatHelper");
            var copyDataStruct = new COPYDATASTRUCT();
            copyDataStruct.dwData = msg;
            copyDataStruct.cbData = size;
            copyDataStruct.lpData = data;
            SendMessage(hwnd, WM_COPYDATA, 0, ref copyDataStruct);
        }

        /// <summary>
        /// 发送微信文本消息
        /// </summary>
        /// <param name="wxid"></param>
        /// <param name="content"></param>
        public static void SendWechatMessage(string wxid, string content)
        {
            int size = Marshal.SizeOf<SendMessageInfo>();
            IntPtr pAddress = Marshal.AllocHGlobal(size);
            var message = new SendMessageInfo();
            message.wxid = wxid;
            message.content = content;
            Marshal.StructureToPtr(message, pAddress, false);
            SendWechatHelper(WM_SendTextMessage, pAddress, size);
            Marshal.FreeHGlobal(pAddress);
        }
    }
}
