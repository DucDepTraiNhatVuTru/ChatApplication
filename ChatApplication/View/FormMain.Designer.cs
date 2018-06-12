namespace ChatApplication.View
{
    partial class FormMain
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
            this._lbUserName = new System.Windows.Forms.Label();
            this._ptbChinhSua = new System.Windows.Forms.PictureBox();
            this._ptbAvatar = new System.Windows.Forms.PictureBox();
            this._radlvFriendList = new Telerik.WinControls.UI.RadListView();
            this._tabControlMain = new System.Windows.Forms.TabControl();
            this._tabPageFriend = new System.Windows.Forms.TabPage();
            this._tabPageGroupChat = new System.Windows.Forms.TabPage();
            this._radLVGroupChat = new Telerik.WinControls.UI.RadListView();
            ((System.ComponentModel.ISupportInitialize)(this._ptbChinhSua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ptbAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._radlvFriendList)).BeginInit();
            this._tabControlMain.SuspendLayout();
            this._tabPageFriend.SuspendLayout();
            this._tabPageGroupChat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._radLVGroupChat)).BeginInit();
            this.SuspendLayout();
            // 
            // _lbUserName
            // 
            this._lbUserName.AutoSize = true;
            this._lbUserName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lbUserName.Location = new System.Drawing.Point(111, 12);
            this._lbUserName.Name = "_lbUserName";
            this._lbUserName.Size = new System.Drawing.Size(88, 21);
            this._lbUserName.TabIndex = 3;
            this._lbUserName.Text = "User Name";
            // 
            // _ptbChinhSua
            // 
            this._ptbChinhSua.Image = global::ChatApplication.Properties.Resources.pen;
            this._ptbChinhSua.InitialImage = null;
            this._ptbChinhSua.Location = new System.Drawing.Point(85, 87);
            this._ptbChinhSua.Name = "_ptbChinhSua";
            this._ptbChinhSua.Size = new System.Drawing.Size(20, 21);
            this._ptbChinhSua.TabIndex = 4;
            this._ptbChinhSua.TabStop = false;
            this._ptbChinhSua.Click += new System.EventHandler(this._ptbChinhSua_Click);
            // 
            // _ptbAvatar
            // 
            this._ptbAvatar.Image = global::ChatApplication.Properties.Resources.hello;
            this._ptbAvatar.Location = new System.Drawing.Point(5, 12);
            this._ptbAvatar.Name = "_ptbAvatar";
            this._ptbAvatar.Size = new System.Drawing.Size(100, 96);
            this._ptbAvatar.TabIndex = 2;
            this._ptbAvatar.TabStop = false;
            // 
            // _radlvFriendList
            // 
            this._radlvFriendList.Dock = System.Windows.Forms.DockStyle.Fill;
            this._radlvFriendList.Location = new System.Drawing.Point(3, 3);
            this._radlvFriendList.Name = "_radlvFriendList";
            this._radlvFriendList.Size = new System.Drawing.Size(259, 373);
            this._radlvFriendList.TabIndex = 0;
            this._radlvFriendList.ThemeName = "ControlDefault";
            // 
            // _tabControlMain
            // 
            this._tabControlMain.Controls.Add(this._tabPageFriend);
            this._tabControlMain.Controls.Add(this._tabPageGroupChat);
            this._tabControlMain.Location = new System.Drawing.Point(5, 114);
            this._tabControlMain.Name = "_tabControlMain";
            this._tabControlMain.SelectedIndex = 0;
            this._tabControlMain.Size = new System.Drawing.Size(273, 405);
            this._tabControlMain.TabIndex = 6;
            // 
            // _tabPageFriend
            // 
            this._tabPageFriend.Controls.Add(this._radlvFriendList);
            this._tabPageFriend.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tabPageFriend.Location = new System.Drawing.Point(4, 22);
            this._tabPageFriend.Name = "_tabPageFriend";
            this._tabPageFriend.Padding = new System.Windows.Forms.Padding(3);
            this._tabPageFriend.Size = new System.Drawing.Size(265, 379);
            this._tabPageFriend.TabIndex = 0;
            this._tabPageFriend.Text = "Friends";
            this._tabPageFriend.UseVisualStyleBackColor = true;
            // 
            // _tabPageGroupChat
            // 
            this._tabPageGroupChat.Controls.Add(this._radLVGroupChat);
            this._tabPageGroupChat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tabPageGroupChat.Location = new System.Drawing.Point(4, 22);
            this._tabPageGroupChat.Name = "_tabPageGroupChat";
            this._tabPageGroupChat.Padding = new System.Windows.Forms.Padding(3);
            this._tabPageGroupChat.Size = new System.Drawing.Size(265, 379);
            this._tabPageGroupChat.TabIndex = 1;
            this._tabPageGroupChat.Text = "Groups Chat";
            this._tabPageGroupChat.UseVisualStyleBackColor = true;
            // 
            // _radLVGroupChat
            // 
            this._radLVGroupChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this._radLVGroupChat.Location = new System.Drawing.Point(3, 3);
            this._radLVGroupChat.Name = "_radLVGroupChat";
            this._radLVGroupChat.Size = new System.Drawing.Size(259, 373);
            this._radLVGroupChat.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(280, 523);
            this.Controls.Add(this._tabControlMain);
            this.Controls.Add(this._ptbChinhSua);
            this.Controls.Add(this._lbUserName);
            this.Controls.Add(this._ptbAvatar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormMain";
            this.Text = "FormTest";
            ((System.ComponentModel.ISupportInitialize)(this._ptbChinhSua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._ptbAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._radlvFriendList)).EndInit();
            this._tabControlMain.ResumeLayout(false);
            this._tabPageFriend.ResumeLayout(false);
            this._tabPageGroupChat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._radLVGroupChat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox _ptbAvatar;
        private System.Windows.Forms.Label _lbUserName;
        private System.Windows.Forms.PictureBox _ptbChinhSua;
        private Telerik.WinControls.UI.RadListView _radlvFriendList;
        private System.Windows.Forms.TabControl _tabControlMain;
        private System.Windows.Forms.TabPage _tabPageFriend;
        private System.Windows.Forms.TabPage _tabPageGroupChat;
        private Telerik.WinControls.UI.RadListView _radLVGroupChat;
    }
}