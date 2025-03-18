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
    public partial class AddPartForm : Form
    {
        public AddPartForm()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddPartForm_Load(object sender, EventArgs e)
        {
            int nextPart = Inventory.AllParts.Max(part => part.PartID) + 1;
            AddPartIDTextBox.Text = nextPart.ToString();
        }

        public void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                CompareMinMax(Int32.Parse(AddPartMinTextBox.Text), Int32.Parse(AddPartMaxTextBox.Text));
                CheckInvValues(Int32.Parse(AddPartInvTextBox.Text), Int32.Parse(AddPartMinTextBox.Text), Int32.Parse(AddPartMaxTextBox.Text));

                int AddPartPartID = Int32.Parse(AddPartIDTextBox.Text);

                if (InHouseRadioButton.Checked)
                {
                    Part inHouse = new InHouse(AddPartPartID, AddPartNameTextBox.Text, Decimal.Parse(AddPartPriceTextBox.Text), Int32.Parse(AddPartInvTextBox.Text), Int32.Parse(AddPartMinTextBox.Text), Int32.Parse(AddPartMaxTextBox.Text), Int32.Parse(AddPartMachineIDCompanyNameTextBox.Text));

                    Inventory.AllParts.Add(inHouse);
                }
                else if (OutsourcedRadioButton.Checked)
                {
                    Part OutSourced = new OutSourced(AddPartPartID, AddPartNameTextBox.Text, Decimal.Parse(AddPartPriceTextBox.Text), Int32.Parse(AddPartInvTextBox.Text), Int32.Parse(AddPartMinTextBox.Text), Int32.Parse(AddPartMaxTextBox.Text), AddPartMachineIDCompanyNameTextBox.Text);

                    Inventory.AllParts.Add(OutSourced);
                }



                this.Close();

                //MainScreen mainScreen = new MainScreen();
                //mainScreen.Show();

                //DataGridPart.DataSource = null;
                //DataGridPart.DataSource = Inventory.AllParts;

            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        public void ResetBindings(bool v)
        {
            /*
            if (v)
                MessageBox.Show("Part added.");
            else
                MessageBox.Show("Part not added.");
            */
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
        private void InHouseRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (InHouseRadioButton.Checked == true)
            {
                MachineIDCompanyNameLabel.Text = "Machine ID";
                MachineIDCompanyNameLabel.Name = "Machine ID";
                MachineIDCompanyNameLabel.Visible = true;
            }
        }

        private void OutsourcedRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (OutsourcedRadioButton.Checked == true)
            {
                MachineIDCompanyNameLabel.Text = "Company Name";
                MachineIDCompanyNameLabel.Name = "Company Name";
                MachineIDCompanyNameLabel.Visible = true;
            }
        }

        private void AddPartMachineIDTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void MachineIDCompanyNameLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
