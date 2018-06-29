namespace ChatApplication.View
{
    partial class FormFindFriends
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFindFriends));
            this._txtSearch = new System.Windows.Forms.TextBox();
            this._btnSearch = new System.Windows.Forms.Button();
            this._radLVSearchResult = new Telerik.WinControls.UI.RadListView();
            ((System.ComponentModel.ISupportInitialize)(this._radLVSearchResult)).BeginInit();
            this.SuspendLayout();
            // 
            // _txtSearch
            // 
            this._txtSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtSearch.Location = new System.Drawing.Point(12, 12);
            this._txtSearch.Multiline = true;
            this._txtSearch.Name = "_txtSearch";
            this._txtSearch.Size = new System.Drawing.Size(186, 30);
            this._txtSearch.TabIndex = 0;
            // 
            // _btnSearch
            // 
            this._btnSearch.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this._btnSearch.FlatAppearance.BorderSize = 0;
            this._btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnSearch.Location = new System.Drawing.Point(204, 12);
            this._btnSearch.Name = "_btnSearch";
            this._btnSearch.Size = new System.Drawing.Size(74, 30);
            this._btnSearch.TabIndex = 1;
            this._btnSearch.Text = "Search";
            this._btnSearch.UseVisualStyleBackColor = false;
            this._btnSearch.Click += new System.EventHandler(this._btnSearch_Click);
            // 
            // _radLVSearchResult
            // 
            this._radLVSearchResult.Location = new System.Drawing.Point(12, 48);
            this._radLVSearchResult.Name = "_radLVSearchResult";
            this._radLVSearchResult.Size = new System.Drawing.Size(266, 351);
            this._radLVSearchResult.TabIndex = 2;
            // 
            // FormFindFriends
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 411);
            this.Controls.Add(this._radLVSearchResult);
            this.Controls.Add(this._btnSearch);
            this.Controls.Add(this._txtSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormFindFriends";
            this.Text = "Tìm bạn bè";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormFindFriends_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this._radLVSearchResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _txtSearch;
        private System.Windows.Forms.Button _btnSearch;
        private Telerik.WinControls.UI.RadListView _radLVSearchResult;
    }
}