using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webservice_examen.Models
{
    public class UsuarioRol
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public Rol Rol { get; set; }
    }
}