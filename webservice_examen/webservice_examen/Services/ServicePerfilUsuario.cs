using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webservice_examen.Data;
using webservice_examen.Models;

namespace webservice_examen.Services
{
    public class ServicePerfilUsuario
    {
        productosdbEntities conexion = null;

        public ServicePerfilUsuario()
        {
            conexion = new productosdbEntities();
        }

        public bool Crear(Data.perfilUsuario x)
        {
            bool resultado = false;
            var transaccion = conexion.Database.BeginTransaction();

            try
            {
                this.conexion.perfilUsuario.Add(x);
                this.conexion.SaveChanges();
                transaccion.Commit();
                resultado = true;
                return resultado;
            }
            
            catch (Exception ex)
            {
                transaccion.Rollback();
                return resultado;
                
                
            }
        
        }

       
        public List<UsuarioDireccionTelefono> GetAllInfoPerfilDireccionTelefono()
        {
            try
            {
                var consulta = from pu in conexion.perfilUsuario
                               join d in conexion.direcciones
                               on pu.id equals d.idPerfilUsuario
                               join t in conexion.Telefonos
                               on pu.id equals t.IdPerfilUsuario
                               select new UsuarioDireccionTelefono
                               {
                                   Id = pu.id,
                                   Nombre = pu.nombre,
                                   Calle = d.calle,
                                   Celular = t.celular

                               };


                return consulta.ToList();
            }
            catch (Exception ex)
            {
                List<UsuarioDireccionTelefono> usuariosPerfiles = new List<UsuarioDireccionTelefono>();
                return usuariosPerfiles;
            }


        }


        public List<perfilUsuario> GetAllInfoPerfilUsuario()
        {
           
            try
            {
                List<perfilUsuario> usuariosPerfiles = this.conexion.perfilUsuario
                               .Include("direcciones")
                               .Include("Telefonos").ToList();
                return usuariosPerfiles;
            }
            catch (Exception ex)
            {
                List<perfilUsuario> usuariosPerfiles = new List<perfilUsuario>();
                return usuariosPerfiles;

            }
        }

        public bool DeleteAllInfoPerfilDireccionTelefono(int IdPerfilUsuario)
        {
            bool result = false;
            var transaccion = this.conexion.Database.BeginTransaction();
            try
            {
                perfilUsuario perfilUsuario = this.conexion.perfilUsuario
                    .Include("direcciones")
                    .Include("Telefonos").Where(p => p.id == IdPerfilUsuario)
                    .FirstOrDefault();
                //validamos que realmente exista un usuario antes de ser eliminado

                if (perfilUsuario == null)
                {
                    return false;
                }

                //Eliminar direcciones
                if (perfilUsuario.direcciones != null && perfilUsuario.direcciones.Any())
                {
                    this.conexion.direcciones.RemoveRange(perfilUsuario.direcciones);
                }

                //Eliminar teléfonos
                if (perfilUsuario.Telefonos != null && perfilUsuario.Telefonos.Any())
                {
                    this.conexion.Telefonos.RemoveRange(perfilUsuario.Telefonos);
                }

                this.conexion.perfilUsuario.Remove(perfilUsuario);
                this.conexion.SaveChanges();
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

        public bool EditAllInforPerfilDireccionTelefono(perfilUsuario perfil)
        {
            bool result = false;
            var transaccion = conexion.Database.BeginTransaction();
            try
            {
                if (perfil == null || perfil.id <= 0)
                {
                    return result;
                }

                var user = conexion.perfilUsuario
                .Include("Direcciones")
                .Include("Telefonos")
                .FirstOrDefault(p => p.id == perfil.id);

                if (user == null) 
                {
                    return false;
                }
                user.nombre = perfil.nombre.ToLower().Trim();
                user.apellidoPaterno = perfil.apellidoPaterno.Trim();
                user.apellidoMaterno = perfil.apellidoMaterno.Trim();
                user.fechaNacimiento = perfil.fechaNacimiento;
                user.rfc = perfil.rfc;
                user.IdUsuario = perfil.IdUsuario;

                var direccionesEliminar = user.direcciones
                .Where(d => !perfil.direcciones.Any(pd => pd.id == d.id))
                .ToList();

                

                


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
    }

}