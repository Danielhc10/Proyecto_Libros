using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Proyecto1
{
    public partial class Libro_EF : System.Web.UI.Page
    {
        /**
         * DANIEL HERNANDEZ CRUZ
         * 22/06/2021
         */
        private void ConsultaLibros()
        {
            using (DB_PROG_WEBEntities db = new DB_PROG_WEBEntities())
            {
                var Libros = db.C_LIBRO_EF.ToList();
                gvDatos.DataSource = Libros;
                gvDatos.DataBind();
                
                ddwLibros.DataSource = Libros;
                ddwLibros.DataValueField = "ID";
                ddwLibros.DataTextField = "LIBRO";
                ddwLibros.DataBind();
                ddwLibros.Items.Insert(0, "--Seleccionar--");
            }
        }
        /**
         * DANIEL HERNANDEZ CRUZ
         * 22/06/2021
         */
        private void AgregaLibro()
        {
            using (DB_PROG_WEBEntities db = new DB_PROG_WEBEntities())
            {
                C_LIBRO_EF Datos = new C_LIBRO_EF();
                Datos.LIBRO = txtLibro.Text;
                Datos.ACTIVO = "1";

                db.C_LIBRO_EF.Add(Datos);
                db.SaveChanges();
            }
        }
        /**
          * DANIEL HERNANDEZ CRUZ
          * 22/06/2021
          */
        private void ActualizaLibro()
        {
            using (DB_PROG_WEBEntities db = new DB_PROG_WEBEntities())
            {
                C_LIBRO_EF Datos = db.C_LIBRO_EF.Find(int.Parse(ddwLibros.SelectedItem.Value));
                Datos.LIBRO = txtLibro.Text;
                Datos.ACTIVO = "2";//El 2 significa que se ha modificado

                db.Entry(Datos).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        /**
          * DANIEL HERNANDEZ CRUZ
          * 22/06/2021
          */
        private void EliminaLibro()
        {
            using (DB_PROG_WEBEntities db = new DB_PROG_WEBEntities())
            {
                C_LIBRO_EF Datos = db.C_LIBRO_EF.Find(int.Parse(ddwLibros.SelectedItem.Value));

                db.C_LIBRO_EF.Remove(Datos);
                db.SaveChanges();
            }
        }
        
        
        
        
        /**
          * DANIEL HERNANDEZ CRUZ
          * 29/06/2021
          */
        private void Reporte()
        {
            try
            {
                Document doc = new Document();
                PdfWriter.GetInstance(doc, new FileStream("C:\\Users\\halco\\Desktop\\8_SEMESTRE\\PROGRAMACION WEB\\REPORTES\\reporte.pdf", FileMode.Create));
                //EN LA LINEA ANTERIOR SE PONE LA DIRECCION EN DONDE SE GUARDARÁ EL REPORTE
                doc.Open();

                //ESTE ESPACIO DE CODIGO SE MODIFICARÁ EL TIPO DE LETRA Y TODO LO RELACIONADO A LA FUENTE DEL TITULO
                Paragraph titulo = new Paragraph();
                titulo.Font = FontFactory.GetFont(FontFactory.TIMES, 18f, BaseColor.BLUE);
                titulo.Add(":::::::Libros::::::");
                doc.Add(titulo);

                doc.Add(new Paragraph(" "));

                //EN ESTA PARTE MECIONA QUE LA TABLA QUE GENERARÁ EL REPORTE TENDRÁ 3 COLUMNAS
                PdfPTable tabla = new PdfPTable(3);

                //ESTAS SON LAS 3 COLUMNAS QUE AGREGARÁ A LA TABLA
                tabla.AddCell("Id Libro");
                tabla.AddCell("Libro");
                tabla.AddCell("Activo");

                tabla.CompleteRow();

                //CON EL SIGUIENTE USING SE HACE REFERENCIA A QUE SE USARÁN LOS DATOS DE LAS TABLA
                //QUE SE HA CREADO ANTERIORMENTE EN EL ENTITY
                using (DB_PROG_WEBEntities db = new DB_PROG_WEBEntities())
                {
                    //SE DECLARA LA VARIABLE LIBROS QUE OBTENDRÁ LOS DATOS DEL CATALAGO C_LIBRO_EF
                    var Libros = db.C_LIBRO_EF.ToList();

                    //CON ESTE CICLO FOREACH RECORRERÁ LOS REGISTROS DE LA BASE DE DATOS PARA QUE AL FINAL
                    //DE CADA REGISTRO SE PASE A OTRO.
                    foreach (var dato in Libros)
                    {
                        tabla.AddCell(dato.ID.ToString());
                        tabla.AddCell(dato.LIBRO.ToString());
                        tabla.AddCell(dato.ACTIVO.ToString());
                        tabla.CompleteRow();
                    }
                    doc.Add(tabla);
                }
                doc.Close();
            }
            //EN EL CATCH DECIMOS QUE NOS MUESTRE EL ERROR EN CASO DE TENERLO
            catch(Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }

        }




        /**
          * DANIEL HERNANDEZ CRUZ
          * 22/06/2021
          */
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ConsultaLibros();
            }
        }
        /**
          * DANIEL HERNANDEZ CRUZ
          * 22/06/2021
          */
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ddwLibros.SelectedIndex != 0)
            {
                EliminaLibro();
                ConsultaLibros();
            }
            else
            {
                Response.Write("Favor de seleccionar el Libro");
            }
        }
        /**
          * DANIEL HERNANDEZ CRUZ
          * 22/06/2021
          */
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ddwLibros.SelectedIndex == 0)
            {
                if (txtLibro.Text == "")
                {
                    Response.Write("Favor de capturar el Libro");
                }
                else
                {
                    AgregaLibro();
                    ConsultaLibros();
                }
            }
            else
            {
                if (txtLibro.Text == "")
                {
                    Response.Write("Favor de capturar el Libro");
                }
                else
                {
                    ActualizaLibro();
                    ConsultaLibros();
                }
            }
        }
        /**
         * Daniel Hernandez Cruz
         * 29/06/2021
         * **/
        protected void btnReporte_Click(object sender, EventArgs e)
        {
            Reporte();
            Response.Write("PDF Creado");
        }
    }
}