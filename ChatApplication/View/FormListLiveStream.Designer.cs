namespace ChatApplication.View
{
    partial class FormListLiveStream
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this._btnAddFriend = new System.Windows.Forms.Button();
            this.radListView1 = new Telerik.WinControls.UI.RadListView();
            this._btnStream = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.radListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(180, 30);
            this.textBox1.TabIndex = 0;
            // 
            // _btnAddFriend
            // 
            this._btnAddFriend.FlatAppearance.BorderSize = 0;
            this._btnAddFriend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnAddFriend.Image = global::ChatApplication.Properties.Resources.findfriend;
            this._btnAddFriend.Location = new System.Drawing.Point(198, 10);
            this._btnAddFriend.Name = "_btnAddFriend";
            this._btnAddFriend.Size = new System.Drawing.Size(32, 32);
            this._btnAddFriend.TabIndex = 8;
            this._btnAddFriend.UseVisualStyleBackColor = true;
            // 
            // radListView1
            // 
            this.radListView1.Location = new System.Drawing.Point(12, 48);
            this.radListView1.Name = "radListView1";
            this.radListView1.Size = new System.Drawing.Size(249, 339);
            this.radListView1.TabIndex = 9;
            // 
            // _btnStream
            // 
            this._btnStream.FlatAppearance.BorderSize = 0;
            this._btnStream.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnStream.Image = global::ChatApplication.Properties.Resources.stream;
            this._btnStream.Location = new System.Drawing.Point(229, 10);
            this._btnStream.Name = "_btnStream";
            this._btnStream.Size = new System.Drawing.Size(32, 32);
            this._btnStream.TabIndex = 10;
            this._btnStream.UseVisualStyleBackColor = true;
            // 
            // FormListLiveStream
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(271, 399);
            this.Controls.Add(this._btnStream);
            this.Controls.Add(this.radListView1);
            this.Controls.Add(this._btnAddFriend);
            this.Controls.Add(this.textBox1);
            this.Name = "FormListLiveStream";
            this.Text = "FormListLiveStream";
            ((System.ComponentModel.ISupportInitialize)(this.radListView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button _btnAddFriend;
        private Telerik.WinControls.UI.RadListView radListView1;
        private System.Windows.Forms.Button _btnStream;
    }
}