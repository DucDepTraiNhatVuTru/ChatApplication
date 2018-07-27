namespace ChatApplication.View
{
    partial class FormWatchStream
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
            this._cmtboxComment = new FormChung.CommentBoxControl();
            this._ptbVideoView = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this._ptbVideoView)).BeginInit();
            this.SuspendLayout();
            // 
            // _cmtboxComment
            // 
            this._cmtboxComment.Location = new System.Drawing.Point(808, 1);
            this._cmtboxComment.Name = "_cmtboxComment";
            this._cmtboxComment.Size = new System.Drawing.Size(250, 450);
            this._cmtboxComment.TabIndex = 2;
            // 
            // _ptbVideoView
            // 
            this._ptbVideoView.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._ptbVideoView.Location = new System.Drawing.Point(2, 1);
            this._ptbVideoView.Name = "_ptbVideoView";
            this._ptbVideoView.Size = new System.Drawing.Size(800, 450);
            this._ptbVideoView.TabIndex = 1;
            this._ptbVideoView.TabStop = false;
            // 
            // FormWatchStream
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1064, 451);
            this.Controls.Add(this._cmtboxComment);
            this.Controls.Add(this._ptbVideoView);
            this.Name = "FormWatchStream";
            this.Text = "FormWatchStream";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormWatchStream_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this._ptbVideoView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox _ptbVideoView;
        private FormChung.CommentBoxControl _cmtboxComment;
    }
}