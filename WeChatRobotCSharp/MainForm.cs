using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static WeChatRobotCSharp.NativeMethods;
using static WeChatRobotCSharp.Messages;
using System.Runtime.InteropServices;
using System.Media;
using System.IO;

namespace WeChatRobotCSharp
{
    public partial class MainForm : Form
    {
        private DataTable _userInfos;

        private DataTable _messages;

        private ChatRobot _chatRobot;

        private bool _autoChat;

        private bool _autoChatFileHelper;

        public MainForm()
        {
            InitializeComponent();
            _chatRobot = new ChatRobot();
            _userInfos = new DataTable();
            _userInfos.Columns.Add("UserId", typeof(string));
            _userInfos.Columns.Add("UserNumber", typeof(string));
            _userInfos.Columns.Add("UserNickName", typeof(string));
            _userInfos.Columns.Add("UserRemark", typeof(string));

            _messages = new DataTable();
            _messages.Columns.Add("Type", typeof(string));
            _messages.Columns.Add("Source", typeof(string));
            _messages.Columns.Add("Wxid", typeof(string));
            _messages.Columns.Add("MsgSender", typeof(string));
            _messages.Columns.Add("Content", typeof(string));
            _messages.Columns.Add("ReciveTime", typeof(DateTime));
            _messages.DefaultView.Sort = "ReciveTime desc";
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_COPYDATA)
            {
                COPYDATASTRUCT copyDataStruct = (COPYDATASTRUCT)m.GetLParam(typeof(COPYDATASTRUCT));
                if (copyDataStruct.dwData == WM_GetFriendList)
                {
                    var userInfo = Marshal.PtrToStructure<UserInfo>(copyDataStruct.lpData);
                    _userInfos.Rows.Add(userInfo.userid, userInfo.usernumber, userInfo.usernickname, userInfo.userremark);
                }
                else if (copyDataStruct.dwData == WM_ShowChatRecord)
                {
                    var message = Marshal.PtrToStructure<MessageInfo>(copyDataStruct.lpData);
                    _messages.Rows.Add(message.type, message.source, message.wxid, message.msgSender, message.content, DateTime.Now);
                    tabControl.SelectedTab = tabPage_messages;
                    if (message.type == "文字" && message.source == "好友消息" && (_autoChat || (_autoChatFileHelper && message.wxid == "filehelper")))
                    {
#pragma warning disable CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
                        _chatRobot.QingYunKeAutoReply(message.wxid, message.content);
#pragma warning restore CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
                    }
                }
            }

            base.WndProc(ref m);
        }

        /// <summary>
        /// 退出微信
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem_logout_Click(object sender, EventArgs e)
        {
            SendWechatHelper(WM_Logout);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            dgv_friends.AutoGenerateColumns = false;
            dgv_friends.DataSource = _userInfos;
            dgv_messages.AutoGenerateColumns = false;
            dgv_messages.DataSource = _messages;
        }

        /// <summary>
        /// 显示行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_friends_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgv_friends.RowHeadersWidth - 4,
                e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgv_friends.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgv_friends.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void dgv_friends_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ShowContextMenuStrip(sender, e, contextMenu_dgv_friends);
        }

        private void dgv_messages_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ShowContextMenuStrip(sender, e, contextMenu_dgv_messages);
        }

        private void ShowContextMenuStrip(object sender, DataGridViewCellMouseEventArgs e, ContextMenuStrip contextMenuStrip)
        {
            var dgv = (DataGridView)sender;
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (dgv.Rows[e.RowIndex].Selected == false)
                    {
                        dgv.ClearSelection();
                        dgv.Rows[e.RowIndex].Selected = true;
                    }
                    //只选中一行时设置活动单元格
                    if (dgv.SelectedRows.Count == 1)
                    {
                        dgv.CurrentCell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }
                    //弹出操作菜单
                    contextMenuStrip.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        private void menuItem_sendMessage_Click(object sender, EventArgs e)
        {
            if(dgv_friends.SelectedRows.Count > 0)
            {
                var row = dgv_friends.SelectedRows[0];
                var wxid = row.Cells["UserId"].Value.ToString();
                var displayName = row.Cells["UserNickName"].Value.ToString();
                if (displayName == "(null)")
                    displayName = null;
                var sendMessageForm = new SendMessageForm(wxid, displayName);
                sendMessageForm.ShowDialog();
            }
        }

        private void menuItem_replyMessage_Click(object sender, EventArgs e)
        {
            if (dgv_messages.SelectedRows.Count > 0)
            {
                var row = dgv_messages.SelectedRows[0];
                var wxid = row.Cells["Wxid"].Value.ToString();
                var sendMessageForm = new SendMessageForm(wxid, null, true);
                sendMessageForm.ShowDialog();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("是否确认退出？", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void menuItem_saveContact_Click(object sender, EventArgs e)
        {
            var lines = new List<string>();
            var columns = _userInfos.Columns.Cast<DataColumn>().Select(o => o.ColumnName).ToArray();
            lines.Add(string.Join(",", columns));
            foreach (DataRow row in _userInfos.Rows)
            {
                lines.Add(string.Join(",", columns.Select(o => row[o].ToString())));
            }
            var saveDialog = new SaveFileDialog();
            saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            saveDialog.FileName = "微信联系人.csv";
            if(saveDialog.ShowDialog() == DialogResult.OK)
                File.WriteAllLines(saveDialog.FileName, lines, Encoding.GetEncoding("GBK"));
        }

        private void menuItem_autoChat_CheckedChanged(object sender, EventArgs e)
        {
            _autoChat = menuItem_autoChat.Checked;
            if (_autoChat && _autoChatFileHelper)
                menuItem_autoChatFileHelper.Checked = false;
        }

        private void menuItem_autoChatFileHelper_CheckedChanged(object sender, EventArgs e)
        {
            _autoChatFileHelper = menuItem_autoChatFileHelper.Checked;
            if(_autoChatFileHelper && _autoChat)
                menuItem_autoChat.Checked = false;
        }
    }
}
