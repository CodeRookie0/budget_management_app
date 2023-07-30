namespace budget_management_app
{
    partial class AccountsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountsForm));
            this.accountsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.backButton = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // accountsFlowLayoutPanel
            // 
            this.accountsFlowLayoutPanel.AutoScroll = true;
            this.accountsFlowLayoutPanel.Location = new System.Drawing.Point(0, 62);
            this.accountsFlowLayoutPanel.Name = "accountsFlowLayoutPanel";
            this.accountsFlowLayoutPanel.Size = new System.Drawing.Size(580, 645);
            this.accountsFlowLayoutPanel.TabIndex = 40;
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
            this.backButton.PressedColor = System.Drawing.Color.Transparent;
            this.backButton.PressedDepth = 0;
            this.backButton.Size = new System.Drawing.Size(58, 56);
            this.backButton.TabIndex = 41;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Variable Display", 12.75F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(120)))), ((int)(((byte)(130)))));
            this.label1.Location = new System.Drawing.Point(1, 710);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(579, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Click on an account to change information anout it or delete it";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AccountsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(580, 750);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.accountsFlowLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AccountsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AccountForm";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel accountsFlowLayoutPanel;
        private Guna.UI2.WinForms.Guna2Button backButton;
        private System.Windows.Forms.Label label1;
    }
}