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
    public partial class frmKullanici : Form
    {
        public frmKullanici()
        {
            InitializeComponent();
        }

        private async void btnYeniKaydet_Click(object sender, EventArgs e)
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

                    Kullanici kull = new Kullanici()
                    {
                        kullAdi = txtKullAdi.Text,
                        kullSifre = txtKullSifresi.Text,
                        kullRolID = int.Parse(txtKullRolID.Text),
                        kullSirketID = int.Parse(txtKullSirketID.Text),
                        Ad = txtAd.Text,
                        Soyad = txtSoyad.Text,
                        TelNo = txtTelNo.Text,
                        Adres = txtAdresi.Text
                    };

                    var serializedProduct = JsonConvert.SerializeObject(kull);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync("api/Kullanici", content);
                    if (result.IsSuccessStatusCode)
                    {
                        success = true;
                    }
                }
                var message = success ? "başarılı" : "başarısız";
                MessageBox.Show("Kayıt " + message);
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

                    Kullanici kull = new Kullanici()
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
                    };

                    var serializedProduct = JsonConvert.SerializeObject(kull);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    var result = await client.PutAsync("api/Kullanici/" + txtKullID.Text, content);
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

            kullListele();
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

                    var result = await client.DeleteAsync("api/Kullanici/" + txtKullID.Text);
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
        }

        async void kullListele()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:54361/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var result = await client.GetAsync("api/Kullanici"))
                    {
                        if (result.IsSuccessStatusCode)
                        {
                            var value = result.Content.ReadAsStringAsync().Result;

                            dgKullanici.DataSource = JsonConvert.DeserializeObject<ResponseContent<Kullanici>>(value).Data.ToList();
                            dgKullanici.Columns[0].HeaderText = "ID";
                            dgKullanici.Columns[0].Width = 40;
                            dgKullanici.Columns[9].Visible = false;
                        }
                    }
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
