namespace ChatApplication.View
{
    partial class FormListLiveStream
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this._radListFriendStreaming = new Telerik.WinControls.UI.RadListView();
            this._btnRefresh = new System.Windows.Forms.Button();
            this._btnStream = new System.Windows.Forms.Button();
            this._btnAddFriend = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._radListFriendStreaming)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(135, 30);
            this.textBox1.TabIndex = 0;
            // 
            // _radListFriendStreaming
            // 
            this._radListFriendStreaming.Location = new System.Drawing.Point(12, 48);
            this._radListFriendStreaming.Name = "_radListFriendStreaming";
            this._radListFriendStreaming.Size = new System.Drawing.Size(249, 339);
            this._radListFriendStreaming.TabIndex = 9;
            // 
            // _btnRefresh
            // 
            this._btnRefresh.FlatAppearance.BorderSize = 0;
            this._btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnRefresh.Image = global::ChatApplication.Properties.Resources.refresh;
            this._btnRefresh.Location = new System.Drawing.Point(191, 12);
            this._btnRefresh.Name = "_btnRefresh";
            this._btnRefresh.Size = new System.Drawing.Size(32, 32);
            this._btnRefresh.TabIndex = 11;
            this._btnRefresh.UseVisualStyleBackColor = true;
            this._btnRefresh.Click += new System.EventHandler(this._btnRefresh_Click);
            // 
            // _btnStream
            // 
            this._btnStream.FlatAppearance.BorderSize = 0;
            this._btnStream.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnStream.Image = global::ChatApplication.Properties.Resources.stream;
            this._btnStream.Location = new System.Drawing.Point(229, 10);
            this._btnStream.Name = "_btnStream";
            this._btnStream.Size = new System.Drawing.Size(32, 32);
            this._btnStream.TabIndex = 10;
            this._btnStream.UseVisualStyleBackColor = true;
            this._btnStream.Click += new System.EventHandler(this._btnStream_Click);
            // 
            // _btnAddFriend
            // 
            this._btnAddFriend.FlatAppearance.BorderSize = 0;
            this._btnAddFriend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnAddFriend.Image = global::ChatApplication.Properties.Resources.findfriend;
            this._btnAddFriend.Location = new System.Drawing.Point(153, 12);
            this._btnAddFriend.Name = "_btnAddFriend";
            this._btnAddFriend.Size = new System.Drawing.Size(32, 32);
            this._btnAddFriend.TabIndex = 8;
            this._btnAddFriend.UseVisualStyleBackColor = true;
            // 
            // FormListLiveStream
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(271, 399);
            this.Controls.Add(this._btnRefresh);
            this.Controls.Add(this._btnStream);
            this.Controls.Add(this._radListFriendStreaming);
            this.Controls.Add(this._btnAddFriend);
            this.Controls.Add(this.textBox1);
            this.Name = "FormListLiveStream";
            this.Text = "FormListLiveStream";
            ((System.ComponentModel.ISupportInitialize)(this._radListFriendStreaming)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button _btnAddFriend;
        private Telerik.WinControls.UI.RadListView _radListFriendStreaming;
        private System.Windows.Forms.Button _btnStream;
        private System.Windows.Forms.Button _btnRefresh;
    }
}