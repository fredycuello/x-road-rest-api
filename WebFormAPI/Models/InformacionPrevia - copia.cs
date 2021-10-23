using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestApi
{
    public class InformacionPrevia
    {
        public int ID { get; set; }
        public string numero { get; set; }
        public DateTime Fecha { get; set; }
        public string ROL { get; set; }

        [NotMapped]
        public byte[] documento { get; set; }
    }
}