using System;
using System.Windows.Forms;

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
    }
}