using System.Collections.Generic;
using webservice_examen.Data;

namespace webservice_examen.Models
{
    public partial class Usuario
    {
        public int id { get; set; }
        public string username { get; set; }
        public bool suspendido { get; set; }
        public string contrasenia { get; set; }
        public List<UsuarioRol> UsuariosRoles { get; set; }
    }
} 