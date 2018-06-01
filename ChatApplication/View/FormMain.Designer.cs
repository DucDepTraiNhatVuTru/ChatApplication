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
            this.label1 = new System.Windows.Forms.Label();
            this._lbUserName = new System.Windows.Forms.Label();
            this._ptbChinhSua = new System.Windows.Forms.PictureBox();
            this._ptbAvatar = new System.Windows.Forms.PictureBox();
            this._btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._ptbChinhSua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ptbAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chat Application";
            // 
            // _lbUserName
            // 
            this._lbUserName.AutoSize = true;
            this._lbUserName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lbUserName.Location = new System.Drawing.Point(112, 42);
            this._lbUserName.Name = "_lbUserName";
            this._lbUserName.Size = new System.Drawing.Size(88, 21);
            this._lbUserName.TabIndex = 3;
            this._lbUserName.Text = "User Name";
            // 
            // _ptbChinhSua
            // 
            this._ptbChinhSua.Image = global::ChatApplication.Properties.Resources.pen;
            this._ptbChinhSua.InitialImage = null;
            this._ptbChinhSua.Location = new System.Drawing.Point(85, 116);
            this._ptbChinhSua.Name = "_ptbChinhSua";
            this._ptbChinhSua.Size = new System.Drawing.Size(20, 21);
            this._ptbChinhSua.TabIndex = 4;
            this._ptbChinhSua.TabStop = false;
            this._ptbChinhSua.Click += new System.EventHandler(this._ptbChinhSua_Click);
            // 
            // _ptbAvatar
            // 
            this._ptbAvatar.Image = global::ChatApplication.Properties.Resources.hello;
            this._ptbAvatar.Location = new System.Drawing.Point(6, 42);
            this._ptbAvatar.Name = "_ptbAvatar";
            this._ptbAvatar.Size = new System.Drawing.Size(100, 96);
            this._ptbAvatar.TabIndex = 2;
            this._ptbAvatar.TabStop = false;
            // 
            // _btnClose
            // 
            this._btnClose.FlatAppearance.BorderSize = 0;
            this._btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnClose.Image = global::ChatApplication.Properties.Resources.exit;
            this._btnClose.Location = new System.Drawing.Point(247, 1);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(32, 32);
            this._btnClose.TabIndex = 0;
            this._btnClose.UseVisualStyleBackColor = true;
            this._btnClose.Click += new System.EventHandler(this._btnClose_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(280, 523);
            this.Controls.Add(this._ptbChinhSua);
            this.Controls.Add(this._lbUserName);
            this.Controls.Add(this._ptbAvatar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMain";
            this.Text = "FormTest";
            ((System.ComponentModel.ISupportInitialize)(this._ptbChinhSua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._ptbAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox _ptbAvatar;
        private System.Windows.Forms.Label _lbUserName;
        private System.Windows.Forms.PictureBox _ptbChinhSua;
    }
}