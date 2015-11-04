namespace StockManagement.Views
{
    partial class HomeForm
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
            this.ProductCount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.HomeTabControl = new System.Windows.Forms.TabControl();
            this.ProductMgmtTab = new System.Windows.Forms.TabPage();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CreateButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.OwnerComboBox = new System.Windows.Forms.ComboBox();
            this.ProductNameTextBox = new System.Windows.Forms.TextBox();
            this.StockMgmtTab = new System.Windows.Forms.TabPage();
            this.OwnerLabel = new System.Windows.Forms.Label();
            this.OwnerLabel0 = new System.Windows.Forms.Label();
            this.ProductNameLabel = new System.Windows.Forms.Label();
            this.UpdateStockButton = new System.Windows.Forms.Button();
            this.ProductListBox = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ProductCount)).BeginInit();
            this.HomeTabControl.SuspendLayout();
            this.ProductMgmtTab.SuspendLayout();
            this.StockMgmtTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProductCount
            // 
            this.ProductCount.Location = new System.Drawing.Point(97, 48);
            this.ProductCount.Maximum = new decimal(new int[] {
            5000000,
            0,
            0,
            0});
            this.ProductCount.Name = "ProductCount";
            this.ProductCount.Size = new System.Drawing.Size(120, 20);
            this.ProductCount.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Count";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Product Name";
            // 
            // HomeTabControl
            // 
            this.HomeTabControl.Controls.Add(this.ProductMgmtTab);
            this.HomeTabControl.Controls.Add(this.StockMgmtTab);
            this.HomeTabControl.Location = new System.Drawing.Point(12, 12);
            this.HomeTabControl.Name = "HomeTabControl";
            this.HomeTabControl.SelectedIndex = 0;
            this.HomeTabControl.Size = new System.Drawing.Size(308, 312);
            this.HomeTabControl.TabIndex = 9;
            // 
            // ProductMgmtTab
            // 
            this.ProductMgmtTab.Controls.Add(this.DeleteButton);
            this.ProductMgmtTab.Controls.Add(this.SaveButton);
            this.ProductMgmtTab.Controls.Add(this.CreateButton);
            this.ProductMgmtTab.Controls.Add(this.label4);
            this.ProductMgmtTab.Controls.Add(this.label3);
            this.ProductMgmtTab.Controls.Add(this.OwnerComboBox);
            this.ProductMgmtTab.Controls.Add(this.ProductNameTextBox);
            this.ProductMgmtTab.Location = new System.Drawing.Point(4, 22);
            this.ProductMgmtTab.Name = "ProductMgmtTab";
            this.ProductMgmtTab.Padding = new System.Windows.Forms.Padding(3);
            this.ProductMgmtTab.Size = new System.Drawing.Size(300, 286);
            this.ProductMgmtTab.TabIndex = 1;
            this.ProductMgmtTab.Text = "Product Management";
            this.ProductMgmtTab.UseVisualStyleBackColor = true;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(202, 73);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(88, 23);
            this.DeleteButton.TabIndex = 7;
            this.DeleteButton.Text = "Delete Product";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(108, 73);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(88, 23);
            this.SaveButton.TabIndex = 6;
            this.SaveButton.Text = "Save Product";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(14, 73);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(88, 23);
            this.CreateButton.TabIndex = 5;
            this.CreateButton.Text = "Create Product";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Owner";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Product Name";
            // 
            // OwnerComboBox
            // 
            this.OwnerComboBox.FormattingEnabled = true;
            this.OwnerComboBox.Location = new System.Drawing.Point(92, 41);
            this.OwnerComboBox.Name = "OwnerComboBox";
            this.OwnerComboBox.Size = new System.Drawing.Size(121, 21);
            this.OwnerComboBox.TabIndex = 2;
            // 
            // ProductNameTextBox
            // 
            this.ProductNameTextBox.Location = new System.Drawing.Point(92, 15);
            this.ProductNameTextBox.Name = "ProductNameTextBox";
            this.ProductNameTextBox.Size = new System.Drawing.Size(121, 20);
            this.ProductNameTextBox.TabIndex = 1;
            // 
            // StockMgmtTab
            // 
            this.StockMgmtTab.Controls.Add(this.OwnerLabel);
            this.StockMgmtTab.Controls.Add(this.OwnerLabel0);
            this.StockMgmtTab.Controls.Add(this.ProductNameLabel);
            this.StockMgmtTab.Controls.Add(this.UpdateStockButton);
            this.StockMgmtTab.Controls.Add(this.label2);
            this.StockMgmtTab.Controls.Add(this.ProductCount);
            this.StockMgmtTab.Controls.Add(this.label1);
            this.StockMgmtTab.Location = new System.Drawing.Point(4, 22);
            this.StockMgmtTab.Name = "StockMgmtTab";
            this.StockMgmtTab.Padding = new System.Windows.Forms.Padding(3);
            this.StockMgmtTab.Size = new System.Drawing.Size(300, 286);
            this.StockMgmtTab.TabIndex = 0;
            this.StockMgmtTab.Text = "Stock Management";
            this.StockMgmtTab.UseVisualStyleBackColor = true;
            // 
            // OwnerLabel
            // 
            this.OwnerLabel.AutoSize = true;
            this.OwnerLabel.Location = new System.Drawing.Point(94, 31);
            this.OwnerLabel.Name = "OwnerLabel";
            this.OwnerLabel.Size = new System.Drawing.Size(0, 13);
            this.OwnerLabel.TabIndex = 12;
            // 
            // OwnerLabel0
            // 
            this.OwnerLabel0.AutoSize = true;
            this.OwnerLabel0.Location = new System.Drawing.Point(10, 31);
            this.OwnerLabel0.Name = "OwnerLabel0";
            this.OwnerLabel0.Size = new System.Drawing.Size(38, 13);
            this.OwnerLabel0.TabIndex = 11;
            this.OwnerLabel0.Text = "Owner";
            // 
            // ProductNameLabel
            // 
            this.ProductNameLabel.AutoSize = true;
            this.ProductNameLabel.Location = new System.Drawing.Point(94, 12);
            this.ProductNameLabel.Name = "ProductNameLabel";
            this.ProductNameLabel.Size = new System.Drawing.Size(0, 13);
            this.ProductNameLabel.TabIndex = 10;
            // 
            // UpdateStockButton
            // 
            this.UpdateStockButton.Location = new System.Drawing.Point(11, 76);
            this.UpdateStockButton.Name = "UpdateStockButton";
            this.UpdateStockButton.Size = new System.Drawing.Size(84, 23);
            this.UpdateStockButton.TabIndex = 9;
            this.UpdateStockButton.Text = "Update Stock";
            this.UpdateStockButton.UseVisualStyleBackColor = true;
            this.UpdateStockButton.Click += new System.EventHandler(this.UpdateStockButton_Click);
            // 
            // ProductListBox
            // 
            this.ProductListBox.FormattingEnabled = true;
            this.ProductListBox.Location = new System.Drawing.Point(343, 34);
            this.ProductListBox.Name = "ProductListBox";
            this.ProductListBox.Size = new System.Drawing.Size(262, 290);
            this.ProductListBox.TabIndex = 0;
            this.ProductListBox.SelectedIndexChanged += new System.EventHandler(this.ProductListBox_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(343, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Products";
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 347);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.HomeTabControl);
            this.Controls.Add(this.ProductListBox);
            this.Name = "HomeForm";
            this.Text = "Home - Stock Management";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HomeForm_FormClosed);
            this.Load += new System.EventHandler(this.HomeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProductCount)).EndInit();
            this.HomeTabControl.ResumeLayout(false);
            this.ProductMgmtTab.ResumeLayout(false);
            this.ProductMgmtTab.PerformLayout();
            this.StockMgmtTab.ResumeLayout(false);
            this.StockMgmtTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown ProductCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl HomeTabControl;
        private System.Windows.Forms.TabPage ProductMgmtTab;
        private System.Windows.Forms.TabPage StockMgmtTab;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox OwnerComboBox;
        private System.Windows.Forms.TextBox ProductNameTextBox;
        private System.Windows.Forms.ListBox ProductListBox;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button UpdateStockButton;
        private System.Windows.Forms.Label OwnerLabel;
        private System.Windows.Forms.Label OwnerLabel0;
        private System.Windows.Forms.Label ProductNameLabel;
        private System.Windows.Forms.Label label7;

    }
}