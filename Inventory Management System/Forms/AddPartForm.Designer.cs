namespace Inventory_Management_System
{
    partial class AddPartForm
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
            this.AddPartIDTextBox = new System.Windows.Forms.TextBox();
            this.AddPartMaxTextBox = new System.Windows.Forms.TextBox();
            this.AddPartMachineIDCompanyNameTextBox = new System.Windows.Forms.TextBox();
            this.AddPartMinTextBox = new System.Windows.Forms.TextBox();
            this.AddPartPriceTextBox = new System.Windows.Forms.TextBox();
            this.AddPartInvTextBox = new System.Windows.Forms.TextBox();
            this.AddPartNameTextBox = new System.Windows.Forms.TextBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.MachineIDCompanyNameLabel = new System.Windows.Forms.Label();
            this.OutsourcedRadioButton = new System.Windows.Forms.RadioButton();
            this.InHouseRadioButton = new System.Windows.Forms.RadioButton();
            this.MaxLabel = new System.Windows.Forms.Label();
            this.MinLabel = new System.Windows.Forms.Label();
            this.PriceCostLabel = new System.Windows.Forms.Label();
            this.InventoryLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.IDLabel = new System.Windows.Forms.Label();
            this.AddPartLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AddPartIDTextBox
            // 
            this.AddPartIDTextBox.BackColor = System.Drawing.Color.LightGray;
            this.AddPartIDTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AddPartIDTextBox.ForeColor = System.Drawing.Color.Black;
            this.AddPartIDTextBox.Location = new System.Drawing.Point(82, 221);
            this.AddPartIDTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.AddPartIDTextBox.Name = "AddPartIDTextBox";
            this.AddPartIDTextBox.ReadOnly = true;
            this.AddPartIDTextBox.Size = new System.Drawing.Size(194, 31);
            this.AddPartIDTextBox.TabIndex = 75;
            // 
            // AddPartMaxTextBox
            // 
            this.AddPartMaxTextBox.Location = new System.Drawing.Point(376, 460);
            this.AddPartMaxTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.AddPartMaxTextBox.Name = "AddPartMaxTextBox";
            this.AddPartMaxTextBox.Size = new System.Drawing.Size(194, 31);
            this.AddPartMaxTextBox.TabIndex = 74;
            // 
            // AddPartMachineIDCompanyNameTextBox
            // 
            this.AddPartMachineIDCompanyNameTextBox.Location = new System.Drawing.Point(218, 531);
            this.AddPartMachineIDCompanyNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.AddPartMachineIDCompanyNameTextBox.Name = "AddPartMachineIDCompanyNameTextBox";
            this.AddPartMachineIDCompanyNameTextBox.Size = new System.Drawing.Size(194, 31);
            this.AddPartMachineIDCompanyNameTextBox.TabIndex = 73;
            this.AddPartMachineIDCompanyNameTextBox.TextChanged += new System.EventHandler(this.AddPartMachineIDTextBox_TextChanged);
            // 
            // AddPartMinTextBox
            // 
            this.AddPartMinTextBox.Location = new System.Drawing.Point(100, 462);
            this.AddPartMinTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.AddPartMinTextBox.Name = "AddPartMinTextBox";
            this.AddPartMinTextBox.Size = new System.Drawing.Size(194, 31);
            this.AddPartMinTextBox.TabIndex = 72;
            // 
            // AddPartPriceTextBox
            // 
            this.AddPartPriceTextBox.Location = new System.Drawing.Point(176, 400);
            this.AddPartPriceTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.AddPartPriceTextBox.Name = "AddPartPriceTextBox";
            this.AddPartPriceTextBox.Size = new System.Drawing.Size(194, 31);
            this.AddPartPriceTextBox.TabIndex = 71;
            // 
            // AddPartInvTextBox
            // 
            this.AddPartInvTextBox.Location = new System.Drawing.Point(150, 340);
            this.AddPartInvTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.AddPartInvTextBox.Name = "AddPartInvTextBox";
            this.AddPartInvTextBox.Size = new System.Drawing.Size(194, 31);
            this.AddPartInvTextBox.TabIndex = 70;
            // 
            // AddPartNameTextBox
            // 
            this.AddPartNameTextBox.Location = new System.Drawing.Point(118, 279);
            this.AddPartNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.AddPartNameTextBox.Name = "AddPartNameTextBox";
            this.AddPartNameTextBox.Size = new System.Drawing.Size(194, 31);
            this.AddPartNameTextBox.TabIndex = 69;
            // 
            // CancelButton
            // 
            this.CancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F);
            this.CancelButton.Location = new System.Drawing.Point(324, 606);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(178, 65);
            this.CancelButton.TabIndex = 68;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F);
            this.SaveButton.Location = new System.Drawing.Point(80, 606);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(4);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(178, 65);
            this.SaveButton.TabIndex = 67;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // MachineIDCompanyNameLabel
            // 
            this.MachineIDCompanyNameLabel.AutoSize = true;
            this.MachineIDCompanyNameLabel.Location = new System.Drawing.Point(44, 533);
            this.MachineIDCompanyNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MachineIDCompanyNameLabel.Name = "MachineIDCompanyNameLabel";
            this.MachineIDCompanyNameLabel.Size = new System.Drawing.Size(120, 25);
            this.MachineIDCompanyNameLabel.TabIndex = 66;
            this.MachineIDCompanyNameLabel.Text = "Machine ID";
            this.MachineIDCompanyNameLabel.Click += new System.EventHandler(this.MachineIDCompanyNameLabel_Click);
            // 
            // OutsourcedRadioButton
            // 
            this.OutsourcedRadioButton.AutoSize = true;
            this.OutsourcedRadioButton.Location = new System.Drawing.Point(358, 135);
            this.OutsourcedRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.OutsourcedRadioButton.Name = "OutsourcedRadioButton";
            this.OutsourcedRadioButton.Size = new System.Drawing.Size(154, 29);
            this.OutsourcedRadioButton.TabIndex = 65;
            this.OutsourcedRadioButton.Text = "Outsourced";
            this.OutsourcedRadioButton.UseVisualStyleBackColor = true;
            this.OutsourcedRadioButton.CheckedChanged += new System.EventHandler(this.OutsourcedRadioButton_CheckedChanged);
            // 
            // InHouseRadioButton
            // 
            this.InHouseRadioButton.AutoSize = true;
            this.InHouseRadioButton.Checked = true;
            this.InHouseRadioButton.Location = new System.Drawing.Point(82, 135);
            this.InHouseRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.InHouseRadioButton.Name = "InHouseRadioButton";
            this.InHouseRadioButton.Size = new System.Drawing.Size(129, 29);
            this.InHouseRadioButton.TabIndex = 64;
            this.InHouseRadioButton.TabStop = true;
            this.InHouseRadioButton.Text = "In-House";
            this.InHouseRadioButton.UseVisualStyleBackColor = true;
            this.InHouseRadioButton.CheckedChanged += new System.EventHandler(this.InHouseRadioButton_CheckedChanged);
            // 
            // MaxLabel
            // 
            this.MaxLabel.AutoSize = true;
            this.MaxLabel.Location = new System.Drawing.Point(318, 465);
            this.MaxLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MaxLabel.Name = "MaxLabel";
            this.MaxLabel.Size = new System.Drawing.Size(53, 25);
            this.MaxLabel.TabIndex = 63;
            this.MaxLabel.Text = "Max";
            // 
            // MinLabel
            // 
            this.MinLabel.AutoSize = true;
            this.MinLabel.Location = new System.Drawing.Point(46, 467);
            this.MinLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MinLabel.Name = "MinLabel";
            this.MinLabel.Size = new System.Drawing.Size(47, 25);
            this.MinLabel.TabIndex = 62;
            this.MinLabel.Text = "Min";
            // 
            // PriceCostLabel
            // 
            this.PriceCostLabel.AutoSize = true;
            this.PriceCostLabel.Location = new System.Drawing.Point(46, 406);
            this.PriceCostLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PriceCostLabel.Name = "PriceCostLabel";
            this.PriceCostLabel.Size = new System.Drawing.Size(123, 25);
            this.PriceCostLabel.TabIndex = 61;
            this.PriceCostLabel.Text = "Price / Cost";
            // 
            // InventoryLabel
            // 
            this.InventoryLabel.AutoSize = true;
            this.InventoryLabel.Location = new System.Drawing.Point(44, 342);
            this.InventoryLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.InventoryLabel.Name = "InventoryLabel";
            this.InventoryLabel.Size = new System.Drawing.Size(100, 25);
            this.InventoryLabel.TabIndex = 60;
            this.InventoryLabel.Text = "Inventory";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(44, 285);
            this.NameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(68, 25);
            this.NameLabel.TabIndex = 59;
            this.NameLabel.Text = "Name";
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(44, 221);
            this.IDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(32, 25);
            this.IDLabel.TabIndex = 58;
            this.IDLabel.Text = "ID";
            // 
            // AddPartLabel
            // 
            this.AddPartLabel.AutoSize = true;
            this.AddPartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddPartLabel.Location = new System.Drawing.Point(38, 21);
            this.AddPartLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AddPartLabel.Name = "AddPartLabel";
            this.AddPartLabel.Size = new System.Drawing.Size(231, 61);
            this.AddPartLabel.TabIndex = 57;
            this.AddPartLabel.Text = "Add Part";
            // 
            // AddPartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 701);
            this.Controls.Add(this.AddPartIDTextBox);
            this.Controls.Add(this.AddPartMaxTextBox);
            this.Controls.Add(this.AddPartMachineIDCompanyNameTextBox);
            this.Controls.Add(this.AddPartMinTextBox);
            this.Controls.Add(this.AddPartPriceTextBox);
            this.Controls.Add(this.AddPartInvTextBox);
            this.Controls.Add(this.AddPartNameTextBox);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.MachineIDCompanyNameLabel);
            this.Controls.Add(this.OutsourcedRadioButton);
            this.Controls.Add(this.InHouseRadioButton);
            this.Controls.Add(this.MaxLabel);
            this.Controls.Add(this.MinLabel);
            this.Controls.Add(this.PriceCostLabel);
            this.Controls.Add(this.InventoryLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.IDLabel);
            this.Controls.Add(this.AddPartLabel);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximumSize = new System.Drawing.Size(620, 772);
            this.MinimumSize = new System.Drawing.Size(620, 772);
            this.Name = "AddPartForm";
            this.Text = "Add Part";
            this.Load += new System.EventHandler(this.AddPartForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox AddPartIDTextBox;
        private System.Windows.Forms.TextBox AddPartMaxTextBox;
        private System.Windows.Forms.TextBox AddPartMachineIDCompanyNameTextBox;
        private System.Windows.Forms.TextBox AddPartMinTextBox;
        private System.Windows.Forms.TextBox AddPartPriceTextBox;
        private System.Windows.Forms.TextBox AddPartInvTextBox;
        private System.Windows.Forms.TextBox AddPartNameTextBox;
        private new System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label MachineIDCompanyNameLabel;
        private System.Windows.Forms.RadioButton OutsourcedRadioButton;
        private System.Windows.Forms.RadioButton InHouseRadioButton;
        private System.Windows.Forms.Label MaxLabel;
        private System.Windows.Forms.Label MinLabel;
        private System.Windows.Forms.Label PriceCostLabel;
        private System.Windows.Forms.Label InventoryLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.Label AddPartLabel;
    }
}