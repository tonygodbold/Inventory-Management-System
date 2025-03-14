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
    public partial class AddProductForm : Form
    {
        public AddProductForm()
        {
            InitializeComponent();
            formatDGV(DataGridPart);
            display();

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void ModInHouseRadioButton_CheckedChanged(object sendee, EventArgs e)
        {
            if (AddProdInHouseRadioButton.Checked == true)
            {
                MachCompLabel.Text = "Machine ID";
                MachCompLabel.Name = "Machine ID";
                MachCompLabel.Visible = true;
            }
        }

        private void ModOutSourcedRadioButton_CheckedChanged(Object sendee, EventArgs e)
        {
            if (AddProdOutSourcedRadioButton.Checked == true)
            {
                MachCompLabel.Text = "Company Name";
                MachCompLabel.Name = "Company Name";
                MachCompLabel.Visible = true;
            }
        }
        private void AddProductForm_Load(object sender, EventArgs e)
        {
            int nextProduct = Inventory.AllProducts.Max(product => product.ProductID) + 1;
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
        public void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                CompareMinMax(Int32.Parse(AddProdMinTextBox.Text), Int32.Parse(AddProdMaxTextBox.Text));
                CheckInvValues(Int32.Parse(AddProdInventoryTextBox.Text), Int32.Parse(AddProdMinTextBox.Text), Int32.Parse(AddProdMaxTextBox.Text));

                int AddPartPartID = Int32.Parse(AddProdIDTextBox.Text);

                if (AddProdInHouseRadioButton.Checked)
                {
                    Part inHouse = new InHouse(AddPartPartID, AddProdNameTextBox.Text, Decimal.Parse(AddProdPriceCostTextBox.Text), Int32.Parse(AddProdInventoryTextBox.Text), Int32.Parse(AddProdMinTextBox.Text), Int32.Parse(AddProdMaxTextBox.Text), Int32.Parse(AddProdMachCompIDTextBox.Text));

                    Inventory.AllParts.Add(inHouse);
                }
                else if (AddProdOutSourcedRadioButton.Checked)
                {
                    Part OutSourced = new OutSourced(AddPartPartID, AddProdNameTextBox.Text, Decimal.Parse(AddProdPriceCostTextBox.Text), Int32.Parse(AddProdInventoryTextBox.Text), Int32.Parse(AddProdMinTextBox.Text), Int32.Parse(AddProdMaxTextBox.Text), AddProdMachCompIDTextBox.Text);

                    Inventory.AllParts.Add(OutSourced);
                }

                this.Close();

            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
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
    }
}
