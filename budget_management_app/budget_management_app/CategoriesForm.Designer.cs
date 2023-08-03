namespace budget_management_app
{
    partial class CategoriesForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoriesForm));
            this.label2 = new System.Windows.Forms.Label();
            this.budget_managementDataSet1 = new budget_management_app.Budget_managementDataSet1();
            this.categoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.categoryTableAdapter = new budget_management_app.Budget_managementDataSet1TableAdapters.CategoryTableAdapter();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2Panel7 = new Guna.UI2.WinForms.Guna2Panel();
            this.statisticButtonBar = new Guna.UI2.WinForms.Guna2Button();
            this.categoriesButton = new Guna.UI2.WinForms.Guna2Button();
            this.transactionsButton = new Guna.UI2.WinForms.Guna2Button();
            this.accountsButton = new Guna.UI2.WinForms.Guna2Button();
            this.homeButton = new Guna.UI2.WinForms.Guna2Button();
            this.settingsButton = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.budget_managementDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(220, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 29);
            this.label2.TabIndex = 35;
            this.label2.Text = "Categories";
            // 
            // budget_managementDataSet1
            // 
            this.budget_managementDataSet1.DataSetName = "Budget_managementDataSet1";
            this.budget_managementDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // categoryBindingSource
            // 
            this.categoryBindingSource.DataMember = "Category";
            this.categoryBindingSource.DataSource = this.budget_managementDataSet1;
            // 
            // categoryTableAdapter
            // 
            this.categoryTableAdapter.ClearBeforeFill = true;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderRadius = 40;
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.guna2Panel1.Location = new System.Drawing.Point(0, -71);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.BorderRadius = 45;
            this.guna2Panel1.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.guna2Panel1.ShadowDecoration.Enabled = true;
            this.guna2Panel1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(7);
            this.guna2Panel1.Size = new System.Drawing.Size(580, 147);
            this.guna2Panel1.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(253)))));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 92);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(583, 605);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // guna2Panel7
            // 
            this.guna2Panel7.Controls.Add(this.statisticButtonBar);
            this.guna2Panel7.Controls.Add(this.categoriesButton);
            this.guna2Panel7.Controls.Add(this.transactionsButton);
            this.guna2Panel7.Controls.Add(this.accountsButton);
            this.guna2Panel7.Controls.Add(this.homeButton);
            this.guna2Panel7.Controls.Add(this.settingsButton);
            this.guna2Panel7.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(253)))));
            this.guna2Panel7.Location = new System.Drawing.Point(0, 700);
            this.guna2Panel7.Name = "guna2Panel7";
            this.guna2Panel7.ShadowDecoration.BorderRadius = 0;
            this.guna2Panel7.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.guna2Panel7.ShadowDecoration.Depth = 10;
            this.guna2Panel7.ShadowDecoration.Enabled = true;
            this.guna2Panel7.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(4);
            this.guna2Panel7.Size = new System.Drawing.Size(583, 52);
            this.guna2Panel7.TabIndex = 85;
            // 
            // statisticButtonBar
            // 
            this.statisticButtonBar.BackColor = System.Drawing.Color.Transparent;
            this.statisticButtonBar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.statisticButtonBar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.statisticButtonBar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.statisticButtonBar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.statisticButtonBar.FillColor = System.Drawing.Color.Transparent;
            this.statisticButtonBar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statisticButtonBar.ForeColor = System.Drawing.Color.Transparent;
            this.statisticButtonBar.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.statisticButtonBar.Image = ((System.Drawing.Image)(resources.GetObject("statisticButtonBar.Image")));
            this.statisticButtonBar.ImageSize = new System.Drawing.Size(35, 35);
            this.statisticButtonBar.Location = new System.Drawing.Point(387, 0);
            this.statisticButtonBar.Name = "statisticButtonBar";
            this.statisticButtonBar.Size = new System.Drawing.Size(97, 52);
            this.statisticButtonBar.TabIndex = 5;
            this.statisticButtonBar.UseTransparentBackground = true;
            this.statisticButtonBar.Click += new System.EventHandler(this.statisticButtonBar_Click);
            // 
            // categoriesButton
            // 
            this.categoriesButton.BackColor = System.Drawing.Color.Transparent;
            this.categoriesButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.categoriesButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.categoriesButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.categoriesButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.categoriesButton.FillColor = System.Drawing.Color.Transparent;
            this.categoriesButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.categoriesButton.ForeColor = System.Drawing.Color.Transparent;
            this.categoriesButton.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.categoriesButton.Image = ((System.Drawing.Image)(resources.GetObject("categoriesButton.Image")));
            this.categoriesButton.ImageSize = new System.Drawing.Size(35, 35);
            this.categoriesButton.Location = new System.Drawing.Point(290, 0);
            this.categoriesButton.Name = "categoriesButton";
            this.categoriesButton.Size = new System.Drawing.Size(97, 52);
            this.categoriesButton.TabIndex = 4;
            this.categoriesButton.UseTransparentBackground = true;
            // 
            // transactionsButton
            // 
            this.transactionsButton.BackColor = System.Drawing.Color.Transparent;
            this.transactionsButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.transactionsButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.transactionsButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.transactionsButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.transactionsButton.FillColor = System.Drawing.Color.Transparent;
            this.transactionsButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.transactionsButton.ForeColor = System.Drawing.Color.Transparent;
            this.transactionsButton.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            this.transactionsButton.Image = ((System.Drawing.Image)(resources.GetObject("transactionsButton.Image")));
            this.transactionsButton.ImageSize = new System.Drawing.Size(35, 35);
            this.transactionsButton.Location = new System.Drawing.Point(193, 0);
            this.transactionsButton.Name = "transactionsButton";
            this.transactionsButton.Size = new System.Drawing.Size(97, 52);
            this.transactionsButton.TabIndex = 3;
            this.transactionsButton.UseTransparentBackground = true;
            this.transactionsButton.Click += new System.EventHandler(this.transactionsButton_Click);
            // 
            // accountsButton
            // 
            this.accountsButton.BackColor = System.Drawing.Color.Transparent;
            this.accountsButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.accountsButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.accountsButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.accountsButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.accountsButton.FillColor = System.Drawing.Color.Transparent;
            this.accountsButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.accountsButton.ForeColor = System.Drawing.Color.Transparent;
            this.accountsButton.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            this.accountsButton.Image = ((System.Drawing.Image)(resources.GetObject("accountsButton.Image")));
            this.accountsButton.ImageSize = new System.Drawing.Size(35, 35);
            this.accountsButton.Location = new System.Drawing.Point(96, 0);
            this.accountsButton.Name = "accountsButton";
            this.accountsButton.Size = new System.Drawing.Size(97, 52);
            this.accountsButton.TabIndex = 2;
            this.accountsButton.UseTransparentBackground = true;
            this.accountsButton.Click += new System.EventHandler(this.accountsButton_Click);
            // 
            // homeButton
            // 
            this.homeButton.BackColor = System.Drawing.Color.Transparent;
            this.homeButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.homeButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.homeButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.homeButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.homeButton.FillColor = System.Drawing.Color.Transparent;
            this.homeButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.homeButton.ForeColor = System.Drawing.Color.Transparent;
            this.homeButton.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image4")));
            this.homeButton.Image = ((System.Drawing.Image)(resources.GetObject("homeButton.Image")));
            this.homeButton.ImageSize = new System.Drawing.Size(35, 35);
            this.homeButton.Location = new System.Drawing.Point(0, 0);
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(96, 52);
            this.homeButton.TabIndex = 1;
            this.homeButton.UseTransparentBackground = true;
            this.homeButton.Click += new System.EventHandler(this.homeButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.BackColor = System.Drawing.Color.Transparent;
            this.settingsButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.settingsButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.settingsButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.settingsButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.settingsButton.FillColor = System.Drawing.Color.Transparent;
            this.settingsButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.settingsButton.ForeColor = System.Drawing.Color.Transparent;
            this.settingsButton.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image5")));
            this.settingsButton.Image = ((System.Drawing.Image)(resources.GetObject("settingsButton.Image")));
            this.settingsButton.ImageSize = new System.Drawing.Size(35, 35);
            this.settingsButton.Location = new System.Drawing.Point(484, 0);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(96, 52);
            this.settingsButton.TabIndex = 0;
            this.settingsButton.UseTransparentBackground = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // CategoriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(580, 750);
            this.Controls.Add(this.guna2Panel7);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CategoriesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CategoriesForm";
            ((System.ComponentModel.ISupportInitialize)(this.budget_managementDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2Panel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private Budget_managementDataSet1 budget_managementDataSet1;
        private System.Windows.Forms.BindingSource categoryBindingSource;
        private Budget_managementDataSet1TableAdapters.CategoryTableAdapter categoryTableAdapter;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel7;
        private Guna.UI2.WinForms.Guna2Button statisticButtonBar;
        private Guna.UI2.WinForms.Guna2Button categoriesButton;
        private Guna.UI2.WinForms.Guna2Button transactionsButton;
        private Guna.UI2.WinForms.Guna2Button accountsButton;
        private Guna.UI2.WinForms.Guna2Button homeButton;
        private Guna.UI2.WinForms.Guna2Button settingsButton;
    }
}