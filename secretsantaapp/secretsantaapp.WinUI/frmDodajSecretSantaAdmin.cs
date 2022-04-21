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
    public partial class frmDodajSecretSantaAdmin : Form
    {
        APIService _userService = new APIService("Users");
        APIService _giftService = new APIService("Gift");
        public frmDodajSecretSantaAdmin()
        {
            InitializeComponent();
        }

        private async Task LoadUsers1()
        {
            var result = await _userService.Get<List<secretsantaapp.Model.Models.Users>>();
            cmbPrimaoci.DisplayMember = "FirstName"+"LastName";
            cmbPrimaoci.ValueMember = "UsersId";
            cmbPrimaoci.DataSource = result;
        }
        private async Task LoadUsers2()
        {
            var result = await _userService.Get<List<secretsantaapp.Model.Models.Users>>();
            cmbDavaoci.DisplayMember = "FirstName" + "LastName";
            cmbDavaoci.ValueMember = "UsersId";
            cmbDavaoci.DataSource = result;
        }
        private async void frmDodajSecretSantaAdmin_Load(object sender, EventArgs e)
        {
            await LoadUsers1();
            await LoadUsers2();
        }

        private void cmbDavaoci_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var model = new Model.Requests.GiftInsertRequest
                {
                    DatePublished = DateTime.Now,
                    FromUsersId = int.Parse(cmbDavaoci.SelectedValue.ToString()),
                    ToUsersId = int.Parse(cmbPrimaoci.SelectedValue.ToString())
                };
                await _giftService.Insert<Model.Models.Gift>(model);
            }
            catch
            {
                MessageBox.Show("Podaci nisu validni/Par vec postoji/ Primalac je prethodno darovan.");
            }
        }
    }
}
