using System;
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
            var password = Md5Convert.Md5Parse(txtPassword.Text);

            // Check username or password is null or not
            if ((string.IsNullOrWhiteSpace(username)) || (string.IsNullOrWhiteSpace(password)))
            {
                MessageBox.Show(ConstantVariable.MesageErrorEmpty, @"WARNING", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            // if not null do next
            else
            {
                var database = new DatabaseAccount();

                // Load account from database
                var accountDatabase = database.FindAccount(username);

                // Parse into Account
                var account = new Account(username, password);

                // Compare Account input and Account in database
                // if compareNum = 1: Login correct
                // if compareNum = 2: Password incorrect
                // if compareNum = 0: Account doesn't exist
                var compareNum = account.CompareAccount(accountDatabase);
                if (1 == compareNum)
                {
                    var mainFrame = new MainFrame(username);
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUsername.ResetText();
            txtPassword.ResetText();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}