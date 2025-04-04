using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inventory_Management_System.Models;

namespace Inventory_Management_System
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
            formatDGV(DataGridPart);
            formatDGV(DataGridProduct);
            display();
        }

        private void display() // re-populate the DGV using the current MyList 
        {
            DataGridPart.DataSource = null;
            DataGridPart.DataSource = Inventory.AllParts;
            DataGridPart.Refresh();

            DataGridProduct.DataSource = null;
            DataGridProduct.DataSource = Inventory.Products;
            DataGridProduct.Refresh();
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
            d.AutoGenerateColumns = true;

            foreach (DataGridViewColumn column in d.Columns)
            {
                column.HeaderCell.Value = column.Index.ToString();
            }
        }
        public static void Redirect(Form currentForm, Form targetForm)
        {
            targetForm.Show();
            currentForm.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Inventory.CurrentIndex = e.RowIndex;
            //Inventory.CurrentObject = Inventory.AllParts[Inventory.CurrentIndex];
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Inventory.CurrentIndex = e.RowIndex;
            Inventory.CurrentPart = Inventory.AllParts[Inventory.CurrentIndex];
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Inventory.CurrentIndex = e.RowIndex;
            //Inventory.CurrentProduct = Inventory.Products[Inventory.CurrentIndex];
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddPartForm addPartForm = new AddPartForm(); // Instantiate the new form
            addPartForm.Show(); // Show the new form

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void SearchButtonPart_Click(object sender, EventArgs e)
        {
            BindingList<Part> TempList = new BindingList<Part>();
            bool found = false;
            if (SearchFieldPart.Text != "")
            {
                for (int i = 0; i < Inventory.AllParts.Count; i++)
                {
                    if (Inventory.AllParts[i].Name.ToUpper().Contains(SearchFieldPart.Text.ToUpper()))
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
                MessageBox.Show("Nothing found.");
                DataGridPart.DataSource = Inventory.AllParts;
            }
        }

        private void ExitApplication_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DataGridPart_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            //// Deselect rows if user clicks outside the data grid cells
            //if (e.RowIndex == -1 && e.ColumnIndex == -1) // Header or outside of cells
            //{
            //    DataGridPart.ClearSelection();
            //}
        }


        public void ModifyPart_Click(object sender, EventArgs e)
        {
            
            // Verify if a part is selected, assuming Inventory.CurrentIndex represents the selected part
            if (DataGridPart.SelectedRows.Count > 0)
            {
                int rowIndex = DataGridPart.SelectedRows[0].Index;
                var selectedPart = (Part)DataGridPart.SelectedRows[0].DataBoundItem;

                ModifyPartForm modifyPartForm = new ModifyPartForm(); // Instantiate the new form
                modifyPartForm.Show(); // Show the new form
            }
            else
            {
                MessageBox.Show("No part is selected. Please select a part to modify.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void AddProduct_Click(object sender, EventArgs e)
        {
            AddProductForm addProductForm = new AddProductForm();
            addProductForm.Show();
        }

        private void ModifyProduct_Click(object sender, EventArgs e)
        {
            if (!DataGridProduct.CurrentRow.Selected)
            {
                MessageBox.Show("No product is selected. Please select a product to modify.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int productID = ((Product)DataGridProduct.CurrentRow.DataBoundItem).ProductID;

                Inventory inventoryInstance = new Inventory();

                Product product = inventoryInstance.lookupProduct(productID);

                if (product != null)
                {
                    ModifyProductForm modifyProductForm = new ModifyProductForm();
                    modifyProductForm.Show();
                }
                else
                {
                    MessageBox.Show("Product not found!");
                }
            }
        }

        private void DeletePart_Click(object sender, EventArgs e)
        {
            if (DataGridPart.CurrentRow == null || !DataGridPart.CurrentRow.Selected)
            {
                MessageBox.Show("Nothing selected!", "Please make a selection.");
                return;
            }

            Part selectedPart = DataGridPart.CurrentRow.DataBoundItem as Part;

            if (selectedPart == null)
            {
                MessageBox.Show("Selected part is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the selected part is associated with any products
            List<Product> associatedProducts = Inventory.Products.Where(product => product.AssociatedParts.Contains(selectedPart)).ToList();

            if (associatedProducts.Count > 0)
            {
                string productNames = string.Join(", ", associatedProducts.Select(p => p.Name));
                MessageBox.Show($"This part is associated with at least one product. You must remove this part from its associated product(s) before it can be deleted.\n\nAssociated Parts:\n{productNames}", "Part Associated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Show confirmation dialog
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this part?",
                "Delete Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            // Check the user's choice
            if (result == DialogResult.Yes)
            {
                // Logic to delete the part
                Inventory inventory = new Inventory();
                inventory.deletePart(selectedPart);

                MessageBox.Show("Part has been deleted.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh the DataGridView to reflect the change
                DataGridPart.DataSource = null;
                DataGridPart.DataSource = Inventory.AllParts;
            }
            else
            {
                // Logic for cancelling the delete action
                MessageBox.Show("Delete action has been cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void myBindingCompleteProduct(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridProduct.ClearSelection();

        }

        private void myBindingCompletePart(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridPart.ClearSelection();
        }

        private void DeleteProduct_Click(object sender, EventArgs e)
        {
            if (DataGridProduct.CurrentRow == null || !DataGridProduct.CurrentRow.Selected)
            {
                MessageBox.Show("Nothing selected!", "Please make a selection.");
                return;
            }

            // Show confirmation dialog
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this product?",
                "Delete Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            // Check the user's choice
            if (result == DialogResult.Yes)
            {
                // Logic to delete the product
                MessageBox.Show("Product has been deleted.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Product P = DataGridProduct.CurrentRow.DataBoundItem as Product;

                Inventory inventoryInstance = new Inventory();
                inventoryInstance.removeProduct(P.ProductID);
            }
            else
            {
                // Logic for cancelling the delete action
                MessageBox.Show("Delete action has been cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SearchButtonProduct_Click(object sender, EventArgs e)
        {
            BindingList<Product> TempList = new BindingList<Product>();
            bool found = false;
            if (SearchFieldProduct.Text != "")
            {
                for (int i = 0; i < Inventory.Products.Count; i++)
                {
                    if (Inventory.Products[i].Name.ToUpper().Contains(SearchFieldProduct.Text.ToUpper()))
                    {
                        TempList.Add(Inventory.Products[i]);
                        found = true;
                    }
                }
                if (found)
                    DataGridProduct.DataSource = TempList;
            }
            if (!found)
            {
                MessageBox.Show("Nothing found.");
                DataGridProduct.DataSource = Inventory.Products;
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Inventory.CurrentIndex = e.RowIndex;
            Inventory.CurrentProduct = Inventory.Products[Inventory.CurrentIndex];
        }
    }
}
