namespace ChatApplication
{
    partial class FormCall
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this._lbCallTo = new System.Windows.Forms.Label();
            this._btnHangUp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ChatApplication.Properties.Resources.callling;
            this.pictureBox1.Location = new System.Drawing.Point(79, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // _lbCallTo
            // 
            this._lbCallTo.AutoSize = true;
            this._lbCallTo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lbCallTo.Location = new System.Drawing.Point(139, 28);
            this._lbCallTo.Name = "_lbCallTo";
            this._lbCallTo.Size = new System.Drawing.Size(63, 25);
            this._lbCallTo.TabIndex = 3;
            this._lbCallTo.Text = "label1";
            // 
            // _btnHangUp
            // 
            this._btnHangUp.BackColor = System.Drawing.Color.Red;
            this._btnHangUp.FlatAppearance.BorderSize = 0;
            this._btnHangUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnHangUp.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnHangUp.ForeColor = System.Drawing.Color.White;
            this._btnHangUp.Location = new System.Drawing.Point(156, 62);
            this._btnHangUp.Name = "_btnHangUp";
            this._btnHangUp.Size = new System.Drawing.Size(104, 24);
            this._btnHangUp.TabIndex = 4;
            this._btnHangUp.Text = "Hủy";
            this._btnHangUp.UseVisualStyleBackColor = false;
            this._btnHangUp.Click += new System.EventHandler(this._btnHangUp_Click);
            // 
            // FormCall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(447, 98);
            this.Controls.Add(this._btnHangUp);
            this.Controls.Add(this._lbCallTo);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FormCall";
            this.Text = "FormCall";
            this.Load += new System.EventHandler(this.FormCall_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label _lbCallTo;
        private System.Windows.Forms.Button _btnHangUp;
    }
}