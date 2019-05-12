namespace AnadoluRentalForm
{
    partial class frmAna
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
            this.btnArac = new System.Windows.Forms.Button();
            this.btnKiralama = new System.Windows.Forms.Button();
            this.btnSirket = new System.Windows.Forms.Button();
            this.btnCikis = new System.Windows.Forms.Button();
            this.txtKullanici = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnArac
            // 
            this.btnArac.Location = new System.Drawing.Point(189, 12);
            this.btnArac.Name = "btnArac";
            this.btnArac.Size = new System.Drawing.Size(171, 126);
            this.btnArac.TabIndex = 0;
            this.btnArac.Text = "ARAÇ\r\nİŞLEMLERİ";
            this.btnArac.UseVisualStyleBackColor = true;
            this.btnArac.Click += new System.EventHandler(this.btnArac_Click);
            // 
            // btnKiralama
            // 
            this.btnKiralama.Location = new System.Drawing.Point(366, 12);
            this.btnKiralama.Name = "btnKiralama";
            this.btnKiralama.Size = new System.Drawing.Size(171, 126);
            this.btnKiralama.TabIndex = 0;
            this.btnKiralama.Text = "KİRALAMA\r\nİŞLEMLERİ";
            this.btnKiralama.UseVisualStyleBackColor = true;
            this.btnKiralama.Click += new System.EventHandler(this.btnKiralama_Click);
            // 
            // btnSirket
            // 
            this.btnSirket.Location = new System.Drawing.Point(12, 12);
            this.btnSirket.Name = "btnSirket";
            this.btnSirket.Size = new System.Drawing.Size(171, 126);
            this.btnSirket.TabIndex = 0;
            this.btnSirket.Text = "ŞİRKET\r\nİŞLEMLERİ";
            this.btnSirket.UseVisualStyleBackColor = true;
            this.btnSirket.Click += new System.EventHandler(this.btnSirket_Click);
            // 
            // btnCikis
            // 
            this.btnCikis.Location = new System.Drawing.Point(368, 204);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(169, 56);
            this.btnCikis.TabIndex = 1;
            this.btnCikis.Text = "ÇIKIŞ";
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // txtKullanici
            // 
            this.txtKullanici.Location = new System.Drawing.Point(12, 144);
            this.txtKullanici.Name = "txtKullanici";
            this.txtKullanici.Size = new System.Drawing.Size(171, 116);
            this.txtKullanici.TabIndex = 2;
            this.txtKullanici.Text = "KULLANICI\r\nİŞLEMLERİ";
            this.txtKullanici.UseVisualStyleBackColor = true;
            this.txtKullanici.Click += new System.EventHandler(this.txtKullanici_Click);
            // 
            // frmAna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 274);
            this.Controls.Add(this.txtKullanici);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnSirket);
            this.Controls.Add(this.btnKiralama);
            this.Controls.Add(this.btnArac);
            this.Name = "frmAna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AnadoluRental";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnArac;
        private System.Windows.Forms.Button btnKiralama;
        private System.Windows.Forms.Button btnSirket;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Button txtKullanici;
    }
}