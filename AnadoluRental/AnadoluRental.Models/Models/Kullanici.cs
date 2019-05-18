namespace AnadoluRental.Models.Models
{
    using System.Collections.Generic;

    public partial class Kullanici
    {
        public Kullanici()
        {
            this.Kiralik = new HashSet<Kiralik>();
        }

        public int kullaniciID { get; set; }
        public string kullAdi { get; set; }
        public string kullSifre { get; set; }
        public int kullRolID { get; set; }
        public int kullSirketID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TelNo { get; set; }
        public string Adres { get; set; }
        
        public virtual ICollection<Kiralik> Kiralik { get; set; }
        public virtual Rol Rol { get; set; }
    }
}
