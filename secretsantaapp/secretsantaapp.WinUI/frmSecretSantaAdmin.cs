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
            var result = await _giftService.Get<List<Model.Models.Gift>>();
            dgvGiftPairs.DataSource = result;
        }
        private async void frmSecretSantaAdmin_Load(object sender, EventArgs e)
        {
            await LoadGiftPairs();
        }

        private async void btnDodaj_Click(object sender, EventArgs e)
        {
            var frm = new frmDodajSecretSantaAdmin();
            frm.ShowDialog();
            await LoadGiftPairs();
        }
    }
}
