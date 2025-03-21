using System;
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
        Product product1 = new Product();

        public ModifyProductForm()
        {
            InitializeComponent();
            formatDGV(DataGridPart);
            display();
        }

        private void display() // re-populate the DGV using the current MyList 
        {
            DataGridPart.DataSource = Inventory.AllParts;
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

        private void addAssociatedPart(Part part)
        {
            AssociatedParts.Add(part);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (!DataGridPart.CurrentRow.Selected)
            {
                MessageBox.Show("Nothing selected!", "Please select a part to add");
                return;
            }
            else
            {
                Part part = (Part)DataGridPart.CurrentRow.DataBoundItem; //Grabs current row | Casts DataBoundItem into a type Part

                product1.addAssociatedPart(part);
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
            public void ModProdSaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                CompareMinMax(Int32.Parse(ModProdMinTextBox.Text), Int32.Parse(ModProdMaxTextBox.Text));
                CheckInvValues(Int32.Parse(ModProdStockTextBox.Text), Int32.Parse(ModProdMinTextBox.Text), Int32.Parse(ModProdMaxTextBox.Text));

                int ModID = Int32.Parse(ModProdIDTextBox.Text);

                // Find the part in the list by its ID
                Product productToUpdate = Inventory.Products.FirstOrDefault(product => product.ProductID == ModID);

                if (productToUpdate != null)
                {
                    // Update the existing part
                    productToUpdate.Name = ModProdNameTextBox.Text;
                    productToUpdate.Price = Decimal.Parse(ModProdPriceTextBox.Text);
                    productToUpdate.InStock = Int32.Parse(ModProdStockTextBox.Text);
                    productToUpdate.Min = Int32.Parse(ModProdMinTextBox.Text);
                    productToUpdate.Max = Int32.Parse(ModProdMaxTextBox.Text);
                }

                else
                {
                    // Handle the case when the part with ModProdID doesn't exist
                    MessageBox.Show("Product not found in the inventory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.Close();

            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void ModProd_Load(object sender, EventArgs e)
        {
            if (Inventory.CurrentProduct != null)
            {
                ModProdIDTextBox.Text = Inventory.CurrentProduct.ProductID.ToString();
                ModProdNameTextBox.Text = Inventory.CurrentProduct.Name.ToString();
                ModProdStockTextBox.Text = Inventory.CurrentProduct.InStock.ToString();
                ModProdPriceTextBox.Text = Inventory.CurrentProduct.Price.ToString();
                ModProdMinTextBox.Text = Inventory.CurrentProduct.Min.ToString();
                ModProdMaxTextBox.Text = Inventory.CurrentProduct.Max.ToString();
            }
            else
            {
                ModProdIDTextBox.Text = string.Empty; // Fallback for null
            }
        }
    }
}
