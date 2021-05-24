
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
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.VerifyLabel = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.VerifyTextBox = new System.Windows.Forms.TextBox();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(48, 49);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(60, 15);
            this.PasswordLabel.TabIndex = 1;
            this.PasswordLabel.Text = "Password:";
            // 
            // VerifyLabel
            // 
            this.VerifyLabel.AutoSize = true;
            this.VerifyLabel.Location = new System.Drawing.Point(16, 78);
            this.VerifyLabel.Name = "VerifyLabel";
            this.VerifyLabel.Size = new System.Drawing.Size(92, 15);
            this.VerifyLabel.TabIndex = 2;
            this.VerifyLabel.Text = "Verify Password:";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(114, 46);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(229, 23);
            this.PasswordTextBox.TabIndex = 4;
            // 
            // VerifyTextBox
            // 
            this.VerifyTextBox.Location = new System.Drawing.Point(114, 75);
            this.VerifyTextBox.Name = "VerifyTextBox";
            this.VerifyTextBox.PasswordChar = '*';
            this.VerifyTextBox.Size = new System.Drawing.Size(229, 23);
            this.VerifyTextBox.TabIndex = 5;
            // 
            // RegisterButton
            // 
            this.RegisterButton.Location = new System.Drawing.Point(69, 122);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(229, 38);
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
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(364, 172);
            this.Controls.Add(this.EmailTextBox);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.VerifyTextBox);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.VerifyLabel);
            this.Controls.Add(this.PasswordLabel);
            this.Name = "RegisterPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SimpleChat - Register";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RegisterPage_FormClosed);
            //this.Load += new System.EventHandler(this.RegisterPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label VerifyLabel;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.TextBox VerifyTextBox;
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.Label EmailLabel;
    }
}