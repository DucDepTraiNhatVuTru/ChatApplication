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
            ((System.ComponentModel.ISupportInitialize)(this._rcChatlog)).BeginInit();
            this.SuspendLayout();
            // 
            // _rcChatlog
            // 
            this._rcChatlog.Location = new System.Drawing.Point(4, 2);
            this._rcChatlog.Name = "_rcChatlog";
            this._rcChatlog.Size = new System.Drawing.Size(870, 389);
            this._rcChatlog.TabIndex = 0;
            this._rcChatlog.Text = "_radchatChatLog";
            this._rcChatlog.TimeSeparatorInterval = System.TimeSpan.Parse("1.00:00:00");
            this._rcChatlog.SendMessage += new Telerik.WinControls.UI.SendMessageEventHandler(this._rcChatlog_SendMessage);
            // 
            // FormChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 394);
            this.Controls.Add(this._rcChatlog);
            this.Name = "FormChat";
            this.Text = "FormChat";
            ((System.ComponentModel.ISupportInitialize)(this._rcChatlog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadChat _rcChatlog;
    }
}