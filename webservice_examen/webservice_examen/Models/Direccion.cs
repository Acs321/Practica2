using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webservice_examen.Models
{
    public class Direccion
    {
        public int Id { get; set; }
        public string Calle { get; set; }
        public string Colonia { get; set; }
        public string NumInterior { get; set; }
        public string NumExterior { get; set; }
        public string Municipio { get; set; }
        public int idPerfilUsuario { get; set; }
    }
}