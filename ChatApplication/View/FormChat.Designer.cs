namespace ChatApplication
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this._btnClose = new System.Windows.Forms.Button();
            this.chatLogControl1 = new FormChung.ChatLogControl();
            this.SuspendLayout();
            // 
            // _btnClose
            // 
            resources.ApplyResources(this._btnClose, "_btnClose");
            this._btnClose.ForeColor = System.Drawing.Color.LightGray;
            this._btnClose.Image = global::ChatApplication.Properties.Resources.exit;
            this._btnClose.Name = "_btnClose";
            this._btnClose.UseVisualStyleBackColor = true;
            this._btnClose.Click += new System.EventHandler(this._btnClose_Click);
            // 
            // chatLogControl1
            // 
            this.chatLogControl1.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.chatLogControl1, "chatLogControl1");
            this.chatLogControl1.Name = "chatLogControl1";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this.chatLogControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private FormChung.ChatLogControl chatLogControl1;
        private System.Windows.Forms.Button _btnClose;
    }
}

