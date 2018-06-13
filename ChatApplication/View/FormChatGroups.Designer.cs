﻿namespace ChatApplication.View
{
    partial class FormChatGroups
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
            this._radchatChatGroup = new Telerik.WinControls.UI.RadChat();
            this._radLVListFriendInGroup = new Telerik.WinControls.UI.RadListView();
            this._lbGroupName = new System.Windows.Forms.Label();
            this._btnAddUserToGroup = new System.Windows.Forms.Button();
            this._btnOutOfGroup = new System.Windows.Forms.Button();
            this.dotsRingWaitingBarIndicatorElement1 = new Telerik.WinControls.UI.DotsRingWaitingBarIndicatorElement();
            ((System.ComponentModel.ISupportInitialize)(this._radchatChatGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._radLVListFriendInGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // _radchatChatGroup
            // 
            this._radchatChatGroup.Location = new System.Drawing.Point(1, 1);
            this._radchatChatGroup.Name = "_radchatChatGroup";
            this._radchatChatGroup.Size = new System.Drawing.Size(562, 393);
            this._radchatChatGroup.TabIndex = 0;
            this._radchatChatGroup.Text = "radChat1";
            this._radchatChatGroup.TimeSeparatorInterval = System.TimeSpan.Parse("1.00:00:00");
            // 
            // _radLVListFriendInGroup
            // 
            this._radLVListFriendInGroup.Location = new System.Drawing.Point(569, 43);
            this._radLVListFriendInGroup.Name = "_radLVListFriendInGroup";
            this._radLVListFriendInGroup.Size = new System.Drawing.Size(154, 252);
            this._radLVListFriendInGroup.TabIndex = 1;
            // 
            // _lbGroupName
            // 
            this._lbGroupName.AutoSize = true;
            this._lbGroupName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lbGroupName.Location = new System.Drawing.Point(569, 9);
            this._lbGroupName.Name = "_lbGroupName";
            this._lbGroupName.Size = new System.Drawing.Size(52, 21);
            this._lbGroupName.TabIndex = 0;
            this._lbGroupName.Text = "label1";
            // 
            // _btnAddUserToGroup
            // 
            this._btnAddUserToGroup.BackColor = System.Drawing.Color.PowderBlue;
            this._btnAddUserToGroup.FlatAppearance.BorderSize = 0;
            this._btnAddUserToGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnAddUserToGroup.Location = new System.Drawing.Point(569, 301);
            this._btnAddUserToGroup.Name = "_btnAddUserToGroup";
            this._btnAddUserToGroup.Size = new System.Drawing.Size(69, 27);
            this._btnAddUserToGroup.TabIndex = 2;
            this._btnAddUserToGroup.Text = "Add";
            this._btnAddUserToGroup.UseVisualStyleBackColor = false;
            // 
            // _btnOutOfGroup
            // 
            this._btnOutOfGroup.BackColor = System.Drawing.Color.PowderBlue;
            this._btnOutOfGroup.FlatAppearance.BorderSize = 0;
            this._btnOutOfGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnOutOfGroup.Location = new System.Drawing.Point(644, 301);
            this._btnOutOfGroup.Name = "_btnOutOfGroup";
            this._btnOutOfGroup.Size = new System.Drawing.Size(79, 27);
            this._btnOutOfGroup.TabIndex = 3;
            this._btnOutOfGroup.Text = "Out";
            this._btnOutOfGroup.UseVisualStyleBackColor = false;
            // 
            // dotsRingWaitingBarIndicatorElement1
            // 
            this.dotsRingWaitingBarIndicatorElement1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.dotsRingWaitingBarIndicatorElement1.Name = "dotsRingWaitingBarIndicatorElement1";
            this.dotsRingWaitingBarIndicatorElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.dotsRingWaitingBarIndicatorElement1.UseCompatibleTextRendering = false;
            // 
            // FormChatGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 394);
            this.Controls.Add(this._btnOutOfGroup);
            this.Controls.Add(this._btnAddUserToGroup);
            this.Controls.Add(this._lbGroupName);
            this.Controls.Add(this._radLVListFriendInGroup);
            this.Controls.Add(this._radchatChatGroup);
            this.Name = "FormChatGroups";
            this.Text = "FormChatGroups";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormChatGroups_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this._radchatChatGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._radLVListFriendInGroup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadChat _radchatChatGroup;
        private Telerik.WinControls.UI.RadListView _radLVListFriendInGroup;
        private System.Windows.Forms.Label _lbGroupName;
        private System.Windows.Forms.Button _btnAddUserToGroup;
        private System.Windows.Forms.Button _btnOutOfGroup;
        private Telerik.WinControls.UI.DotsRingWaitingBarIndicatorElement dotsRingWaitingBarIndicatorElement1;
    }
}