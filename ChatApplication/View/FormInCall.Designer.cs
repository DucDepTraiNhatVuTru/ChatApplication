namespace ChatApplication.View
{
    partial class FormInCall
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
            this.components = new System.ComponentModel.Container();
            this._ptbAvatar = new System.Windows.Forms.PictureBox();
            this._lbName = new System.Windows.Forms.Label();
            this._timerThoiLuongCuocGoi = new System.Windows.Forms.Timer(this.components);
            this._btnHangUp = new System.Windows.Forms.Button();
            this._lbtime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._ptbAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // _ptbAvatar
            // 
            this._ptbAvatar.Location = new System.Drawing.Point(73, 12);
            this._ptbAvatar.Name = "_ptbAvatar";
            this._ptbAvatar.Size = new System.Drawing.Size(64, 64);
            this._ptbAvatar.TabIndex = 0;
            this._ptbAvatar.TabStop = false;
            // 
            // _lbName
            // 
            this._lbName.AutoSize = true;
            this._lbName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lbName.Location = new System.Drawing.Point(69, 89);
            this._lbName.Name = "_lbName";
            this._lbName.Size = new System.Drawing.Size(52, 21);
            this._lbName.TabIndex = 1;
            this._lbName.Text = "label1";
            // 
            // _timerThoiLuongCuocGoi
            // 
            this._timerThoiLuongCuocGoi.Enabled = true;
            this._timerThoiLuongCuocGoi.Interval = 1000;
            // 
            // _btnHangUp
            // 
            this._btnHangUp.BackColor = System.Drawing.Color.Red;
            this._btnHangUp.FlatAppearance.BorderSize = 0;
            this._btnHangUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnHangUp.Location = new System.Drawing.Point(58, 194);
            this._btnHangUp.Name = "_btnHangUp";
            this._btnHangUp.Size = new System.Drawing.Size(97, 23);
            this._btnHangUp.TabIndex = 2;
            this._btnHangUp.Text = "Tắt máy";
            this._btnHangUp.UseVisualStyleBackColor = false;
            this._btnHangUp.Click += new System.EventHandler(this._btnHangUp_Click);
            // 
            // _lbtime
            // 
            this._lbtime.AutoSize = true;
            this._lbtime.Location = new System.Drawing.Point(86, 124);
            this._lbtime.Name = "_lbtime";
            this._lbtime.Size = new System.Drawing.Size(35, 13);
            this._lbtime.TabIndex = 3;
            this._lbtime.Text = "label1";
            // 
            // FormInCall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(212, 229);
            this.Controls.Add(this._lbtime);
            this.Controls.Add(this._btnHangUp);
            this.Controls.Add(this._lbName);
            this.Controls.Add(this._ptbAvatar);
            this.Name = "FormInCall";
            this.Text = "FormInCall";
            ((System.ComponentModel.ISupportInitialize)(this._ptbAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox _ptbAvatar;
        private System.Windows.Forms.Label _lbName;
        private System.Windows.Forms.Timer _timerThoiLuongCuocGoi;
        private System.Windows.Forms.Button _btnHangUp;
        private System.Windows.Forms.Label _lbtime;
    }
}