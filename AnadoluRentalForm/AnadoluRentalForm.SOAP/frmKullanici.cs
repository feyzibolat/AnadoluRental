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
    public partial class frmKullanici : Form
    {
        public frmKullanici()
        {
            InitializeComponent();
        }

        private void btnYeniKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                bool success;
                using (var kullaniciBusiness = new KullaniciBusiness())
                {
                    success = kullaniciBusiness.KullaniciEkle(new Kullanici()
                    {
                        kullAdi = txtKullAdi.Text,
                        kullSifre = txtKullSifresi.Text,
                        kullRolID = int.Parse(txtKullRolID.Text),
                        kullSirketID = int.Parse(txtKullSirketID.Text),
                        Ad = txtAd.Text,
                        Soyad = txtSoyad.Text,
                        TelNo = txtTelNo.Text,
                        Adres = txtAdresi.Text
                    });
                }
                var message = success ? "Başarıyla eklendi" : "Hata oluştu";

                MessageBox.Show(message);

                inputTemizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error happened: " + ex.Message);
            }

            kullListele();
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
                using (var kullaniciBusiness = new KullaniciBusiness())
                {
                    success = kullaniciBusiness.KullaniciGuncelle(new Kullanici()
                    {
                        kullaniciID = int.Parse(txtKullID.Text),
                        kullAdi = txtKullAdi.Text,
                        kullSifre = txtKullSifresi.Text,
                        kullRolID = int.Parse(txtKullRolID.Text),
                        kullSirketID = int.Parse(txtKullSirketID.Text),
                        Ad = txtAd.Text,
                        Soyad = txtSoyad.Text,
                        TelNo = txtTelNo.Text,
                        Adres = txtAdresi.Text
                    });
                }
                var message = success ? "Başarıyla güncellendi" : "Hata oluştu";

                MessageBox.Show(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error happened: " + ex.Message);
            }

            kullListele();
            inputTemizle();
        }

        private void btnSeciliSil_Click(object sender, EventArgs e)
        {
            try
            {
                bool success;
                using (var kullaniciBusiness = new KullaniciBusiness())
                {
                    success = kullaniciBusiness.KullaniciSilById(int.Parse(dgKullanici.CurrentRow.Cells[0].Value.ToString()));
                }
                var message = success ? "Başarıyla silindi" : "Hata oluştu";

                MessageBox.Show(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error happened: " + ex.Message);
            }

            kullListele();
            inputTemizle();
        }

        private void dgKullanici_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKullID.Text = dgKullanici.CurrentRow.Cells[0].Value.ToString();
            txtKullAdi.Text = dgKullanici.CurrentRow.Cells[1].Value.ToString();
            txtKullSifresi.Text = dgKullanici.CurrentRow.Cells[2].Value.ToString();
            txtKullRolID.Text = dgKullanici.CurrentRow.Cells[3].Value.ToString();
            txtKullSirketID.Text = dgKullanici.CurrentRow.Cells[4].Value.ToString();
            txtAd.Text = dgKullanici.CurrentRow.Cells[5].Value.ToString();
            txtSoyad.Text = dgKullanici.CurrentRow.Cells[6].Value.ToString();
            txtTelNo.Text = dgKullanici.CurrentRow.Cells[7].Value.ToString();
            txtAdresi.Text = dgKullanici.CurrentRow.Cells[8].Value.ToString();
        }

        private void frmKullanici_Load(object sender, EventArgs e)
        {
            //Genel Ayarlar
            kullListele();
            inputTemizle();

            dgKullanici.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dgKullanici.RowHeadersVisible = false;
            dgKullanici.ReadOnly = true;
            dgKullanici.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgKullanici.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgKullanici.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgKullanici.MultiSelect = false;
            dgKullanici.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgKullanici.AllowUserToAddRows = false;
            dgKullanici.Columns[0].HeaderText = "ID";
            dgKullanici.Columns[0].Width = 40;
            dgKullanici.Columns[9].Visible = false;
        }

        void kullListele()
        {
            try
            {
                using (var kullaniciBusiness = new KullaniciBusiness())
                {
                    List<Kullanici> kullList = kullaniciBusiness.SelectAllKullanici().ToList();
                    dgKullanici.DataSource = kullList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error happened: " + ex.Message);
            }

            dgKullanici.ClearSelection();
        }

        void inputTemizle()
        {
            txtKullID.Text = "";
            txtKullAdi.Text = "";
            txtKullSifresi.Text = "";
            txtKullRolID.Text = "";
            txtKullSirketID.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtTelNo.Text = "";
            txtAdresi.Text = "";

            dgKullanici.ClearSelection();
        }
    }
}
