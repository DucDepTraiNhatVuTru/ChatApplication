namespace ChatApplication.View
{
    partial class FormCreateGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCreateGroup));
            this._txtGroupName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._radLVFriends = new Telerik.WinControls.UI.RadListView();
            this._btnCreateGroup = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._radLVFriends)).BeginInit();
            this.SuspendLayout();
            // 
            // _txtGroupName
            // 
            this._txtGroupName.BackColor = System.Drawing.Color.White;
            this._txtGroupName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtGroupName.Location = new System.Drawing.Point(12, 33);
            this._txtGroupName.Name = "_txtGroupName";
            this._txtGroupName.Size = new System.Drawing.Size(266, 29);
            this._txtGroupName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Đặt tên cho nhóm chat của bạn";
            // 
            // _radLVFriends
            // 
            this._radLVFriends.Location = new System.Drawing.Point(12, 114);
            this._radLVFriends.Name = "_radLVFriends";
            this._radLVFriends.Size = new System.Drawing.Size(266, 251);
            this._radLVFriends.TabIndex = 2;
            // 
            // _btnCreateGroup
            // 
            this._btnCreateGroup.BackColor = System.Drawing.Color.SkyBlue;
            this._btnCreateGroup.FlatAppearance.BorderSize = 0;
            this._btnCreateGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnCreateGroup.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnCreateGroup.Location = new System.Drawing.Point(139, 371);
            this._btnCreateGroup.Name = "_btnCreateGroup";
            this._btnCreateGroup.Size = new System.Drawing.Size(139, 28);
            this._btnCreateGroup.TabIndex = 3;
            this._btnCreateGroup.Text = "Tạo Nhóm Chat";
            this._btnCreateGroup.UseVisualStyleBackColor = false;
            this._btnCreateGroup.Click += new System.EventHandler(this._btnCreateGroup_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Thêm thành viên vào nhóm";
            // 
            // FormCreateGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(290, 411);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._btnCreateGroup);
            this.Controls.Add(this._radLVFriends);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._txtGroupName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCreateGroup";
            this.Text = "Tạo cuộc trò chuyện nhóm";
            this.Load += new System.EventHandler(this.FormCreateGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this._radLVFriends)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _txtGroupName;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadListView _radLVFriends;
        private System.Windows.Forms.Button _btnCreateGroup;
        private System.Windows.Forms.Label label2;
    }
}