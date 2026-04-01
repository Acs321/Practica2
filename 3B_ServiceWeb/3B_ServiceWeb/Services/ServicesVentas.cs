using _3B_ServiceWeb.Data;
using _3B_ServiceWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace _3B_ServiceWeb.Services
{
    public class ServicesVentas
    {
        BD_3BEntities conexion = null;

        public ServicesVentas()
        {
            conexion = new BD_3BEntities();
        }

        public List<Cliente> GetAllClientes()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            var query = from c in conexion.Cliente
                        orderby c.nombre ascending
                        select c;

            foreach (var item in query)
            {
                listaClientes.Add(item);
            }
            return listaClientes;
        }

        public List<Productos> GetAllProductos()
        {
            List<Productos> listaProductos = new List<Productos>();
            var query = from p in conexion.Productos
                        orderby p.nombre ascending
                        select p;

            foreach (var item in query)
            {
                listaProductos.Add(item);
            }
            return listaProductos;
        }

        public RespuestaVentaModel RegistrarVenta(string idCliente, DetalleVentaModel[] detalle)
        {
            RespuestaVentaModel result = new RespuestaVentaModel();

            try
            {
                if (string.IsNullOrEmpty(idCliente))
                {
                    result.Respuesta = false;
                    result.Mensaje = "El cliente es obligatorio";
                    return result;
                }

                if (detalle == null || detalle.Length == 0)
                {
                    result.Respuesta = false;
                    result.Mensaje = "Debe seleccionar productos";
                    return result;
                }

                DataTable tabla = new DataTable();
                tabla.Columns.Add("idProducto", typeof(int));
                tabla.Columns.Add("Cantidad", typeof(int));

                foreach (var item in detalle)
                {
                    if (item != null)
                    {
                        tabla.Rows.Add(item.IdProducto, item.Cantidad);
                    }
                }

                string entityConnection = ConfigurationManager.ConnectionStrings["BD_3BEntities"].ConnectionString;
                EntityConnectionStringBuilder builder = new EntityConnectionStringBuilder(entityConnection);

                using (SqlConnection sqlConnection = new SqlConnection(builder.ProviderConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_RegistrarVentaMultiples", sqlConnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@idCliente", idCliente.Trim());

                        SqlParameter detalleParameter = command.Parameters.AddWithValue("@detalleVenta", tabla);
                        detalleParameter.SqlDbType = SqlDbType.Structured;
                        detalleParameter.TypeName = "dbo.TypeDetalleVenta";

                        SqlParameter idVenta = new SqlParameter("@idVenta", SqlDbType.Int);
                        idVenta.Direction = ParameterDirection.Output;
                        command.Parameters.Add(idVenta);

                        sqlConnection.Open();
                        command.ExecuteNonQuery();

                        result.Respuesta = true;
                        result.Mensaje = "La venta se registro correctamente";
                        result.IdVenta = int.Parse(command.Parameters["@idVenta"].Value.ToString());
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                result.Respuesta = false;
                result.Mensaje = ex.Message;
                result.IdVenta = 0;
                return result;
            }
        }

        public List<VentaConsultaModel> GetAllVentas()
        {
            List<VentaConsultaModel> listaVentas = new List<VentaConsultaModel>();

            var query = from v in conexion.Venta
                        join c in conexion.Cliente on v.idCleinte equals c.idCleinte
                        orderby v.idVenta descending
                        select new
                        {
                            v.idVenta,
                            v.fecha,
                            v.idCleinte,
                            NombreCliente = c.nombre
                        };

            foreach (var item in query)
            {
                decimal totalVenta = 0;
                var detalle = conexion.DetalleVenta.Where(p => p.idVenta == item.idVenta).ToList();
                foreach (var itemDetalle in detalle)
                {
                    totalVenta = totalVenta + (itemDetalle.PrecioVenta * itemDetalle.Cantidad);
                }

                VentaConsultaModel venta = new VentaConsultaModel();
                venta.IdVenta = item.idVenta;
                venta.Fecha = item.fecha.HasValue ? item.fecha.Value : DateTime.Now;
                venta.IdCliente = item.idCleinte;
                venta.NombreCliente = item.NombreCliente;
                venta.TotalVenta = totalVenta;
                listaVentas.Add(venta);
            }

            return listaVentas;
        }

        public List<DetalleVentaConsultaModel> GetDetalleVenta(int idVenta)
        {
            List<DetalleVentaConsultaModel> listaDetalle = new List<DetalleVentaConsultaModel>();

            var query = from d in conexion.DetalleVenta
                        join p in conexion.Productos on d.idProducto equals p.idProducto
                        where d.idVenta == idVenta
                        select new
                        {
                            d.idVenta,
                            d.idProducto,
                            NombreProducto = p.nombre,
                            d.PrecioVenta,
                            d.Cantidad
                        };

            foreach (var item in query)
            {
                DetalleVentaConsultaModel detalle = new DetalleVentaConsultaModel();
                detalle.IdVenta = item.idVenta;
                detalle.IdProducto = item.idProducto;
                detalle.NombreProducto = item.NombreProducto;
                detalle.PrecioVenta = item.PrecioVenta;
                detalle.Cantidad = item.Cantidad;
                detalle.Subtotal = item.PrecioVenta * item.Cantidad;
                listaDetalle.Add(detalle);
            }

            return listaDetalle;
        }
    }
}
