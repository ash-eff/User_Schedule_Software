﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace software_2_c969
{
    public partial class FormUpdateCustomer : Form
    {
        private FormMain _parentForm;
        private Customer customer = null;
        public Customer SetCustomer { set { customer = value; PopulateFields(); } }
        public FormUpdateCustomer(FormMain parentForm)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _parentForm = parentForm;
        }

        public void PopulateFields()
        {
            txtId.Text = customer.CustomerID.ToString();
            txtName.Text = customer.Name;
            txtAddress1.Text = customer.Address.Address1;
            txtAddress2.Text = customer.Address.Address2;
            txtPostalCode.Text = customer.Address.PostalCode;
            txtPhone.Text = customer.Address.Phone;
            txtCity.Text = customer.Address.City.Name;
            txtCountry.Text = customer.Address.City.Country.Name;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateCustomer();
            CustomerRecords.UpdateCustomerData(customer, _parentForm.GetWorkingUser.Name);
            this.Hide();
        }

        private void UpdateCustomer()
        {
            customer.Name = txtName.Text;
            customer.Address.Address1 = txtAddress1.Text;
            customer.Address.Address2 = txtAddress2.Text;
            customer.Address.PostalCode = txtPostalCode.Text;
            customer.Address.Phone = txtPhone.Text;
            customer.Address.City.Name = txtCity.Text;
            customer.Address.City.Country.Name = txtCountry.Text;
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            _parentForm.RefreshData();
        }
    }
}