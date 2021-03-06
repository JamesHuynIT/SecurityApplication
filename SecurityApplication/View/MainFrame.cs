﻿using System;
using System.IO.Ports;
using System.Windows.Forms;
using SecurityApplication.Util;

namespace SecurityApplication.View
{
    public partial class MainFrame : Form
    {
        /*
         * Declare variable using in this Form
         */
        // Seriable Port for listening Port of Arduino
        private SerialPort _serialPort;

        private string UserName;

        public MainFrame(string userName)
        {
            UserName = userName;
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            //OpenPort();
        }

        /*
         * Function Open Port for open port
         */

        private void OpenPort()
        {
            _serialPort = new SerialPort
            {
                BaudRate = ConstantVariable.Baudrate,
                PortName = ConstantVariable.Portname
            };
            _serialPort.Open();
        }

        private void MainFrame_Load(object sender, EventArgs e)
        {
        }

        private void btnBackward_Click(object sender, EventArgs e)
        {
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var startFrame = new StartFrame();
            Hide();
            startFrame.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addNewCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addCarFrame = new AddCarFrame(UserName);
            addCarFrame.ShowDialog();
        }
    }
}