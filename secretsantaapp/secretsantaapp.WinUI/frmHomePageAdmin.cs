using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace secretsantaapp.WinUI
{
    public partial class frmHomePageAdmin : Form
    {
        public frmHomePageAdmin()
        {
            InitializeComponent();
        }

        private void btnUpravljanje_Click(object sender, EventArgs e)
        {
            var frm = new frmSecretSantaAdmin();
            frm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var frm = new frmConfirmation();
            if (frm.ShowDialog() == DialogResult.Yes)
            {
                Close();
                LoggedInUser.LoggedUser = null;
                var loginPonovo = new frmLogin();
                loginPonovo.ShowDialog();
            }
        }
    }
}
