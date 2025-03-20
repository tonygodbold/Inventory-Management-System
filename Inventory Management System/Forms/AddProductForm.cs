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
        public AddProductForm()
        {
            InitializeComponent();
            formatDGV(DataGridPart);
            formatDGV(DataGridAssociatedPart);
            display();

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void display() // re-populate the DGV using the current MyList 
        {
            DataGridPart.DataSource = Inventory.AllParts;
            DataGridAssociatedPart.DataSource = Product.AssociatedParts;
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
                //MessageBox.Show("Nothing found.");
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
                throw new Exception("Inventory cannot be greater than Max or less than Minium.");
            }
        }

        public void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                CompareMinMax(Int32.Parse(AddProdMinTextBox.Text), Int32.Parse(AddProdMaxTextBox.Text));
                CheckInvValues(Int32.Parse(AddProdInventoryTextBox.Text), Int32.Parse(AddProdMinTextBox.Text), Int32.Parse(AddProdMaxTextBox.Text));

                int AddProdProductID = Int32.Parse(AddProdIDTextBox.Text);

                //Product newProduct = new Product (AddProdProductID, AddProdNameTextBox.Text, Decimal.Parse(AddProdPriceCostTextBox.Text), Int32.Parse(AddProdInventoryTextBox.Text), Int32.Parse(AddProdMinTextBox.Text), Int32.Parse(AddProdMaxTextBox.Text));

                Product newProduct = new Product
                {
                    ProductID = AddProdProductID,
                    Name = AddProdNameTextBox.Text,
                    Price = Decimal.Parse(AddProdPriceCostTextBox.Text),
                    InStock = Int32.Parse(AddProdInventoryTextBox.Text),
                    Min = Int32.Parse(AddProdMinTextBox.Text),
                    Max = Int32.Parse(AddProdMaxTextBox.Text)
                };

                Inventory.Products.Add(newProduct);

                this.Close();

            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (Product.CurrentIndexPart >= 0)
            {


                Inventory.Products[Product.CurrentIndexPart].AssociatedParts.Add(Product.AssociatedParts[cbxUpper.SelectedIndex]);
                DataGridAssociatedPart.DataSource = Inventory.AllParts[Product.CurrentIndexPart].AssociatedParts;
            }

            else
            {
                MessageBox.Show("Nothing selected!", "Please select a part to add");
                return;
            }
        }

        private void DataGridPart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridPart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Product.CurrentIndexAssociatedPart = e.RowIndex;
                Inventory.AllProducts[Product.CurrentIndexPart].AssociatedParts.RemoveAt(Product.CurrentIndexAssociatedPart);
                DataGridAssociatedPart.DataSource = Inventory.AllParts[Product.CurrentIndexPart].AssociatedParts;
            }
        }
    }
}
