using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI.WebControls;
using webservice_examen.Data;
using webservice_examen.Models;

namespace webservice_examen.Web
{
    /// <summary>
    /// Descripción breve de WebUsuarios
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebUsuarios : System.Web.Services.WebService
    {
        [WebMethod]
        public bool Create(Usuario usuario)
        {
            usuarios usuarios = new usuarios();
            usuarios.username = usuario.username;
            usuarios.contrasenia = usuario.contrasenia;
            usuarios.suspendido = usuario.suspendido;

            Services.ServicesUsuarios usuariosServices = new Services.ServicesUsuarios();
            usuariosServices.CreateUsuarios(usuarios);
            return true;

        }

        [WebMethod]
        public bool Crear(Usuario usuario)
        {
            usuarios usuarios = new usuarios();
            usuarios.username = usuario.username.Trim().ToLower();
            usuarios.contrasenia = usuario.contrasenia.Trim().ToLower();
            usuarios.suspendido = usuario.suspendido;
            List<UsuarioRoles> userRoles = new List<UsuarioRoles>();

            foreach (var userR in usuario.UsuariosRoles)
            {
                userRoles.Add(new UsuarioRoles
                {
                    //idUsuario = userR.Usuario.id,
                    idRol = userR.Rol.Id
                });
                
            }
            usuarios.UsuarioRoles = userRoles;

            Services.ServicesUsuarios usuariosServices = new Services.ServicesUsuarios();
            return usuariosServices.Crear(usuarios);
        }

        [WebMethod]
        public Usuario GetUsuario(Usuario usuario)
        {
            usuarios usuarios = new usuarios();
            usuarios.username = usuario.username;
            usuarios.contrasenia = usuario.contrasenia;

            Services.ServicesUsuarios servicesUsuarios = new Services.ServicesUsuarios();
            var result = servicesUsuarios.GetUsuario(usuarios);

            Usuario GetUsuario = new Usuario();

            if (result != null)
            {
                GetUsuario.id = result.id;
                GetUsuario.username = result.username;
                GetUsuario.suspendido = result.suspendido;
                GetUsuario.contrasenia = result.contrasenia;
            }
            
            return GetUsuario;
        }

        [WebMethod]
        public bool Delete(int id)
        { 
            Services.ServicesUsuarios servicesUsuarios = new Services.ServicesUsuarios();
            return servicesUsuarios.DeleteUsuario(id);
        }

        [WebMethod]
        public bool Suspender(Usuario usuario)
        {
            usuarios usuarios = new usuarios();
            usuarios.id = usuario.id;

            Services.ServicesUsuarios servicesUsuarios = new Services.ServicesUsuarios();
            return servicesUsuarios.SuspenderCuenta(usuarios);
            
        }

        [WebMethod]
        public bool ValidarLogin(Usuario usuario)
        {
            usuarios usuarios = new usuarios();
            usuarios.username = usuario.username;
            usuarios.suspendido = usuario.suspendido;
            usuarios.contrasenia = usuario.contrasenia;

            Services.ServicesUsuarios servicesUsuarios = new Services.ServicesUsuarios();
            return servicesUsuarios.ValidarLogin(usuarios);
        }

        [WebMethod]
        public bool ValidarSuspension(Usuario usuario)
        {
            usuarios usuarios = new usuarios();
            usuarios.username = usuario.username;
            usuarios.suspendido = usuario.suspendido;
            usuarios.contrasenia = usuario.contrasenia;

            Services.ServicesUsuarios servicesUsuarios = new Services.ServicesUsuarios();
            return servicesUsuarios.ValidarSuspension(usuarios);
        }

        [WebMethod]
        public bool ReactivarCuenta(Usuario usuario)
        {
            usuarios usuarios = new usuarios();
            usuarios.id = usuario.id;

            Services.ServicesUsuarios servicesUsuarios = new Services.ServicesUsuarios();
            return servicesUsuarios.ActivarSuspension(usuarios);
        }

        [WebMethod]
        public bool EditarUsuario(Usuario usuario)
        {
            usuarios usuarios = new usuarios();
            usuarios.id = usuario.id;
            usuarios.username = usuario.username;
            usuarios.suspendido = usuario.suspendido;
            usuarios.contrasenia = usuario.contrasenia;

            Services.ServicesUsuarios servicesUsuarios = new Services.ServicesUsuarios();
            servicesUsuarios.EditarUsuario(usuarios);
            return true;
        }

        [WebMethod]
        public List<Usuario> GetAll()
        {
            Services.ServicesUsuarios servicesUsuarios = new Services.ServicesUsuarios();
            var resultado = servicesUsuarios.GetAllUsuarios();

            List<Usuario> listita = new List<Usuario>();

            foreach (var item in resultado)
            {
                Usuario usuarios = new Usuario();
                usuarios.id = item.id;
                usuarios.username = item.username;
                usuarios.contrasenia = item.contrasenia;
                usuarios.suspendido = item.suspendido;

                listita.Add(usuarios);
            }
            return listita;
        }

        [WebMethod]
        public Usuario Login(Usuario user)
        {
            usuarios usuario = new usuarios();
            usuario.suspendido = false;
            usuario.username = user.username;
            usuario.contrasenia = user.contrasenia;

            List<UsuarioRoles> UsuarioRoles = new List<UsuarioRoles>();

            foreach (var usuarioRol in user.UsuariosRoles)
            {
                UsuarioRoles.Add(new UsuarioRoles
                { 
                    idUsuario = usuarioRol.Usuario.id,
                    idRol = usuarioRol.Rol.Id
                });
            }
            usuario.UsuarioRoles = UsuarioRoles;
            Services.ServicesUsuarios servicesUsuarios = new Services.ServicesUsuarios();
            return servicesUsuarios.Login(usuario);

        }

        [WebMethod]
        public Usuario GetUsuarioByName(string username)
        {
            Services.ServicesUsuarios servicesUsuarios = new Services.ServicesUsuarios();

            var resultado = servicesUsuarios.GetUsuarioByName(username);

            Usuario usuario = new Usuario();

            if (resultado != null)
            {
                usuario.id = resultado.id;
                usuario.username = resultado.username;
                usuario.suspendido = resultado.suspendido;
                usuario.contrasenia = resultado.contrasenia;
            }

            return usuario;
        }

        [WebMethod]
        public List<Usuario> GetSuspendidoStp()
        {
            Services.ServicesUsuarios servicesUsuarios = new Services.ServicesUsuarios();
            var resultado = servicesUsuarios.GetSuspendidoSp();

            List<Usuario> listita = new List<Usuario>();

            foreach (var item in resultado)
            {
                Usuario usuarios = new Usuario();
                usuarios.id = item.id;
                usuarios.username = item.username;
                usuarios.contrasenia = item.contrasenia;
                usuarios.suspendido = item.suspendido;

                listita.Add(usuarios);

            }

            return listita;
        }

        [WebMethod]
        public int GetIdMaximo()
        {
            Services.ServicesUsuarios servicesUsuarios = new Services.ServicesUsuarios();
            return servicesUsuarios.GetIdMaximo();
        }

        [WebMethod]
        public int GetIdMinimo()
        {
            Services.ServicesUsuarios servicesUsuarios = new Services.ServicesUsuarios();
            return servicesUsuarios.GetIdMinimo();
        }

        [WebMethod]
        public List<Usuario> GetUsuariosByLike(string letra)
        {
            Services.ServicesUsuarios servicesUsuarios = new Services.ServicesUsuarios();
            var resultado=  servicesUsuarios.GetUsuariosByLike(letra);

            List<Usuario> listita = new List<Usuario>();

            foreach (var item in resultado)
            {
                Usuario usuarios = new Usuario();
                usuarios.id = item.id;
                usuarios.username = item.username;
                usuarios.contrasenia = item.contrasenia;
                usuarios.suspendido = item.suspendido;

                listita.Add(usuarios);
            }

            return listita;
        }

        [WebMethod]
        public int GetSumAll(string letra)
        {
            Services.ServicesUsuarios servicesUsuarios = new Services.ServicesUsuarios();
            return servicesUsuarios.GetSumAll(letra);
        }

        [WebMethod]
        public List<Usuario> GetAlgo()
        {
            Services.ServicesUsuarios servicesUsuarios = new Services.ServicesUsuarios();
            var resultado =  servicesUsuarios.GetSuspendidoSp();

            List<Usuario> listita = new List<Usuario>();

            foreach (var item in resultado)
            {
                Usuario usuarios = new Usuario();
                usuarios.id = item.id;
                usuarios.username = item.username;
                usuarios.contrasenia = item.contrasenia;
                usuarios.suspendido = item.suspendido;

                listita.Add(usuarios);
            }

            return listita;
        }

        [WebMethod]
        public List<UsuarioConRoles> GetAllUsuariosRoles()
        {
            Services.ServicesUsuarios servicesUsuarios = new Services.ServicesUsuarios();
            return servicesUsuarios.GetAllUsuariosRoles();
            
        }

        //[WebMethod]
        //public List<UsuarioSimple> GetAlgo()
        //{
        //    Services.ServicesUsuarios servicesUsuarios = new Services.ServicesUsuarios();

        //    var lista = servicesUsuarios.GetSuspendidoSp();

        //    return lista.Select(u => new UsuarioSimple
        //    {
        //        Nombre = u.username
        //    }).ToList();
        //}

        //[WebMethod]
        //public double GetAlgo1()
        //{
        //    Services.ServicesUsuarios servicesUsuarios = new Services.ServicesUsuarios();
        //    return servicesUsuarios.GetAlgo1();
        //}

        //[WebMethod]
        //public List<usuarios> GetUsuariosRoles()
        //{
        //    Services.ServicesUsuarios servicesUsuarios = new Services.ServicesUsuarios();
        //    return servicesUsuarios.GetUsuariosRoles();
        //}


    }
}
