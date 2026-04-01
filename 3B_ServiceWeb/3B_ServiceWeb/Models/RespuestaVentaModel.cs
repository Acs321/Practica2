using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3B_ServiceWeb.Models
{
    public class RespuestaVentaModel
    {
        public bool Respuesta { get; set; }
        public string Mensaje { get; set; }
        public int IdVenta { get; set; }
    }
}
