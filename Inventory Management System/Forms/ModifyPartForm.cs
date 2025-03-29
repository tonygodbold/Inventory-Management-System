﻿using System;
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


        public ModifyPartForm()
        {
            InitializeComponent();
        }
        
        public void ModInHouseRadioButton_CheckedChanged(object sendee, EventArgs e)
        {
            if (ModInHouseRadioButton.Checked == true)
            {
                ModMachCompLabel.Text = "Machine ID";
                ModMachCompLabel.Name = "Machine ID";
                ModMachCompLabel.Visible = true;
            }
        }

        public void ModOutSourcedRadioButton_CheckedChanged(Object sendee, EventArgs e)
        {
            if (ModOutSourcedRadioButton.Checked == true)
            {
                ModMachCompLabel.Text = "Company Name";
                ModMachCompLabel.Name = "Company Name";
                ModMachCompLabel.Visible = true;
            }
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
                ModPartSaveButton.Enabled = true;
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
                ModPartSaveButton.Enabled = true;
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
                ToolTip toolTipNum = new ToolTip();
                toolTipNum.SetToolTip(ModInvTextBox, "Number Values only.");
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
                ToolTip toolTipDeci = new ToolTip();
                toolTipDeci.SetToolTip(ModPriceTextBox, "Numeric or decimal values only.");
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
                ToolTip toolTipNum = new ToolTip();
                toolTipNum.SetToolTip(ModMaxTextBox, "Numeric values only.");
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
                ToolTip toolTipNum = new ToolTip();
                toolTipNum.SetToolTip(ModMinTextBox, "Numeric values only.");
            }
        }

        private void ModMachCompTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ModMachCompTextBox.Text))
            {
                ModMachCompTextBox.BackColor = Color.Salmon;
                ToolTip toolTipNum = new ToolTip();
                ModPartSaveButton.Enabled = false;

                if (ModInHouseRadioButton.Checked)
                {
                    toolTipNum.SetToolTip(ModMachCompTextBox, "Numeric values only.");
                }
                else if (ModOutSourcedRadioButton.Checked)
                {
                    toolTipNum.SetToolTip(ModMachCompTextBox, "Company name only.");
                }
            }
            else
            {
                ModMachCompTextBox.BackColor = Color.White;
                ModPartSaveButton.Enabled = true;
            }
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
        
        public void ModPartSaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                CompareMinMax(Int32.Parse(ModMinTextBox.Text), Int32.Parse(ModMaxTextBox.Text));
                CheckInvValues(Int32.Parse(ModInvTextBox.Text), Int32.Parse(ModMinTextBox.Text), Int32.Parse(ModMaxTextBox.Text));

                int ModID = Int32.Parse(ModIDTextBox.Text);

                // Find the part in the list by its ID
                Part partToUpdate = Inventory.AllParts.FirstOrDefault(part => part.PartID == ModID);

                //Part updatePart = null;

                if (partToUpdate != null)
                {
                        // Update the existing part
                        partToUpdate.Name = ModPartNameTextBox.Text;
                        partToUpdate.Price = Decimal.Parse(ModPriceTextBox.Text);
                        partToUpdate.InStock = Int32.Parse(ModInvTextBox.Text);
                        partToUpdate.Min = Int32.Parse(ModMinTextBox.Text);
                        partToUpdate.Max = Int32.Parse(ModMaxTextBox.Text);

                    if (ModInHouseRadioButton.Checked && partToUpdate is InHouse inHousePart)
                    {
                        Part inHouse = new InHouse(ModID, ModPartNameTextBox.Text, Decimal.Parse(ModPriceTextBox.Text), Int32.Parse(ModInvTextBox.Text), Int32.Parse(ModMinTextBox.Text), Int32.Parse(ModMaxTextBox.Text), Int32.Parse(ModMachCompTextBox.Text));

                        inHousePart.MachineID = Int32.Parse(ModMachCompTextBox.Text);
                    }
                    else if ((ModOutSourcedRadioButton.Checked && partToUpdate is OutSourced outSourcedPart))
                    {
                        Part OutSourced = new OutSourced(ModID, ModPartNameTextBox.Text, Decimal.Parse(ModPriceTextBox.Text), Int32.Parse(ModInvTextBox.Text), Int32.Parse(ModMinTextBox.Text), Int32.Parse(ModMaxTextBox.Text), ModMachCompTextBox.Text);

                        outSourcedPart.CompanyName = ModMachCompTextBox.Text;
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
            // Assuming Inventory.CurrentIndex is an integer or a string
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
                }
                else if (Inventory.CurrentPart is OutSourced outSourcedPart)
                {
                    ModOutSourcedRadioButton.Checked = true;
                    ModMachCompTextBox.Text = outSourcedPart.CompanyName;
                }
            }
            else
            {
                ModIDTextBox.Text = string.Empty; // Fallback for null
            }
        }

        private void ModInHouseRadioButton_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void InHouseRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //if (ModInHouseRadioButton.Checked == true)
            //{
            //    ModMachCompLabel.Text = "Machine ID";
            //    ModMachCompLabel.Name = "Machine ID";
            //    ModMachCompLabel.Visible = true;
            //}
        }

        private void OutSourcedRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //if (ModOutSourcedRadioButton.Checked == true)
            //{
            //    ModMachCompLabel.Text = "Company Name";
            //    ModMachCompLabel.Name = "Company Name";
            //    ModMachCompLabel.Visible = true;
            //}
        }
                public static void Redirect(Form currentForm, Form targetForm)
        {
            targetForm.Show();
            currentForm.Hide();
        }
    }
}
