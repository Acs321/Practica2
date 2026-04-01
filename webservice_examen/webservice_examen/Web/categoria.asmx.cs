using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace webservice_examen.Service
{
    /// <summary>
    /// Descripción breve de categoria
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class categoria : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Models.Categoria> GetCategoria() {
            return new List<Models.Categoria>() 
            { 
            new Models.Categoria { idCategoria = 1, NombreCategoria= "Frutas"},
            new Models.Categoria { idCategoria = 2, NombreCategoria= "Verduras"},
            new Models.Categoria { idCategoria = 3, NombreCategoria= "Carnes y Embutidos"},
            new Models.Categoria { idCategoria = 4, NombreCategoria= "Cremeria"},
            new Models.Categoria { idCategoria = 5, NombreCategoria= "Electronica"},
            new Models.Categoria { idCategoria = 6, NombreCategoria= "Hogar"}
            };
        
        }
    }
}
