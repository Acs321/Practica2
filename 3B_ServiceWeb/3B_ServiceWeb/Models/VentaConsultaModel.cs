using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3B_ServiceWeb.Models
{
    public class VentaConsultaModel
    {
        public int IdVenta { get; set; }
        public DateTime Fecha { get; set; }
        public string IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public decimal TotalVenta { get; set; }
    }
}
