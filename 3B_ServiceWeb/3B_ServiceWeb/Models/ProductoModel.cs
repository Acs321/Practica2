using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3B_ServiceWeb.Models
{
    public class ProductoModel
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public short Existencia { get; set; }
    }
}
