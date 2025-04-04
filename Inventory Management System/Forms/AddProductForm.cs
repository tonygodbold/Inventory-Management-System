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
    public partial class AddProductForm : Form
    {
        //instance of a Product class
        Product product1 = new Product();
        private ToolTip toolTip = new ToolTip();

        //Constructor
        public AddProductForm()
        {
            InitializeComponent();
            formatDGV(DataGridPart);
            formatDGV(DataGridAssociatedPart);
            display();
            AddEventHandlers(); // Call the method to add event handlers
            InitializeToolTips(); // Initialize tooltips
            DeleteButton.Enabled = false; // Disable delete button initially
            SaveButton.Enabled = false; // Disable save button initially
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void display() // re-populate the DGV using the current MyList 
        {
            DataGridPart.DataSource = Inventory.AllParts;
            DataGridAssociatedPart.DataSource = product1.AssociatedParts;
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
            int nextProduct = Inventory.Products.Max(product => product.ProductID) + 1;
            AddProdIDTextBox.Text = nextProduct.ToString();
            AddProdIDTextBox.ReadOnly = true; // Set AddProdIDTextBox to readonly
            AddProdIDTextBox.BackColor = Color.LightGray; // Set background color to light gray
        }

        private void SearchButtonProduct_Click(object sender, EventArgs e)
        {
            BindingList<Part> TempList = new BindingList<Part>();
            bool found = false;
            if (SearchFieldProduct.Text != "")
            {
                for (int i = 0; i < Inventory.AllParts.Count; i++)
                {
                    if (Inventory.AllParts[i].Name.ToUpper().Contains(SearchFieldProduct.Text.ToUpper()))
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

        public static void CompareMinMax(int min, int max)
        {
            if (min > max)
            {
                throw new Exception("Minium value cannot be greater than Max value.");
            }
        }

        public static void CheckInvValues(int inv, int min, int max)
        {
            if (inv < min || inv > max)
            {
                throw new Exception("Inventory cannot be greater than Max or less than Min.");
            }
        }

        // Modify the SaveButton_Click method
        public void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Remove the check for at least one associated part
                // if (product1.AssociatedParts.Count == 0)
                // {
                //     MessageBox.Show("At least one part must be associated with the product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //     return;
                // }

                CompareMinMax(Int32.Parse(AddProdMinTextBox.Text), Int32.Parse(AddProdMaxTextBox.Text));
                CheckInvValues(Int32.Parse(AddProdInvTextBox.Text), Int32.Parse(AddProdMinTextBox.Text), Int32.Parse(AddProdMaxTextBox.Text));

                int AddProdProductID = Int32.Parse(AddProdIDTextBox.Text);

                Product newProduct = new Product
                {
                    ProductID = AddProdProductID,
                    Name = AddProdNameTextBox.Text,
                    Price = Decimal.Parse(AddProdPriceTextBox.Text),
                    InStock = Int32.Parse(AddProdInvTextBox.Text),
                    Min = Int32.Parse(AddProdMinTextBox.Text),
                    Max = Int32.Parse(AddProdMaxTextBox.Text),
                    AssociatedParts = product1.AssociatedParts // Ensure associated parts are saved
                };

                Inventory inventoryInstance = new Inventory();
                inventoryInstance.addProduct(newProduct);

                this.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        //dgvAssociated should display the associated parts 
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
                    if (product1.lookupAssociatedPart(partID) == null)
                    {
                        product1.addAssociatedPart(part);
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

        private void DataGridPart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridPart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //    if (e.RowIndex >= 0)
            //    {
            //        Product.CurrentIndexAssociatedPart = e.RowIndex;
            //        Inventory.Products[Product.CurrentIndexPart].AssociatedParts.RemoveAt(Product.CurrentIndexAssociatedPart);
            //        DataGridAssociatedPart.DataSource = Inventory.AllParts[Product.CurrentIndexPart].AssociatedParts;
            //    }
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
                    product1.removeAssociatedPart(selectedPart.PartID);
                    display(); // Refresh the DataGridView to reflect the change
                }
            }
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
                EnableAddProdSaveButton(); // Check whether to enable the save button
            }
        }

        private void InitializeToolTips()
        {
            toolTip.SetToolTip(AddProdIDTextBox, "This is the product ID.");
            toolTip.SetToolTip(AddProdMaxTextBox, "Enter the maximum inventory level.");
            toolTip.SetToolTip(AddProdMinTextBox, "Enter the minimum inventory level.");
            toolTip.SetToolTip(AddProdPriceTextBox, "Enter the price/cost of the product.");
            toolTip.SetToolTip(AddProdInvTextBox, "Enter the current inventory level.");
            toolTip.SetToolTip(AddProdNameTextBox, "Enter the name of the product.");
        }

        private void AddEventHandlers()
        {
            AddProdIDTextBox.TextChanged += ValidateTextBox;
            AddProdMaxTextBox.TextChanged += ValidateTextBox;
            AddProdMinTextBox.TextChanged += ValidateTextBox;
            AddProdPriceTextBox.TextChanged += ValidateTextBox;
            AddProdInvTextBox.TextChanged += ValidateTextBox;
            AddProdNameTextBox.TextChanged += ValidateTextBox;

            AddProdInvTextBox.TextChanged += AddProdInvTextBox_TextChanged;
            AddProdPriceTextBox.TextChanged += AddProdPriceTextBox_TextChanged;
            AddProdMaxTextBox.TextChanged += AddProdMaxTextBox_TextChanged;
            AddProdMinTextBox.TextChanged += AddProdMinTextBox_TextChanged;

            DataGridAssociatedPart.SelectionChanged += DataGridAssociatedPart_SelectionChanged;
        }

        private void AddProdNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(AddProdNameTextBox.Text))
            {
                AddProdNameTextBox.BackColor = Color.Salmon;
                SaveButton.Enabled = false;
            }
            else
            {
                AddProdNameTextBox.BackColor = Color.White;
                EnableAddProdSaveButton();
            }
        }

        private void AddProdInvTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CheckIfNum(AddProdInvTextBox.Text);
                AddProdInvTextBox.BackColor = Color.White;
                EnableAddProdSaveButton();
            }
            catch (Exception)
            {
                AddProdInvTextBox.BackColor = Color.Salmon;
                SaveButton.Enabled = false;
            }
        }

        private void AddProdPriceTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CheckIfDeci(AddProdPriceTextBox.Text);
                AddProdPriceTextBox.BackColor = Color.White;
                EnableAddProdSaveButton();
            }
            catch (Exception)
            {
                AddProdPriceTextBox.BackColor = Color.Salmon;
                SaveButton.Enabled = false;
            }
        }

        private void AddProdMaxTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CheckIfNum(AddProdMaxTextBox.Text);
                AddProdMaxTextBox.BackColor = Color.White;
                EnableAddProdSaveButton();
            }
            catch (Exception)
            {
                AddProdMaxTextBox.BackColor = Color.Salmon;
                SaveButton.Enabled = false;
            }
        }

        private void AddProdMinTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CheckIfNum(AddProdMinTextBox.Text);
                AddProdMinTextBox.BackColor = Color.White;
                EnableAddProdSaveButton();
            }
            catch (Exception)
            {
                AddProdMinTextBox.BackColor = Color.Salmon;
                SaveButton.Enabled = false;
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
            return (AddProdNameTextBox.BackColor == Color.White) &&
                   (AddProdInvTextBox.BackColor == Color.White) &&
                   (AddProdPriceTextBox.BackColor == Color.White) &&
                   (AddProdMaxTextBox.BackColor == Color.White) &&
                   (AddProdMinTextBox.BackColor == Color.White);
        }

        private void EnableAddProdSaveButton()
        {
            SaveButton.Enabled = AreAllFieldsValid();
        }
    }
}
/*
    private void SearchButtonProduct_Click(object sender, EventArgs e)
        {
            BindingList<Part> TempList = new BindingList<Part>();
            bool found = false;
            if (SearchFieldProduct.Text != "")
            {
                for (int i = 0; i < Inventory.AllParts.Count; i++)
                {
                    if (Inventory.AllParts[i].Name.ToUpper().Contains(SearchFieldProduct.Text.ToUpper()))
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
*/