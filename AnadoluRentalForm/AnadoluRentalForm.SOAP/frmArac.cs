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
    public partial class frmArac : Form
    {
        public frmArac()
        {
            InitializeComponent();
        }

        private void frmArac_Load(object sender, EventArgs e)
        {
            //Genel Ayarlar
            aracListele();
            inputTemizle();

            dgAracListesi.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dgAracListesi.RowHeadersVisible = false;
            dgAracListesi.ReadOnly = true;
            dgAracListesi.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgAracListesi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgAracListesi.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgAracListesi.MultiSelect = false;
            dgAracListesi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgAracListesi.AllowUserToAddRows = false;
            dgAracListesi.Columns[0].Width = 50;
            dgAracListesi.Columns[12].Visible = false;
            dgAracListesi.Columns[13].Visible = false;
        }

        private void btnYeniArac_Click(object sender, EventArgs e)
        {
            try
            {
                bool success;
                using (var aracBusiness = new AracBusiness())
                {
                    success = aracBusiness.AracEkle(new Arac()
                    {
                        aracMarka = txtAracMarka.Text,
                        aracModel = txtAracModel.Text,
                        gerekenEhliyetYasi = int.Parse(txtGerekenEhliyetYasi.Text),
                        minYasSiniri = int.Parse(txtMinYasSiniri.Text),
                        gunlukSinirKM = int.Parse(txtGunlukSinir.Text),
                        aracKM = int.Parse(txtAracKM.Text),
                        airBagSayisi = int.Parse(txtAirBagSayisi.Text),
                        bagacHacmi = int.Parse(txtBagajHacmi.Text),
                        koltukSayisi = int.Parse(txtKoltukSayisi.Text),
                        gunlukKiralikFiyati = int.Parse(txtGunlukKiralikFiyati.Text),
                        aitOlduguSirketID = int.Parse(txtAitOlduguSirketID.Text)

                    });
                }
                var message = success ? "Başarıyla eklendi" : "Hata oluştu";

                MessageBox.Show(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error happened: " + ex.Message);
            }

            aracListele();
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
                using (var aracBusiness = new AracBusiness())
                {
                    success = aracBusiness.AracGuncelle(new Arac()
                    {
                        aracID = int.Parse(txtAracID.Text),
                        aracMarka = txtAracMarka.Text,
                        aracModel = txtAracModel.Text,
                        gerekenEhliyetYasi = int.Parse(txtGerekenEhliyetYasi.Text),
                        minYasSiniri = int.Parse(txtMinYasSiniri.Text),
                        gunlukSinirKM = int.Parse(txtGunlukSinir.Text),
                        aracKM = int.Parse(txtAracKM.Text),
                        airBagSayisi = int.Parse(txtAirBagSayisi.Text),
                        bagacHacmi = int.Parse(txtBagajHacmi.Text),
                        koltukSayisi = int.Parse(txtKoltukSayisi.Text),
                        gunlukKiralikFiyati = int.Parse(txtGunlukKiralikFiyati.Text),
                        aitOlduguSirketID = int.Parse(txtAitOlduguSirketID.Text)
                    });
                }
                var message = success ? "Başarıyla güncellendi" : "Hata oluştu";

                MessageBox.Show(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error happened: " + ex.Message);
            }

            aracListele();
            inputTemizle();
        }

        private void btnSeciliSil_Click(object sender, EventArgs e)
        {
            try
            {
                bool success;
                using (var aracBusiness = new AracBusiness())
                {
                    success = aracBusiness.AracSilById(int.Parse(dgAracListesi.CurrentRow.Cells[0].Value.ToString()));
                }
                var message = success ? "Başarıyla silindi" : "Hata oluştu";

                MessageBox.Show(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error happened: " + ex.Message);
            }

            aracListele();
            inputTemizle();
        }

        private void dgAracListesi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtAracID.Text = dgAracListesi.CurrentRow.Cells[0].Value.ToString();
            txtAracMarka.Text = dgAracListesi.CurrentRow.Cells[1].Value.ToString();
            txtAracModel.Text = dgAracListesi.CurrentRow.Cells[2].Value.ToString();
            txtGerekenEhliyetYasi.Text = dgAracListesi.CurrentRow.Cells[3].Value.ToString();
            txtMinYasSiniri.Text = dgAracListesi.CurrentRow.Cells[4].Value.ToString();
            txtGunlukSinir.Text = dgAracListesi.CurrentRow.Cells[5].Value.ToString();
            txtAracKM.Text = dgAracListesi.CurrentRow.Cells[6].Value.ToString();
            txtAirBagSayisi.Text = dgAracListesi.CurrentRow.Cells[7].Value.ToString();
            txtBagajHacmi.Text = dgAracListesi.CurrentRow.Cells[8].Value.ToString();
            txtKoltukSayisi.Text = dgAracListesi.CurrentRow.Cells[9].Value.ToString();
            txtGunlukKiralikFiyati.Text = dgAracListesi.CurrentRow.Cells[10].Value.ToString();
            txtAitOlduguSirketID.Text = dgAracListesi.CurrentRow.Cells[11].Value.ToString();
        }

        void aracListele()
        {
            try
            {
                using (var aracBusiness = new AracBusiness())
                {
                    List<Arac> aracList = aracBusiness.SelectAllArac().ToList();
                    dgAracListesi.DataSource = aracList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error happened: " + ex.Message);
            }

            dgAracListesi.ClearSelection();
        }

        void inputTemizle()
        {
            txtAracID.Text = "";
            txtAracMarka.Text = "";
            txtAracModel.Text = "";
            txtGerekenEhliyetYasi.Text = "";
            txtMinYasSiniri.Text = "";
            txtGunlukSinir.Text = "";
            txtAracKM.Text = "";
            txtAirBagSayisi.Text = "";
            txtBagajHacmi.Text = "";
            txtKoltukSayisi.Text = "";
            txtGunlukKiralikFiyati.Text = "";
            txtAitOlduguSirketID.Text = "";

            dgAracListesi.ClearSelection();
        }

    }
}
