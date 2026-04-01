using _3B_ServiceWeb.Models;
using _3B_ServiceWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace _3B_ServiceWeb.Web
{
    /// <summary>
    /// Descripción breve de WebVentas
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class WebVentas : System.Web.Services.WebService
    {
        [WebMethod]
        public List<ClienteModel> GetAllClientes()
        {
            ServicesVentas services = new ServicesVentas();
            var resultado = services.GetAllClientes();
            List<ClienteModel> listita = new List<ClienteModel>();

            foreach (var item in resultado)
            {
                ClienteModel cliente = new ClienteModel();
                cliente.IdCliente = item.idCleinte;
                cliente.Nombre = item.nombre;
                cliente.Pais = item.pais;
                cliente.Ciudad = item.ciudad;
                listita.Add(cliente);
            }

            return listita;
        }

        [WebMethod]
        public List<ProductoModel> GetAllProductos()
        {
            ServicesVentas services = new ServicesVentas();
            var resultado = services.GetAllProductos();
            List<ProductoModel> listita = new List<ProductoModel>();

            foreach (var item in resultado)
            {
                ProductoModel producto = new ProductoModel();
                producto.IdProducto = item.idProducto;
                producto.Nombre = item.nombre;
                producto.Precio = item.precio.HasValue ? item.precio.Value : 0;
                producto.Existencia = item.existencia.HasValue ? item.existencia.Value : (short)0;
                listita.Add(producto);
            }

            return listita;
        }

        [WebMethod]
        public RespuestaVentaModel RegistrarVenta(string idCliente, DetalleVentaModel[] detalleVenta)
        {
            ServicesVentas services = new ServicesVentas();
            return services.RegistrarVenta(idCliente, detalleVenta);
        }

        [WebMethod]
        public List<VentaConsultaModel> GetAllVentas()
        {
            ServicesVentas services = new ServicesVentas();
            return services.GetAllVentas();
        }

        [WebMethod]
        public List<DetalleVentaConsultaModel> GetDetalleVenta(int idVenta)
        {
            ServicesVentas services = new ServicesVentas();
            return services.GetDetalleVenta(idVenta);
        }
    }
}
