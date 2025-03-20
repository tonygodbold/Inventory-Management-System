namespace Inventory_Management_System
{
    partial class AddProductForm
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
            this.AddProdIDTextBox = new System.Windows.Forms.TextBox();
            this.AddProdMaxTextBox = new System.Windows.Forms.TextBox();
            this.AddProdMinTextBox = new System.Windows.Forms.TextBox();
            this.AddProdPriceCostTextBox = new System.Windows.Forms.TextBox();
            this.AddProdInventoryTextBox = new System.Windows.Forms.TextBox();
            this.AddProdNameTextBox = new System.Windows.Forms.TextBox();
            this.MaxLabel = new System.Windows.Forms.Label();
            this.MinLabel = new System.Windows.Forms.Label();
            this.PriceCostLabel = new System.Windows.Forms.Label();
            this.InventoryLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.IDLabel = new System.Windows.Forms.Label();
            this.DataGridPart = new System.Windows.Forms.DataGridView();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SearchFieldProduct = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.DataGridAssociatedPart = new System.Windows.Forms.DataGridView();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.AllCandidatePartsLabel = new System.Windows.Forms.Label();
            this.PartsAssociatedWithThisProductLabel = new System.Windows.Forms.Label();
            this.AddProductLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridPart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridAssociatedPart)).BeginInit();
            this.SuspendLayout();
            // 
            // AddProdIDTextBox
            // 
            this.AddProdIDTextBox.Location = new System.Drawing.Point(68, 220);
            this.AddProdIDTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.AddProdIDTextBox.Name = "AddProdIDTextBox";
            this.AddProdIDTextBox.ReadOnly = true;
            this.AddProdIDTextBox.Size = new System.Drawing.Size(194, 31);
            this.AddProdIDTextBox.TabIndex = 30;
            // 
            // AddProdMaxTextBox
            // 
            this.AddProdMaxTextBox.Location = new System.Drawing.Point(360, 651);
            this.AddProdMaxTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.AddProdMaxTextBox.Name = "AddProdMaxTextBox";
            this.AddProdMaxTextBox.Size = new System.Drawing.Size(194, 31);
            this.AddProdMaxTextBox.TabIndex = 29;
            // 
            // AddProdMinTextBox
            // 
            this.AddProdMinTextBox.Location = new System.Drawing.Point(84, 654);
            this.AddProdMinTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.AddProdMinTextBox.Name = "AddProdMinTextBox";
            this.AddProdMinTextBox.Size = new System.Drawing.Size(194, 31);
            this.AddProdMinTextBox.TabIndex = 28;
            // 
            // AddProdPriceCostTextBox
            // 
            this.AddProdPriceCostTextBox.Location = new System.Drawing.Point(160, 549);
            this.AddProdPriceCostTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.AddProdPriceCostTextBox.Name = "AddProdPriceCostTextBox";
            this.AddProdPriceCostTextBox.Size = new System.Drawing.Size(194, 31);
            this.AddProdPriceCostTextBox.TabIndex = 27;
            // 
            // AddProdInventoryTextBox
            // 
            this.AddProdInventoryTextBox.Location = new System.Drawing.Point(136, 443);
            this.AddProdInventoryTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.AddProdInventoryTextBox.Name = "AddProdInventoryTextBox";
            this.AddProdInventoryTextBox.Size = new System.Drawing.Size(194, 31);
            this.AddProdInventoryTextBox.TabIndex = 26;
            // 
            // AddProdNameTextBox
            // 
            this.AddProdNameTextBox.Location = new System.Drawing.Point(104, 324);
            this.AddProdNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.AddProdNameTextBox.Name = "AddProdNameTextBox";
            this.AddProdNameTextBox.Size = new System.Drawing.Size(194, 31);
            this.AddProdNameTextBox.TabIndex = 25;
            // 
            // MaxLabel
            // 
            this.MaxLabel.AutoSize = true;
            this.MaxLabel.Location = new System.Drawing.Point(302, 656);
            this.MaxLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MaxLabel.Name = "MaxLabel";
            this.MaxLabel.Size = new System.Drawing.Size(53, 25);
            this.MaxLabel.TabIndex = 24;
            this.MaxLabel.Text = "Max";
            // 
            // MinLabel
            // 
            this.MinLabel.AutoSize = true;
            this.MinLabel.Location = new System.Drawing.Point(32, 660);
            this.MinLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MinLabel.Name = "MinLabel";
            this.MinLabel.Size = new System.Drawing.Size(47, 25);
            this.MinLabel.TabIndex = 23;
            this.MinLabel.Text = "Min";
            // 
            // PriceCostLabel
            // 
            this.PriceCostLabel.AutoSize = true;
            this.PriceCostLabel.Location = new System.Drawing.Point(32, 554);
            this.PriceCostLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PriceCostLabel.Name = "PriceCostLabel";
            this.PriceCostLabel.Size = new System.Drawing.Size(123, 25);
            this.PriceCostLabel.TabIndex = 22;
            this.PriceCostLabel.Text = "Price / Cost";
            // 
            // InventoryLabel
            // 
            this.InventoryLabel.AutoSize = true;
            this.InventoryLabel.Location = new System.Drawing.Point(28, 447);
            this.InventoryLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.InventoryLabel.Name = "InventoryLabel";
            this.InventoryLabel.Size = new System.Drawing.Size(100, 25);
            this.InventoryLabel.TabIndex = 21;
            this.InventoryLabel.Text = "Inventory";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(28, 329);
            this.NameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(68, 25);
            this.NameLabel.TabIndex = 20;
            this.NameLabel.Text = "Name";
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(28, 220);
            this.IDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(32, 25);
            this.IDLabel.TabIndex = 19;
            this.IDLabel.Text = "ID";
            // 
            // DataGridPart
            // 
            this.DataGridPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridPart.Location = new System.Drawing.Point(604, 133);
            this.DataGridPart.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.DataGridPart.Name = "DataGridPart";
            this.DataGridPart.RowHeadersVisible = false;
            this.DataGridPart.RowHeadersWidth = 82;
            this.DataGridPart.RowTemplate.Height = 33;
            this.DataGridPart.Size = new System.Drawing.Size(866, 225);
            this.DataGridPart.TabIndex = 31;
            this.DataGridPart.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridPart_CellClick);
            this.DataGridPart.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridPart_CellContentClick);
            // 
            // SearchButton
            // 
            this.SearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SearchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchButton.Location = new System.Drawing.Point(968, 52);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(160, 50);
            this.SearchButton.TabIndex = 33;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButtonProduct_Click);
            // 
            // SearchFieldProduct
            // 
            this.SearchFieldProduct.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SearchFieldProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SearchFieldProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchFieldProduct.Location = new System.Drawing.Point(1140, 52);
            this.SearchFieldProduct.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.SearchFieldProduct.Name = "SearchFieldProduct";
            this.SearchFieldProduct.Size = new System.Drawing.Size(330, 44);
            this.SearchFieldProduct.TabIndex = 32;
            // 
            // AddButton
            // 
            this.AddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.Location = new System.Drawing.Point(1298, 387);
            this.AddButton.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(156, 60);
            this.AddButton.TabIndex = 34;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DataGridAssociatedPart
            // 
            this.DataGridAssociatedPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridAssociatedPart.Location = new System.Drawing.Point(604, 477);
            this.DataGridAssociatedPart.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.DataGridAssociatedPart.Name = "DataGridAssociatedPart";
            this.DataGridAssociatedPart.RowHeadersVisible = false;
            this.DataGridAssociatedPart.RowHeadersWidth = 82;
            this.DataGridAssociatedPart.RowTemplate.Height = 33;
            this.DataGridAssociatedPart.Size = new System.Drawing.Size(866, 225);
            this.DataGridAssociatedPart.TabIndex = 35;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.Location = new System.Drawing.Point(1300, 733);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(156, 60);
            this.DeleteButton.TabIndex = 36;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F);
            this.CancelButton.Location = new System.Drawing.Point(1298, 810);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(156, 60);
            this.CancelButton.TabIndex = 38;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F);
            this.SaveButton.Location = new System.Drawing.Point(1120, 812);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(4);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(156, 60);
            this.SaveButton.TabIndex = 37;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // AllCandidatePartsLabel
            // 
            this.AllCandidatePartsLabel.AutoSize = true;
            this.AllCandidatePartsLabel.Location = new System.Drawing.Point(600, 92);
            this.AllCandidatePartsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AllCandidatePartsLabel.Name = "AllCandidatePartsLabel";
            this.AllCandidatePartsLabel.Size = new System.Drawing.Size(196, 25);
            this.AllCandidatePartsLabel.TabIndex = 39;
            this.AllCandidatePartsLabel.Text = "All Candidate Parts";
            // 
            // PartsAssociatedWithThisProductLabel
            // 
            this.PartsAssociatedWithThisProductLabel.AutoSize = true;
            this.PartsAssociatedWithThisProductLabel.Location = new System.Drawing.Point(608, 429);
            this.PartsAssociatedWithThisProductLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PartsAssociatedWithThisProductLabel.Name = "PartsAssociatedWithThisProductLabel";
            this.PartsAssociatedWithThisProductLabel.Size = new System.Drawing.Size(350, 25);
            this.PartsAssociatedWithThisProductLabel.TabIndex = 40;
            this.PartsAssociatedWithThisProductLabel.Text = "Parts Associated With This Product";
            // 
            // AddProductLabel
            // 
            this.AddProductLabel.AutoSize = true;
            this.AddProductLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddProductLabel.Location = new System.Drawing.Point(36, 29);
            this.AddProductLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AddProductLabel.Name = "AddProductLabel";
            this.AddProductLabel.Size = new System.Drawing.Size(316, 61);
            this.AddProductLabel.TabIndex = 41;
            this.AddProductLabel.Text = "Add Product";
            // 
            // AddProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1504, 897);
            this.Controls.Add(this.AddProductLabel);
            this.Controls.Add(this.PartsAssociatedWithThisProductLabel);
            this.Controls.Add(this.AllCandidatePartsLabel);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.DataGridAssociatedPart);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.SearchFieldProduct);
            this.Controls.Add(this.DataGridPart);
            this.Controls.Add(this.AddProdIDTextBox);
            this.Controls.Add(this.AddProdMaxTextBox);
            this.Controls.Add(this.AddProdMinTextBox);
            this.Controls.Add(this.AddProdPriceCostTextBox);
            this.Controls.Add(this.AddProdInventoryTextBox);
            this.Controls.Add(this.AddProdNameTextBox);
            this.Controls.Add(this.MaxLabel);
            this.Controls.Add(this.MinLabel);
            this.Controls.Add(this.PriceCostLabel);
            this.Controls.Add(this.InventoryLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.IDLabel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1530, 968);
            this.MinimumSize = new System.Drawing.Size(1530, 968);
            this.Name = "AddProductForm";
            this.Text = "Add Product";
            this.Load += new System.EventHandler(this.AddProductForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridPart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridAssociatedPart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox AddProdIDTextBox;
        private System.Windows.Forms.TextBox AddProdMaxTextBox;
        private System.Windows.Forms.TextBox AddProdMinTextBox;
        private System.Windows.Forms.TextBox AddProdPriceCostTextBox;
        private System.Windows.Forms.TextBox AddProdInventoryTextBox;
        private System.Windows.Forms.TextBox AddProdNameTextBox;
        private System.Windows.Forms.Label MaxLabel;
        private System.Windows.Forms.Label MinLabel;
        private System.Windows.Forms.Label PriceCostLabel;
        private System.Windows.Forms.Label InventoryLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.DataGridView DataGridPart;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TextBox SearchFieldProduct;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.DataGridView DataGridAssociatedPart;
        private System.Windows.Forms.Button DeleteButton;
        private new System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label AllCandidatePartsLabel;
        private System.Windows.Forms.Label PartsAssociatedWithThisProductLabel;
        private System.Windows.Forms.Label AddProductLabel;
    }
}