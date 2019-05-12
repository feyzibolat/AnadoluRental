using AnadoluRental.Business;
using AnadoluRental.Models.Models;
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
    public partial class frmKirala : Form
    {
        public frmKirala()
        {
            InitializeComponent();
        }

        private void btnAracKirala_Click(object sender, EventArgs e)
        {
            try
            {
                bool success;
                using (var kiralikBusiness = new KiralikBusiness())
                {
                    success = kiralikBusiness.AracKirala(new Kiralik()
                    {
                        kiralananAracID = int.Parse(txtKiraAracID.Text),
                        kiraTarihi = DateTime.Parse(dtpKiraTarihi.Text),
                        verilisKM = int.Parse(txtVerilisKM.Text),
                        kiraBitisKM = int.Parse(txtKiraBitisKM.Text),
                        kiraAlinanUcret = int.Parse(txtAlinanUcret.Text),
                        kiralayanKulID = int.Parse(txtKullID.Text)
                    });
                }
                var message = success ? "Araç Kiralama Başarılı" : "Hata oluştu";

                MessageBox.Show(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error happened: " + ex.Message);
            }

            kiralananListele();
            inputTemizle();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            inputTemizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                bool success;
                using (var kiralikBusiness = new KiralikBusiness())
                {
                    success = kiralikBusiness.KiralikGuncelle(new Kiralik()
                    {
                        kiraID = int.Parse(txtKiraID.Text),
                        kiralananAracID = int.Parse(txtKiraAracID.Text),
                        kiraTarihi = DateTime.Parse(dtpKiraTarihi.Text),
                        verilisKM = int.Parse(txtVerilisKM.Text),
                        kiraBitisKM = int.Parse(txtKiraBitisKM.Text),
                        kiraAlinanUcret = int.Parse(txtAlinanUcret.Text),
                        kiralayanKulID = int.Parse(txtKullID.Text)
                    });
                }
                var message = success ? "Başarıyla güncellendi" : "Hata oluştu";

                MessageBox.Show(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error happened: " + ex.Message);
            }

            kiralananListele();
            inputTemizle();
        }

        private void btnSeciliSil_Click(object sender, EventArgs e)
        {
            try
            {
                bool success;
                using (var kiralikBusiness = new KiralikBusiness())
                {
                    success = kiralikBusiness.KiralikSilById(int.Parse(dgKiralananAraclar.CurrentRow.Cells[0].Value.ToString()));
                }
                var message = success ? "Kiralama başarıyla sonlandı" : "Hata oluştu";

                MessageBox.Show(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error happened: " + ex.Message);
            }

            kiralananListele();
            inputTemizle();
        }

        private void dgKiralananAraclar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKiraID.Text = dgKiralananAraclar.CurrentRow.Cells[0].Value.ToString();
            txtKiraAracID.Text = dgKiralananAraclar.CurrentRow.Cells[1].Value.ToString();
            dtpKiraTarihi.Text = dgKiralananAraclar.CurrentRow.Cells[2].Value.ToString();
            txtVerilisKM.Text = dgKiralananAraclar.CurrentRow.Cells[3].Value.ToString();
            txtKiraBitisKM.Text = dgKiralananAraclar.CurrentRow.Cells[4].Value.ToString();
            txtAlinanUcret.Text = dgKiralananAraclar.CurrentRow.Cells[5].Value.ToString();
            txtKullID.Text = dgKiralananAraclar.CurrentRow.Cells[6].Value.ToString();
        }

        private void frmKirala_Load(object sender, EventArgs e)
        {
            //Genel Ayarlar
            kiralananListele();
            inputTemizle();

            dgKiralananAraclar.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dgKiralananAraclar.RowHeadersVisible = false;
            dgKiralananAraclar.ReadOnly = true;
            dgKiralananAraclar.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgKiralananAraclar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgKiralananAraclar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgKiralananAraclar.MultiSelect = false;
            dgKiralananAraclar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgKiralananAraclar.AllowUserToAddRows = false;
            dgKiralananAraclar.Columns[0].Width = 40;
            dgKiralananAraclar.Columns[7].Visible = false;
            dgKiralananAraclar.Columns[8].Visible = false;
        }

        void kiralananListele()
        {
            try
            {
                using (var kiralikBusiness = new KiralikBusiness())
                {
                    List<Kiralik> kiraList = kiralikBusiness.SelectAllKiralik().ToList();
                    dgKiralananAraclar.DataSource = kiraList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error happened: " + ex.Message);
            }

            dgKiralananAraclar.ClearSelection();
        }

        void inputTemizle()
        {
            txtKiraID.Text = "";
            txtKiraAracID.Text = "";
            dtpKiraTarihi.Text = "";
            txtVerilisKM.Text = "";
            txtKiraBitisKM.Text = "";
            txtAlinanUcret.Text = "";
            txtKullID.Text = "";

            dgKiralananAraclar.ClearSelection();
        }
    }
}
