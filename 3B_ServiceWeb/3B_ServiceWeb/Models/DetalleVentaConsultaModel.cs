using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3B_ServiceWeb.Models
{
    public class DetalleVentaConsultaModel
    {
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
    }
}
