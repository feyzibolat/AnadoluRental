namespace AnadoluRental.Models.Models
{
    using System.Collections.Generic;

    public class Sirket
    {

        public Sirket()
        {
            this.Arac = new HashSet<Arac>();
        }

        public int sirketID { get; set; }
        public string sirketAdi { get; set; }
        public string sirketSehir { get; set; }
        public string sirketAdres { get; set; }
        public int sirketAracSayisi { get; set; }
        public int sirketPuani { get; set; }

        public virtual ICollection<Arac> Arac { get; set; }

    }
}
