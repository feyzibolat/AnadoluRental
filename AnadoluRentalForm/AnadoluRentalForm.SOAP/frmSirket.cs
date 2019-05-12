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
    public partial class frmSirket : Form
    {
        public frmSirket()
        {
            InitializeComponent();
        }

        void sirketListele()
        {
            try
            {
                using (var sirketBusiness = new SirketBusiness())
                {
                    List<Sirket> sirketList = sirketBusiness.SelectAllSirket().ToList();
                    dgSirketListe.DataSource = sirketList;
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

        private void btnYeniKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                bool success;
                using (var sirketBusiness = new SirketBusiness())
                {
                    success = sirketBusiness.SirketEkle(new Sirket()
                    {
                        sirketAdi = txtSirketAdi.Text,
                        sirketSehir = txtSirketSehir.Text,
                        sirketAracSayisi = int.Parse(txtAracSayisi.Text),
                        sirketPuani = int.Parse(txtSirketPuani.Text),
                        sirketAdres = txtSirketAdres.Text
                    });
                }
                var message = success ? "Başarıyla eklendi" : "Hata oluştu";

                MessageBox.Show(message);
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

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                bool success;
                using (var sirketBusiness = new SirketBusiness())
                {
                    success = sirketBusiness.SirketGuncelle(new Sirket()
                    {
                        sirketID = int.Parse(txtSirketID.Text),
                        sirketAdi = txtSirketAdi.Text,
                        sirketSehir = txtSirketSehir.Text,
                        sirketAracSayisi = int.Parse(txtAracSayisi.Text),
                        sirketPuani = int.Parse(txtSirketPuani.Text),
                        sirketAdres = txtSirketAdres.Text
                    });
                }
                var message = success ? "Başarıyla güncellendi" : "Hata oluştu";

                MessageBox.Show(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error happened: " + ex.Message);
            }

            sirketListele();
            inputTemizle();
        }

        private void btnSeciliSil_Click(object sender, EventArgs e)
        {
            try
            {
                bool success;
                using (var sirketBusiness = new SirketBusiness())
                {
                    success = sirketBusiness.SirketSilById(int.Parse(dgSirketListe.CurrentRow.Cells[0].Value.ToString()));
                }
                var message = success ? "Başarıyla silindi" : "Hata oluştu";

                MessageBox.Show(message);
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
            dgSirketListe.Columns[0].Width = 40;
            dgSirketListe.Columns[6].Visible = false;
        }
    }
}
