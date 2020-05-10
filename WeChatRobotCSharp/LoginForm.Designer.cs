namespace WeChatRobotCSharp
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.btn_showQrCode = new System.Windows.Forms.Button();
            this.pic_qrCode = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_qrCode)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_showQrCode
            // 
            this.btn_showQrCode.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_showQrCode.Location = new System.Drawing.Point(63, 263);
            this.btn_showQrCode.Name = "btn_showQrCode";
            this.btn_showQrCode.Size = new System.Drawing.Size(146, 36);
            this.btn_showQrCode.TabIndex = 0;
            this.btn_showQrCode.Text = "显示二维码";
            this.btn_showQrCode.UseVisualStyleBackColor = true;
            this.btn_showQrCode.Click += new System.EventHandler(this.btn_showQrCode_Click);
            // 
            // pic_qrCode
            // 
            this.pic_qrCode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pic_qrCode.Location = new System.Drawing.Point(36, 33);
            this.pic_qrCode.Name = "pic_qrCode";
            this.pic_qrCode.Size = new System.Drawing.Size(200, 200);
            this.pic_qrCode.TabIndex = 1;
            this.pic_qrCode.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 330);
            this.Controls.Add(this.pic_qrCode);
            this.Controls.Add(this.btn_showQrCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.pic_qrCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_showQrCode;
        private System.Windows.Forms.PictureBox pic_qrCode;
    }
}