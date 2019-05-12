using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnadoluRentalWeb.Models
{
    public class ResponseContent<T> where T : class
    {
        public string Result { get; set; }
        public List<T> Data { get; set; }
    }
}