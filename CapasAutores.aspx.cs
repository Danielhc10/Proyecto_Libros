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
    public partial class CapasAutores : System.Web.UI.Page
    {

        private CAutoresCapas _OLog;
        private DataTable _dt;
        private MAutores _datos;
        public CapasAutores()
        {

        }

        private void ObtenAutores()
        {
            _OLog = new CAutoresCapas();
            _dt = _OLog.ObtenAutores();

            if (_OLog.Error.ToString() == "")
            {
                gvDatos.DataSource = _dt;
                gvDatos.DataBind();

                ddwAutores.DataSource = _dt;
                ddwAutores.DataValueField = "ID_AUTOR";
                ddwAutores.DataTextField = "AUTOR";
                ddwAutores.DataBind();
                ddwAutores.Items.Insert(0, "--Seleccionar--");
            }
            else
            {
                Response.Write(_OLog.Error.ToString());
            }

            _OLog = null;
        }

        private void AgregaAutores()
        {
            string res = "";

            _datos = new MAutores();
            _OLog = new CAutoresCapas();

            _datos.Autor = txtAutor.Text;
            _datos.Telefono = txtTelefono.Text;
            _datos.Fec_Nac = txtFecN.Text;

            res = _OLog.AgregaAutor(_datos);

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

        private void ActualizaAutor()
        {
            string res = "";

            _datos = new MAutores();
            _OLog = new CAutoresCapas();

            _datos.IdAutor = int.Parse(ddwAutores.SelectedItem.Value);
            _datos.Autor = txtAutor.Text;
            _datos.Telefono = txtTelefono.Text;
            _datos.Fec_Nac = txtFecN.Text;

            res = _OLog.ActualizaAutor(_datos);

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

        private void EliminaAutor()
        {
            string res = "";

            _datos = new MAutores();
            _OLog = new CAutoresCapas();

            _datos.IdAutor = int.Parse(ddwAutores.SelectedItem.Value);
            res = _OLog.EliminaAutor(_datos);

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
                ObtenAutores();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ddwAutores.SelectedIndex == 0)
            {
                if (txtAutor.Text != "")
                {
                    AgregaAutores();
                    ObtenAutores();
                }
            }
            else
            {
                if (txtAutor.Text != "")
                {
                    ActualizaAutor();
                    ObtenAutores();
                }
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ddwAutores.SelectedIndex !=0)
            {
                this.EliminaAutor();
                ObtenAutores();
            }
            else
            {
                Response.Write("Se debe seleccionar un Autor para Eliminar");
            }
        }

        
    }
}