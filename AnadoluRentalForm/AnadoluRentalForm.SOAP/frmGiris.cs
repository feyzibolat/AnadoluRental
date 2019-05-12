using AnadoluRentalForm.SOAP.AnadoluRentalKullaniciService;
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
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        }

        private void frmGiris_Load(object sender, EventArgs e)
        {

        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            try
            {
                using (var kullSoapClient = new KullaniciWebServiceSoapClient())
                {
                    List<Kullanici> kullanicilar = new List<Kullanici>();
                    foreach (var responsedKullanici in kullSoapClient.SelectAllKullanici().OrderBy(x => x.kullaniciID).ToList())
                    {
                        Kullanici kull = new Kullanici()
                        {
                            kullaniciID = responsedKullanici.kullaniciID,
                            kullAdi = responsedKullanici.kullAdi,
                            kullSifre = responsedKullanici.kullSifre,
                            kullRolID = responsedKullanici.kullRolID,
                            Ad = responsedKullanici.Ad,
                            Soyad = responsedKullanici.Soyad,
                            TelNo = responsedKullanici.TelNo,
                            Adres = responsedKullanici.Adres
                        };
                        kullanicilar.Add(kull);
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
                            if (kullRol == "Admin"|| kullRol == "Yönetici"|| kullRol == "Çalışan")
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
