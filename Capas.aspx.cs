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
    public partial class Capas : System.Web.UI.Page
    {
        private CLibroCapas _OLog;
        private DataTable _dt;
        private MLibro _datos;
        public Capas()
        {

        }

        private void ObtenLibrosPaginacion()
        {
            _OLog = new CLibroCapas();
            _dt = _OLog.ObtenLibros();

            if (_OLog.Error.ToString() == "")
            {
                gvDatos.DataSource = _dt;
                gvDatos.DataBind();

            }
            else
            {
                Response.Write(_OLog.Error.ToString());
            }

            _OLog = null;
        }

        private void ObtenLibros()
        {
            _OLog = new CLibroCapas();
            _dt = _OLog.ObtenLibros();

            if (_OLog.Error.ToString() == "")
            {
                gvDatos.DataSource = _dt;
                gvDatos.DataBind();

                ddwLibros.DataSource = _dt;
                ddwLibros.DataValueField = "ID_LIBRO";
                ddwLibros.DataTextField = "LIBRO";
                ddwLibros.DataBind();
                ddwLibros.Items.Insert(0, "--Seleccionar--");
            }
            else
            {
                Response.Write(_OLog.Error.ToString());
            }

            _OLog = null;
        }

        private void AgregaLibro()
        {
            string res = "";

            _datos = new MLibro();
            _OLog = new CLibroCapas();

            _datos.Libro = txtLibro.Text;

            res = _OLog.AgregaLibro(_datos);

            if (_OLog.Error.ToString() == "")
            {
                Response.Write(res);
            }
            else
            {
                Response.Write(_OLog.Error.ToString());
            }

            _OLog = null;
        }

        private void ActualizaLibro()
        {
            string res = "";

            _datos = new MLibro();
            _OLog = new CLibroCapas();

            _datos.IdLibro = int.Parse(ddwLibros.SelectedItem.Value);
            _datos.Libro = txtLibro.Text;

            res = _OLog.ActualizaLibro(_datos);

            if (_OLog.Error.ToString() == "")
            {
                Response.Write(res);
            }
            else
            {
                Response.Write(_OLog.Error.ToString());
            }

            _OLog = null;
        }

        private void EliminaLibro()
        {
            string res = "";

            _datos = new MLibro();
            _OLog = new CLibroCapas();

            _datos.IdLibro = int.Parse(ddwLibros.SelectedItem.Value);

            res = _OLog.EliminaLibro(_datos);

            if (_OLog.Error.ToString() == "")
            {
                Response.Write(res);
            }
            else
            {
                Response.Write(_OLog.Error.ToString());
            }

            _OLog = null;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ObtenLibros();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ddwLibros.SelectedIndex == 0)
            {
                if (txtLibro.Text != "")
                {
                    AgregaLibro();
                    ObtenLibros();
                }
            }
            else
            {
                if (txtLibro.Text != "")
                {
                    ActualizaLibro();
                    ObtenLibros();
                }
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ddwLibros.SelectedIndex != 0)
            {
                this.EliminaLibro();
                ObtenLibros();
            }
            else
            {
                Response.Redirect("Se debe seleccionar un libro");
            }


        }

        /**
         * AUTOR: DANIEL HERNANDEZ CRUZ
         * FECHA: 18/06/2021
         * **/
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
        /**
         * AUTOR: DANIEL HERNANDEZ CRUZ
         * FECHA: 18/06/2021
         * **/
        protected void gvDatos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string activo; //SE CREA UNA VARIABLE ACTIVO DE TIPO STRING
                activo = (string)DataBinder.Eval(e.Row.DataItem, "ACTIVO");
                //SE HACE REFERENCIA A QUE SOLO SE EVALUARA EL CAMPO "ACTIVO"

                if (activo == "0")//SI EL CAMPO ACTIVO ES IGUAL A 0 SE PINTARA DE ROJO
                {
                    e.Row.ForeColor = System.Drawing.Color.Red;
                }
                else//DE LO CONTRARIO SE PINTARA DE AZUL
                {
                    e.Row.ForeColor = System.Drawing.Color.Blue;
                }
            }
        }
        /**
         * AUTOR: DANIEL HERNANDEZ CRUZ
         * FECHA: 18/06/2021
         * **/
        protected void gvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDatos.PageIndex = e.NewPageIndex;//DENTRO DEL GRIDVIEW SE HACE UNA PAGINACION
            ObtenLibros();//SE LLAMA EL METODO YA CREADO PARA SEGUIR VIENDO LOS DATOS
        } 

        /**
         * AUTOR: DANIEL HERNANDEZ CRUZ
         * FECHA: 18/06/2021
         * **/
        protected void gvDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddwLibros.Text = gvDatos.Rows[gvDatos.SelectedIndex].Cells[1].Text;
            /**
             * AL HACER CLICK EN ESTE BOTON, TAMBIEN SE VERÁ EL DATO SELECCIONADO 
             * EN EL DROPDOWN**/
            txtLibro.Text = gvDatos.Rows[gvDatos.SelectedIndex].Cells[2].Text;
            /**
             * AL HACER CLICK EN ESTE BOTON, EL DATO SELECCIONADO SE VERÁ TAMBIEN
             * EN EL CUADRO DE TEXTO**/
        }
    }
}