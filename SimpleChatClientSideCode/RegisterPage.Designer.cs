
namespace SimpleChatClientSideCode
{
    partial class RegisterPage
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
            this.IdentityNumberLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.VerifyLabel = new System.Windows.Forms.Label();
            this.IdentityNumberTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.VerifyTextBox = new System.Windows.Forms.TextBox();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // IdentityNumberLabel
            // 
            this.IdentityNumberLabel.AutoSize = true;
            this.IdentityNumberLabel.Location = new System.Drawing.Point(11, 49);
            this.IdentityNumberLabel.Name = "IdentityNumberLabel";
            this.IdentityNumberLabel.Size = new System.Drawing.Size(97, 15);
            this.IdentityNumberLabel.TabIndex = 8;
            this.IdentityNumberLabel.Text = "Identity Number:";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(48, 78);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(60, 15);
            this.PasswordLabel.TabIndex = 1;
            this.PasswordLabel.Text = "Password:";
            // 
            // VerifyLabel
            // 
            this.VerifyLabel.AutoSize = true;
            this.VerifyLabel.Location = new System.Drawing.Point(16, 108);
            this.VerifyLabel.Name = "VerifyLabel";
            this.VerifyLabel.Size = new System.Drawing.Size(92, 15);
            this.VerifyLabel.TabIndex = 2;
            this.VerifyLabel.Text = "Verify Password:";
            // 
            // IdentityNumberTextBox
            // 
            this.IdentityNumberTextBox.Location = new System.Drawing.Point(114, 46);
            this.IdentityNumberTextBox.Name = "IdentityNumberTextBox";
            this.IdentityNumberTextBox.Size = new System.Drawing.Size(229, 23);
            this.IdentityNumberTextBox.TabIndex = 3;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(114, 75);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(229, 23);
            this.PasswordTextBox.TabIndex = 4;
            // 
            // VerifyTextBox
            // 
            this.VerifyTextBox.Location = new System.Drawing.Point(114, 105);
            this.VerifyTextBox.Name = "VerifyTextBox";
            this.VerifyTextBox.PasswordChar = '*';
            this.VerifyTextBox.Size = new System.Drawing.Size(229, 23);
            this.VerifyTextBox.TabIndex = 5;
            // 
            // RegisterButton
            // 
            this.RegisterButton.Location = new System.Drawing.Point(16, 144);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(327, 38);
            this.RegisterButton.TabIndex = 6;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Location = new System.Drawing.Point(114, 17);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(229, 23);
            this.EmailTextBox.TabIndex = 0;
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(69, 20);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(39, 15);
            this.EmailLabel.TabIndex = 7;
            this.EmailLabel.Text = "Email:";
            // 
            // RegisterPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 201);
            this.Controls.Add(this.EmailTextBox);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.VerifyTextBox);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.IdentityNumberTextBox);
            this.Controls.Add(this.VerifyLabel);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.IdentityNumberLabel);
            this.Name = "RegisterPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegisterPage";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RegisterPage_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label IdentityNumberLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label VerifyLabel;
        private System.Windows.Forms.TextBox IdentityNumberTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.TextBox VerifyTextBox;
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.Label EmailLabel;
    }
}