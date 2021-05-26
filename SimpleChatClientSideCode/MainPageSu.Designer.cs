
namespace SimpleChatClientSideCode
{
    partial class MainPageSu
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
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.DBLogView = new System.Windows.Forms.DataGridView();
            this.DBLogRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DBLogView)).BeginInit();
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
            this.OnlineEmployeeListBox.Size = new System.Drawing.Size(140, 304);
            this.OnlineEmployeeListBox.TabIndex = 0;
            this.OnlineEmployeeListBox.SelectedIndexChanged += new System.EventHandler(this.OnlineEmployeeListBox_SelectedIndexChanged);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RefreshButton.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.RefreshButton.Location = new System.Drawing.Point(12, 328);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(140, 50);
            this.RefreshButton.TabIndex = 1;
            this.RefreshButton.Text = "🔁";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // MessageField
            // 
            this.MessageField.Location = new System.Drawing.Point(158, 328);
            this.MessageField.Multiline = true;
            this.MessageField.Name = "MessageField";
            this.MessageField.Size = new System.Drawing.Size(330, 50);
            this.MessageField.TabIndex = 2;
            this.MessageField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MessageField_KeyPress);
            // 
            // SendButton
            // 
            this.SendButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SendButton.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.SendButton.Location = new System.Drawing.Point(494, 328);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(84, 50);
            this.SendButton.TabIndex = 3;
            this.SendButton.Text = "⏭";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // richTextBox
            // 
            this.richTextBox.Enabled = false;
            this.richTextBox.Location = new System.Drawing.Point(158, 18);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.ReadOnly = true;
            this.richTextBox.Size = new System.Drawing.Size(420, 304);
            this.richTextBox.TabIndex = 5;
            this.richTextBox.Text = "";
            // 
            // DBLogView
            // 
            this.DBLogView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DBLogView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DBLogView.Location = new System.Drawing.Point(583, 18);
            this.DBLogView.Name = "DBLogView";
            this.DBLogView.ReadOnly = true;
            this.DBLogView.RowTemplate.Height = 25;
            this.DBLogView.Size = new System.Drawing.Size(550, 304);
            this.DBLogView.TabIndex = 6;
            // 
            // DBLogRefresh
            // 
            this.DBLogRefresh.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DBLogRefresh.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.DBLogRefresh.Location = new System.Drawing.Point(584, 328);
            this.DBLogRefresh.Name = "DBLogRefresh";
            this.DBLogRefresh.Size = new System.Drawing.Size(549, 50);
            this.DBLogRefresh.TabIndex = 7;
            this.DBLogRefresh.Text = "🔁";
            this.DBLogRefresh.UseVisualStyleBackColor = true;
            this.DBLogRefresh.Click += new System.EventHandler(this.DBLogRefresh_Click);
            // 
            // MainPageSu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1154, 393);
            this.Controls.Add(this.DBLogRefresh);
            this.Controls.Add(this.DBLogView);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.MessageField);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.OnlineEmployeeListBox);
            this.MinimumSize = new System.Drawing.Size(1170, 432);
            this.Name = "MainPageSu";
            this.Text = "SimpleChat - So Simple A Human Could Use It™";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainPage_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.DBLogView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox OnlineEmployeeListBox;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.TextBox MessageField;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.DataGridView DBLogView;
        private System.Windows.Forms.Button DBLogRefresh;
    }
}