﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inventory_Management_System.Models;

namespace Inventory_Management_System
{
    public partial class ModifyPartForm : Form
    {
        MainScreen mainScreen = (MainScreen)Application.OpenForms["MainScreen"];

        public ModifyPartForm()
        {
            InitializeComponent();
        }
        /*
            Part PartsGV = Part.lookupPart(partID);

            String CoName = "";
            String MachID = "0";

            ModIDTextBox.Text = PartsGV.PartID.ToString();
            ModPartNameTextBox.Text = PartsGV.Name;
            ModInvTextBox.Text = PartsGV.InStock.ToString();
            ModPriceTextBox.Text = PartsGV.Price.ToString();
            ModMinTextBox.Text = PartsGV.Min.ToString();
            ModMaxTextBox.Text = PartsGV.Max.ToString();

            try
            {
                MachID = PartsGV.MachineID.ToString();
                if (MachID != "0")
                {
                    ModMachCompTextBox.Text = MachID;
                    this.ModInHouseRadioButton.Checked = true;
                    CoName = "";
                }
            }
            catch (NullReferenceException) { }

            try
            {
                CoName = PartsGV.CompanyName.ToString();
                if (MachID == "0")
                {
                    CoName = PartsGV.CompanyName.ToString();
                    ModMachCompTextBox.Text = CoName;
                    this.ModOutSourcedRadioButton.Checked = true;
                }
            }
            catch (NullReferenceException) { }
        }
        */
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
            if (ModInHouseRadioButton.Checked)
            {
                if (string.IsNullOrWhiteSpace(ModMachCompTextBox.Text) || !(int.TryParse(ModMachCompTextBox.Text, out int x)))
                {
                    ModPartSaveButton.Enabled = false;
                }
            }
            if (ModOutSourcedRadioButton.Checked)
            {
                if (string.IsNullOrWhiteSpace(ModMachCompTextBox.Text))
                {
                    ModPartSaveButton.Enabled = false;
                }
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
        
        private void ModPartSaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                CompareMinMax(Int32.Parse(ModMinTextBox.Text), Int32.Parse(ModMaxTextBox.Text));
                CheckInvValues(Int32.Parse(ModInvTextBox.Text), Int32.Parse(ModMinTextBox.Text), Int32.Parse(ModMaxTextBox.Text));

                int ModID = Int32.Parse(modPartID);

                if (ModInHouseRadioButton.Checked)
                {
                    Part inHouse = new InHouse(ModID, ModPartNameTextBox.Text, Decimal.Parse(ModPriceTextBox.Text), Int32.Parse(ModInvTextBox.Text), Int32.Parse(ModMinTextBox.Text), Int32.Parse(ModMaxTextBox.Text), Int32.Parse(ModMachCompTextBox.Text));

                    Inventory.AllParts.Add(inHouse);
                }
                else if (ModOutSourcedRadioButton.Checked)
                {
                    Part OutSourced = new OutSourced(ModID, ModPartNameTextBox.Text, Decimal.Parse(ModPriceTextBox.Text), Int32.Parse(ModInvTextBox.Text), Int32.Parse(ModMinTextBox.Text), Int32.Parse(ModMaxTextBox.Text), ModMachCompTextBox.Text);

                    Inventory.AllParts.Add(OutSourced);
                }

                this.Close();

            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void ModifyPartForm_Load(object sender, EventArgs e)
        {
            // Assuming Inventory.CurrentIndex is an integer or a string
            if (Inventory.CurrentObject != null)
            {
                ModIDTextBox.Text = Inventory.CurrentObject.PartID.ToString();
                ModPartNameTextBox.Text = Inventory.CurrentObject.Name.ToString();
                ModInvTextBox.Text = Inventory.CurrentObject.InStock.ToString();
                ModPriceTextBox.Text = Inventory.CurrentObject.Price.ToString();
                ModMinTextBox.Text = Inventory.CurrentObject.Min.ToString();
                ModMaxTextBox.Text = Inventory.CurrentObject.Max.ToString();

                if (Inventory.CurrentObject is InHouse inHousePart)
                {
                    ModInHouseRadioButton.Checked = true;
                    ModMachCompTextBox.Text = inHousePart.MachineID.ToString();
                }
                else if (Inventory.CurrentObject is OutSourced outSourcedPart)
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
    }
}
