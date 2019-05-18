namespace AnadoluRental.Models.Models
{
    using System.Collections.Generic;

    public class Rol
    {
        public Rol()
        {
            this.Kullanici = new HashSet<Kullanici>();
        }

        public int rolID { get; set; }
        public string rolAdi { get; set; }
        
        public virtual ICollection<Kullanici> Kullanici { get; set; }
    }
}
