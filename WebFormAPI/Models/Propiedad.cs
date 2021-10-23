using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestAPI
{
    [Table("Propiedades")]
    public class Propiedad
    {
        public int ID { get; set; }
        public string ROL { get; set; }
        public string NombreVia { get; set; }
        public int Numero { get; set; }
        public string NumeroLocal { get; set; }
        public string Manzana { get; set; }
        public string Lote { get; set; }
        public string Poblacion { get; set; }
        public string Localidad { get; set; }
        public string NumeroPlano { get; set; }
    }
}