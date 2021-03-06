using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace secretsantaapp.WinUI
{
    public partial class frmSecretSantaUposlenik : Form
    {
        APIService _giftService = new APIService("Gift");
        APIService _usersService = new APIService("Users");
        public frmSecretSantaUposlenik()
        {
            InitializeComponent();
        }

        private async void btnSecretSanta_Click(object sender, EventArgs e)
        {
                var model = new Model.Requests.GiftInsertRequest
                {
                    FromUsersId = LoggedInUser.LoggedUser.UsersId
                };
                var santa = await _giftService.Get<List<Model.Models.Gift>>(model);
                var secretsanta = santa.FirstOrDefault();
                if (secretsanta != null)
                {
                    MessageBox.Show($"Vas secret santa je uposlenik: {secretsanta.ToUsers}");
                }
                else
                {
                    MessageBox.Show($"Svi uposlenici su vec darovani!");
                }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
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
