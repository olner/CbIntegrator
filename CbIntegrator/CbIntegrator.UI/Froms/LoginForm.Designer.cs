namespace CbIntegrator.UI.Froms
{
	partial class LoginForm
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
            this.LoginBtn = new System.Windows.Forms.Button();
            this.loginTb = new System.Windows.Forms.TextBox();
            this.passwordTb = new System.Windows.Forms.TextBox();
            this.registrationLkLbl = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // LoginBtn
            // 
            this.LoginBtn.Location = new System.Drawing.Point(276, 329);
            this.LoginBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(86, 31);
            this.LoginBtn.TabIndex = 0;
            this.LoginBtn.Text = "Login";
            this.LoginBtn.UseVisualStyleBackColor = true;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // loginTb
            // 
            this.loginTb.Location = new System.Drawing.Point(213, 182);
            this.loginTb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.loginTb.Name = "loginTb";
            this.loginTb.Size = new System.Drawing.Size(234, 27);
            this.loginTb.TabIndex = 1;
            // 
            // passwordTb
            // 
            this.passwordTb.Location = new System.Drawing.Point(213, 251);
            this.passwordTb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.passwordTb.Name = "passwordTb";
            this.passwordTb.PasswordChar = '*';
            this.passwordTb.Size = new System.Drawing.Size(234, 27);
            this.passwordTb.TabIndex = 2;
            // 
            // registrationLkLbl
            // 
            this.registrationLkLbl.AutoSize = true;
            this.registrationLkLbl.Location = new System.Drawing.Point(213, 397);
            this.registrationLkLbl.Name = "registrationLkLbl";
            this.registrationLkLbl.Size = new System.Drawing.Size(244, 20);
            this.registrationLkLbl.TabIndex = 3;
            this.registrationLkLbl.TabStop = true;
            this.registrationLkLbl.Text = "Нет аккаунта? Зарегестрируйтесь.";
            this.registrationLkLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.registrationLkLbl_LinkClicked);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 473);
            this.Controls.Add(this.registrationLkLbl);
            this.Controls.Add(this.passwordTb);
            this.Controls.Add(this.loginTb);
            this.Controls.Add(this.LoginBtn);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LoginForm";
            this.Text = "Вход";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Button LoginBtn;
		private TextBox loginTb;
		private TextBox passwordTb;
        private LinkLabel registrationLkLbl;
    }
}