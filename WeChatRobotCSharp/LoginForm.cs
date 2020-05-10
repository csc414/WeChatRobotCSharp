using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WeChatRobotCSharp.NativeMethods;
using static WeChatRobotCSharp.Messages;
using System.Threading;
using System.IO;

namespace WeChatRobotCSharp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            if(m.Msg == WM_COPYDATA)
            {
                COPYDATASTRUCT copyDataStruct = (COPYDATASTRUCT)m.GetLParam(typeof(COPYDATASTRUCT));
                if(copyDataStruct.dwData == WM_Login)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else if(copyDataStruct.dwData == WM_AlreadyLogin)
                {
                    MessageBox.Show("已经登陆微信 请重启微信 在未登录状态下运行程序");
                    this.DialogResult = DialogResult.Cancel;
                }
            }

            base.WndProc(ref m);
        }

        private void btn_showQrCode_Click(object sender, EventArgs e)
        {
            SendWechatHelper(WM_ShowQrPicture);
            Thread.Sleep(200);
            //显示图片
            var tempPath = Path.GetTempPath();
            var qrCodePath = Path.Combine(tempPath, "qrcode.png");
            if(!File.Exists(qrCodePath))
            {
                MessageBox.Show("二维码不存在");
                return;
            }

            //显示二维码
            using (var fs = File.OpenRead(qrCodePath))
            {
                using (var memoryStream = new MemoryStream())
                {
                    fs.CopyTo(memoryStream);
                    pic_qrCode.Image = Image.FromStream(memoryStream);
                }
            }
        }
    }
}
