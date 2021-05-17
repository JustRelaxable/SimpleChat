
namespace SimpleChatClientSideCode
{
    partial class MainPage
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
            this.OnlineEmployeeListBox = new System.Windows.Forms.ListBox();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.MessageField = new System.Windows.Forms.TextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.MessagesTextBox = new System.Windows.Forms.TextBox();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // OnlineEmployeeListBox
            // 
            this.OnlineEmployeeListBox.FormattingEnabled = true;
            this.OnlineEmployeeListBox.ItemHeight = 15;
            this.OnlineEmployeeListBox.Items.AddRange(new object[] {
            ""});
            this.OnlineEmployeeListBox.Location = new System.Drawing.Point(12, 18);
            this.OnlineEmployeeListBox.Name = "OnlineEmployeeListBox";
            this.OnlineEmployeeListBox.Size = new System.Drawing.Size(185, 364);
            this.OnlineEmployeeListBox.TabIndex = 0;
            this.OnlineEmployeeListBox.SelectedIndexChanged += new System.EventHandler(this.OnlineEmployeeListBox_SelectedIndexChanged);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(12, 388);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(185, 50);
            this.RefreshButton.TabIndex = 1;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // MessageField
            // 
            this.MessageField.Location = new System.Drawing.Point(204, 388);
            this.MessageField.Multiline = true;
            this.MessageField.Name = "MessageField";
            this.MessageField.Size = new System.Drawing.Size(449, 50);
            this.MessageField.TabIndex = 2;
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(659, 388);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(129, 50);
            this.SendButton.TabIndex = 3;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // MessagesTextBox
            // 
            this.MessagesTextBox.Enabled = false;
            this.MessagesTextBox.Location = new System.Drawing.Point(204, 18);
            this.MessagesTextBox.Multiline = true;
            this.MessagesTextBox.Name = "MessagesTextBox";
            this.MessagesTextBox.ReadOnly = true;
            this.MessagesTextBox.Size = new System.Drawing.Size(584, 97);
            this.MessagesTextBox.TabIndex = 4;
            // 
            // richTextBox
            // 
            this.richTextBox.Enabled = false;
            this.richTextBox.Location = new System.Drawing.Point(203, 121);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.ReadOnly = true;
            this.richTextBox.Size = new System.Drawing.Size(585, 261);
            this.richTextBox.TabIndex = 5;
            this.richTextBox.Text = "";
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.MessagesTextBox);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.MessageField);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.OnlineEmployeeListBox);
            this.Name = "MainPage";
            this.Text = "MainPage";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainPage_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox OnlineEmployeeListBox;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.TextBox MessageField;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.TextBox MessagesTextBox;
        private System.Windows.Forms.RichTextBox richTextBox;
    }
}