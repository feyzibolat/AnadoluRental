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
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        }

        private void frmGiris_Load(object sender, EventArgs e)
        {

        }

        private async void btnGirisYap_Click(object sender, EventArgs e)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:54361/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    List<Kullanici> kullanicilar = new List<Kullanici>();

                    using (var result = await client.GetAsync("api/Kullanici"))
                    {
                        if (result.IsSuccessStatusCode)
                        {
                            var value = result.Content.ReadAsStringAsync().Result;

                            kullanicilar = JsonConvert.DeserializeObject<ResponseContent<Kullanici>>(value).Data.ToList();
                        }
                    }


                    bool girisYapildi = false;
                    foreach (Kullanici kull in kullanicilar)
                    {
                        if (kull.kullAdi == txtKullAdi.Text && kull.kullSifre == txtSifre.Text)
                        {
                            girisYapildi = true;
                            string kullRol = "";
                            switch (kull.kullRolID)
                            {
                                case 1:
                                    kullRol = "Admin";
                                    break;
                                case 2:
                                    kullRol = "Yönetici";
                                    break;
                                case 3:
                                    kullRol = "Çalışan";
                                    break;
                                case 4:
                                    kullRol = "Müşteri";
                                    break;
                                default:
                                    break;
                            }
                            if (kullRol != "Müşteri")
                            {
                                MessageBox.Show("Hoşgeldiniz, " + kull.Ad + " " + kull.Soyad + ". Rol: " + kullRol);
                                this.Hide();
                                frmAna frmAna = new frmAna();
                                frmAna.ShowDialog();
                                this.Show();

                                txtKullAdi.Text = txtSifre.Text = "";
                                txtKullAdi.Focus();
                            }
                            else
                            {
                                MessageBox.Show("Müşteriler yalnızca webten giriş yapabilir!");
                            }
                            
                            break;
                        }
                    }

                    if (!girisYapildi)
                    {
                        MessageBox.Show("Hatalı Giriş Bilgisi.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error happened: " + ex.Message);
            }
        }
    }
}
