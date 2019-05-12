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
    public partial class frmSirket : Form
    {
        public frmSirket()
        {
            InitializeComponent();
        }

        async void sirketListele()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:54361/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    
                    using (var result = await client.GetAsync("api/Sirket"))
                    {
                        if (result.IsSuccessStatusCode)
                        {
                            var value = result.Content.ReadAsStringAsync().Result;
                            
                            dgSirketListe.DataSource = JsonConvert.DeserializeObject<ResponseContent<Sirket>>(value).Data.ToList();
                            dgSirketListe.Columns[0].Width = 40;
                            dgSirketListe.Columns[6].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error happened: " + ex.Message);
            }

            dgSirketListe.ClearSelection();
        }

        void inputTemizle()
        {
            txtSirketID.Text = "";
            txtSirketAdi.Text = "";
            txtSirketSehir.Text = "";
            txtAracSayisi.Text = "";
            txtSirketPuani.Text = "";
            txtSirketAdres.Text = "";

            dgSirketListe.ClearSelection();
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
                    
                    Sirket sirket = new Sirket()
                    {
                        sirketAdi = txtSirketAdi.Text,
                        sirketSehir = txtSirketSehir.Text,
                        sirketAracSayisi = int.Parse(txtAracSayisi.Text),
                        sirketPuani = int.Parse(txtSirketPuani.Text),
                        sirketAdres = txtSirketAdres.Text
                    };
                    
                    var serializedProduct = JsonConvert.SerializeObject(sirket);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync("api/Sirket", content);
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
            sirketListele();
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
                    
                    Sirket sirket = new Sirket()
                    {
                        sirketID = int.Parse(txtSirketID.Text),
                        sirketAdi = txtSirketAdi.Text,
                        sirketSehir = txtSirketSehir.Text,
                        sirketAracSayisi = int.Parse(txtAracSayisi.Text),
                        sirketPuani = int.Parse(txtSirketPuani.Text),
                        sirketAdres = txtSirketAdres.Text
                    };
                    
                    var serializedProduct = JsonConvert.SerializeObject(sirket);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    var result = await client.PutAsync("api/Sirket/"+txtSirketID.Text, content);
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
            sirketListele();
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
                    
                    var result = await client.DeleteAsync("api/Sirket/" + txtSirketID.Text);
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
            sirketListele();
            inputTemizle();
        }

        private void dgSirketListe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSirketID.Text = dgSirketListe.CurrentRow.Cells[0].Value.ToString();
            txtSirketAdi.Text = dgSirketListe.CurrentRow.Cells[1].Value.ToString();
            txtSirketSehir.Text = dgSirketListe.CurrentRow.Cells[2].Value.ToString();
            txtSirketAdres.Text = dgSirketListe.CurrentRow.Cells[3].Value.ToString();
            txtAracSayisi.Text = dgSirketListe.CurrentRow.Cells[4].Value.ToString();
            txtSirketPuani.Text = dgSirketListe.CurrentRow.Cells[5].Value.ToString();
        }

        private void frmSirket_Load(object sender, EventArgs e)
        {
            //Genel Ayarlar
            sirketListele();
            inputTemizle();

            dgSirketListe.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dgSirketListe.RowHeadersVisible = false;
            dgSirketListe.ReadOnly = true;
            dgSirketListe.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgSirketListe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgSirketListe.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgSirketListe.MultiSelect = false;
            dgSirketListe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgSirketListe.AllowUserToAddRows = false;
        }
    }
}
