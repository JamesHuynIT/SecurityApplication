using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using SecurityApplication.Entity;
using SecurityApplication.Model;
using SecurityApplication.Util;

namespace SecurityApplication.View
{
    public partial class StartFrame : Form
    {
        public StartFrame()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text;
            var password = MD5Parse(txtPassword.Text);

            // Check username or password is null or not
            if ((string.IsNullOrWhiteSpace(username)) || (string.IsNullOrWhiteSpace(password)))
            {
                MessageBox.Show(ConstantVariable.MesageErrorEmpty, @"WARNING", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            // if not null do next
            else
            {
                var database = new Database();

                // Load account from database
                var accountList = database.LoadAccount();

                // Parse into Account
                var account = new Account(username, password);

                // Compare Account input and Account in database
                // if compareNum = 1: Login correct
                // if compareNum = 2: Password incorrect
                // if compareNum = 0: Account doesn't exist
                foreach (var ac in accountList)
                {
                    var compareNum = account.CompareAccount(ac);
                    if (1 == compareNum)
                    {
                        var mainFrame = new MainFrame();
                        Hide();
                        mainFrame.ShowDialog();
                    }

                    else if (0 == compareNum)
                    {
                        MessageBox.Show(ConstantVariable.MesageErrorAccount, @"ERROR", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }

                    else if (2 == compareNum)
                    {
                        MessageBox.Show(ConstantVariable.MesageErrorPassword, @"WARNING", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUsername.ResetText();
            txtPassword.ResetText();
        }

        /*
         * Function MD5Parse use for parse password to MD5
         */

        private string MD5Parse(string password)
        {
            var md5Hash = MD5.Create();
            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            foreach (var t in data)
            {
                sBuilder.Append(t.ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}