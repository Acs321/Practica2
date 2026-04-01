using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Services;
using webservice_examen.Models;


namespace webservice_examen.Service
{
    /// <summary>
    /// Descripción breve de producto
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class producto : System.Web.Services.WebService
    {
        
        [WebMethod]
        public List<Models.Producto> GetProductos(List<Models.Producto> products) 
        {
            return products;
        }

        [WebMethod]
        public List<Models.Producto> OrdenarPorPrecio(List<Models.Producto> products)
        {
            Producto temp;

            for (int i = 0; i < products.Count - 1; i++)
            {
                for (int j = 0; j < products.Count - 1 - i; j++)
                {
                    if (products[j + 1].Precio > products[j].Precio)
                    {
                        temp = products[j];
                        products[j] = products[j + 1];
                        products[j + 1] = temp;

                    }
                }

            }

            return products;
        }

        [WebMethod]
        public List<Models.Producto> OrdenarPrecioBarato(List<Models.Producto> products) 
        {
            Producto temp;

            for (int i = 0; i < products.Count; i++)
            {
                for (int j = 0; j < products.Count - 1 -i; j++) 
                {
                    if (products[j+1].Precio < products[j].Precio)
                    {
                        temp = products[j];
                        products[j] = products[j + 1];
                        products[j + 1] = temp;
                    }
                
                }
            }

            return products;
        }

        [WebMethod]
        public List<Models.Producto> BuscarPorNombre(List<Models.Producto> products, string busqueda)
        { 
            List<Producto> encontrados = new List<Producto>();

            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Nombre.ToLower().Contains(busqueda.ToLower()))
                {
                    encontrados.Add(products[i]);
                }
            }
            return encontrados;
        }
        
        [WebMethod]
        public Models.Producto ObtenerPrimero(List<Models.Producto> products)
        {
            if (products.Count>0)
            {
                return products[0];
            }

            return null;
        }

        [WebMethod]
        public Models.Producto ObtenerUltimo(List<Models.Producto> products)
        {
            if (products.Count > 0)
            {
                return products[products.Count - 1];
            }
            return null;
        }

        [WebMethod]
        public void PdfProducto(List<Models.Producto> products)
        {
            FileStream fs = new FileStream(@"C:\pdfvisual\PDFGenerado.pdf", FileMode.Create);
            Document doc = new Document(PageSize.LETTER, 6, 6, 8, 8);
            PdfWriter pw = PdfWriter.GetInstance(doc, fs);

            doc.Open();
            

            doc.AddAuthor("Papu");
            doc.AddTitle("PDF Productos");

           
            iTextSharp.text.Font standarFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            
            doc.Add(new Paragraph("Productos Windows Forms"));
            doc.Add(Chunk.NEWLINE);
            
            
            PdfPTable tblEjemplo = new PdfPTable(8);
            tblEjemplo.WidthPercentage = 100;

            
            PdfPCell clCategoria = new PdfPCell(new Phrase("Categoria", standarFont));
            clCategoria.BorderWidth = 0;
            clCategoria.BorderWidthBottom = 0.75f;

            PdfPCell clNombre = new PdfPCell(new Phrase("Nombre", standarFont));
            clNombre.BorderWidth = 0;
            clNombre.BorderWidthBottom = 0.75f;

            PdfPCell clDescripcion = new PdfPCell(new Phrase("Descripcion", standarFont));
            clDescripcion.BorderWidth = 0;
            clDescripcion.BorderWidthBottom = 0.75f;

            PdfPCell clPrecio = new PdfPCell(new Phrase("Precio", standarFont));
            clPrecio.BorderWidth = 0;
            clPrecio.BorderWidthBottom = 0.75f;

            PdfPCell clUnidadMedida = new PdfPCell(new Phrase("Unidad de Medida", standarFont));
            clUnidadMedida.BorderWidth = 0;
            clUnidadMedida.BorderWidthBottom = 0.75f;

            PdfPCell clCaducable = new PdfPCell(new Phrase("Caducable", standarFont));
            clCaducable.BorderWidth = 0;
            clCaducable.BorderWidthBottom = 0.75f;

            PdfPCell clCodigoBarras = new PdfPCell(new Phrase("Codigo de barras", standarFont));
            clCodigoBarras.BorderWidth = 0;
            clCodigoBarras.BorderWidthBottom = 0.75f;

            PdfPCell clImagen = new PdfPCell(new Phrase("Imagen", standarFont));
            clImagen.BorderWidth = 0;
            clImagen.BorderWidthBottom = 0.75f;

            tblEjemplo.AddCell(clCategoria);
            tblEjemplo.AddCell(clNombre);
            tblEjemplo.AddCell(clDescripcion);
            tblEjemplo.AddCell(clPrecio);
            tblEjemplo.AddCell(clUnidadMedida);
            tblEjemplo.AddCell(clCaducable);
            tblEjemplo.AddCell(clCodigoBarras);
            tblEjemplo.AddCell(clImagen);

         
            foreach (var producto in products)
            {
                clCategoria = new PdfPCell(new Phrase(producto.Categoria, standarFont));
                clCategoria.BorderWidth = 0;

                clNombre = new PdfPCell(new Phrase(producto.Nombre, standarFont));
                clNombre.BorderWidth = 0;

                clDescripcion = new PdfPCell(new Phrase(producto.Descripcion, standarFont));
                clDescripcion.BorderWidth = 0;

                clPrecio = new PdfPCell(new Phrase(producto.Precio.ToString(), standarFont));
                clPrecio.BorderWidth = 0;

                clUnidadMedida = new PdfPCell(new Phrase(producto.UnidadMedida, standarFont));
                clUnidadMedida.BorderWidth = 0;

                clCaducable = new PdfPCell(new Phrase(producto.Caducable, standarFont));
                clCaducable.BorderWidth = 0;

                clCodigoBarras = new PdfPCell(new Phrase(producto.CodigoBarras, standarFont));
                clCodigoBarras.BorderWidth = 0;

                clImagen = new PdfPCell(new Phrase(producto.NombreImagen, standarFont));
                clImagen.BorderWidth = 0;

                tblEjemplo.AddCell(clCategoria);
                tblEjemplo.AddCell(clNombre);
                tblEjemplo.AddCell(clDescripcion);
                tblEjemplo.AddCell(clPrecio);
                tblEjemplo.AddCell(clUnidadMedida);
                tblEjemplo.AddCell(clCaducable);
                tblEjemplo.AddCell(clCodigoBarras);
                tblEjemplo.AddCell(clImagen);

            }

            doc.Add(tblEjemplo);
            doc.Close();
            pw.Close();
   
        }

        [WebMethod]
        public void GuardarProductos(List<Models.Producto> products)
        {
            foreach (var producto in products)
            {
                    string carpeta = HttpContext.Current.Server.MapPath("~/image/");
                    string nombreArchivo = producto.NombreImagen;
                    string rutaCompleta = Path.Combine(carpeta, nombreArchivo);

                    File.WriteAllBytes(rutaCompleta, producto.ImagenBytes);
                
            }

        }

    }
}
