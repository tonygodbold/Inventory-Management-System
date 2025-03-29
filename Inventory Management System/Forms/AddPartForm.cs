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
            //TextLoad();
        }

        //private void TextLoad()

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
            if (AddPartInHouseRadioButton.Checked == true)
            {
                MachineIDCompanyNameLabel.Text = "Machine ID";
                MachineIDCompanyNameLabel.Name = "Machine ID";
                MachineIDCompanyNameLabel.Visible = true;
            }
        }

        private void OutsourcedRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (AddPartOutSourcedRadioButton.Checked == true)
            {
                MachineIDCompanyNameLabel.Text = "Company Name";
                MachineIDCompanyNameLabel.Name = "Company Name";
                MachineIDCompanyNameLabel.Visible = true;
            }
        }

        private void MachineIDCompanyNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void AddPartNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(AddPartNameTextBox.Text))
            {
                AddPartNameTextBox.BackColor = Color.Salmon;
                AddPartSaveButton.Enabled = false;
            }
            else
            {
                AddPartNameTextBox.BackColor = Color.White;
                EnableAddPartSaveButton();
            }
        }

        private void AddPartInvTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CheckIfNum(AddPartInvTextBox.Text);
                AddPartInvTextBox.BackColor = Color.White;
                EnableAddPartSaveButton();
            }
            catch (Exception)
            {
                AddPartInvTextBox.BackColor = Color.Salmon;
                ToolTip toolTipNum = new ToolTip();
                toolTipNum.SetToolTip(AddPartInvTextBox, "Number Values only.");
                AddPartSaveButton.Enabled = false;
            }
        }

        private void AddPartPriceTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CheckIfDeci(AddPartPriceTextBox.Text);
                AddPartPriceTextBox.BackColor = Color.White;
                EnableAddPartSaveButton();
            }
            catch (Exception)
            {
                AddPartPriceTextBox.BackColor = Color.Salmon;
                ToolTip toolTipDeci = new ToolTip();
                toolTipDeci.SetToolTip(AddPartPriceTextBox, "Numeric or decimal values only.");
                AddPartSaveButton.Enabled = false;
            }
        }

        private void AddPartMaxTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CheckIfNum(AddPartMaxTextBox.Text);
                AddPartMaxTextBox.BackColor = Color.White;
                EnableAddPartSaveButton();
            }
            catch (Exception)
            {
                AddPartMaxTextBox.BackColor = Color.Salmon;
                ToolTip toolTipNum = new ToolTip();
                toolTipNum.SetToolTip(AddPartMaxTextBox, "Numeric values only.");
                AddPartSaveButton.Enabled = false;
            }
        }

        private void AddPartMinTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CheckIfNum(AddPartMinTextBox.Text);
                AddPartMinTextBox.BackColor = Color.White;
                EnableAddPartSaveButton();
            }
            catch (Exception)
            {
                AddPartMinTextBox.BackColor = Color.Salmon;
                ToolTip toolTipNum = new ToolTip();
                toolTipNum.SetToolTip(AddPartMinTextBox, "Numeric values only.");
            }
        }

        private void AddPartMachCompTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(AddPartMachCompTextBox.Text))
            {
                AddPartMachCompTextBox.BackColor = Color.Salmon;
                ToolTip toolTipNum = new ToolTip();
                AddPartSaveButton.Enabled = false;

                if (AddPartInHouseRadioButton.Checked)
                {
                    toolTipNum.SetToolTip(AddPartMachCompTextBox, "Numeric values only.");
                }
                else if (AddPartOutSourcedRadioButton.Checked)
                {
                    toolTipNum.SetToolTip(AddPartMachCompTextBox, "Company name only.");
                }
            }
            else
            {
                AddPartMachCompTextBox.BackColor = Color.White;
                EnableAddPartSaveButton();
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

        private void EnableAddPartSaveButton()
        {
            if ((AddPartNameTextBox.BackColor == Color.White) && (AddPartInvTextBox.BackColor == Color.White) && (AddPartPriceTextBox.BackColor == Color.White) && (AddPartMaxTextBox.BackColor == Color.White) && (AddPartMinTextBox.BackColor == Color.White) && (AddPartMachCompTextBox.BackColor == Color.White))
            {
                AddPartSaveButton.Enabled = true;
            }
            else
            {
                AddPartSaveButton.Enabled = false;
                //MessageBox.Show("All values must contain a value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void CheckMachCompValue()
        {
            try
            {
                // If InHouseButton is checked
                if (AddPartInHouseRadioButton.Checked)
                {
                    // Validate if AddPartMachCompTextBox.Text is an integer
                    if (!int.TryParse(AddPartMachCompTextBox.Text, out _))
                    {
                        throw new Exception("Machine ID must be an number value.");
                    }
                }
                // If OutSourcedButton is checked
                else if (AddPartOutSourcedRadioButton.Checked)
                {
                    // Validate if AddPartMachCompTextBox.Text is a non-numeric string
                    if (int.TryParse(AddPartMachCompTextBox.Text, out _))
                    {
                        throw new Exception("Company Name must be a word.");
                    }
                }
                else
                {
                    // Enable Save button if validation passes
                    EnableAddPartSaveButton();
                }
            }
            catch (Exception ex)
            {
                // Display the error message
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void AddPartSaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                CompareMinMax(Int32.Parse(AddPartMinTextBox.Text), Int32.Parse(AddPartMaxTextBox.Text));
                CheckInvValues(Int32.Parse(AddPartInvTextBox.Text), Int32.Parse(AddPartMinTextBox.Text), Int32.Parse(AddPartMaxTextBox.Text));
                CheckMachCompValue();
                
                int AddPartID = Int32.Parse(AddPartIDTextBox.Text);

                //Part newPart = new Part (AddPartID, AddProdNameTextBox.Text, Decimal.Parse(AddProdPriceCostTextBox.Text), Int32.Parse(AddProdInventoryTextBox.Text), Int32.Parse(AddProdMinTextBox.Text), Int32.Parse(AddProdMaxTextBox.Text));

                Part newPart = null;

                if (AddPartInHouseRadioButton.Checked)
                {
                    newPart = new InHouse(
                        AddPartID,
                        AddPartNameTextBox.Text,
                        Decimal.Parse(AddPartPriceTextBox.Text),
                        Int32.Parse(AddPartInvTextBox.Text),
                        Int32.Parse(AddPartMinTextBox.Text),
                        Int32.Parse(AddPartMaxTextBox.Text),
                        Int32.Parse(AddPartMachCompTextBox.Text) // MachineID
                    );
                }
                else if (AddPartOutSourcedRadioButton.Checked)
                {
                    newPart = new OutSourced(
                        AddPartID,
                        AddPartNameTextBox.Text,
                        Decimal.Parse(AddPartPriceTextBox.Text),
                        Int32.Parse(AddPartInvTextBox.Text),
                        Int32.Parse(AddPartMinTextBox.Text),
                        Int32.Parse(AddPartMaxTextBox.Text),
                        AddPartMachCompTextBox.Text // CompanyName
                    );
                }

                Inventory inventoryInstance = new Inventory();

                //Inventory.AllParts.Add(newPart);
                inventoryInstance.addPart(newPart);

                this.Close();

                //MainScreen mainScreenForm = new MainScreen(); // Instantiate the new form
                //mainScreenForm.Show(); // Show the new form
            }

            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}
