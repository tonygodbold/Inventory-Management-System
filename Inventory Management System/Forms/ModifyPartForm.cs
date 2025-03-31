using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inventory_Management_System.Models;

namespace Inventory_Management_System
{
    public partial class ModifyPartForm : Form
    {
        MainScreen mainScreen = (MainScreen)Application.OpenForms["MainScreen"];
        Inventory part3 = new Inventory();
        private ToolTip toolTip = new ToolTip();

        public ModifyPartForm()
        {
            InitializeComponent();
            InitializeToolTips(); // Initialize tooltips
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void EnableModSaveButton()
        {
            if ((ModPartNameTextBox.BackColor == Color.White) && (ModInvTextBox.BackColor == Color.White) && (ModPriceTextBox.BackColor == Color.White) && (ModMaxTextBox.BackColor == Color.White) && (ModMinTextBox.BackColor == Color.White) && (ModMachCompTextBox.BackColor == Color.White))
            {
                ModPartSaveButton.Enabled = true;
            }
            else
            {
                ModPartSaveButton.Enabled = false;
            }
        }

        private void ModPartNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ModPartNameTextBox.Text))
            {
                ModPartNameTextBox.BackColor = Color.Salmon;
                ModPartSaveButton.Enabled = false;
            }
            else
            {
                ModPartNameTextBox.BackColor = Color.White;
                EnableModSaveButton();
            }
        }

        private void ModIDTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ModIDTextBox.Text))
            {
                ModIDTextBox.BackColor = Color.Salmon;
                ModPartSaveButton.Enabled = false;
            }
            else
            {
                ModIDTextBox.BackColor = Color.White;
                EnableModSaveButton();
            }

        }

        private void ModInvTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CheckIfNum(ModInvTextBox.Text);
                ModInvTextBox.BackColor = Color.White;
                EnableModSaveButton();
            }
            catch (Exception)
            {
                ModInvTextBox.BackColor = Color.Salmon;
                ModPartSaveButton.Enabled = false;
            }
        }

        private void ModPriceTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CheckIfDeci(ModPriceTextBox.Text);
                ModPriceTextBox.BackColor = Color.White;
                EnableModSaveButton();
            }
            catch (Exception)
            {
                ModPriceTextBox.BackColor = Color.Salmon;
                ModPartSaveButton.Enabled = false;
            }
        }

        private void ModMaxTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CheckIfNum(ModMaxTextBox.Text);
                ModMaxTextBox.BackColor = Color.White;
                EnableModSaveButton();
            }
            catch (Exception)
            {
                ModMaxTextBox.BackColor = Color.Salmon;
                ModPartSaveButton.Enabled = false;
            }
        }

        private void ModMinTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CheckIfNum(ModMinTextBox.Text);
                ModMinTextBox.BackColor = Color.White;
                EnableModSaveButton();
            }
            catch (Exception)
            {
                ModMinTextBox.BackColor = Color.Salmon;
                ModPartSaveButton.Enabled = false;
            }
        }

        private void ModMachCompTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ModMachCompTextBox.Text))
            {
                ModMachCompTextBox.BackColor = Color.Salmon;
                ModPartSaveButton.Enabled = false;
            }
            else
            {
                ModMachCompTextBox.BackColor = Color.White;
                EnableModSaveButton();
            }
        }

        private static void CompareMinMax(int min, int max)
        {
            if (min > max)
            {
                throw new Exception("Min value cannot be greater than Max value.");
            }
        }

        private static void CheckInvValues(int inv, int min, int max)
        {
            if (inv < min || inv > max)
            {
                throw new Exception("Inventory cannot be greater than Max or less than Min.");
            }
        }

        public string modPartID
        {
            get
            {
                return this.ModIDTextBox.Text;
            }
            set
            {
                this.ModIDTextBox.Text = value;
            }
        }
        private void CheckIfString()
        {
            // Validate if AddPartMachCompTextBox.Text is an integer
            if (!int.TryParse(ModIDTextBox.Text, out _))
            {
                throw new Exception("ID must be an number value.");
            }
        }

        private void CheckMachCompValue()
        {
            {
                // If InHouseButton is checked
                if (ModInHouseRadioButton.Checked)
                {
                    // Validate if AddPartMachCompTextBox.Text is an integer
                    if (!int.TryParse(ModMachCompTextBox.Text, out _))
                    {
                        throw new Exception("Machine ID must be an number value.");
                    }
                }
                // If OutSourcedButton is checked
                else if (ModOutSourcedRadioButton.Checked)
                {
                    // Validate if AddPartMachCompTextBox.Text is a non-numeric string
                    if (int.TryParse(ModMachCompTextBox.Text, out _))
                    {
                        throw new Exception("Company Name must be a word.");
                    }
                }
                else
                {
                    // Enable Save button if validation passes
                    EnableModSaveButton();
                }
            }
        }
        public void ModPartSaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                CompareMinMax(Int32.Parse(ModMinTextBox.Text), Int32.Parse(ModMaxTextBox.Text));
                CheckInvValues(Int32.Parse(ModInvTextBox.Text), Int32.Parse(ModMinTextBox.Text), Int32.Parse(ModMaxTextBox.Text));
                CheckMachCompValue(); 
                CheckIfString();

                int ModID = Int32.Parse(ModIDTextBox.Text);

                // Find the part in the list by its ID
                Part partToUpdate = Inventory.AllParts.FirstOrDefault(part => part.PartID == ModID);

                if (partToUpdate != null)
                {
                    // Update the existing part
                    partToUpdate.Name = ModPartNameTextBox.Text;
                    partToUpdate.Price = Decimal.Parse(ModPriceTextBox.Text);
                    partToUpdate.InStock = Int32.Parse(ModInvTextBox.Text);
                    partToUpdate.Min = Int32.Parse(ModMinTextBox.Text);
                    partToUpdate.Max = Int32.Parse(ModMaxTextBox.Text);

                    if (ModInHouseRadioButton.Checked)
                    {
                        if (partToUpdate is OutSourced)
                        {
                            partToUpdate = new InHouse(
                                partToUpdate.PartID,
                                partToUpdate.Name,
                                partToUpdate.Price,
                                partToUpdate.InStock,
                                partToUpdate.Min,
                                partToUpdate.Max,
                                Int32.Parse(ModMachCompTextBox.Text));
                        }
                        else if (partToUpdate is InHouse inHousePart)
                        {
                            inHousePart.MachineID = Int32.Parse(ModMachCompTextBox.Text);
                        }
                    }
                    else if (ModOutSourcedRadioButton.Checked)
                    {
                        if (partToUpdate is InHouse)
                        {
                            partToUpdate = new OutSourced(
                                partToUpdate.PartID,
                                partToUpdate.Name,
                                partToUpdate.Price,
                                partToUpdate.InStock,
                                partToUpdate.Min,
                                partToUpdate.Max,
                                ModMachCompTextBox.Text);
                        }
                        else if (partToUpdate is OutSourced outSourcedPart)
                        {
                            outSourcedPart.CompanyName = ModMachCompTextBox.Text;
                        }
                    }
                }

                Inventory inventoryInstance = new Inventory();

                inventoryInstance.updatePart(partToUpdate.PartID, partToUpdate);

                this.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void ReloadDataGridView(DataGridView q)
        {
            // Clear the current data source (optional, but ensures no stale data)
            q.DataSource = null;

            // Re-assign the data source
            q.DataSource = Inventory.AllParts;
        }

        private void ModifyPartForm_Load(object sender, EventArgs e)
        {
            if (Inventory.CurrentPart != null)
            {
                ModIDTextBox.Text = Inventory.CurrentPart.PartID.ToString();
                ModPartNameTextBox.Text = Inventory.CurrentPart.Name.ToString();
                ModInvTextBox.Text = Inventory.CurrentPart.InStock.ToString();
                ModPriceTextBox.Text = Inventory.CurrentPart.Price.ToString();
                ModMinTextBox.Text = Inventory.CurrentPart.Min.ToString();
                ModMaxTextBox.Text = Inventory.CurrentPart.Max.ToString();

                if (Inventory.CurrentPart is InHouse inHousePart)
                {
                    ModInHouseRadioButton.Checked = true;
                    ModMachCompTextBox.Text = inHousePart.MachineID.ToString();
                    //toolTip.SetToolTip(ModMachCompTextBox, "Enter the machine ID.");
                }
                else if (Inventory.CurrentPart is OutSourced outSourcedPart)
                {
                    ModOutSourcedRadioButton.Checked = true;
                    ModMachCompTextBox.Text = outSourcedPart.CompanyName;
                    //toolTip.SetToolTip(ModMachCompTextBox, "Enter the company name.");
                }
            }
            else
            {
                ModIDTextBox.Text = string.Empty; // Fallback for null
            }
        }

        private void ModInHouseRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (ModInHouseRadioButton.Checked)
            {
                ModMachCompLabel.Text = "Machine ID";
                ModMachCompLabel.Name = "Machine ID";
                ModMachCompTextBox.Clear();
                toolTip.SetToolTip(ModMachCompTextBox, "Enter the machine ID.");
            }
        }

        private void ModOutSourcedRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (ModOutSourcedRadioButton.Checked)
            {
                ModMachCompLabel.Text = "Company Name";
                ModMachCompLabel.Name = "Company Name";
                ModMachCompTextBox.Clear();
                toolTip.SetToolTip(ModMachCompTextBox, "Enter the company name.");
            }
        }

        private void InitializeToolTips()
        {
            toolTip.SetToolTip(ModIDTextBox, "This is the part ID.");
            toolTip.SetToolTip(ModPartNameTextBox, "Enter the name of the part.");
            toolTip.SetToolTip(ModInvTextBox, "Enter the current inventory level.");
            toolTip.SetToolTip(ModPriceTextBox, "Enter the price/cost of the part.");
            toolTip.SetToolTip(ModMaxTextBox, "Enter the maximum inventory level.");
            toolTip.SetToolTip(ModMinTextBox, "Enter the minimum inventory level.");
            //toolTip.SetToolTip(ModMachCompTextBox, "Enter the machine ID or company name, depending on the part type.");
        }
    }
}