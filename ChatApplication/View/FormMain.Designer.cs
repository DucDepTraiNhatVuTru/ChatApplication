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
            this._btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._ptbAvatar = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._ptbAvatar)).BeginInit();
            this.SuspendLayout();
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
            // _ptbAvatar
            // 
            this._ptbAvatar.Image = global::ChatApplication.Properties.Resources.hello;
            this._ptbAvatar.Location = new System.Drawing.Point(6, 42);
            this._ptbAvatar.Name = "_ptbAvatar";
            this._ptbAvatar.Size = new System.Drawing.Size(100, 96);
            this._ptbAvatar.TabIndex = 2;
            this._ptbAvatar.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(112, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "User Name";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(280, 523);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._ptbAvatar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMain";
            this.Text = "FormTest";
            ((System.ComponentModel.ISupportInitialize)(this._ptbAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox _ptbAvatar;
        private System.Windows.Forms.Label label2;
    }
}