﻿using System;
using System.Windows.Forms;
using SecurityApplication.Entity;
using SecurityApplication.Model;
using SecurityApplication.Util;

namespace SecurityApplication.View
{
    public partial class AddCarFrame : Form
    {
        public AddCarFrame()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var hostName = txtHostName.Text;
            var displayName = txtDisplayName.Text;
            var userName = txtUserName.Text;
            var password = Md5Convert.Md5Parse(txtHostName.Text);

            var car = new Car(hostName, displayName, userName, password);

            var database = new DatabaseCar();

            var insert = database.AddNewCar(car);
            if (insert)
            {
                MessageBox.Show(ConstantVariable.MesageInformation, @"INFORMATION", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show(ConstantVariable.MesageInformation, @"INFORMATION", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
            }

        }

        private void AddCarFrame_Load(object sender, EventArgs e)
        {

        }
    }
}