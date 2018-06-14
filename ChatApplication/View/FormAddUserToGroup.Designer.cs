namespace ChatApplication.View
{
    partial class FormAddUserToGroup
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
            this._radListFriendToAddToGroup = new Telerik.WinControls.UI.RadListView();
            this._btnOK = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this._radListFriendToAddToGroup)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _radListFriendToAddToGroup
            // 
            this._radListFriendToAddToGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this._radListFriendToAddToGroup.Location = new System.Drawing.Point(0, 0);
            this._radListFriendToAddToGroup.Name = "_radListFriendToAddToGroup";
            this._radListFriendToAddToGroup.Size = new System.Drawing.Size(200, 288);
            this._radListFriendToAddToGroup.TabIndex = 0;
            // 
            // _btnOK
            // 
            this._btnOK.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this._btnOK.FlatAppearance.BorderSize = 0;
            this._btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnOK.Location = new System.Drawing.Point(116, 297);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(75, 23);
            this._btnOK.TabIndex = 0;
            this._btnOK.Text = "OK";
            this._btnOK.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._radListFriendToAddToGroup);
            this.panel1.Location = new System.Drawing.Point(1, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 288);
            this.panel1.TabIndex = 0;
            // 
            // FormAddUserToGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(203, 332);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._btnOK);
            this.Name = "FormAddUserToGroup";
            this.Text = "FormAddUserToGroup";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormAddUserToGroup_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this._radListFriendToAddToGroup)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadListView _radListFriendToAddToGroup;
        private System.Windows.Forms.Button _btnOK;
        private System.Windows.Forms.Panel panel1;
    }
}