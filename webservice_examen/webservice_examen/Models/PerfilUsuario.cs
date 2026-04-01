using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webservice_examen.Data;

namespace webservice_examen.Models
{
    public class PerfilUsuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Rfc { get; set; }
        public int IdUsuario { get; set; }
        public List<Direccion> Direcciones { get; set; }
        public List<Telefono> Telefonos { get; set; }
    }
}