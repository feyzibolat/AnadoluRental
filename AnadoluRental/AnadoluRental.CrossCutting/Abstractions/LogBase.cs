using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnadoluRental.CrossCutting.Abstractions
{
    // Bu arayüz farklı tipteki Loglama kaynaklarını ortak bir arayüz üzerinden yönetmemizi sağlar. 
    // Liskov yerine geçme kuralı ile işlerimizi kolaylaştırır.
    public abstract class LogBase
    {
        protected readonly object lockObj = new object();
        public abstract void Log(string message, bool isError);
    }
}
