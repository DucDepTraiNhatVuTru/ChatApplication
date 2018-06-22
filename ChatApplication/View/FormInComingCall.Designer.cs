namespace ChatApplication.View
{
    partial class FormInComingCall
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
            this.radWaitingBar1 = new Telerik.WinControls.UI.RadWaitingBar();
            this.dotsLineWaitingBarIndicatorElement1 = new Telerik.WinControls.UI.DotsLineWaitingBarIndicatorElement();
            this._lbCaller = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this._btnPickUp = new System.Windows.Forms.Button();
            this._btnTuChoi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // radWaitingBar1
            // 
            this.radWaitingBar1.Location = new System.Drawing.Point(94, 12);
            this.radWaitingBar1.Name = "radWaitingBar1";
            this.radWaitingBar1.Size = new System.Drawing.Size(67, 24);
            this.radWaitingBar1.TabIndex = 0;
            this.radWaitingBar1.Text = "radWaitingBar1";
            this.radWaitingBar1.WaitingIndicators.Add(this.dotsLineWaitingBarIndicatorElement1);
            this.radWaitingBar1.WaitingSpeed = 80;
            this.radWaitingBar1.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.DotsLine;
            ((Telerik.WinControls.UI.RadWaitingBarElement)(this.radWaitingBar1.GetChildAt(0))).WaitingSpeed = 80;
            ((Telerik.WinControls.UI.WaitingBarSeparatorElement)(this.radWaitingBar1.GetChildAt(0).GetChildAt(0).GetChildAt(0))).Dash = false;
            // 
            // dotsLineWaitingBarIndicatorElement1
            // 
            this.dotsLineWaitingBarIndicatorElement1.Name = "dotsLineWaitingBarIndicatorElement1";
            // 
            // _lbCaller
            // 
            this._lbCaller.AutoSize = true;
            this._lbCaller.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lbCaller.Location = new System.Drawing.Point(167, 11);
            this._lbCaller.Name = "_lbCaller";
            this._lbCaller.Size = new System.Drawing.Size(63, 25);
            this._lbCaller.TabIndex = 0;
            this._lbCaller.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ChatApplication.Properties.Resources.callling;
            this.pictureBox1.Location = new System.Drawing.Point(61, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // _btnPickUp
            // 
            this._btnPickUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this._btnPickUp.FlatAppearance.BorderSize = 0;
            this._btnPickUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnPickUp.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnPickUp.ForeColor = System.Drawing.Color.White;
            this._btnPickUp.Location = new System.Drawing.Point(61, 62);
            this._btnPickUp.Name = "_btnPickUp";
            this._btnPickUp.Size = new System.Drawing.Size(104, 24);
            this._btnPickUp.TabIndex = 2;
            this._btnPickUp.Text = "Chấp nhận";
            this._btnPickUp.UseVisualStyleBackColor = false;
            this._btnPickUp.Click += new System.EventHandler(this._btnPickUp_Click);
            // 
            // _btnTuChoi
            // 
            this._btnTuChoi.BackColor = System.Drawing.Color.Red;
            this._btnTuChoi.FlatAppearance.BorderSize = 0;
            this._btnTuChoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnTuChoi.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnTuChoi.ForeColor = System.Drawing.Color.White;
            this._btnTuChoi.Location = new System.Drawing.Point(259, 62);
            this._btnTuChoi.Name = "_btnTuChoi";
            this._btnTuChoi.Size = new System.Drawing.Size(104, 24);
            this._btnTuChoi.TabIndex = 3;
            this._btnTuChoi.Text = "Từ chối";
            this._btnTuChoi.UseVisualStyleBackColor = false;
            // 
            // FormInComingCall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(447, 98);
            this.Controls.Add(this._btnTuChoi);
            this.Controls.Add(this._btnPickUp);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this._lbCaller);
            this.Controls.Add(this.radWaitingBar1);
            this.Name = "FormInComingCall";
            this.Text = "Cuộc gọi đến";
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadWaitingBar radWaitingBar1;
        private Telerik.WinControls.UI.DotsLineWaitingBarIndicatorElement dotsLineWaitingBarIndicatorElement1;
        private System.Windows.Forms.Label _lbCaller;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button _btnPickUp;
        private System.Windows.Forms.Button _btnTuChoi;
    }
}