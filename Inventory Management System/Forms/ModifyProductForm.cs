﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inventory_Management_System.Models;

namespace Inventory_Management_System
{
    public partial class ModifyProductForm : Form
    {
        Product product2 = new Product();
        Inventory product3 = new Inventory();
        private ToolTip toolTip = new ToolTip();

        public ModifyProductForm()
        {
            InitializeComponent();
            formatDGV(DataGridPart);
            formatDGV(DataGridAssociatedPart);
            display();
            InitializeToolTips(); // Initialize tooltips
            AddEventHandlers(); // Call the method to add event handlers
            DeleteButton.Enabled = false; // Disable delete button initially
        }

        private void display() // re-populate the DGV using the current MyList 
        {
            DataGridPart.DataSource = Inventory.AllParts;
            DataGridAssociatedPart.DataSource = product2.AssociatedParts;
        }
        private void formatDGV(DataGridView d)
        {
            d.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            d.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Blue;
            d.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            d.RowHeadersVisible = false;
            d.ReadOnly = true;
            d.MultiSelect = false;
            d.AllowUserToAddRows = false;
            d.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            d.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            foreach (DataGridViewColumn column in d.Columns)
            {
                column.HeaderCell.Value = column.Index.ToString();
            }
        }

        private void AddProductForm_Load(object sender, EventArgs e)
        {
            //// Assuming Inventory.CurrentIndex is an integer or a string
            //if (Inventory.CurrentProduct != null)
            //{
            //    ModProdIDTextBox.Text = Inventory.CurrentProduct.PartID.ToString();
            //    ModProdNameTextBox.Text = Inventory.CurrentProduct.Name.ToString();
            //    ModProdStockTextBox.Text = Inventory.CurrentObject.InStock.ToString();
            //    ModProdPriceTextBox.Text = Inventory.CurrentObject.Price.ToString();
            //    ModProdMinTextBox.Text = Inventory.CurrentObject.Min.ToString();
            //    ModProdMaxTextBox.Text = Inventory.CurrentObject.Max.ToString();
            //}
            //else
            //{
            //    ModProdIDTextBox.Text = string.Empty; // Fallback for null
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //public void addAssociatedPart(Part part)
        //{
        //    Product.CurrentIndexAssociatedPart.Add(part);
        //}

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (!DataGridPart.CurrentRow.Selected)
            {
                MessageBox.Show("Nothing selected!", "Please select a part to add");
                return;
            }
            else
            {
                int partID = ((Part)DataGridPart.CurrentRow.DataBoundItem).PartID;

                Inventory inventoryInstance = new Inventory();

                Part part = inventoryInstance.lookupPart(partID);

                if (part != null)
                {
                    if (product2.lookupAssociatedPart(partID) == null)
                    {
                        product2.addAssociatedPart(part);
                        display(); // Refresh the DataGridView to reflect the change
                    }
                    else
                    {
                        MessageBox.Show("Part is already associated with the product.");
                    }
                }
                else
                {
                    MessageBox.Show("Part not found!");
                }
            }
        }

        private void Button2(object sender, EventArgs e)
        {

        }

        private static void CompareMinMax(int min, int max)
        {
            if (min > max)
            {
                MessageBox.Show("Min value cannot be greater than Max value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static void CheckInvValues(int inv, int min, int max)
        {
            if (inv < min || inv > max)
            {
                MessageBox.Show("Inventory cannot be greater than Max or less than Min.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Modify the ModProdSaveButton_Click method
        public void ModProdSaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Remove the check for at least one associated part
                // if (product2.AssociatedParts.Count == 0)
                // {
                //     MessageBox.Show("At least one part must be associated with the product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //     return;
                // }

                CompareMinMax(Int32.Parse(ModProdMinTextBox.Text), Int32.Parse(ModProdMaxTextBox.Text));
                CheckInvValues(Int32.Parse(ModProdStockTextBox.Text), Int32.Parse(ModProdMinTextBox.Text), Int32.Parse(ModProdMaxTextBox.Text));

                int ModID = Int32.Parse(ModProdIDTextBox.Text);

                Product productToUpdate = Inventory.Products.FirstOrDefault(product => product.ProductID == ModID);

                if (productToUpdate != null)
                {
                    productToUpdate.Name = ModProdNameTextBox.Text;
                    productToUpdate.Price = Decimal.Parse(ModProdPriceTextBox.Text);
                    productToUpdate.InStock = Int32.Parse(ModProdStockTextBox.Text);
                    productToUpdate.Min = Int32.Parse(ModProdMinTextBox.Text);
                    productToUpdate.Max = Int32.Parse(ModProdMaxTextBox.Text);
                    productToUpdate.AssociatedParts = product2.AssociatedParts; // Ensure associated parts are saved

                    Inventory inventoryInstance = new Inventory();

                    inventoryInstance.updateProduct(productToUpdate.ProductID, productToUpdate);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Product not found in the inventory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        void ModProd_Load(object sender, EventArgs e)
        {
            if (Inventory.CurrentProduct != null)
            {
                ModProdIDTextBox.Text = Inventory.CurrentProduct.ProductID.ToString();
                ModProdNameTextBox.Text = Inventory.CurrentProduct.Name.ToString();
                ModProdStockTextBox.Text = Inventory.CurrentProduct.InStock.ToString();
                ModProdPriceTextBox.Text = Inventory.CurrentProduct.Price.ToString();
                ModProdMinTextBox.Text = Inventory.CurrentProduct.Min.ToString();
                ModProdMaxTextBox.Text = Inventory.CurrentProduct.Max.ToString();
                DataGridAssociatedPart.DataSource = Inventory.CurrentProduct.AssociatedParts;
            }

            else
            {
                ModProdIDTextBox.Text = string.Empty; // Fallback for null
            }
            ModProdIDTextBox.ReadOnly = true; // Set ModProdIDTextBox to readonly
            ModProdIDTextBox.BackColor = Color.LightGray; // Set background color to light gray
        }

        private void DataGridAssociatedPart_SelectionChanged(object sender, EventArgs e)
        {
            DeleteButton.Enabled = DataGridAssociatedPart.CurrentRow != null;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (!DataGridAssociatedPart.CurrentRow.Selected)
            {
                MessageBox.Show("No associated part selected. Please select a part.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Part selectedPart = DataGridAssociatedPart.CurrentRow.DataBoundItem as Part;
                if (selectedPart != null)
                {
                    product2.removeAssociatedPart(selectedPart.PartID);
                    display(); // Refresh the DataGridView to reflect the change
                }
            }
        }

        private void InitializeToolTips()
        {
            toolTip.SetToolTip(ModProdIDTextBox, "This is the product ID.");
            toolTip.SetToolTip(ModProdMaxTextBox, "Enter the maximum inventory level.");
            toolTip.SetToolTip(ModProdMinTextBox, "Enter the minimum inventory level.");
            toolTip.SetToolTip(ModProdPriceTextBox, "Enter the price/cost of the product.");
            toolTip.SetToolTip(ModProdStockTextBox, "Enter the current inventory level.");
            toolTip.SetToolTip(ModProdNameTextBox, "Enter the name of the product.");
        }

        private void AddEventHandlers()
        {
            ModProdIDTextBox.TextChanged += ValidateTextBox;
            ModProdMaxTextBox.TextChanged += ValidateTextBox;
            ModProdMinTextBox.TextChanged += ValidateTextBox;
            ModProdPriceTextBox.TextChanged += ValidateTextBox;
            ModProdStockTextBox.TextChanged += ValidateTextBox;
            ModProdNameTextBox.TextChanged += ValidateTextBox;

            ModProdStockTextBox.TextChanged += ModProdStockTextBox_TextChanged;
            ModProdPriceTextBox.TextChanged += ModProdPriceTextBox_TextChanged;
            ModProdMaxTextBox.TextChanged += ModProdMaxTextBox_TextChanged;
            ModProdMinTextBox.TextChanged += ModProdMinTextBox_TextChanged;

            DataGridAssociatedPart.SelectionChanged += DataGridAssociatedPart_SelectionChanged;
        }

        private void ValidateTextBox(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    textBox.BackColor = Color.Salmon;
                }
                else
                {
                    textBox.BackColor = Color.White;
                }
            }
        }

        private void ModProdNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ModProdNameTextBox.Text))
            {
                ModProdNameTextBox.BackColor = Color.Salmon;
                ModProdSaveButton.Enabled = false;
            }
            else
            {
                ModProdNameTextBox.BackColor = Color.White;
                EnableModSaveButton();
            }
        }

        private void ModProdStockTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CheckIfNum(ModProdStockTextBox.Text);
                ModProdStockTextBox.BackColor = Color.White;
                EnableModSaveButton();
            }
            catch (Exception)
            {
                ModProdStockTextBox.BackColor = Color.Salmon;
                ModProdSaveButton.Enabled = false;
            }
        }

        private void ModProdPriceTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CheckIfDeci(ModProdPriceTextBox.Text);
                ModProdPriceTextBox.BackColor = Color.White;
                EnableModSaveButton();
            }
            catch (Exception)
            {
                ModProdPriceTextBox.BackColor = Color.Salmon;
                ModProdSaveButton.Enabled = false;
            }
        }

        private void ModProdMaxTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CheckIfNum(ModProdMaxTextBox.Text);
                ModProdMaxTextBox.BackColor = Color.White;
                EnableModSaveButton();
            }
            catch (Exception)
            {
                ModProdMaxTextBox.BackColor = Color.Salmon;
                ModProdSaveButton.Enabled = false;
            }
        }

        private void ModProdMinTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CheckIfNum(ModProdMinTextBox.Text);
                ModProdMinTextBox.BackColor = Color.White;
                EnableModSaveButton();
            }
            catch (Exception)
            {
                ModProdMinTextBox.BackColor = Color.Salmon;
                ModProdSaveButton.Enabled = false;
            }
        }

        public void CheckIfNum(string checkData)
        {
            var isNum = int.TryParse(checkData, out int n);
            if (isNum == false)
            {
                throw new Exception();
            }
        }

        private void CheckIfDeci(string checkDeci)
        {
            decimal deciNum;
            var isDecimal = decimal.TryParse(checkDeci, out deciNum);
            if (isDecimal == false)
            {
                throw new Exception();
            }
        }

        private bool AreAllFieldsValid()
        {
            return (ModProdNameTextBox.BackColor == Color.White) &&
                   (ModProdStockTextBox.BackColor == Color.White) &&
                   (ModProdPriceTextBox.BackColor == Color.White) &&
                   (ModProdMaxTextBox.BackColor == Color.White) &&
                   (ModProdMinTextBox.BackColor == Color.White);
        }

        private void EnableModSaveButton()
        {
            ModProdSaveButton.Enabled = AreAllFieldsValid();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            BindingList<Part> TempList = new BindingList<Part>();
            bool found = false;
            if (SearchField.Text != "")
            {
                for (int i = 0; i < Inventory.AllParts.Count; i++)
                {
                    if (Inventory.AllParts[i].Name.ToUpper().Contains(SearchField.Text.ToUpper()))
                    {
                        TempList.Add(Inventory.AllParts[i]);
                        found = true;
                    }
                }
                if (found)
                    DataGridPart.DataSource = TempList;
            }
            if (!found)
            {
                DataGridPart.DataSource = Inventory.AllParts;
            }
        }
    }
}