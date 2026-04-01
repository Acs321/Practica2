using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using webservice_examen.Data;

namespace webservice_examen.Services
{
    public class ServiceRoles
    {
        productosdbEntities conexion = null;

        public ServiceRoles()
        { 
        conexion = new productosdbEntities();
        }

        public bool Create(roles roles)
        {
            bool result = false;
            var  transaction = conexion.Database.BeginTransaction();
            try
            {
                conexion.roles.Add(roles);
                conexion.SaveChanges();
                transaction.Commit();
                result = true;
                return result;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                result = false;
                return result;
            }
        
        }

        public List<roles> GeAlltRoles()
        {
            return conexion.roles.ToList();
        }

        public List<roles> GetTodosRoles()
        { 
            //se crea una lista de roles vacia
            List<roles> listaRoles = new List<roles>();
            //genera la consulta trayendo todos los roles per ordenados de forma
            ////descendente
            var query = from r in conexion.roles
                        orderby r.strValor descending
                        select r;
            //los agrega a la lista
            foreach (var item in query)
            {
                listaRoles.Add(item);
            }
            //regresa la lista de forma ordenada
            return listaRoles;
        }
    }
}