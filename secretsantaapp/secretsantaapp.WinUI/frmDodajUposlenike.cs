using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace secretsantaapp.WinUI
{
    public partial class frmDodajUposlenike : Form
    {
        APIService _userService = new APIService("Users");
        APIService _giftService = new APIService("Gift");
        public frmDodajUposlenike()
        {
            InitializeComponent();
            dgvUposlenici.AutoGenerateColumns = false;
        }
        private async Task LoadUsers()
        {
            var result = await _userService.Get<List<Model.Models.Users>>();
            dgvUposlenici.DataSource = result;
        }
        private async void frmDodajSecretSantaAdmin_Load(object sender, EventArgs e)
        {
            await LoadUsers();
        }

        private void cmbDavaoci_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public static string GenerisiString(string atribut,int trenutnibroj)
        {
            string novi = atribut+"_";

            if (trenutnibroj < 10)
            {
                novi += "00" + trenutnibroj;
            }
            else if (trenutnibroj < 100 && trenutnibroj > 9)
            {
                novi += "0" + trenutnibroj;
            }
            else
            {
                novi += trenutnibroj;
            }
            return novi;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            int brojUcesnika = int.Parse(txtBroj.Text.ToString());

            List<Model.Models.Users> list = await _userService.Get<List<Model.Models.Users>>(null);
            int najveci = int.MinValue;
            foreach (var item in list)
            {
                if (item.UsersId > najveci)
                {
                    najveci = item.UsersId;
                }
            }
            int BrojKorisnika = najveci + 1;

            for (int i = 0; i < brojUcesnika; i++)
            {
                var model = new Model.Requests.UsersInsertRequest
                {
                    FirstName=GenerisiString("FirstName", BrojKorisnika),
                    LastName = GenerisiString("LastName", BrojKorisnika),
                    Email = GenerisiString("email", BrojKorisnika)+"@gmail.com",
                    Address = GenerisiString("Address", BrojKorisnika),
                    Phone = GenerisiString("Phone", BrojKorisnika),
                    Password = "test",
                    PasswordPotvrda = "test",
                    Status = false,
                    Username = GenerisiString("Username", BrojKorisnika),
                };
                await _userService.Insert<Model.Models.Users>(model);
                BrojKorisnika++;
            }
            MessageBox.Show($"Uspjesno ste dodali {brojUcesnika} uposlenika!");
           await LoadUsers();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
