using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestAPI
{
    [Table("Factibilidades")]
    public class Factibilidad
    {
        public int ID { get; set; }
        public string ROL { get; set; }
        public bool factible { get; set; }

    }
}