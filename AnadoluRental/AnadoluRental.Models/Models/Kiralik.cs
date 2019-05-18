namespace AnadoluRental.Models.Models
{
    using System;

    public partial class Kiralik
    {
        public int kiraID { get; set; }
        public int kiralananAracID { get; set; }
        public DateTime kiraTarihi { get; set; }
        public int verilisKM { get; set; }
        public int kiraBitisKM { get; set; }
        public int kiraAlinanUcret { get; set; }
        public int kiralayanKulID { get; set; }

        public virtual Arac Arac { get; set; }
        public virtual Kullanici Kullanici { get; set; }
    }
}
