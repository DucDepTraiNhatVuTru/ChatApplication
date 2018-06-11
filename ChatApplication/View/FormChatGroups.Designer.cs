namespace ChatApplication.View
{
    partial class FormChatGroups
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
            this._radchatChatGroup = new Telerik.WinControls.UI.RadChat();
            ((System.ComponentModel.ISupportInitialize)(this._radchatChatGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // _radchatChatGroup
            // 
            this._radchatChatGroup.Location = new System.Drawing.Point(12, 7);
            this._radchatChatGroup.Name = "_radchatChatGroup";
            this._radchatChatGroup.Size = new System.Drawing.Size(554, 333);
            this._radchatChatGroup.TabIndex = 0;
            this._radchatChatGroup.Text = "radChat1";
            this._radchatChatGroup.TimeSeparatorInterval = System.TimeSpan.Parse("1.00:00:00");
            // 
            // FormChatGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 344);
            this.Controls.Add(this._radchatChatGroup);
            this.Name = "FormChatGroups";
            this.Text = "FormChatGroups";
            ((System.ComponentModel.ISupportInitialize)(this._radchatChatGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadChat _radchatChatGroup;
    }
}