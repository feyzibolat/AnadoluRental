namespace AnadoluRentalForm
{
    partial class frmSirket
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
            this.dgSirketListe = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSirketAdres = new System.Windows.Forms.TextBox();
            this.txtAracSayisi = new System.Windows.Forms.TextBox();
            this.txtSirketSehir = new System.Windows.Forms.TextBox();
            this.txtSirketAdi = new System.Windows.Forms.TextBox();
            this.txtSirketID = new System.Windows.Forms.TextBox();
            this.btnYeniKaydet = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSirketPuani = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgSirketListe)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSeciliSil
            // 
            this.btnSeciliSil.Location = new System.Drawing.Point(14, 331);
            this.btnSeciliSil.Name = "btnSeciliSil";
            this.btnSeciliSil.Size = new System.Drawing.Size(220, 33);
            this.btnSeciliSil.TabIndex = 9;
            this.btnSeciliSil.Text = "Seçili Şirketi Sil";
            this.btnSeciliSil.UseVisualStyleBackColor = true;
            this.btnSeciliSil.Click += new System.EventHandler(this.btnSeciliSil_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(14, 292);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(220, 33);
            this.btnGuncelle.TabIndex = 8;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnTemizle
            // 
            this.btnTemizle.Location = new System.Drawing.Point(14, 253);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(220, 33);
            this.btnTemizle.TabIndex = 7;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.UseVisualStyleBackColor = true;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // dgSirketListe
            // 
            this.dgSirketListe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSirketListe.Location = new System.Drawing.Point(240, 12);
            this.dgSirketListe.Name = "dgSirketListe";
            this.dgSirketListe.Size = new System.Drawing.Size(621, 352);
            this.dgSirketListe.TabIndex = 10;
            this.dgSirketListe.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSirketListe_CellClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "Şirket Adres";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Araç Sayısı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Şehir";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Şirket Adı";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Şirket ID";
            // 
            // txtSirketAdres
            // 
            this.txtSirketAdres.Location = new System.Drawing.Point(101, 151);
            this.txtSirketAdres.MaxLength = 150;
            this.txtSirketAdres.Multiline = true;
            this.txtSirketAdres.Name = "txtSirketAdres";
            this.txtSirketAdres.Size = new System.Drawing.Size(133, 57);
            this.txtSirketAdres.TabIndex = 5;
            // 
            // txtAracSayisi
            // 
            this.txtAracSayisi.Location = new System.Drawing.Point(101, 99);
            this.txtAracSayisi.MaxLength = 20;
            this.txtAracSayisi.Name = "txtAracSayisi";
            this.txtAracSayisi.Size = new System.Drawing.Size(133, 20);
            this.txtAracSayisi.TabIndex = 3;
            // 
            // txtSirketSehir
            // 
            this.txtSirketSehir.Location = new System.Drawing.Point(101, 70);
            this.txtSirketSehir.MaxLength = 50;
            this.txtSirketSehir.Name = "txtSirketSehir";
            this.txtSirketSehir.Size = new System.Drawing.Size(133, 20);
            this.txtSirketSehir.TabIndex = 2;
            // 
            // txtSirketAdi
            // 
            this.txtSirketAdi.Location = new System.Drawing.Point(101, 41);
            this.txtSirketAdi.MaxLength = 50;
            this.txtSirketAdi.Name = "txtSirketAdi";
            this.txtSirketAdi.Size = new System.Drawing.Size(133, 20);
            this.txtSirketAdi.TabIndex = 1;
            // 
            // txtSirketID
            // 
            this.txtSirketID.Enabled = false;
            this.txtSirketID.Location = new System.Drawing.Point(101, 12);
            this.txtSirketID.Name = "txtSirketID";
            this.txtSirketID.Size = new System.Drawing.Size(133, 20);
            this.txtSirketID.TabIndex = 0;
            // 
            // btnYeniKaydet
            // 
            this.btnYeniKaydet.Location = new System.Drawing.Point(14, 214);
            this.btnYeniKaydet.Name = "btnYeniKaydet";
            this.btnYeniKaydet.Size = new System.Drawing.Size(220, 33);
            this.btnYeniKaydet.TabIndex = 6;
            this.btnYeniKaydet.Text = "Yeni Şirket Kaydet";
            this.btnYeniKaydet.UseVisualStyleBackColor = true;
            this.btnYeniKaydet.Click += new System.EventHandler(this.btnYeniKaydet_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 43;
            this.label6.Text = "Şirket Puanı";
            // 
            // txtSirketPuani
            // 
            this.txtSirketPuani.Location = new System.Drawing.Point(101, 125);
            this.txtSirketPuani.MaxLength = 20;
            this.txtSirketPuani.Name = "txtSirketPuani";
            this.txtSirketPuani.Size = new System.Drawing.Size(133, 20);
            this.txtSirketPuani.TabIndex = 4;
            // 
            // frmSirket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 374);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSirketPuani);
            this.Controls.Add(this.btnSeciliSil);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.dgSirketListe);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSirketAdres);
            this.Controls.Add(this.txtAracSayisi);
            this.Controls.Add(this.txtSirketSehir);
            this.Controls.Add(this.txtSirketAdi);
            this.Controls.Add(this.txtSirketID);
            this.Controls.Add(this.btnYeniKaydet);
            this.Name = "frmSirket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Şirket Formu";
            this.Load += new System.EventHandler(this.frmSirket_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgSirketListe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSeciliSil;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.DataGridView dgSirketListe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSirketAdres;
        private System.Windows.Forms.TextBox txtAracSayisi;
        private System.Windows.Forms.TextBox txtSirketSehir;
        private System.Windows.Forms.TextBox txtSirketAdi;
        private System.Windows.Forms.TextBox txtSirketID;
        private System.Windows.Forms.Button btnYeniKaydet;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSirketPuani;
    }
}