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
    public partial class frmKirala : Form
    {
        public frmKirala()
        {
            InitializeComponent();
        }

        private async void btnAracKirala_Click(object sender, EventArgs e)
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

                    Kiralik kirala = new Kiralik()
                    {
                        kiralananAracID = int.Parse(txtKiraAracID.Text),
                        kiraTarihi = DateTime.Parse(dtpKiraTarihi.Text),
                        verilisKM = int.Parse(txtVerilisKM.Text),
                        kiraBitisKM = int.Parse(txtKiraBitisKM.Text),
                        kiraAlinanUcret = int.Parse(txtAlinanUcret.Text),
                        kiralayanKulID = int.Parse(txtKullID.Text)
                    };

                    var serializedProduct = JsonConvert.SerializeObject(kirala);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync("api/Kiralik", content);
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

            kiralananListele();
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

                    Kiralik kirala = new Kiralik()
                    {
                        kiraID = int.Parse(txtKiraID.Text),
                        kiralananAracID = int.Parse(txtKiraAracID.Text),
                        kiraTarihi = DateTime.Parse(dtpKiraTarihi.Text),
                        verilisKM = int.Parse(txtVerilisKM.Text),
                        kiraBitisKM = int.Parse(txtKiraBitisKM.Text),
                        kiraAlinanUcret = int.Parse(txtAlinanUcret.Text),
                        kiralayanKulID = int.Parse(txtKullID.Text)
                    };

                    var serializedProduct = JsonConvert.SerializeObject(kirala);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    var result = await client.PutAsync("api/Kiralik/" + txtKiraID.Text, content);
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

            kiralananListele();
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

                    var result = await client.DeleteAsync("api/Kiralik/" + txtKiraID.Text);
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
        }

        async void kiralananListele()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:54361/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var result = await client.GetAsync("api/Kiralik"))
                    {
                        if (result.IsSuccessStatusCode)
                        {
                            var value = result.Content.ReadAsStringAsync().Result;

                            dgKiralananAraclar.DataSource = JsonConvert.DeserializeObject<ResponseContent<Kiralik>>(value).Data.ToList();
                            dgKiralananAraclar.Columns[0].Width = 40;
                            dgKiralananAraclar.Columns[7].Visible = false;
                            dgKiralananAraclar.Columns[8].Visible = false;
                        }
                    }
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
