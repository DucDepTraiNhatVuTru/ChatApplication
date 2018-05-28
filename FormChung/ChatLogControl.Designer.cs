namespace FormChung
{
    partial class ChatLogControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._txtChatBox = new System.Windows.Forms.TextBox();
            this._btnSend = new System.Windows.Forms.Button();
            this._rtbChatLog = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // _txtChatBox
            // 
            this._txtChatBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtChatBox.Location = new System.Drawing.Point(3, 313);
            this._txtChatBox.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this._txtChatBox.Multiline = true;
            this._txtChatBox.Name = "_txtChatBox";
            this._txtChatBox.Size = new System.Drawing.Size(558, 34);
            this._txtChatBox.TabIndex = 1;
            this._txtChatBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // _btnSend
            // 
            this._btnSend.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this._btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnSend.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnSend.ForeColor = System.Drawing.Color.White;
            this._btnSend.Location = new System.Drawing.Point(567, 313);
            this._btnSend.Name = "_btnSend";
            this._btnSend.Size = new System.Drawing.Size(93, 34);
            this._btnSend.TabIndex = 2;
            this._btnSend.Text = "Gửi";
            this._btnSend.UseVisualStyleBackColor = false;
            // 
            // _rtbChatLog
            // 
            this._rtbChatLog.BackColor = System.Drawing.Color.White;
            this._rtbChatLog.Location = new System.Drawing.Point(3, 3);
            this._rtbChatLog.Name = "_rtbChatLog";
            this._rtbChatLog.Size = new System.Drawing.Size(657, 291);
            this._rtbChatLog.TabIndex = 0;
            this._rtbChatLog.Text = "";
            // 
            // ChatLogControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this._btnSend);
            this.Controls.Add(this._txtChatBox);
            this.Controls.Add(this._rtbChatLog);
            this.Name = "ChatLogControl";
            this.Size = new System.Drawing.Size(663, 350);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox _txtChatBox;
        private System.Windows.Forms.Button _btnSend;
        private System.Windows.Forms.RichTextBox _rtbChatLog;
    }
}
