﻿namespace ChatApplication.View
{
    partial class FormLiveStream
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
            this._btnSetting = new System.Windows.Forms.Button();
            this._ptbVideoView = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this._ptbVideoView)).BeginInit();
            this.SuspendLayout();
            // 
            // _cmtboxComment
            // 
            this._cmtboxComment.Location = new System.Drawing.Point(812, 0);
            this._cmtboxComment.Name = "_cmtboxComment";
            this._cmtboxComment.Size = new System.Drawing.Size(250, 450);
            this._cmtboxComment.TabIndex = 1;
            // 
            // _btnSetting
            // 
            this._btnSetting.BackColor = System.Drawing.Color.LightBlue;
            this._btnSetting.FlatAppearance.BorderSize = 0;
            this._btnSetting.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this._btnSetting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this._btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnSetting.Image = global::ChatApplication.Properties.Resources.setting;
            this._btnSetting.Location = new System.Drawing.Point(368, 402);
            this._btnSetting.Name = "_btnSetting";
            this._btnSetting.Size = new System.Drawing.Size(44, 37);
            this._btnSetting.TabIndex = 2;
            this._btnSetting.UseVisualStyleBackColor = false;
            this._btnSetting.Click += new System.EventHandler(this._btnSetting_Click);
            // 
            // _ptbVideoView
            // 
            this._ptbVideoView.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._ptbVideoView.Location = new System.Drawing.Point(0, 0);
            this._ptbVideoView.Name = "_ptbVideoView";
            this._ptbVideoView.Size = new System.Drawing.Size(800, 450);
            this._ptbVideoView.TabIndex = 0;
            this._ptbVideoView.TabStop = false;
            // 
            // FormLiveStream
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1064, 451);
            this.Controls.Add(this._btnSetting);
            this.Controls.Add(this._cmtboxComment);
            this.Controls.Add(this._ptbVideoView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormLiveStream";
            this.Text = "FormLiveStream";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLiveStream_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this._ptbVideoView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox _ptbVideoView;
        private FormChung.CommentBoxControl _cmtboxComment;
        private System.Windows.Forms.Button _btnSetting;
    }
}