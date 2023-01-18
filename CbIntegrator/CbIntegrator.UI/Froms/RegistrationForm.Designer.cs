namespace CbIntegrator.UI.Froms
{
    partial class RegistrationForm
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
            this.loginTb = new System.Windows.Forms.TextBox();
            this.passwordTb = new System.Windows.Forms.TextBox();
            this.RegistartionBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loginTb
            // 
            this.loginTb.Location = new System.Drawing.Point(126, 102);
            this.loginTb.Name = "loginTb";
            this.loginTb.Size = new System.Drawing.Size(209, 27);
            this.loginTb.TabIndex = 0;
            // 
            // passwordTb
            // 
            this.passwordTb.Location = new System.Drawing.Point(126, 183);
            this.passwordTb.Name = "passwordTb";
            this.passwordTb.Size = new System.Drawing.Size(209, 27);
            this.passwordTb.TabIndex = 1;
            // 
            // RegistartionBtn
            // 
            this.RegistartionBtn.Location = new System.Drawing.Point(168, 265);
            this.RegistartionBtn.Name = "RegistartionBtn";
            this.RegistartionBtn.Size = new System.Drawing.Size(123, 29);
            this.RegistartionBtn.TabIndex = 2;
            this.RegistartionBtn.Text = "Регистрация";
            this.RegistartionBtn.UseVisualStyleBackColor = true;
            this.RegistartionBtn.Click += new System.EventHandler(this.RegistartionBtn_Click);
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 407);
            this.Controls.Add(this.RegistartionBtn);
            this.Controls.Add(this.passwordTb);
            this.Controls.Add(this.loginTb);
            this.Name = "RegistrationForm";
            this.Text = "Регистрация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox loginTb;
        private TextBox passwordTb;
        private Button RegistartionBtn;
    }
}