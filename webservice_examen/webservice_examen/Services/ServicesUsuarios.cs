using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webservice_examen.Data;
using webservice_examen.Models;

namespace webservice_examen.Services
{
    public class ServicesUsuarios
    {
        productosdbEntities conexion = null;

        public ServicesUsuarios() 
        { 
        conexion = new productosdbEntities();
        }

        public bool CreateUsuarios(usuarios usuario)
        {
            bool result = false;
            var transaccion = conexion.Database.BeginTransaction();

            try
            {
                if (usuario!=null)
                {
                    conexion.usuarios.Add(usuario);
                    conexion.SaveChanges();
                    transaccion.Commit();
                    result = true;
                }
                return result;
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                result = false;
                return result;
            }
        }

        public bool Crear(webservice_examen.Data.usuarios usuario)
        {
            bool result = true;
            var transaccion = conexion.Database.BeginTransaction();
            try
            {
                if (usuario != null)
                {
                    //usuario.suspendido = false;
                    conexion.usuarios.Add(usuario);
                    foreach (var u in usuario.UsuarioRoles)
                    {
                        conexion.UsuarioRoles.Add(u);
                    }
                    conexion.SaveChanges();
                    transaccion.Commit();
                    result = true;
                }
                return result;
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                return result;
            }
        }

        public usuarios GetUsuario(usuarios usuarios)
        {
            try
            {
                return conexion.usuarios
                    .Where(p => p.username.Equals(usuarios.username.Trim()) && p.contrasenia.Equals(usuarios.contrasenia.Trim()))
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                usuarios usuario = new usuarios { username = string.Empty, id = 0 };
                return usuario;
            }
        }

        public bool DeleteUsuario(int id)
        {
            bool result = true;
            var transaccion = conexion.Database.BeginTransaction();
            try
            {
                usuarios user = conexion.usuarios.First(p => p.id == id);
                if (user != null)
                {
                    conexion.usuarios.Remove(user);
                    conexion.SaveChanges();
                    transaccion.Commit(); 
                    result = true;
                }
                return result;
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                result = false;
                return result;
            }
        
        }

        public bool SuspenderCuenta(usuarios usuarios)
        {
            bool result = true;
            var transaccion = conexion.Database.BeginTransaction();
            try
            {
                usuarios user = conexion.usuarios.First(p => p.id == usuarios.id);
                if (user != null)
                {
                    user.suspendido = true;
                    conexion.SaveChanges();
                    transaccion.Commit();
                    result = true;

                }
                return result;
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                result = false;
                return result;
            }
        
        }

        public bool ValidarLogin(usuarios usuario)
        {
            bool result = false;
            try
            {
                usuarios user = conexion.usuarios.First(p => p.username.Equals(usuario.username)
                && p.contrasenia.Equals(usuario.contrasenia) && p.suspendido == false);
                if (user != null)
                {
                    result = true;

                }

                return result;
            }
            catch (Exception ex)
            {
                return result;

            }

        }

        public Usuario Login(usuarios usuario)
        {
            bool result = true;
            try
            {
                usuarios user = conexion.usuarios.First(p => p.username.Equals(usuario.username)
                && p.contrasenia.Equals(usuario.contrasenia) && p.suspendido == false);

                if (user != null)
                {
                    Usuario objUser = new Usuario{ 
                        id = user.id, 
                        username = user.username, 
                        contrasenia = user.contrasenia, 
                        suspendido = user.suspendido
                    };
                    return objUser;
                }
                else
                {
                    Usuario usuarioNull = new Usuario { username = string.Empty, id = 0 };
                    return usuarioNull;
                }

            }
            catch (Exception ex)
            {
                Usuario usuarioNull =  new Usuario { username = string.Empty, id = 0 };
                return usuarioNull;
            }
        }

        public bool ValidarSuspension(usuarios usuario)
        {
            bool result = true;
            try
            {
                return result = conexion.usuarios.Any(p => p.username.Equals(usuario.username) &&
                p.contrasenia.Equals(usuario.contrasenia) &&
                p.suspendido == false);
            }
            catch (Exception ex)
            {
                result = false;
                return result;
               
            }
        
        }

        public bool ActivarSuspension(usuarios usuario)
        {
            bool result = true; 
            var transaccion = conexion.Database.BeginTransaction(); 
            try
            {
                usuarios user = conexion.usuarios.First(p => p.id == usuario.id);
                if (user!= null)
                {
                    if (user.suspendido == true)
                    {
                        user.suspendido = false;
                        conexion.SaveChanges();
                        transaccion.Commit();
                        result = true;
                    }
                    else {
                        return result;
                    }
                }
                return result;
            }
            catch (Exception ex) 
            {

                transaccion.Rollback();
                return result;

            }
        
        }

        public bool EditarUsuario(usuarios usuario)
        {
            bool result = false;
            var transaccion = conexion.Database.BeginTransaction();

            try
            {
                if (usuario == null || usuario.id <=0)
                {
                    return result;
                }
                var user = conexion.usuarios.FirstOrDefault(p => p.id == usuario.id);
                if (user == null)
                {
                    return false;
                }

                user.username = usuario.username.ToLower().Trim();
                user.contrasenia = usuario.contrasenia.ToLower().Trim();
                conexion.SaveChanges();
                transaccion.Commit();
                result = true;
                return result;

                
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                return result;
                
            }
        
        }

        public List<usuarios> GetAllUsuarios()
        {
            try
            {
                return conexion.usuarios.OrderBy(p => p.username).ToList();

            }
            catch (Exception ex)
            {

                return new List<usuarios>();
            }
        
        }
        /* Este metodo se encargara de consultar al usuario utilizando la clausula like de sql*/
        public webservice_examen.Data.usuarios GetUsuarioByName(string username)
        {
            try
            {
                return conexion.usuarios.
                    Where(p => p.username.
                    StartsWith(username) && p.suspendido == false).FirstOrDefault();
            }
            catch (Exception ex)
            {
                webservice_examen.Data.usuarios usuario = new webservice_examen.Data.usuarios { username = string.Empty, id = 0 };
                return usuario;
            }
        }

        public List<webservice_examen.Data.usuarios> GetSuspendidoSp()
        {
            try
            {
                return conexion.usuarios
                        .SqlQuery("EXEC dbo.sp_GetSuspendidos")
                        .AsNoTracking()
                        .ToList();
            }
            catch (Exception ex)
            {
                return new List<webservice_examen.Data.usuarios>();
            }
        
        
        }

        public int GetIdMaximo() 
        {
            try
            {
                //var query = from p in conexion.usuarios
                //            orderby p.id descending
                //            group p by p.id into g
                //            select new { identificador = g.Key };


                //var maximo = query.Max(g => g.identificador);
                //var query3 = (from u in conexion.usuarios
                //              where u.id == maximo
                //              select u).AsQueryable().ToList().First(); 



                //TipoA tipoA = new TipoA { Maximo = maximo,
                //    nombre = query3.username, suspendido = query3.suspendido};

                return conexion.usuarios.Max(p => p.id);
            }
            catch (Exception ex)
            {
                return 0;
            }
        
        }

        public int GetIdMinimo()
        {
            try
            {
                return conexion.usuarios.Min(p => p.id);
            }
            catch (Exception ex)
            {
                return 0;
            }
        
        
        }

        public List<webservice_examen.Data.usuarios> GetUsuariosByLike(string letra)
        {
            try
            {
                var query = from u in conexion.usuarios
                            where u.username.StartsWith(letra) && u.suspendido == false
                            select u;

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener usuarios por letra", ex);
            }

        }

        public int GetSumAll(string letra)
        {
            try
            {
                var query = from u in conexion.usuarios
                            where u.suspendido == false && u.username.StartsWith(letra)
                            select u.id;

                int suma = query.Sum();

                return suma;

                //var quety2 = conexion.usuarios
                //    .Where(p => p.suspendido == false && p.username.StartsWith(letra))
                //    .Select(p => p.id).Sum();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al calcular la suma de IDs", ex);
            }
        
        }

        public List<UsuarioSimple> GetAlgo()
        {
            //conexion.usuarios.Where (p => p.suspendido == false).ToList();

            //conexion.usuarios.ToList();
            try
            {
                var query = from u in conexion.usuarios
                            where u.suspendido == true
                            orderby u.username ascending
                            select new { Nombre = u.username, Status = u.suspendido };

                var result = query.GroupBy(p => p.Nombre).ToList();

                List<UsuarioSimple> user = new List<UsuarioSimple>();

                foreach (var item in result)
                {
                    UsuarioSimple usuario = new UsuarioSimple();
                    usuario.Nombre = item.Key;
                    user.Add(usuario);
                }

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en método GetAlgo", ex);
            }

        }

        public double GetAlgo1()
        {
            try
            {
                var query = from u in conexion.usuarios
                            where u.username.StartsWith("a") && u.suspendido == false
                            select (double?)u.id;

                double result = query.Average() ?? 0;

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al calcular promedio", ex);
            }

        }

        //public List<webservice_examen.Data.usuarios> GetUsuariosRoles()
        //{
        //    try
        //    {
        //       List<usuarios> user = conexion.usuarios.Include("UsuarioRoles").Include("roles").ToList();   
        //        return user;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new List<webservice_examen.Data.usuarios>();
        //    }

        //}

        public List<UsuarioConRoles> GetAllUsuariosRoles()
        {
            try
            {
                var consulta = from u in conexion.usuarios
                               join ur in conexion.UsuarioRoles
                               on u.id equals ur.idUsuario
                               join r in conexion.roles
                               on ur.idRol equals r.id
                               select new UsuarioConRoles
                               {
                                   //IdUsuario = u.id,
                                   Nombre = u.username.Trim().ToLower(),
                                   //IdRol = r.id,
                                   NombreRol = r.strValor.Trim().ToLower(),
                                   Descripcion = r.strDescripcion.Trim().ToLower(),
                               };
                return consulta.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        
        }
    }
    }
