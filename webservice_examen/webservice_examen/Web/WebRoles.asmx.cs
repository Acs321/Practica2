using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using webservice_examen.Data;
using webservice_examen.Models;

namespace webservice_examen.Web
{
    /// <summary>
    /// Descripción breve de WebRoles
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebRoles : System.Web.Services.WebService
    {

        [WebMethod]
        public bool Create(Rol rol)
        {
            roles roles = new roles();
            roles.strValor = rol.strValor;
            roles.strDescripcion = rol.strDescripcion;
            
            Services.ServiceRoles servicesRoles = new Services.ServiceRoles();
            servicesRoles.Create(roles);
            return true;
        }

        [WebMethod]
        public List<Rol> GetAllRoles()
        { 
        Services.ServiceRoles serviceRoles = new Services.ServiceRoles();
        List<Rol> Roles = new List<Rol>();
        foreach (var item in serviceRoles.GeAlltRoles())
        {
            Rol rol = new Rol();
                rol.Id = item.id;
                rol.strValor = item.strValor;
                rol.strDescripcion = item.strDescripcion;

                Roles.Add(rol);
        }
            return Roles;
        }
    }
}
