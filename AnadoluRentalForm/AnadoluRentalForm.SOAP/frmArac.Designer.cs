namespace AnadoluRentalForm
{
    partial class frmArac
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label6 = new System.Windows.Forms.Label();
            this.txtMinYasSiniri = new System.Windows.Forms.TextBox();
            this.btnSeciliSil = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.dgAracListesi = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGunlukSinir = new System.Windows.Forms.TextBox();
            this.txtGerekenEhliyetYasi = new System.Windows.Forms.TextBox();
            this.txtAracModel = new System.Windows.Forms.TextBox();
            this.txtAracMarka = new System.Windows.Forms.TextBox();
            this.txtAracID = new System.Windows.Forms.TextBox();
            this.btnYeniArac = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGunlukKiralikFiyati = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAitOlduguSirketID = new System.Windows.Forms.TextBox();
            this.txtKoltukSayisi = new System.Windows.Forms.TextBox();
            this.txtBagajHacmi = new System.Windows.Forms.TextBox();
            this.txtAirBagSayisi = new System.Windows.Forms.TextBox();
            this.txtAracKM = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgAracListesi)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(116, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 60;
            this.label6.Text = "Min Yaş Sınırı";
            // 
            // txtMinYasSiniri
            // 
            this.txtMinYasSiniri.Location = new System.Drawing.Point(225, 129);
            this.txtMinYasSiniri.MaxLength = 20;
            this.txtMinYasSiniri.Name = "txtMinYasSiniri";
            this.txtMinYasSiniri.Size = new System.Drawing.Size(133, 20);
            this.txtMinYasSiniri.TabIndex = 4;
            // 
            // btnSeciliSil
            // 
            this.btnSeciliSil.Location = new System.Drawing.Point(848, 138);
            this.btnSeciliSil.Name = "btnSeciliSil";
            this.btnSeciliSil.Size = new System.Drawing.Size(220, 33);
            this.btnSeciliSil.TabIndex = 15;
            this.btnSeciliSil.Text = "Seçili Aracı Sil";
            this.btnSeciliSil.UseVisualStyleBackColor = true;
            this.btnSeciliSil.Click += new System.EventHandler(this.btnSeciliSil_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(848, 99);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(220, 33);
            this.btnGuncelle.TabIndex = 14;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnTemizle
            // 
            this.btnTemizle.Location = new System.Drawing.Point(848, 60);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(220, 33);
            this.btnTemizle.TabIndex = 13;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.UseVisualStyleBackColor = true;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // dgAracListesi
            // 
            this.dgAracListesi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAracListesi.Location = new System.Drawing.Point(13, 189);
            this.dgAracListesi.Name = "dgAracListesi";
            this.dgAracListesi.Size = new System.Drawing.Size(1055, 263);
            this.dgAracListesi.TabIndex = 16;
            this.dgAracListesi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgAracListesi_CellClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(116, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 59;
            this.label5.Text = "Günlük Sınırı KM";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(116, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 58;
            this.label4.Text = "Gereken Ehliyet Yaşı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(116, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 57;
            this.label3.Text = "Modeli";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 56;
            this.label2.Text = "Markası";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(116, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 55;
            this.label1.Text = "Araç ID";
            // 
            // txtGunlukSinir
            // 
            this.txtGunlukSinir.Location = new System.Drawing.Point(225, 155);
            this.txtGunlukSinir.MaxLength = 150;
            this.txtGunlukSinir.Name = "txtGunlukSinir";
            this.txtGunlukSinir.Size = new System.Drawing.Size(133, 20);
            this.txtGunlukSinir.TabIndex = 5;
            // 
            // txtGerekenEhliyetYasi
            // 
            this.txtGerekenEhliyetYasi.Location = new System.Drawing.Point(225, 103);
            this.txtGerekenEhliyetYasi.MaxLength = 20;
            this.txtGerekenEhliyetYasi.Name = "txtGerekenEhliyetYasi";
            this.txtGerekenEhliyetYasi.Size = new System.Drawing.Size(133, 20);
            this.txtGerekenEhliyetYasi.TabIndex = 3;
            // 
            // txtAracModel
            // 
            this.txtAracModel.Location = new System.Drawing.Point(225, 74);
            this.txtAracModel.MaxLength = 50;
            this.txtAracModel.Name = "txtAracModel";
            this.txtAracModel.Size = new System.Drawing.Size(133, 20);
            this.txtAracModel.TabIndex = 2;
            // 
            // txtAracMarka
            // 
            this.txtAracMarka.Location = new System.Drawing.Point(225, 45);
            this.txtAracMarka.MaxLength = 50;
            this.txtAracMarka.Name = "txtAracMarka";
            this.txtAracMarka.Size = new System.Drawing.Size(133, 20);
            this.txtAracMarka.TabIndex = 1;
            // 
            // txtAracID
            // 
            this.txtAracID.Enabled = false;
            this.txtAracID.Location = new System.Drawing.Point(225, 16);
            this.txtAracID.Name = "txtAracID";
            this.txtAracID.Size = new System.Drawing.Size(133, 20);
            this.txtAracID.TabIndex = 0;
            // 
            // btnYeniArac
            // 
            this.btnYeniArac.Location = new System.Drawing.Point(848, 21);
            this.btnYeniArac.Name = "btnYeniArac";
            this.btnYeniArac.Size = new System.Drawing.Size(220, 33);
            this.btnYeniArac.TabIndex = 12;
            this.btnYeniArac.Text = "Yeni Araç Kaydet";
            this.btnYeniArac.UseVisualStyleBackColor = true;
            this.btnYeniArac.Click += new System.EventHandler(this.btnYeniArac_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(422, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 13);
            this.label7.TabIndex = 72;
            this.label7.Text = "Günlük Kiralik Fiyatı";
            // 
            // txtGunlukKiralikFiyati
            // 
            this.txtGunlukKiralikFiyati.Location = new System.Drawing.Point(528, 129);
            this.txtGunlukKiralikFiyati.MaxLength = 20;
            this.txtGunlukKiralikFiyati.Name = "txtGunlukKiralikFiyati";
            this.txtGunlukKiralikFiyati.Size = new System.Drawing.Size(133, 20);
            this.txtGunlukKiralikFiyati.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(422, 158);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 13);
            this.label8.TabIndex = 71;
            this.label8.Text = "Ait Olduğu Şirket ID";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(422, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 70;
            this.label9.Text = "Koltuk Sayısı";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(422, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 69;
            this.label10.Text = "Bagaj Hacmi";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(422, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 13);
            this.label11.TabIndex = 68;
            this.label11.Text = "AirBag Sayısı";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(422, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 13);
            this.label12.TabIndex = 67;
            this.label12.Text = "Araç KM";
            // 
            // txtAitOlduguSirketID
            // 
            this.txtAitOlduguSirketID.Location = new System.Drawing.Point(528, 155);
            this.txtAitOlduguSirketID.MaxLength = 150;
            this.txtAitOlduguSirketID.Name = "txtAitOlduguSirketID";
            this.txtAitOlduguSirketID.Size = new System.Drawing.Size(133, 20);
            this.txtAitOlduguSirketID.TabIndex = 11;
            // 
            // txtKoltukSayisi
            // 
            this.txtKoltukSayisi.Location = new System.Drawing.Point(528, 103);
            this.txtKoltukSayisi.MaxLength = 20;
            this.txtKoltukSayisi.Name = "txtKoltukSayisi";
            this.txtKoltukSayisi.Size = new System.Drawing.Size(133, 20);
            this.txtKoltukSayisi.TabIndex = 9;
            // 
            // txtBagajHacmi
            // 
            this.txtBagajHacmi.Location = new System.Drawing.Point(528, 74);
            this.txtBagajHacmi.MaxLength = 50;
            this.txtBagajHacmi.Name = "txtBagajHacmi";
            this.txtBagajHacmi.Size = new System.Drawing.Size(133, 20);
            this.txtBagajHacmi.TabIndex = 8;
            // 
            // txtAirBagSayisi
            // 
            this.txtAirBagSayisi.Location = new System.Drawing.Point(528, 45);
            this.txtAirBagSayisi.MaxLength = 50;
            this.txtAirBagSayisi.Name = "txtAirBagSayisi";
            this.txtAirBagSayisi.Size = new System.Drawing.Size(133, 20);
            this.txtAirBagSayisi.TabIndex = 7;
            // 
            // txtAracKM
            // 
            this.txtAracKM.Location = new System.Drawing.Point(528, 16);
            this.txtAracKM.Name = "txtAracKM";
            this.txtAracKM.Size = new System.Drawing.Size(133, 20);
            this.txtAracKM.TabIndex = 6;
            // 
            // frmArac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 464);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtGunlukKiralikFiyati);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtAitOlduguSirketID);
            this.Controls.Add(this.txtKoltukSayisi);
            this.Controls.Add(this.txtBagajHacmi);
            this.Controls.Add(this.txtAirBagSayisi);
            this.Controls.Add(this.txtAracKM);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMinYasSiniri);
            this.Controls.Add(this.btnSeciliSil);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.dgAracListesi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGunlukSinir);
            this.Controls.Add(this.txtGerekenEhliyetYasi);
            this.Controls.Add(this.txtAracModel);
            this.Controls.Add(this.txtAracMarka);
            this.Controls.Add(this.txtAracID);
            this.Controls.Add(this.btnYeniArac);
            this.Name = "frmArac";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmArac";
            this.Load += new System.EventHandler(this.frmArac_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgAracListesi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMinYasSiniri;
        private System.Windows.Forms.Button btnSeciliSil;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.DataGridView dgAracListesi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGunlukSinir;
        private System.Windows.Forms.TextBox txtGerekenEhliyetYasi;
        private System.Windows.Forms.TextBox txtAracModel;
        private System.Windows.Forms.TextBox txtAracMarka;
        private System.Windows.Forms.TextBox txtAracID;
        private System.Windows.Forms.Button btnYeniArac;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGunlukKiralikFiyati;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtAitOlduguSirketID;
        private System.Windows.Forms.TextBox txtKoltukSayisi;
        private System.Windows.Forms.TextBox txtBagajHacmi;
        private System.Windows.Forms.TextBox txtAirBagSayisi;
        private System.Windows.Forms.TextBox txtAracKM;
    }
}