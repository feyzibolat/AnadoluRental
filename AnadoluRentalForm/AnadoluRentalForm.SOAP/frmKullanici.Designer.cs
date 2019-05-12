namespace AnadoluRentalForm
{
    partial class frmKullanici
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
            this.btnSeciliSil = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.dgKullanici = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKullRolID = new System.Windows.Forms.TextBox();
            this.txtKullSifresi = new System.Windows.Forms.TextBox();
            this.txtKullAdi = new System.Windows.Forms.TextBox();
            this.txtKullID = new System.Windows.Forms.TextBox();
            this.btnYeniKaydet = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtKullSirketID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAdresi = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTelNo = new System.Windows.Forms.TextBox();
            this.txtSoyad = new System.Windows.Forms.TextBox();
            this.txtAd = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgKullanici)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSeciliSil
            // 
            this.btnSeciliSil.Location = new System.Drawing.Point(12, 419);
            this.btnSeciliSil.Name = "btnSeciliSil";
            this.btnSeciliSil.Size = new System.Drawing.Size(220, 33);
            this.btnSeciliSil.TabIndex = 35;
            this.btnSeciliSil.Text = "Seçili Kullanıcıyı Sil";
            this.btnSeciliSil.UseVisualStyleBackColor = true;
            this.btnSeciliSil.Click += new System.EventHandler(this.btnSeciliSil_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(12, 380);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(220, 33);
            this.btnGuncelle.TabIndex = 34;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnTemizle
            // 
            this.btnTemizle.Location = new System.Drawing.Point(12, 341);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(220, 33);
            this.btnTemizle.TabIndex = 33;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.UseVisualStyleBackColor = true;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // dgKullanici
            // 
            this.dgKullanici.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgKullanici.Location = new System.Drawing.Point(241, 12);
            this.dgKullanici.Name = "dgKullanici";
            this.dgKullanici.Size = new System.Drawing.Size(621, 440);
            this.dgKullanici.TabIndex = 36;
            this.dgKullanici.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgKullanici_CellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Kullanıcı Rol ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Kullanıcı Şifresi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Kullanıcı Adı";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Kullanıcı ID";
            // 
            // txtKullRolID
            // 
            this.txtKullRolID.Location = new System.Drawing.Point(102, 99);
            this.txtKullRolID.MaxLength = 20;
            this.txtKullRolID.Name = "txtKullRolID";
            this.txtKullRolID.Size = new System.Drawing.Size(133, 20);
            this.txtKullRolID.TabIndex = 30;
            // 
            // txtKullSifresi
            // 
            this.txtKullSifresi.Location = new System.Drawing.Point(102, 70);
            this.txtKullSifresi.MaxLength = 50;
            this.txtKullSifresi.Name = "txtKullSifresi";
            this.txtKullSifresi.Size = new System.Drawing.Size(133, 20);
            this.txtKullSifresi.TabIndex = 29;
            // 
            // txtKullAdi
            // 
            this.txtKullAdi.Location = new System.Drawing.Point(102, 41);
            this.txtKullAdi.MaxLength = 50;
            this.txtKullAdi.Name = "txtKullAdi";
            this.txtKullAdi.Size = new System.Drawing.Size(133, 20);
            this.txtKullAdi.TabIndex = 28;
            // 
            // txtKullID
            // 
            this.txtKullID.Enabled = false;
            this.txtKullID.Location = new System.Drawing.Point(102, 12);
            this.txtKullID.Name = "txtKullID";
            this.txtKullID.Size = new System.Drawing.Size(133, 20);
            this.txtKullID.TabIndex = 27;
            // 
            // btnYeniKaydet
            // 
            this.btnYeniKaydet.Location = new System.Drawing.Point(12, 302);
            this.btnYeniKaydet.Name = "btnYeniKaydet";
            this.btnYeniKaydet.Size = new System.Drawing.Size(220, 33);
            this.btnYeniKaydet.TabIndex = 32;
            this.btnYeniKaydet.Text = "Yeni Kullanıcı Kaydet";
            this.btnYeniKaydet.UseVisualStyleBackColor = true;
            this.btnYeniKaydet.Click += new System.EventHandler(this.btnYeniKaydet_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "Kullanıcı Şirket ID";
            // 
            // txtKullSirketID
            // 
            this.txtKullSirketID.Location = new System.Drawing.Point(102, 125);
            this.txtKullSirketID.MaxLength = 20;
            this.txtKullSirketID.Name = "txtKullSirketID";
            this.txtKullSirketID.Size = new System.Drawing.Size(133, 20);
            this.txtKullSirketID.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 238);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 50;
            this.label6.Text = "Adresi";
            // 
            // txtAdresi
            // 
            this.txtAdresi.Location = new System.Drawing.Point(102, 235);
            this.txtAdresi.MaxLength = 20;
            this.txtAdresi.Multiline = true;
            this.txtAdresi.Name = "txtAdresi";
            this.txtAdresi.Size = new System.Drawing.Size(133, 49);
            this.txtAdresi.TabIndex = 49;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 212);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 48;
            this.label7.Text = "Telefon No";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 183);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 47;
            this.label8.Text = "Soyadı";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 154);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 13);
            this.label9.TabIndex = 46;
            this.label9.Text = "Adı";
            // 
            // txtTelNo
            // 
            this.txtTelNo.Location = new System.Drawing.Point(102, 209);
            this.txtTelNo.MaxLength = 20;
            this.txtTelNo.Name = "txtTelNo";
            this.txtTelNo.Size = new System.Drawing.Size(133, 20);
            this.txtTelNo.TabIndex = 45;
            // 
            // txtSoyad
            // 
            this.txtSoyad.Location = new System.Drawing.Point(102, 180);
            this.txtSoyad.MaxLength = 50;
            this.txtSoyad.Name = "txtSoyad";
            this.txtSoyad.Size = new System.Drawing.Size(133, 20);
            this.txtSoyad.TabIndex = 44;
            // 
            // txtAd
            // 
            this.txtAd.Location = new System.Drawing.Point(102, 151);
            this.txtAd.MaxLength = 50;
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(133, 20);
            this.txtAd.TabIndex = 43;
            // 
            // frmKullanici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 462);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAdresi);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTelNo);
            this.Controls.Add(this.txtSoyad);
            this.Controls.Add(this.txtAd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtKullSirketID);
            this.Controls.Add(this.btnSeciliSil);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.dgKullanici);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtKullRolID);
            this.Controls.Add(this.txtKullSifresi);
            this.Controls.Add(this.txtKullAdi);
            this.Controls.Add(this.txtKullID);
            this.Controls.Add(this.btnYeniKaydet);
            this.Name = "frmKullanici";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmKullanici";
            this.Load += new System.EventHandler(this.frmKullanici_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgKullanici)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSeciliSil;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.DataGridView dgKullanici;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKullRolID;
        private System.Windows.Forms.TextBox txtKullSifresi;
        private System.Windows.Forms.TextBox txtKullAdi;
        private System.Windows.Forms.TextBox txtKullID;
        private System.Windows.Forms.Button btnYeniKaydet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtKullSirketID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAdresi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTelNo;
        private System.Windows.Forms.TextBox txtSoyad;
        private System.Windows.Forms.TextBox txtAd;
    }
}