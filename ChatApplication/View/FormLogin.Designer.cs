namespace ChatApplication.View
{
    partial class FormLogin
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
            this._panelLogin = new System.Windows.Forms.Panel();
            this._lbCreateNewAccount = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this._lbPassword = new System.Windows.Forms.Label();
            this._txtPassword = new System.Windows.Forms.TextBox();
            this._lbEmail = new System.Windows.Forms.Label();
            this._txtEmail = new System.Windows.Forms.TextBox();
            this._lbDangNhap = new System.Windows.Forms.Label();
            this._ptbSignIn = new System.Windows.Forms.PictureBox();
            this._btnClose = new System.Windows.Forms.Button();
            this._panelSignUp = new System.Windows.Forms.Panel();
            this._lbBackToLogin = new System.Windows.Forms.Label();
            this._lbConfirmPasswordSignUp = new System.Windows.Forms.Label();
            this._txtConfirmPasswordSignUp = new System.Windows.Forms.TextBox();
            this._btnCreateAccount = new System.Windows.Forms.Button();
            this._lbNameSignUp = new System.Windows.Forms.Label();
            this._txtNameSignUp = new System.Windows.Forms.TextBox();
            this._lbPasswordSignUp = new System.Windows.Forms.Label();
            this._txtPasswordSignUp = new System.Windows.Forms.TextBox();
            this._lbEmailSignUp = new System.Windows.Forms.Label();
            this._txtEmailSignUp = new System.Windows.Forms.TextBox();
            this._lbCreateAccountSignUp = new System.Windows.Forms.Label();
            this._ptbSignUp = new System.Windows.Forms.PictureBox();
            this._panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ptbSignIn)).BeginInit();
            this._panelSignUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ptbSignUp)).BeginInit();
            this.SuspendLayout();
            // 
            // _panelLogin
            // 
            this._panelLogin.BackColor = System.Drawing.Color.White;
            this._panelLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this._panelLogin.Controls.Add(this._lbCreateNewAccount);
            this._panelLogin.Controls.Add(this.button1);
            this._panelLogin.Controls.Add(this._lbPassword);
            this._panelLogin.Controls.Add(this._txtPassword);
            this._panelLogin.Controls.Add(this._lbEmail);
            this._panelLogin.Controls.Add(this._txtEmail);
            this._panelLogin.Controls.Add(this._lbDangNhap);
            this._panelLogin.Controls.Add(this._ptbSignIn);
            this._panelLogin.Location = new System.Drawing.Point(124, 75);
            this._panelLogin.Name = "_panelLogin";
            this._panelLogin.Size = new System.Drawing.Size(548, 281);
            this._panelLogin.TabIndex = 0;
            // 
            // _lbCreateNewAccount
            // 
            this._lbCreateNewAccount.AutoSize = true;
            this._lbCreateNewAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._lbCreateNewAccount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lbCreateNewAccount.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this._lbCreateNewAccount.Location = new System.Drawing.Point(247, 215);
            this._lbCreateNewAccount.Name = "_lbCreateNewAccount";
            this._lbCreateNewAccount.Size = new System.Drawing.Size(146, 21);
            this._lbCreateNewAccount.TabIndex = 7;
            this._lbCreateNewAccount.Text = "Create new account";
            this._lbCreateNewAccount.Click += new System.EventHandler(this._lbCreateNewAccount_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(408, 208);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 34);
            this.button1.TabIndex = 6;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // _lbPassword
            // 
            this._lbPassword.AutoSize = true;
            this._lbPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lbPassword.Location = new System.Drawing.Point(247, 117);
            this._lbPassword.Name = "_lbPassword";
            this._lbPassword.Size = new System.Drawing.Size(76, 21);
            this._lbPassword.TabIndex = 5;
            this._lbPassword.Text = "Password";
            // 
            // _txtPassword
            // 
            this._txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtPassword.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtPassword.Location = new System.Drawing.Point(251, 150);
            this._txtPassword.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this._txtPassword.Multiline = true;
            this._txtPassword.Name = "_txtPassword";
            this._txtPassword.Size = new System.Drawing.Size(275, 29);
            this._txtPassword.TabIndex = 4;
            // 
            // _lbEmail
            // 
            this._lbEmail.AutoSize = true;
            this._lbEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lbEmail.Location = new System.Drawing.Point(247, 45);
            this._lbEmail.Name = "_lbEmail";
            this._lbEmail.Size = new System.Drawing.Size(48, 21);
            this._lbEmail.TabIndex = 3;
            this._lbEmail.Text = "Email";
            // 
            // _txtEmail
            // 
            this._txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEmail.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtEmail.Location = new System.Drawing.Point(251, 78);
            this._txtEmail.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this._txtEmail.Multiline = true;
            this._txtEmail.Name = "_txtEmail";
            this._txtEmail.Size = new System.Drawing.Size(275, 29);
            this._txtEmail.TabIndex = 2;
            // 
            // _lbDangNhap
            // 
            this._lbDangNhap.AutoSize = true;
            this._lbDangNhap.BackColor = System.Drawing.Color.White;
            this._lbDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._lbDangNhap.Font = new System.Drawing.Font("Segoe UI Semibold", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lbDangNhap.ForeColor = System.Drawing.Color.White;
            this._lbDangNhap.Location = new System.Drawing.Point(9, 29);
            this._lbDangNhap.Name = "_lbDangNhap";
            this._lbDangNhap.Size = new System.Drawing.Size(207, 23);
            this._lbDangNhap.TabIndex = 1;
            this._lbDangNhap.Text = "Login to Chat with Friend";
            // 
            // _ptbSignIn
            // 
            this._ptbSignIn.Image = global::ChatApplication.Properties.Resources.hello;
            this._ptbSignIn.ImageLocation = "";
            this._ptbSignIn.InitialImage = null;
            this._ptbSignIn.Location = new System.Drawing.Point(0, 0);
            this._ptbSignIn.Name = "_ptbSignIn";
            this._ptbSignIn.Size = new System.Drawing.Size(223, 280);
            this._ptbSignIn.TabIndex = 0;
            this._ptbSignIn.TabStop = false;
            this._ptbSignIn.Click += new System.EventHandler(this._ptbSignIn_Click);
            // 
            // _btnClose
            // 
            this._btnClose.BackColor = System.Drawing.Color.White;
            this._btnClose.FlatAppearance.BorderSize = 0;
            this._btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnClose.Image = global::ChatApplication.Properties.Resources.exit;
            this._btnClose.Location = new System.Drawing.Point(756, 0);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(32, 32);
            this._btnClose.TabIndex = 1;
            this._btnClose.UseVisualStyleBackColor = false;
            this._btnClose.Click += new System.EventHandler(this._btnClose_Click);
            // 
            // _panelSignUp
            // 
            this._panelSignUp.BackColor = System.Drawing.Color.White;
            this._panelSignUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this._panelSignUp.Controls.Add(this._lbBackToLogin);
            this._panelSignUp.Controls.Add(this._lbConfirmPasswordSignUp);
            this._panelSignUp.Controls.Add(this._txtConfirmPasswordSignUp);
            this._panelSignUp.Controls.Add(this._btnCreateAccount);
            this._panelSignUp.Controls.Add(this._lbNameSignUp);
            this._panelSignUp.Controls.Add(this._txtNameSignUp);
            this._panelSignUp.Controls.Add(this._lbPasswordSignUp);
            this._panelSignUp.Controls.Add(this._txtPasswordSignUp);
            this._panelSignUp.Controls.Add(this._lbEmailSignUp);
            this._panelSignUp.Controls.Add(this._txtEmailSignUp);
            this._panelSignUp.Controls.Add(this._lbCreateAccountSignUp);
            this._panelSignUp.Controls.Add(this._ptbSignUp);
            this._panelSignUp.Location = new System.Drawing.Point(124, 51);
            this._panelSignUp.Name = "_panelSignUp";
            this._panelSignUp.Size = new System.Drawing.Size(548, 342);
            this._panelSignUp.TabIndex = 2;
            this._panelSignUp.Visible = false;
            // 
            // _lbBackToLogin
            // 
            this._lbBackToLogin.AutoSize = true;
            this._lbBackToLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._lbBackToLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lbBackToLogin.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this._lbBackToLogin.Location = new System.Drawing.Point(172, 302);
            this._lbBackToLogin.Name = "_lbBackToLogin";
            this._lbBackToLogin.Size = new System.Drawing.Size(103, 21);
            this._lbBackToLogin.TabIndex = 7;
            this._lbBackToLogin.Text = "Back to Login";
            this._lbBackToLogin.Click += new System.EventHandler(this._lbBackToLogin_Click);
            // 
            // _lbConfirmPasswordSignUp
            // 
            this._lbConfirmPasswordSignUp.AutoSize = true;
            this._lbConfirmPasswordSignUp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lbConfirmPasswordSignUp.Location = new System.Drawing.Point(12, 220);
            this._lbConfirmPasswordSignUp.Name = "_lbConfirmPasswordSignUp";
            this._lbConfirmPasswordSignUp.Size = new System.Drawing.Size(137, 21);
            this._lbConfirmPasswordSignUp.TabIndex = 9;
            this._lbConfirmPasswordSignUp.Text = "Confirm Password";
            // 
            // _txtConfirmPasswordSignUp
            // 
            this._txtConfirmPasswordSignUp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtConfirmPasswordSignUp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtConfirmPasswordSignUp.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtConfirmPasswordSignUp.Location = new System.Drawing.Point(16, 253);
            this._txtConfirmPasswordSignUp.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this._txtConfirmPasswordSignUp.Multiline = true;
            this._txtConfirmPasswordSignUp.Name = "_txtConfirmPasswordSignUp";
            this._txtConfirmPasswordSignUp.Size = new System.Drawing.Size(275, 29);
            this._txtConfirmPasswordSignUp.TabIndex = 8;
            // 
            // _btnCreateAccount
            // 
            this._btnCreateAccount.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this._btnCreateAccount.FlatAppearance.BorderSize = 0;
            this._btnCreateAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnCreateAccount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnCreateAccount.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this._btnCreateAccount.Location = new System.Drawing.Point(16, 295);
            this._btnCreateAccount.Name = "_btnCreateAccount";
            this._btnCreateAccount.Size = new System.Drawing.Size(123, 34);
            this._btnCreateAccount.TabIndex = 6;
            this._btnCreateAccount.Text = "Create";
            this._btnCreateAccount.UseVisualStyleBackColor = false;
            // 
            // _lbNameSignUp
            // 
            this._lbNameSignUp.AutoSize = true;
            this._lbNameSignUp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lbNameSignUp.Location = new System.Drawing.Point(12, 75);
            this._lbNameSignUp.Name = "_lbNameSignUp";
            this._lbNameSignUp.Size = new System.Drawing.Size(52, 21);
            this._lbNameSignUp.TabIndex = 7;
            this._lbNameSignUp.Text = "Name";
            // 
            // _txtNameSignUp
            // 
            this._txtNameSignUp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtNameSignUp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtNameSignUp.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtNameSignUp.Location = new System.Drawing.Point(16, 108);
            this._txtNameSignUp.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this._txtNameSignUp.Multiline = true;
            this._txtNameSignUp.Name = "_txtNameSignUp";
            this._txtNameSignUp.Size = new System.Drawing.Size(275, 29);
            this._txtNameSignUp.TabIndex = 6;
            // 
            // _lbPasswordSignUp
            // 
            this._lbPasswordSignUp.AutoSize = true;
            this._lbPasswordSignUp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lbPasswordSignUp.Location = new System.Drawing.Point(12, 146);
            this._lbPasswordSignUp.Name = "_lbPasswordSignUp";
            this._lbPasswordSignUp.Size = new System.Drawing.Size(76, 21);
            this._lbPasswordSignUp.TabIndex = 5;
            this._lbPasswordSignUp.Text = "Password";
            // 
            // _txtPasswordSignUp
            // 
            this._txtPasswordSignUp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtPasswordSignUp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtPasswordSignUp.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtPasswordSignUp.Location = new System.Drawing.Point(16, 179);
            this._txtPasswordSignUp.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this._txtPasswordSignUp.Multiline = true;
            this._txtPasswordSignUp.Name = "_txtPasswordSignUp";
            this._txtPasswordSignUp.Size = new System.Drawing.Size(275, 29);
            this._txtPasswordSignUp.TabIndex = 4;
            // 
            // _lbEmailSignUp
            // 
            this._lbEmailSignUp.AutoSize = true;
            this._lbEmailSignUp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lbEmailSignUp.Location = new System.Drawing.Point(12, 9);
            this._lbEmailSignUp.Name = "_lbEmailSignUp";
            this._lbEmailSignUp.Size = new System.Drawing.Size(48, 21);
            this._lbEmailSignUp.TabIndex = 3;
            this._lbEmailSignUp.Text = "Email";
            // 
            // _txtEmailSignUp
            // 
            this._txtEmailSignUp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtEmailSignUp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEmailSignUp.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtEmailSignUp.Location = new System.Drawing.Point(16, 42);
            this._txtEmailSignUp.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this._txtEmailSignUp.Multiline = true;
            this._txtEmailSignUp.Name = "_txtEmailSignUp";
            this._txtEmailSignUp.Size = new System.Drawing.Size(275, 29);
            this._txtEmailSignUp.TabIndex = 2;
            // 
            // _lbCreateAccountSignUp
            // 
            this._lbCreateAccountSignUp.AutoSize = true;
            this._lbCreateAccountSignUp.BackColor = System.Drawing.Color.White;
            this._lbCreateAccountSignUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._lbCreateAccountSignUp.Font = new System.Drawing.Font("Segoe UI Semibold", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lbCreateAccountSignUp.ForeColor = System.Drawing.Color.White;
            this._lbCreateAccountSignUp.Location = new System.Drawing.Point(363, 25);
            this._lbCreateAccountSignUp.Name = "_lbCreateAccountSignUp";
            this._lbCreateAccountSignUp.Size = new System.Drawing.Size(160, 46);
            this._lbCreateAccountSignUp.TabIndex = 1;
            this._lbCreateAccountSignUp.Text = "  Create Account\r\nto Chat with Friend";
            // 
            // _ptbSignUp
            // 
            this._ptbSignUp.Image = global::ChatApplication.Properties.Resources.createAccount;
            this._ptbSignUp.ImageLocation = "";
            this._ptbSignUp.InitialImage = null;
            this._ptbSignUp.Location = new System.Drawing.Point(324, 0);
            this._ptbSignUp.Name = "_ptbSignUp";
            this._ptbSignUp.Size = new System.Drawing.Size(223, 342);
            this._ptbSignUp.TabIndex = 0;
            this._ptbSignUp.TabStop = false;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.BackgroundImage = global::ChatApplication.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(788, 450);
            this.Controls.Add(this._panelSignUp);
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this._panelLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormLogin";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormLogin_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormLogin_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormLogin_MouseUp);
            this._panelLogin.ResumeLayout(false);
            this._panelLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ptbSignIn)).EndInit();
            this._panelSignUp.ResumeLayout(false);
            this._panelSignUp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ptbSignUp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _panelLogin;
        private System.Windows.Forms.Label _lbDangNhap;
        private System.Windows.Forms.TextBox _txtEmail;
        private System.Windows.Forms.Label _lbPassword;
        private System.Windows.Forms.TextBox _txtPassword;
        private System.Windows.Forms.Label _lbEmail;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button _btnClose;
        private System.Windows.Forms.Label _lbCreateNewAccount;
        private System.Windows.Forms.PictureBox _ptbSignIn;
        private System.Windows.Forms.Panel _panelSignUp;
        private System.Windows.Forms.Label _lbBackToLogin;
        private System.Windows.Forms.Label _lbConfirmPasswordSignUp;
        private System.Windows.Forms.TextBox _txtConfirmPasswordSignUp;
        private System.Windows.Forms.Button _btnCreateAccount;
        private System.Windows.Forms.Label _lbNameSignUp;
        private System.Windows.Forms.TextBox _txtNameSignUp;
        private System.Windows.Forms.Label _lbPasswordSignUp;
        private System.Windows.Forms.TextBox _txtPasswordSignUp;
        private System.Windows.Forms.Label _lbEmailSignUp;
        private System.Windows.Forms.TextBox _txtEmailSignUp;
        private System.Windows.Forms.Label _lbCreateAccountSignUp;
        private System.Windows.Forms.PictureBox _ptbSignUp;
    }
}