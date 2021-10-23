using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApi
{
    public class Patente
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string RUT { get; set; }
        public string Direccion { get; set; }
        public string Fono { get; set; }
        public string Email { get; set; }
        public string Profesion { get; set; }
        public DateTime Vigencia { get; set; }


    }
}