namespace budget_management_app
{
    partial class EditAccountForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditAccountForm));
            this.accountNameLabel = new System.Windows.Forms.Label();
            this.backButton = new Guna.UI2.WinForms.Guna2Button();
            this.currencyLabel = new System.Windows.Forms.Label();
            this.startBalanceTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.accountNameTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.accountCurrencyComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.updateButton = new Guna.UI2.WinForms.Guna2Button();
            this.deleteButton = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // accountNameLabel
            // 
            this.accountNameLabel.AutoSize = true;
            this.accountNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.accountNameLabel.Font = new System.Drawing.Font("Segoe UI Variable Display", 17.75F, System.Drawing.FontStyle.Bold);
            this.accountNameLabel.ForeColor = System.Drawing.Color.White;
            this.accountNameLabel.Location = new System.Drawing.Point(207, 12);
            this.accountNameLabel.Name = "accountNameLabel";
            this.accountNameLabel.Size = new System.Drawing.Size(167, 32);
            this.accountNameLabel.TabIndex = 79;
            this.accountNameLabel.Text = "New Account";
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.Transparent;
            this.backButton.BorderColor = System.Drawing.Color.Transparent;
            this.backButton.CheckedState.BorderColor = System.Drawing.Color.Transparent;
            this.backButton.CheckedState.FillColor = System.Drawing.Color.Transparent;
            this.backButton.DisabledState.BorderColor = System.Drawing.Color.Transparent;
            this.backButton.DisabledState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.backButton.DisabledState.FillColor = System.Drawing.Color.Transparent;
            this.backButton.DisabledState.ForeColor = System.Drawing.Color.Transparent;
            this.backButton.FillColor = System.Drawing.Color.Transparent;
            this.backButton.FocusedColor = System.Drawing.Color.Transparent;
            this.backButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.backButton.ForeColor = System.Drawing.Color.White;
            this.backButton.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.backButton.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.backButton.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.backButton.Image = ((System.Drawing.Image)(resources.GetObject("backButton.Image")));
            this.backButton.ImageSize = new System.Drawing.Size(50, 50);
            this.backButton.Location = new System.Drawing.Point(0, 0);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(58, 56);
            this.backButton.TabIndex = 80;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // currencyLabel
            // 
            this.currencyLabel.AutoSize = true;
            this.currencyLabel.Font = new System.Drawing.Font("Segoe UI Variable Small", 20.75F);
            this.currencyLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(151)))), ((int)(((byte)(161)))));
            this.currencyLabel.Location = new System.Drawing.Point(438, 437);
            this.currencyLabel.Name = "currencyLabel";
            this.currencyLabel.Size = new System.Drawing.Size(72, 37);
            this.currencyLabel.TabIndex = 83;
            this.currencyLabel.Text = "USD";
            // 
            // startBalanceTextBox
            // 
            this.startBalanceTextBox.BackColor = System.Drawing.Color.Transparent;
            this.startBalanceTextBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(151)))), ((int)(((byte)(161)))));
            this.startBalanceTextBox.BorderRadius = 20;
            this.startBalanceTextBox.BorderThickness = 2;
            this.startBalanceTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.startBalanceTextBox.DefaultText = "0,00";
            this.startBalanceTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.startBalanceTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.startBalanceTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.startBalanceTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.startBalanceTextBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.startBalanceTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.startBalanceTextBox.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 18.75F, System.Drawing.FontStyle.Bold);
            this.startBalanceTextBox.ForeColor = System.Drawing.Color.White;
            this.startBalanceTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.startBalanceTextBox.HoverState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.startBalanceTextBox.Location = new System.Drawing.Point(47, 420);
            this.startBalanceTextBox.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.startBalanceTextBox.Name = "startBalanceTextBox";
            this.startBalanceTextBox.PasswordChar = '\0';
            this.startBalanceTextBox.PlaceholderText = "";
            this.startBalanceTextBox.SelectedText = "";
            this.startBalanceTextBox.ShadowDecoration.BorderRadius = 20;
            this.startBalanceTextBox.ShadowDecoration.Color = System.Drawing.Color.White;
            this.startBalanceTextBox.ShadowDecoration.Enabled = true;
            this.startBalanceTextBox.Size = new System.Drawing.Size(486, 71);
            this.startBalanceTextBox.TabIndex = 87;
            this.startBalanceTextBox.TextOffset = new System.Drawing.Point(10, 0);
            // 
            // accountNameTextBox
            // 
            this.accountNameTextBox.BackColor = System.Drawing.Color.Transparent;
            this.accountNameTextBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(151)))), ((int)(((byte)(161)))));
            this.accountNameTextBox.BorderRadius = 20;
            this.accountNameTextBox.BorderThickness = 2;
            this.accountNameTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.accountNameTextBox.DefaultText = "";
            this.accountNameTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.accountNameTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.accountNameTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.accountNameTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.accountNameTextBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.accountNameTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.accountNameTextBox.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 14.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.accountNameTextBox.ForeColor = System.Drawing.Color.White;
            this.accountNameTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.accountNameTextBox.HoverState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.accountNameTextBox.Location = new System.Drawing.Point(47, 154);
            this.accountNameTextBox.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.accountNameTextBox.Name = "accountNameTextBox";
            this.accountNameTextBox.PasswordChar = '\0';
            this.accountNameTextBox.PlaceholderText = "";
            this.accountNameTextBox.SelectedText = "";
            this.accountNameTextBox.ShadowDecoration.BorderRadius = 20;
            this.accountNameTextBox.ShadowDecoration.Color = System.Drawing.Color.White;
            this.accountNameTextBox.ShadowDecoration.Enabled = true;
            this.accountNameTextBox.Size = new System.Drawing.Size(486, 63);
            this.accountNameTextBox.TabIndex = 86;
            this.accountNameTextBox.TextOffset = new System.Drawing.Point(10, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Variable Display", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(151)))), ((int)(((byte)(161)))));
            this.label3.Location = new System.Drawing.Point(43, 371);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 22);
            this.label3.TabIndex = 85;
            this.label3.Text = "Starting balance";
            // 
            // accountCurrencyComboBox
            // 
            this.accountCurrencyComboBox.BackColor = System.Drawing.Color.Transparent;
            this.accountCurrencyComboBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(151)))), ((int)(((byte)(161)))));
            this.accountCurrencyComboBox.BorderRadius = 20;
            this.accountCurrencyComboBox.BorderThickness = 2;
            this.accountCurrencyComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.accountCurrencyComboBox.DropDownHeight = 250;
            this.accountCurrencyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.accountCurrencyComboBox.DropDownWidth = 480;
            this.accountCurrencyComboBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.accountCurrencyComboBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.accountCurrencyComboBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.accountCurrencyComboBox.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 14.75F, System.Drawing.FontStyle.Bold);
            this.accountCurrencyComboBox.ForeColor = System.Drawing.Color.White;
            this.accountCurrencyComboBox.IntegralHeight = false;
            this.accountCurrencyComboBox.ItemHeight = 45;
            this.accountCurrencyComboBox.Location = new System.Drawing.Point(47, 293);
            this.accountCurrencyComboBox.Name = "accountCurrencyComboBox";
            this.accountCurrencyComboBox.ShadowDecoration.BorderRadius = 20;
            this.accountCurrencyComboBox.ShadowDecoration.Color = System.Drawing.Color.White;
            this.accountCurrencyComboBox.ShadowDecoration.Enabled = true;
            this.accountCurrencyComboBox.Size = new System.Drawing.Size(486, 51);
            this.accountCurrencyComboBox.TabIndex = 84;
            this.accountCurrencyComboBox.TextOffset = new System.Drawing.Point(10, 0);
            this.accountCurrencyComboBox.SelectedIndexChanged += new System.EventHandler(this.accountCurrencyComboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Variable Display", 12.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(151)))), ((int)(((byte)(161)))));
            this.label5.Location = new System.Drawing.Point(47, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 22);
            this.label5.TabIndex = 82;
            this.label5.Text = "Account currency";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Variable Display", 12.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(151)))), ((int)(((byte)(161)))));
            this.label1.Location = new System.Drawing.Point(47, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 22);
            this.label1.TabIndex = 81;
            this.label1.Text = "Name";
            // 
            // updateButton
            // 
            this.updateButton.BackColor = System.Drawing.Color.Transparent;
            this.updateButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.updateButton.BorderRadius = 15;
            this.updateButton.BorderThickness = 2;
            this.updateButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.updateButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.updateButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.updateButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.updateButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.updateButton.Font = new System.Drawing.Font("Segoe UI Variable Display", 17.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.updateButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.updateButton.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.updateButton.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.updateButton.HoverState.ForeColor = System.Drawing.Color.White;
            this.updateButton.Location = new System.Drawing.Point(96, 614);
            this.updateButton.Name = "updateButton";
            this.updateButton.ShadowDecoration.BorderRadius = 20;
            this.updateButton.ShadowDecoration.Color = System.Drawing.Color.White;
            this.updateButton.ShadowDecoration.Enabled = true;
            this.updateButton.Size = new System.Drawing.Size(147, 58);
            this.updateButton.TabIndex = 88;
            this.updateButton.Text = "Update";
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.Transparent;
            this.deleteButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.deleteButton.BorderRadius = 15;
            this.deleteButton.BorderThickness = 2;
            this.deleteButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.deleteButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.deleteButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.deleteButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.deleteButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.deleteButton.Font = new System.Drawing.Font("Segoe UI Variable Display", 17.75F, System.Drawing.FontStyle.Bold);
            this.deleteButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.deleteButton.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.deleteButton.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.deleteButton.HoverState.Font = new System.Drawing.Font("Segoe UI Variable Display", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.deleteButton.HoverState.ForeColor = System.Drawing.Color.White;
            this.deleteButton.Location = new System.Drawing.Point(338, 614);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.ShadowDecoration.BorderRadius = 20;
            this.deleteButton.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.deleteButton.ShadowDecoration.Enabled = true;
            this.deleteButton.Size = new System.Drawing.Size(147, 58);
            this.deleteButton.TabIndex = 89;
            this.deleteButton.Text = "Delete";
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // EditAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(580, 750);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.currencyLabel);
            this.Controls.Add(this.startBalanceTextBox);
            this.Controls.Add(this.accountNameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.accountCurrencyComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.accountNameLabel);
            this.Controls.Add(this.backButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EditAccountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdateAccountForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label accountNameLabel;
        private Guna.UI2.WinForms.Guna2Button backButton;
        private System.Windows.Forms.Label currencyLabel;
        private Guna.UI2.WinForms.Guna2TextBox startBalanceTextBox;
        private Guna.UI2.WinForms.Guna2TextBox accountNameTextBox;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox accountCurrencyComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button updateButton;
        private Guna.UI2.WinForms.Guna2Button deleteButton;
    }
}