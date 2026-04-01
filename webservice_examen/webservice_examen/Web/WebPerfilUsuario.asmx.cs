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
    /// Descripción breve de WebPerfilUsuario
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebPerfilUsuario : System.Web.Services.WebService
    {

        [WebMethod]
        public bool Crear(Models.PerfilUsuario perfilUsuario)
        {
            Data.perfilUsuario perfil = new Data.perfilUsuario();
            perfil.nombre = perfilUsuario.Nombre.Trim().ToLower();

            List<Data.direcciones> listDirecciones = new List<direcciones>();

            foreach (var d in perfilUsuario.Direcciones)
            {
                Data.direcciones direcciones = new Data.direcciones();
                direcciones.calle = d.Calle.Trim().ToLower();
                listDirecciones.Add(direcciones);
            }

            perfil.direcciones = listDirecciones;

            List<Data.Telefonos> listTelefonos = new List<Telefonos>();
            foreach (var t in perfilUsuario.Telefonos)
            {
                Data.Telefonos telefonos = new Data.Telefonos();
                telefonos.celular = t.Celular.Trim().ToLower();
                listTelefonos.Add(telefonos);
            }

            perfil.Telefonos = listTelefonos;

            Services.ServicePerfilUsuario perfilUsuarioServices = new Services.ServicePerfilUsuario();
            return perfilUsuarioServices.Crear(perfil);

        }

        [WebMethod]
        public List<Models.PerfilUsuario> GetAllUsuariosPerfiles()
        {
            Services.ServicePerfilUsuario servicePerfil = new Services.ServicePerfilUsuario();
            List<Data.perfilUsuario> listado = servicePerfil.GetAllInfoPerfilUsuario();

            List<Models.PerfilUsuario> perfilesUsuarios = new List<PerfilUsuario>();
            
            foreach (var pu in listado)
            {
                List<Models.Direccion> listadoD = new List<Models.Direccion>();
                List<Models.Telefono> listadoT = new List<Models.Telefono>();
                foreach (var d in pu.direcciones)
                {
                    Models.Direccion direccion = new Models.Direccion();
                    direccion.Calle = d.calle;
                    direccion.Colonia = d.colonia;
                    direccion.NumExterior = d.NumExterior;
                    direccion.NumInterior = d.NumInterior;
                    direccion.Municipio = d.Municipio;
                    direccion.Id = d.id;
                    listadoD.Add(direccion);
                }

                foreach (var t in pu.Telefonos)
                {
                    Models.Telefono telefono = new Models.Telefono();
                    telefono.Celular = t.celular;
                    telefono.Id = t.id;
                    telefono.Oficina = t.oficina;
                    telefono.Casa = t.casa;
                    listadoT.Add(telefono);
                }
                Models.PerfilUsuario perfilUsuario = new Models.PerfilUsuario();
                perfilUsuario.Nombre = pu.nombre;
                perfilUsuario.Id = pu.id;
                perfilUsuario.Direcciones = listadoD;
                perfilUsuario.Telefonos = listadoT;
            }
            return perfilesUsuarios;

        }

        [WebMethod]
        public List<UsuarioDireccionTelefono> GetAllInfoPerfilDireccionTelefono()
        {
            Services.ServicePerfilUsuario servicePerfil = new Services.ServicePerfilUsuario();
            return servicePerfil.GetAllInfoPerfilDireccionTelefono();
        }

        [WebMethod]
        public bool DeleteAllInfoPerfilDireccionTelefono(int IdPerfilUsuario)
        {

            Services.ServicePerfilUsuario servicePerfil = new Services.ServicePerfilUsuario();
            return servicePerfil.DeleteAllInfoPerfilDireccionTelefono(IdPerfilUsuario);
        }
    }
}
