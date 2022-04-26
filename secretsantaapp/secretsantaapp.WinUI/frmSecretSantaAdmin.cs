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
    public partial class frmSecretSantaAdmin : Form
    {
        APIService _giftService = new APIService("Gift");
        public frmSecretSantaAdmin()
        {
            InitializeComponent();
            dgvGiftPairs.AutoGenerateColumns = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private async Task LoadGiftPairs()
        {
            var model = new Model.Requests.GiftSearchRequest { };
            var result = await _giftService.Get<List<Model.Models.Gift>>(model); 
            dgvGiftPairs.DataSource = result;
        }
        private async Task  LoadNoSanta()
        {
            var m = new Model.Requests.GiftSearchRequest { };
            var result = await _giftService.GetNoSecretSanta<List<Model.Models.Users>>(m);
            if (result.Count > 0)
            {
                var s = result.FirstOrDefault();
                label2.Text = s.ToString();
            }
        }
        private async void frmSecretSantaAdmin_Load(object sender, EventArgs e)
        {
            await LoadGiftPairs();
             await LoadNoSanta();
        }

        private async void btnGenerisi_Click(object sender, EventArgs e)
        {
            var model = new Model.Requests.GiftInsertRequest {};
            await _giftService.Insert<Model.Models.Gift>(model);
            await LoadGiftPairs();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            var frm = new frmDodajUposlenike();
            frm.ShowDialog();
            
        }
       
       
        private async void btnIzbrisi_Click(object sender, EventArgs e)
        {
            await _giftService.Delete<Model.Models.Gift>();
            await LoadGiftPairs();
            MessageBox.Show("Uspjesno ste obrisali podatke");
        }
    }
}
