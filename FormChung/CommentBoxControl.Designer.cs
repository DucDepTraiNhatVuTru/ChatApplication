namespace FormChung
{
    partial class CommentBoxControl
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
            this._txtInputComment = new System.Windows.Forms.TextBox();
            this._btnSend = new System.Windows.Forms.Button();
            this._panelListCmt = new System.Windows.Forms.Panel();
            this._listControlComment = new Telerik.WinControls.UI.RadListControl();
            this._panelListCmt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._listControlComment)).BeginInit();
            this.SuspendLayout();
            // 
            // _txtInputComment
            // 
            this._txtInputComment.Location = new System.Drawing.Point(3, 300);
            this._txtInputComment.Multiline = true;
            this._txtInputComment.Name = "_txtInputComment";
            this._txtInputComment.Size = new System.Drawing.Size(233, 34);
            this._txtInputComment.TabIndex = 0;
            // 
            // _btnSend
            // 
            this._btnSend.FlatAppearance.BorderSize = 0;
            this._btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnSend.Image = global::FormChung.Properties.Resources.Send;
            this._btnSend.Location = new System.Drawing.Point(236, 300);
            this._btnSend.Name = "_btnSend";
            this._btnSend.Size = new System.Drawing.Size(40, 34);
            this._btnSend.TabIndex = 1;
            this._btnSend.UseVisualStyleBackColor = true;
            // 
            // _panelListCmt
            // 
            this._panelListCmt.Controls.Add(this._listControlComment);
            this._panelListCmt.Location = new System.Drawing.Point(0, 0);
            this._panelListCmt.Name = "_panelListCmt";
            this._panelListCmt.Size = new System.Drawing.Size(276, 294);
            this._panelListCmt.TabIndex = 2;
            // 
            // _listControlComment
            // 
            this._listControlComment.Location = new System.Drawing.Point(0, 0);
            this._listControlComment.Name = "_listControlComment";
            this._listControlComment.Size = new System.Drawing.Size(276, 294);
            this._listControlComment.TabIndex = 0;
            // 
            // CommentBoxControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._panelListCmt);
            this.Controls.Add(this._btnSend);
            this.Controls.Add(this._txtInputComment);
            this.Name = "CommentBoxControl";
            this.Size = new System.Drawing.Size(276, 337);
            this._panelListCmt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._listControlComment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _txtInputComment;
        private System.Windows.Forms.Button _btnSend;
        private System.Windows.Forms.Panel _panelListCmt;
        private Telerik.WinControls.UI.RadListControl _listControlComment;
    }
}
