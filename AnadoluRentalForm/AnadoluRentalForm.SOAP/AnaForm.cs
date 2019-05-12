using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnadoluRentalForm
{
    public partial class frmAna : Form
    {
        public frmAna()
        {
            InitializeComponent();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSirket_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSirket frmSirket = new frmSirket();
            frmSirket.ShowDialog();
            this.Show();
        }

        private void btnArac_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmArac frmArac = new frmArac();
            frmArac.ShowDialog();
            this.Show();
        }

        private void btnKiralama_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmKirala frmKirala = new frmKirala();
            frmKirala.ShowDialog();
            this.Show();
        }

        private void txtKullanici_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmKullanici frmKullanici = new frmKullanici();
            frmKullanici.ShowDialog();
            this.Show();
        }
    }
}
