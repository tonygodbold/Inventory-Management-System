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
            if (AddProdOutsourcedRadioButton.Checked == true)
            {
                MachCompLabel.Text = "Company Name";
                MachCompLabel.Name = "Company Name";
                MachCompLabel.Visible = true;
            }
        }
        private void AddProductForm_Load(object sender, EventArgs e)
        {

        }
    }
}
