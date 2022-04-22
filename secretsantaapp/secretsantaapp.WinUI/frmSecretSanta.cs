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
    public partial class frmSecretSanta : Form
    {
        APIService _giftService = new APIService("Gift");
        APIService _usersService = new APIService("Users");
        public frmSecretSanta()
        {
            InitializeComponent();
        }

        private async void btnSecretSanta_Click(object sender, EventArgs e)
        {
            var model = new Model.Requests.GiftInsertRequest
            {
                FromUsersId = LoggedInUser.LoggedUser.UsersId
            };
            await _giftService.Insert<Model.Models.Gift>(model);
            
            await UcitajSantu();
        }
        private async Task UcitajSantu()
        {
            try{
                var list = await _giftService.Get<List<Model.Models.Gift>>();
                var mojlist = new List<Model.Models.Gift>();
                foreach (var item in list)
                {
                    if (item.FromUsersId == LoggedInUser.LoggedUser.UsersId)
                        mojlist.Add(item);
                }
                var santa = mojlist.FirstOrDefault();

                var listauposlenika = await _usersService.Get<List<Model.Models.Users>>();
                var secretsanta = new Model.Models.Users();
                foreach (var item in listauposlenika)
                {
                    if (santa.ToUsersId == item.UsersId)
                        secretsanta = item;
                }
                MessageBox.Show($"Vas secret santa je uposlenik: {secretsanta.FirstName} {secretsanta.LastName}");
            }
            catch
            {
                MessageBox.Show("Nemate secret santu.");
            }
        }
    }
}
