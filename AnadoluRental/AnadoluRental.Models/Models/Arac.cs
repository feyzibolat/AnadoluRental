namespace AnadoluRental.Models.Models
{
    using System.Collections.Generic;

    public partial class Arac
    {
        public Arac()
        {
            this.Kiralik = new HashSet<Kiralik>();
        }

        public int aracID { get; set; }
        public string aracMarka { get; set; }
        public string aracModel { get; set; }
        public int gerekenEhliyetYasi { get; set; }
        public int minYasSiniri { get; set; }
        public int gunlukSinirKM { get; set; }
        public int aracKM { get; set; }
        public int airBagSayisi { get; set; }
        public int bagacHacmi { get; set; }
        public int koltukSayisi { get; set; }
        public int gunlukKiralikFiyati { get; set; }
        public int aitOlduguSirketID { get; set; }
        public string aracResim { get; set; }

        public virtual Sirket Sirket { get; set; }
        public virtual ICollection<Kiralik> Kiralik { get; set; }

    }
}
