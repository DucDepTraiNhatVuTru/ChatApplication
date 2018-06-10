namespace FormChung
{
    partial class Picture
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
            this._ptbHinh = new System.Windows.Forms.PictureBox();
            this._btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._ptbHinh)).BeginInit();
            this.SuspendLayout();
            // 
            // _ptbHinh
            // 
            this._ptbHinh.Location = new System.Drawing.Point(0, 0);
            this._ptbHinh.Name = "_ptbHinh";
            this._ptbHinh.Size = new System.Drawing.Size(50, 50);
            this._ptbHinh.TabIndex = 0;
            this._ptbHinh.TabStop = false;
            // 
            // _btnClose
            // 
            this._btnClose.Location = new System.Drawing.Point(36, 0);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(14, 16);
            this._btnClose.TabIndex = 1;
            this._btnClose.Text = "button1";
            this._btnClose.UseVisualStyleBackColor = true;
            // 
            // Picture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this._ptbHinh);
            this.Name = "Picture";
            this.Size = new System.Drawing.Size(50, 50);
            ((System.ComponentModel.ISupportInitialize)(this._ptbHinh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox _ptbHinh;
        private System.Windows.Forms.Button _btnClose;
    }
}
