using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webservice_examen.Data;

namespace webservice_examen.Models
{
    public class Rol
    {
        public int Id { get; set; }
        public string strValor { get; set; }
        public string strDescripcion { get; set; }
        public List<UsuarioRol> UsuariosRoles { get; set; }
    }
}