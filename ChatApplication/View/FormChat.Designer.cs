namespace ChatApplication.View
{
    partial class FormChat
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
            this._rcChatlog = new Telerik.WinControls.UI.RadChat();
            this._ptbFriendsAvatar = new System.Windows.Forms.PictureBox();
            this._lbFriendsName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._rcChatlog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ptbFriendsAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // _rcChatlog
            // 
            this._rcChatlog.Location = new System.Drawing.Point(1, 2);
            this._rcChatlog.Name = "_rcChatlog";
            this._rcChatlog.Size = new System.Drawing.Size(562, 393);
            this._rcChatlog.TabIndex = 0;
            this._rcChatlog.Text = "_radchatChatLog";
            this._rcChatlog.TimeSeparatorInterval = System.TimeSpan.Parse("1.00:00:00");
            this._rcChatlog.SendMessage += new Telerik.WinControls.UI.SendMessageEventHandler(this._rcChatlog_SendMessage);
            ((Telerik.WinControls.UI.ChatMessagesViewElement)(this._rcChatlog.GetChildAt(0).GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // _ptbFriendsAvatar
            // 
            this._ptbFriendsAvatar.Location = new System.Drawing.Point(569, 12);
            this._ptbFriendsAvatar.Name = "_ptbFriendsAvatar";
            this._ptbFriendsAvatar.Size = new System.Drawing.Size(97, 109);
            this._ptbFriendsAvatar.TabIndex = 1;
            this._ptbFriendsAvatar.TabStop = false;
            // 
            // _lbFriendsName
            // 
            this._lbFriendsName.AutoSize = true;
            this._lbFriendsName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lbFriendsName.Location = new System.Drawing.Point(569, 134);
            this._lbFriendsName.Name = "_lbFriendsName";
            this._lbFriendsName.Size = new System.Drawing.Size(50, 20);
            this._lbFriendsName.TabIndex = 1;
            this._lbFriendsName.Text = "label1";
            // 
            // FormChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(671, 394);
            this.Controls.Add(this._lbFriendsName);
            this.Controls.Add(this._ptbFriendsAvatar);
            this.Controls.Add(this._rcChatlog);
            this.Name = "FormChat";
            this.Text = "FormChat";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormChat_FormClosed);
            this.Load += new System.EventHandler(this.FormChat_Load);
            ((System.ComponentModel.ISupportInitialize)(this._rcChatlog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._ptbFriendsAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadChat _rcChatlog;
        private System.Windows.Forms.PictureBox _ptbFriendsAvatar;
        private System.Windows.Forms.Label _lbFriendsName;
    }
}