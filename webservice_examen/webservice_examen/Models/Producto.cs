using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webservice_examen.Models
{
    public class Producto
    {
        public string Categoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public string UnidadMedida { get; set; }
        public string Caducable { get; set; }
        public string CodigoBarras { get; set; }
        public byte[] ImagenBytes { get; set; }
        public string NombreImagen { get; set; }
       
    }
}