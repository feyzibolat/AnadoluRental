namespace AnadoluRentalForm
{
    partial class frmKirala
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
            this.dgKiralananAraclar = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKiraBitisKM = new System.Windows.Forms.TextBox();
            this.txtVerilisKM = new System.Windows.Forms.TextBox();
            this.txtKiraAracID = new System.Windows.Forms.TextBox();
            this.txtKiraID = new System.Windows.Forms.TextBox();
            this.btnAracKirala = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAlinanUcret = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtKullID = new System.Windows.Forms.TextBox();
            this.dtpKiraTarihi = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgKiralananAraclar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSeciliSil
            // 
            this.btnSeciliSil.Location = new System.Drawing.Point(13, 323);
            this.btnSeciliSil.Name = "btnSeciliSil";
            this.btnSeciliSil.Size = new System.Drawing.Size(220, 33);
            this.btnSeciliSil.TabIndex = 35;
            this.btnSeciliSil.Text = "Seçili Kiralamayi İptal Et";
            this.btnSeciliSil.UseVisualStyleBackColor = true;
            this.btnSeciliSil.Click += new System.EventHandler(this.btnSeciliSil_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(13, 284);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(220, 33);
            this.btnGuncelle.TabIndex = 34;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnTemizle
            // 
            this.btnTemizle.Location = new System.Drawing.Point(13, 245);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(220, 33);
            this.btnTemizle.TabIndex = 33;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.UseVisualStyleBackColor = true;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // dgKiralananAraclar
            // 
            this.dgKiralananAraclar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgKiralananAraclar.Location = new System.Drawing.Point(239, 12);
            this.dgKiralananAraclar.Name = "dgKiralananAraclar";
            this.dgKiralananAraclar.Size = new System.Drawing.Size(621, 344);
            this.dgKiralananAraclar.TabIndex = 36;
            this.dgKiralananAraclar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgKiralananAraclar_CellClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "Kira Bitiş KM";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Veriliş KM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Kira Tarihi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Kiralanan Araç ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Kira ID";
            // 
            // txtKiraBitisKM
            // 
            this.txtKiraBitisKM.Location = new System.Drawing.Point(100, 128);
            this.txtKiraBitisKM.MaxLength = 150;
            this.txtKiraBitisKM.Name = "txtKiraBitisKM";
            this.txtKiraBitisKM.Size = new System.Drawing.Size(133, 20);
            this.txtKiraBitisKM.TabIndex = 31;
            // 
            // txtVerilisKM
            // 
            this.txtVerilisKM.Location = new System.Drawing.Point(100, 99);
            this.txtVerilisKM.MaxLength = 20;
            this.txtVerilisKM.Name = "txtVerilisKM";
            this.txtVerilisKM.Size = new System.Drawing.Size(133, 20);
            this.txtVerilisKM.TabIndex = 30;
            // 
            // txtKiraAracID
            // 
            this.txtKiraAracID.Location = new System.Drawing.Point(100, 41);
            this.txtKiraAracID.MaxLength = 50;
            this.txtKiraAracID.Name = "txtKiraAracID";
            this.txtKiraAracID.Size = new System.Drawing.Size(133, 20);
            this.txtKiraAracID.TabIndex = 28;
            // 
            // txtKiraID
            // 
            this.txtKiraID.Enabled = false;
            this.txtKiraID.Location = new System.Drawing.Point(100, 12);
            this.txtKiraID.Name = "txtKiraID";
            this.txtKiraID.Size = new System.Drawing.Size(133, 20);
            this.txtKiraID.TabIndex = 27;
            // 
            // btnAracKirala
            // 
            this.btnAracKirala.Location = new System.Drawing.Point(13, 206);
            this.btnAracKirala.Name = "btnAracKirala";
            this.btnAracKirala.Size = new System.Drawing.Size(220, 33);
            this.btnAracKirala.TabIndex = 32;
            this.btnAracKirala.Text = "Araç Kirala";
            this.btnAracKirala.UseVisualStyleBackColor = true;
            this.btnAracKirala.Click += new System.EventHandler(this.btnAracKirala_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 43;
            this.label6.Text = "Kira Alinan Ücret";
            // 
            // txtAlinanUcret
            // 
            this.txtAlinanUcret.Location = new System.Drawing.Point(100, 154);
            this.txtAlinanUcret.MaxLength = 150;
            this.txtAlinanUcret.Name = "txtAlinanUcret";
            this.txtAlinanUcret.Size = new System.Drawing.Size(133, 20);
            this.txtAlinanUcret.TabIndex = 42;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "Kiralayan Kull ID";
            // 
            // txtKullID
            // 
            this.txtKullID.Location = new System.Drawing.Point(100, 180);
            this.txtKullID.MaxLength = 150;
            this.txtKullID.Name = "txtKullID";
            this.txtKullID.Size = new System.Drawing.Size(133, 20);
            this.txtKullID.TabIndex = 44;
            // 
            // dtpKiraTarihi
            // 
            this.dtpKiraTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpKiraTarihi.Location = new System.Drawing.Point(100, 70);
            this.dtpKiraTarihi.Name = "dtpKiraTarihi";
            this.dtpKiraTarihi.Size = new System.Drawing.Size(133, 20);
            this.dtpKiraTarihi.TabIndex = 46;
            this.dtpKiraTarihi.Value = new System.DateTime(2019, 4, 26, 0, 0, 0, 0);
            // 
            // frmKirala
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 366);
            this.Controls.Add(this.dtpKiraTarihi);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtKullID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAlinanUcret);
            this.Controls.Add(this.btnSeciliSil);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.dgKiralananAraclar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtKiraBitisKM);
            this.Controls.Add(this.txtVerilisKM);
            this.Controls.Add(this.txtKiraAracID);
            this.Controls.Add(this.txtKiraID);
            this.Controls.Add(this.btnAracKirala);
            this.Name = "frmKirala";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kiralanan Listesi";
            this.Load += new System.EventHandler(this.frmKirala_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgKiralananAraclar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSeciliSil;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.DataGridView dgKiralananAraclar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKiraBitisKM;
        private System.Windows.Forms.TextBox txtVerilisKM;
        private System.Windows.Forms.TextBox txtKiraAracID;
        private System.Windows.Forms.TextBox txtKiraID;
        private System.Windows.Forms.Button btnAracKirala;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAlinanUcret;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtKullID;
        private System.Windows.Forms.DateTimePicker dtpKiraTarihi;
    }
}