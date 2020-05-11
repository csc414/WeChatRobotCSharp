namespace WeChatRobotCSharp
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menu_wechat = new System.Windows.Forms.MenuStrip();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_logout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_saveContact = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage_friends = new System.Windows.Forms.TabPage();
            this.dgv_friends = new System.Windows.Forms.DataGridView();
            this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserNickName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage_messages = new System.Windows.Forms.TabPage();
            this.dgv_messages = new System.Windows.Forms.DataGridView();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wxid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MsgSender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Content = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenu_dgv_friends = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItem_sendMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu_dgv_messages = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItem_replyMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.全自动功能ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_autoChat = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_autoChatFileHelper = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_wechat.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage_friends.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_friends)).BeginInit();
            this.tabPage_messages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_messages)).BeginInit();
            this.contextMenu_dgv_friends.SuspendLayout();
            this.contextMenu_dgv_messages.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu_wechat
            // 
            this.menu_wechat.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem,
            this.全自动功能ToolStripMenuItem});
            this.menu_wechat.Location = new System.Drawing.Point(0, 0);
            this.menu_wechat.Name = "menu_wechat";
            this.menu_wechat.Size = new System.Drawing.Size(956, 25);
            this.menu_wechat.TabIndex = 0;
            this.menu_wechat.Text = "menuStrip1";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_logout,
            this.menuItem_saveContact});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // menuItem_logout
            // 
            this.menuItem_logout.Name = "menuItem_logout";
            this.menuItem_logout.Size = new System.Drawing.Size(180, 22);
            this.menuItem_logout.Text = "退出微信";
            this.menuItem_logout.Click += new System.EventHandler(this.menuItem_logout_Click);
            // 
            // menuItem_saveContact
            // 
            this.menuItem_saveContact.Name = "menuItem_saveContact";
            this.menuItem_saveContact.Size = new System.Drawing.Size(180, 22);
            this.menuItem_saveContact.Text = "保存联系人";
            this.menuItem_saveContact.Click += new System.EventHandler(this.menuItem_saveContact_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage_friends);
            this.tabControl.Controls.Add(this.tabPage_messages);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 25);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(956, 549);
            this.tabControl.TabIndex = 1;
            // 
            // tabPage_friends
            // 
            this.tabPage_friends.Controls.Add(this.dgv_friends);
            this.tabPage_friends.Location = new System.Drawing.Point(4, 22);
            this.tabPage_friends.Name = "tabPage_friends";
            this.tabPage_friends.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_friends.Size = new System.Drawing.Size(948, 523);
            this.tabPage_friends.TabIndex = 0;
            this.tabPage_friends.Text = "好友列表";
            this.tabPage_friends.UseVisualStyleBackColor = true;
            // 
            // dgv_friends
            // 
            this.dgv_friends.AllowUserToAddRows = false;
            this.dgv_friends.AllowUserToDeleteRows = false;
            this.dgv_friends.AllowUserToResizeColumns = false;
            this.dgv_friends.AllowUserToResizeRows = false;
            this.dgv_friends.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_friends.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_friends.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserID,
            this.UserNumber,
            this.UserNickName,
            this.UserRemark});
            this.dgv_friends.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_friends.Location = new System.Drawing.Point(3, 3);
            this.dgv_friends.MultiSelect = false;
            this.dgv_friends.Name = "dgv_friends";
            this.dgv_friends.ReadOnly = true;
            this.dgv_friends.RowHeadersWidth = 50;
            this.dgv_friends.RowTemplate.Height = 23;
            this.dgv_friends.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_friends.Size = new System.Drawing.Size(942, 517);
            this.dgv_friends.TabIndex = 2;
            this.dgv_friends.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_friends_CellMouseClick);
            this.dgv_friends.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_friends_RowPostPaint);
            // 
            // UserID
            // 
            this.UserID.DataPropertyName = "UserID";
            this.UserID.HeaderText = "微信ID";
            this.UserID.Name = "UserID";
            this.UserID.ReadOnly = true;
            // 
            // UserNumber
            // 
            this.UserNumber.DataPropertyName = "UserNumber";
            this.UserNumber.HeaderText = "微信号";
            this.UserNumber.Name = "UserNumber";
            this.UserNumber.ReadOnly = true;
            // 
            // UserNickName
            // 
            this.UserNickName.DataPropertyName = "UserNickName";
            this.UserNickName.HeaderText = "昵称";
            this.UserNickName.Name = "UserNickName";
            this.UserNickName.ReadOnly = true;
            // 
            // UserRemark
            // 
            this.UserRemark.DataPropertyName = "UserRemark";
            this.UserRemark.HeaderText = "备注";
            this.UserRemark.Name = "UserRemark";
            this.UserRemark.ReadOnly = true;
            // 
            // tabPage_messages
            // 
            this.tabPage_messages.Controls.Add(this.dgv_messages);
            this.tabPage_messages.Location = new System.Drawing.Point(4, 22);
            this.tabPage_messages.Name = "tabPage_messages";
            this.tabPage_messages.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_messages.Size = new System.Drawing.Size(948, 523);
            this.tabPage_messages.TabIndex = 1;
            this.tabPage_messages.Text = "聊天记录";
            this.tabPage_messages.UseVisualStyleBackColor = true;
            // 
            // dgv_messages
            // 
            this.dgv_messages.AllowUserToAddRows = false;
            this.dgv_messages.AllowUserToDeleteRows = false;
            this.dgv_messages.AllowUserToResizeColumns = false;
            this.dgv_messages.AllowUserToResizeRows = false;
            this.dgv_messages.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_messages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_messages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Type,
            this.Source,
            this.Wxid,
            this.MsgSender,
            this.Content});
            this.dgv_messages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_messages.Location = new System.Drawing.Point(3, 3);
            this.dgv_messages.MultiSelect = false;
            this.dgv_messages.Name = "dgv_messages";
            this.dgv_messages.ReadOnly = true;
            this.dgv_messages.RowHeadersVisible = false;
            this.dgv_messages.RowHeadersWidth = 50;
            this.dgv_messages.RowTemplate.Height = 23;
            this.dgv_messages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_messages.Size = new System.Drawing.Size(942, 517);
            this.dgv_messages.TabIndex = 3;
            this.dgv_messages.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_messages_CellMouseClick);
            // 
            // Type
            // 
            this.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Type.DataPropertyName = "Type";
            this.Type.FillWeight = 8.871337F;
            this.Type.HeaderText = "消息类型";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Source
            // 
            this.Source.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Source.DataPropertyName = "Source";
            this.Source.FillWeight = 15.79921F;
            this.Source.HeaderText = "消息来源";
            this.Source.Name = "Source";
            this.Source.ReadOnly = true;
            this.Source.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Wxid
            // 
            this.Wxid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Wxid.DataPropertyName = "Wxid";
            this.Wxid.FillWeight = 92.46748F;
            this.Wxid.HeaderText = "微信ID/群ID";
            this.Wxid.Name = "Wxid";
            this.Wxid.ReadOnly = true;
            this.Wxid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Wxid.Width = 150;
            // 
            // MsgSender
            // 
            this.MsgSender.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MsgSender.DataPropertyName = "MsgSender";
            this.MsgSender.FillWeight = 380.7107F;
            this.MsgSender.HeaderText = "群发送者";
            this.MsgSender.Name = "MsgSender";
            this.MsgSender.ReadOnly = true;
            this.MsgSender.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MsgSender.Width = 150;
            // 
            // Content
            // 
            this.Content.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Content.DataPropertyName = "Content";
            this.Content.FillWeight = 2.151299F;
            this.Content.HeaderText = "消息内容";
            this.Content.Name = "Content";
            this.Content.ReadOnly = true;
            this.Content.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // contextMenu_dgv_friends
            // 
            this.contextMenu_dgv_friends.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_sendMessage});
            this.contextMenu_dgv_friends.Name = "contextMenu_dgv_friends";
            this.contextMenu_dgv_friends.Size = new System.Drawing.Size(125, 26);
            // 
            // menuItem_sendMessage
            // 
            this.menuItem_sendMessage.Name = "menuItem_sendMessage";
            this.menuItem_sendMessage.Size = new System.Drawing.Size(124, 22);
            this.menuItem_sendMessage.Text = "发送消息";
            this.menuItem_sendMessage.Click += new System.EventHandler(this.menuItem_sendMessage_Click);
            // 
            // contextMenu_dgv_messages
            // 
            this.contextMenu_dgv_messages.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_replyMessage});
            this.contextMenu_dgv_messages.Name = "contextMenu_dgv_messages";
            this.contextMenu_dgv_messages.Size = new System.Drawing.Size(125, 26);
            // 
            // menuItem_replyMessage
            // 
            this.menuItem_replyMessage.Name = "menuItem_replyMessage";
            this.menuItem_replyMessage.Size = new System.Drawing.Size(124, 22);
            this.menuItem_replyMessage.Text = "回复消息";
            this.menuItem_replyMessage.Click += new System.EventHandler(this.menuItem_replyMessage_Click);
            // 
            // 全自动功能ToolStripMenuItem
            // 
            this.全自动功能ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_autoChat,
            this.menuItem_autoChatFileHelper});
            this.全自动功能ToolStripMenuItem.Name = "全自动功能ToolStripMenuItem";
            this.全自动功能ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.全自动功能ToolStripMenuItem.Text = "全自动功能";
            // 
            // menuItem_autoChat
            // 
            this.menuItem_autoChat.CheckOnClick = true;
            this.menuItem_autoChat.Name = "menuItem_autoChat";
            this.menuItem_autoChat.Size = new System.Drawing.Size(204, 22);
            this.menuItem_autoChat.Text = "自动聊天(所有人)";
            this.menuItem_autoChat.CheckedChanged += new System.EventHandler(this.menuItem_autoChat_CheckedChanged);
            // 
            // menuItem_autoChatFileHelper
            // 
            this.menuItem_autoChatFileHelper.CheckOnClick = true;
            this.menuItem_autoChatFileHelper.Name = "menuItem_autoChatFileHelper";
            this.menuItem_autoChatFileHelper.Size = new System.Drawing.Size(204, 22);
            this.menuItem_autoChatFileHelper.Text = "自动聊天(文件传输助手)";
            this.menuItem_autoChatFileHelper.CheckedChanged += new System.EventHandler(this.menuItem_autoChatFileHelper_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 574);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menu_wechat);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu_wechat;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "微信助手";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menu_wechat.ResumeLayout(false);
            this.menu_wechat.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPage_friends.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_friends)).EndInit();
            this.tabPage_messages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_messages)).EndInit();
            this.contextMenu_dgv_friends.ResumeLayout(false);
            this.contextMenu_dgv_messages.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu_wechat;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItem_logout;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage_friends;
        private System.Windows.Forms.DataGridView dgv_friends;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserNickName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserRemark;
        private System.Windows.Forms.TabPage tabPage_messages;
        private System.Windows.Forms.DataGridView dgv_messages;
        private System.Windows.Forms.ContextMenuStrip contextMenu_dgv_friends;
        private System.Windows.Forms.ToolStripMenuItem menuItem_saveContact;
        private System.Windows.Forms.ToolStripMenuItem menuItem_sendMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Source;
        private System.Windows.Forms.DataGridViewTextBoxColumn Wxid;
        private System.Windows.Forms.DataGridViewTextBoxColumn MsgSender;
        private System.Windows.Forms.DataGridViewTextBoxColumn Content;
        private System.Windows.Forms.ContextMenuStrip contextMenu_dgv_messages;
        private System.Windows.Forms.ToolStripMenuItem menuItem_replyMessage;
        private System.Windows.Forms.ToolStripMenuItem 全自动功能ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItem_autoChat;
        private System.Windows.Forms.ToolStripMenuItem menuItem_autoChatFileHelper;
    }
}

