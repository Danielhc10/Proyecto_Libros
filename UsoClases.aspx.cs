using Proyecto1.Clases;
using Proyecto1.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto1
{
    public partial class UsoClases : System.Web.UI.Page
    {
        private CLibro OLog;
        private DataTable dt;
        private string salida;
        private MLibro datos;
        private String _CadenaConexion;

        public UsoClases()
        {
            datos = null;
            _CadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
        }
        private void ConsultaLibros()
        {
            OLog = new CLibro(_CadenaConexion);
            dt = OLog.ConsultarLibros();
            //if (OLog.StrError.ToString() != "false")
            if (OLog.RegresaError().ToString() != "false")
            {
                Response.Write(OLog.RegresaError().ToString());
            }
            else
            {
                gvDatos.DataSource = dt;
                gvDatos.DataBind();

                ddwLibros.DataSource = dt;
                ddwLibros.DataTextField = "LIBRO";
                ddwLibros.DataValueField = "ID_LIBRO";
                ddwLibros.DataBind();
                ddwLibros.Items.Insert(0, "--Seleccionar--");
            }
            OLog = null;
        }
            private void AgregaLibros()
            {
                OLog = new CLibro(_CadenaConexion);
            salida = OLog.AgregaLibro(txtLibro.Text);
            //if (OLog.StrError.ToString() != "false")
            if (OLog.RegresaError().ToString() != "false")
            {
                Response.Write(OLog.RegresaError().ToString());
            }
            else
            {
                Response.Write(salida);
            }
            OLog = null;
             }

        private void ActualizaLibro()
        {
            OLog = new CLibro(_CadenaConexion);

            datos = new MLibro();
            datos.IdLibro = int.Parse(ddwLibros.SelectedItem.Value);
            datos.Libro = txtLibro.Text;

            salida = OLog.ActualizaLibro(datos);
            
            if (OLog.RegresaError().ToString() != "false")
            {
                Response.Write(OLog.RegresaError().ToString());
            }
            else
            {
                Response.Write(salida);
            }
            OLog = null;
            datos = null;
        }

        private void EliminaLibro()
        {
            OLog = new CLibro(_CadenaConexion);

            datos = new MLibro();

            datos.IdLibro = int.Parse(ddwLibros.SelectedItem.Value);

            salida = OLog.EliminaLibro(datos);

            if (OLog.RegresaError().ToString() != "false")
            {
                Response.Write(OLog.RegresaError().ToString());
            }
            else
            {
                Response.Write(salida);
            }
            OLog = null;
            datos = null;
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ddwLibros.SelectedIndex != 0)
            {
                EliminaLibro();
                ConsultaLibros();
            }
        }

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
                    AgregaLibros();
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ConsultaLibros();
            }
        }

        protected void ddwLibros_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddwLibros.SelectedIndex == 0)
            {
                txtLibro.Text = "";
            }
            else
            {
                txtLibro.Text = ddwLibros.SelectedItem.Text.ToString();
            }
        }
    }
}