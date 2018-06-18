namespace ChatApplication.View
{
    partial class FormAddFriend
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
            this._ptbAvatar = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this._lbName = new System.Windows.Forms.Label();
            this._lbGender = new System.Windows.Forms.Label();
            this._lbCreateTime = new System.Windows.Forms.Label();
            this._btnAddFriend = new System.Windows.Forms.Button();
            this._lbThongBao = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._ptbAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // _ptbAvatar
            // 
            this._ptbAvatar.Location = new System.Drawing.Point(12, 53);
            this._ptbAvatar.Name = "_ptbAvatar";
            this._ptbAvatar.Size = new System.Drawing.Size(103, 108);
            this._ptbAvatar.TabIndex = 0;
            this._ptbAvatar.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(214, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Thông tin";
            // 
            // _lbName
            // 
            this._lbName.AutoSize = true;
            this._lbName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lbName.Location = new System.Drawing.Point(139, 53);
            this._lbName.Name = "_lbName";
            this._lbName.Size = new System.Drawing.Size(52, 21);
            this._lbName.TabIndex = 2;
            this._lbName.Text = "Name";
            // 
            // _lbGender
            // 
            this._lbGender.AutoSize = true;
            this._lbGender.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lbGender.Location = new System.Drawing.Point(139, 83);
            this._lbGender.Name = "_lbGender";
            this._lbGender.Size = new System.Drawing.Size(61, 21);
            this._lbGender.TabIndex = 3;
            this._lbGender.Text = "Gender";
            // 
            // _lbCreateTime
            // 
            this._lbCreateTime.AutoSize = true;
            this._lbCreateTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lbCreateTime.Location = new System.Drawing.Point(139, 115);
            this._lbCreateTime.Name = "_lbCreateTime";
            this._lbCreateTime.Size = new System.Drawing.Size(93, 21);
            this._lbCreateTime.TabIndex = 4;
            this._lbCreateTime.Text = "Create Time";
            // 
            // _btnAddFriend
            // 
            this._btnAddFriend.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this._btnAddFriend.FlatAppearance.BorderSize = 0;
            this._btnAddFriend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnAddFriend.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnAddFriend.Location = new System.Drawing.Point(219, 183);
            this._btnAddFriend.Name = "_btnAddFriend";
            this._btnAddFriend.Size = new System.Drawing.Size(139, 32);
            this._btnAddFriend.TabIndex = 5;
            this._btnAddFriend.Text = "Gửi lời mời kết bạn";
            this._btnAddFriend.UseVisualStyleBackColor = false;
            // 
            // _lbThongBao
            // 
            this._lbThongBao.AutoSize = true;
            this._lbThongBao.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lbThongBao.ForeColor = System.Drawing.Color.Red;
            this._lbThongBao.Location = new System.Drawing.Point(12, 188);
            this._lbThongBao.Name = "_lbThongBao";
            this._lbThongBao.Size = new System.Drawing.Size(0, 21);
            this._lbThongBao.TabIndex = 6;
            // 
            // FormAddFriend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(370, 227);
            this.Controls.Add(this._lbThongBao);
            this.Controls.Add(this._btnAddFriend);
            this.Controls.Add(this._lbCreateTime);
            this.Controls.Add(this._lbGender);
            this.Controls.Add(this._lbName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._ptbAvatar);
            this.Name = "FormAddFriend";
            this.Text = "FormAddFriend";
            ((System.ComponentModel.ISupportInitialize)(this._ptbAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox _ptbAvatar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label _lbName;
        private System.Windows.Forms.Label _lbGender;
        private System.Windows.Forms.Label _lbCreateTime;
        private System.Windows.Forms.Button _btnAddFriend;
        private System.Windows.Forms.Label _lbThongBao;
    }
}