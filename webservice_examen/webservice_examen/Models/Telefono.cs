using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webservice_examen.Models
{
    public class Telefono
    {
        public int Id { get; set; }
        public string Celular { get; set; }
        public string Casa { get; set; }
        public string Oficina { get; set; }
        public int IdPerfilUsuario { get; set; }
    }
}