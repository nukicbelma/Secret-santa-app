using secretsantaapp.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace secretsantaapp.WinUI
{
    public partial class frmLogin : Form
    {
        private readonly APIService _usersService = new APIService("Users");
        private readonly APIService _rolesService = new APIService("Roles");
        Model.Models.Roles admin = null;
 
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            secretsantaapp.Model.Models.Users User = await _usersService.Authenticiraj<secretsantaapp.Model.Models.Users>(txtUsername.Text, txtPassword.Text);
            int RolesId1 = 0;

            if (User != null)
            {
                LoggedInUser.LoggedUser = User;
                APIService.Username = txtUsername.Text;
                APIService.Password = txtPassword.Text;

                foreach (var item in LoggedInUser.LoggedUser.UsersRoles)
                {
                    RolesId1 = item.RolesId;

                }
                admin = await _rolesService.ProvjeriAdmin<Roles>(RolesId1);

                if (admin != null)
                {
                    LoggedInUser.Admin = true;
                }
                MessageBox.Show("Dobrodosli " + User.FirstName + " " + User.LastName);
                DialogResult = DialogResult.OK;

                if (User.UsersRoles.FirstOrDefault().RolesId == 1)
                {
                    var uposlenik = new frmSecretSanta();
                    uposlenik.ShowDialog();
                }
                else if (User.UsersRoles.FirstOrDefault().RolesId == 3)
                {
                    var uposlenik = new frmSecretSanta();
                    uposlenik.ShowDialog();
                }
                Close();
            }
            else
            {
                MessageBox.Show("Pogresan username ili password", "Autentifikacija", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
