using AnadoluRental.Business;
using AnadoluRental.Models.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
        }

        private async void btnYeniArac_Click(object sender, EventArgs e)
        {
            try
            {
                bool success = false;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:54361/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    Arac arac = new Arac()
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
                    };

                    var serializedProduct = JsonConvert.SerializeObject(arac);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync("api/Arac", content);
                    if (result.IsSuccessStatusCode)
                    {
                        success = true;
                    }
                }
                var message = success ? "başarılı" : "başarısız";
                MessageBox.Show("Kayıt " + message);
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

        private async void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                bool success = false;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:54361/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    Arac arac = new Arac()
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
                    };

                    var serializedProduct = JsonConvert.SerializeObject(arac);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    var result = await client.PutAsync("api/Arac/" + txtAracID.Text, content);
                    if (result.IsSuccessStatusCode)
                    {
                        success = true;
                    }
                }
                var message = success ? "başarılı" : "başarısız";
                MessageBox.Show("Güncelleme " + message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error happened: " + ex.Message);
            }

            aracListele();
            inputTemizle();
        }

        private async void btnSeciliSil_Click(object sender, EventArgs e)
        {
            try
            {
                bool success = false;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:54361/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    var result = await client.DeleteAsync("api/Arac/" + txtAracID.Text);
                    if (result.IsSuccessStatusCode)
                    {
                        success = true;
                    }
                }
                var message = success ? "başarılı" : "başarısız";
                MessageBox.Show("Silme " + message);
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

        async void aracListele()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:54361/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var result = await client.GetAsync("api/Arac"))
                    {
                        if (result.IsSuccessStatusCode)
                        {
                            var value = result.Content.ReadAsStringAsync().Result;

                            dgAracListesi.DataSource = JsonConvert.DeserializeObject<ResponseContent<Arac>>(value).Data.ToList();
                            dgAracListesi.Columns[0].Width = 50;
                            dgAracListesi.Columns[12].Visible = false;
                            dgAracListesi.Columns[13].Visible = false;
                        }
                    }
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
