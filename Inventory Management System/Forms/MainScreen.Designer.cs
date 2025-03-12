using System.Data;

namespace Inventory_Management_System
{
    partial class MainScreen
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
            this.DataGridPart = new System.Windows.Forms.DataGridView();
            this.DataGridProduct = new System.Windows.Forms.DataGridView();
            this.TitleOfPage = new System.Windows.Forms.TextBox();
            this.AddPartButton = new System.Windows.Forms.Button();
            this.ModifyPart = new System.Windows.Forms.Button();
            this.DeletePart = new System.Windows.Forms.Button();
            this.DeleteProduct = new System.Windows.Forms.Button();
            this.ModifyProduct = new System.Windows.Forms.Button();
            this.AddProduct = new System.Windows.Forms.Button();
            this.ExitApplication = new System.Windows.Forms.Button();
            this.Parts = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SearchFieldPart = new System.Windows.Forms.TextBox();
            this.SearchButtonPart = new System.Windows.Forms.Button();
            this.SearchButtonProduct = new System.Windows.Forms.Button();
            this.SearchFieldProduct = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridPart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridPart
            // 
            this.DataGridPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridPart.Location = new System.Drawing.Point(66, 154);
            this.DataGridPart.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.DataGridPart.Name = "DataGridPart";
            this.DataGridPart.RowHeadersVisible = false;
            this.DataGridPart.RowHeadersWidth = 82;
            this.DataGridPart.RowTemplate.Height = 33;
            this.DataGridPart.Size = new System.Drawing.Size(862, 769);
            this.DataGridPart.TabIndex = 0;
            this.DataGridPart.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
            this.DataGridPart.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.DataGridPart.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridPart_CellMouseDown);
            this.DataGridPart.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.myBindingCompletePart);
            // 
            // DataGridProduct
            // 
            this.DataGridProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridProduct.Location = new System.Drawing.Point(976, 154);
            this.DataGridProduct.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.DataGridProduct.Name = "DataGridProduct";
            this.DataGridProduct.RowHeadersVisible = false;
            this.DataGridProduct.RowHeadersWidth = 82;
            this.DataGridProduct.RowTemplate.Height = 33;
            this.DataGridProduct.Size = new System.Drawing.Size(896, 769);
            this.DataGridProduct.TabIndex = 1;
            this.DataGridProduct.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            this.DataGridProduct.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.myBindingCompleteProduct);
            // 
            // TitleOfPage
            // 
            this.TitleOfPage.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.TitleOfPage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TitleOfPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleOfPage.Location = new System.Drawing.Point(76, 12);
            this.TitleOfPage.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.TitleOfPage.Name = "TitleOfPage";
            this.TitleOfPage.Size = new System.Drawing.Size(708, 55);
            this.TitleOfPage.TabIndex = 2;
            this.TitleOfPage.Text = "Inventory Management System";
            this.TitleOfPage.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // AddPartButton
            // 
            this.AddPartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddPartButton.Location = new System.Drawing.Point(424, 948);
            this.AddPartButton.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.AddPartButton.Name = "AddPartButton";
            this.AddPartButton.Size = new System.Drawing.Size(160, 60);
            this.AddPartButton.TabIndex = 3;
            this.AddPartButton.Text = "Add";
            this.AddPartButton.UseVisualStyleBackColor = true;
            this.AddPartButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // ModifyPart
            // 
            this.ModifyPart.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModifyPart.Location = new System.Drawing.Point(598, 948);
            this.ModifyPart.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.ModifyPart.Name = "ModifyPart";
            this.ModifyPart.Size = new System.Drawing.Size(160, 60);
            this.ModifyPart.TabIndex = 4;
            this.ModifyPart.Text = "Modify";
            this.ModifyPart.UseVisualStyleBackColor = true;
            this.ModifyPart.Click += new System.EventHandler(this.ModifyPart_Click);
            // 
            // DeletePart
            // 
            this.DeletePart.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeletePart.Location = new System.Drawing.Point(768, 948);
            this.DeletePart.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.DeletePart.Name = "DeletePart";
            this.DeletePart.Size = new System.Drawing.Size(160, 60);
            this.DeletePart.TabIndex = 6;
            this.DeletePart.Text = "Delete";
            this.DeletePart.UseVisualStyleBackColor = true;
            this.DeletePart.Click += new System.EventHandler(this.DeletePart_Click);
            // 
            // DeleteProduct
            // 
            this.DeleteProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteProduct.Location = new System.Drawing.Point(1706, 948);
            this.DeleteProduct.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.DeleteProduct.Name = "DeleteProduct";
            this.DeleteProduct.Size = new System.Drawing.Size(156, 60);
            this.DeleteProduct.TabIndex = 9;
            this.DeleteProduct.Text = "Delete";
            this.DeleteProduct.UseVisualStyleBackColor = true;
            this.DeleteProduct.Click += new System.EventHandler(this.DeleteProduct_Click);
            // 
            // ModifyProduct
            // 
            this.ModifyProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModifyProduct.Location = new System.Drawing.Point(1536, 948);
            this.ModifyProduct.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.ModifyProduct.Name = "ModifyProduct";
            this.ModifyProduct.Size = new System.Drawing.Size(156, 60);
            this.ModifyProduct.TabIndex = 8;
            this.ModifyProduct.Text = "Modify";
            this.ModifyProduct.UseVisualStyleBackColor = true;
            this.ModifyProduct.Click += new System.EventHandler(this.ModifyProduct_Click);
            // 
            // AddProduct
            // 
            this.AddProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddProduct.Location = new System.Drawing.Point(1362, 948);
            this.AddProduct.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.AddProduct.Name = "AddProduct";
            this.AddProduct.Size = new System.Drawing.Size(156, 60);
            this.AddProduct.TabIndex = 7;
            this.AddProduct.Text = "Add";
            this.AddProduct.UseVisualStyleBackColor = true;
            this.AddProduct.Click += new System.EventHandler(this.AddProduct_Click);
            // 
            // ExitApplication
            // 
            this.ExitApplication.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ExitApplication.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitApplication.Location = new System.Drawing.Point(1706, 1015);
            this.ExitApplication.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.ExitApplication.Name = "ExitApplication";
            this.ExitApplication.Size = new System.Drawing.Size(156, 60);
            this.ExitApplication.TabIndex = 10;
            this.ExitApplication.Text = "Exit";
            this.ExitApplication.UseVisualStyleBackColor = true;
            this.ExitApplication.Click += new System.EventHandler(this.ExitApplication_Click);
            this.ExitApplication.MouseCaptureChanged += new System.EventHandler(this.ExitApplication_Click);
            // 
            // Parts
            // 
            this.Parts.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Parts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Parts.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Parts.Location = new System.Drawing.Point(76, 83);
            this.Parts.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.Parts.Name = "Parts";
            this.Parts.Size = new System.Drawing.Size(128, 55);
            this.Parts.TabIndex = 11;
            this.Parts.Text = "Parts";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(982, 83);
            this.textBox1.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(666, 55);
            this.textBox1.TabIndex = 12;
            this.textBox1.Text = "Products";
            // 
            // SearchFieldPart
            // 
            this.SearchFieldPart.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SearchFieldPart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SearchFieldPart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchFieldPart.Location = new System.Drawing.Point(592, 92);
            this.SearchFieldPart.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.SearchFieldPart.Name = "SearchFieldPart";
            this.SearchFieldPart.Size = new System.Drawing.Size(330, 44);
            this.SearchFieldPart.TabIndex = 13;
            this.SearchFieldPart.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // SearchButtonPart
            // 
            this.SearchButtonPart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SearchButtonPart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchButtonPart.Location = new System.Drawing.Point(420, 92);
            this.SearchButtonPart.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.SearchButtonPart.Name = "SearchButtonPart";
            this.SearchButtonPart.Size = new System.Drawing.Size(160, 50);
            this.SearchButtonPart.TabIndex = 14;
            this.SearchButtonPart.Text = "Search";
            this.SearchButtonPart.UseVisualStyleBackColor = true;
            this.SearchButtonPart.Click += new System.EventHandler(this.SearchButtonPart_Click);
            // 
            // SearchButtonProduct
            // 
            this.SearchButtonProduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SearchButtonProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchButtonProduct.Location = new System.Drawing.Point(1350, 92);
            this.SearchButtonProduct.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.SearchButtonProduct.Name = "SearchButtonProduct";
            this.SearchButtonProduct.Size = new System.Drawing.Size(156, 50);
            this.SearchButtonProduct.TabIndex = 16;
            this.SearchButtonProduct.Text = "Search";
            this.SearchButtonProduct.UseVisualStyleBackColor = true;
            this.SearchButtonProduct.Click += new System.EventHandler(this.SearchButtonProduct_Click);
            // 
            // SearchFieldProduct
            // 
            this.SearchFieldProduct.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SearchFieldProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SearchFieldProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchFieldProduct.Location = new System.Drawing.Point(1522, 92);
            this.SearchFieldProduct.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.SearchFieldProduct.Name = "SearchFieldProduct";
            this.SearchFieldProduct.Size = new System.Drawing.Size(326, 44);
            this.SearchFieldProduct.TabIndex = 15;
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.ExitApplication;
            this.ClientSize = new System.Drawing.Size(1890, 1110);
            this.Controls.Add(this.SearchButtonProduct);
            this.Controls.Add(this.SearchFieldProduct);
            this.Controls.Add(this.SearchButtonPart);
            this.Controls.Add(this.SearchFieldPart);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Parts);
            this.Controls.Add(this.ExitApplication);
            this.Controls.Add(this.DeleteProduct);
            this.Controls.Add(this.ModifyProduct);
            this.Controls.Add(this.AddProduct);
            this.Controls.Add(this.DeletePart);
            this.Controls.Add(this.ModifyPart);
            this.Controls.Add(this.AddPartButton);
            this.Controls.Add(this.TitleOfPage);
            this.Controls.Add(this.DataGridProduct);
            this.Controls.Add(this.DataGridPart);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1916, 1181);
            this.MinimumSize = new System.Drawing.Size(1916, 1181);
            this.Name = "MainScreen";
            this.Padding = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.Text = "Main Screen";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridPart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridPart;
        private System.Windows.Forms.DataGridView DataGridProduct;
        private System.Windows.Forms.TextBox TitleOfPage;
        private System.Windows.Forms.Button AddPartButton;
        private System.Windows.Forms.Button ModifyPart;
        private System.Windows.Forms.Button DeletePart;
        private System.Windows.Forms.Button DeleteProduct;
        private System.Windows.Forms.Button ModifyProduct;
        private System.Windows.Forms.Button AddProduct;
        private System.Windows.Forms.Button ExitApplication;
        private System.Windows.Forms.TextBox Parts;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox SearchFieldPart;
        private System.Windows.Forms.Button SearchButtonPart;
        private System.Windows.Forms.Button SearchButtonProduct;
        private System.Windows.Forms.TextBox SearchFieldProduct;
    }
}

