using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Proyecto1
{
    public partial class Inicio : System.Web.UI.Page
    {

        //Programacion del lado del servidor- Backend

        #region  "FUNCIONES Y PROCEDIMIENTOS"
        private void ConsultarLibrosPaginacion()
        {
            SqlConnection oConn = new SqlConnection();
            oConn.ConnectionString = "Data Source=DANIHDZ/DANIHDEZ;Initial Catalog=DB_PROG_WEB;User ID=sa;Password=1234";

            SqlCommand oCmd = new SqlCommand();
            oCmd.CommandType = System.Data.CommandType.StoredProcedure;
            oCmd.Connection = oConn;
            oCmd.CommandText = "CONSULTA_LIBROS";

            DataTable dt = new DataTable();

            SqlDataAdapter oDa = new SqlDataAdapter();
            oDa.SelectCommand = oCmd;

            try
            {
                //oConn.Open();  ----Para Abrir una conexion    
                oDa.Fill(dt);

                gvDatos.DataSource = dt;
                gvDatos.DataBind();

                ddwLibros.DataSource = dt;
                ddwLibros.DataTextField = "LIBRO";
                ddwLibros.DataValueField = "ID_LIBRO";
                ddwLibros.DataBind();
                ddwLibros.Items.Insert(0, "--Seleccionar--");
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message.ToString());
            }
            catch (Exception ex)
            {

                Response.Write(ex.Message.ToString());
            }
            finally
            {
                //if (oConn.State == ConnectionState.Open)
                //{
                //   oConn.Close();
                //}
                oConn.Dispose();
                oCmd.Dispose();
                dt.Dispose();
                oDa.Dispose();
            }

        }

        private void ConsultarLibros()
        {
            SqlConnection oConn = new SqlConnection();
            oConn.ConnectionString = "Data Source=DANIHDZ/DANIHDEZ;Initial Catalog=DB_PROG_WEB;User ID=sa;Password=1234";

            SqlCommand oCmd = new SqlCommand();
            oCmd.CommandType = System.Data.CommandType.StoredProcedure;
            oCmd.Connection = oConn;
            oCmd.CommandText = "CONSULTA_LIBROS";

            DataTable dt = new DataTable();

            SqlDataAdapter oDa = new SqlDataAdapter();
            oDa.SelectCommand = oCmd;

            try
            {
                //oConn.Open();  ----Para Abrir una conexion    
                oDa.Fill(dt);

                gvDatos.DataSource = dt;
                gvDatos.DataBind();

                ddwLibros.DataSource = dt;
                ddwLibros.DataTextField = "LIBRO";
                ddwLibros.DataValueField = "ID_LIBRO";
                ddwLibros.DataBind();
                ddwLibros.Items.Insert(0,"--Seleccionar--");
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message.ToString());
            }
            catch (Exception ex)
            {

                Response.Write(ex.Message.ToString());
            }
            finally {
                //if (oConn.State == ConnectionState.Open)
                //{
                //   oConn.Close();
                //}
                oConn.Dispose();
                oCmd.Dispose();
                dt.Dispose();
                oDa.Dispose();
            }
            
        }
        private void AgregarLibro(string NombreLibro)
        {
            SqlConnection oConn = new SqlConnection();
            oConn.ConnectionString = "Data Source=DANIHDZ/DANIHDEZ;Initial Catalog=DB_PROG_WEB;User ID=sa;Password=1234";

            SqlCommand oCmd = new SqlCommand();
            oCmd.CommandType = System.Data.CommandType.StoredProcedure;
            oCmd.Connection = oConn;
            oCmd.CommandText = "AGREGA_LIBRO";

            //Paso de parametros al procedimiento almacenado

            oCmd.Parameters.Add("LIBRO", SqlDbType.VarChar, 40);
            oCmd.Parameters["LIBRO"].Value = NombreLibro;

            DataTable dt = new DataTable();

            SqlDataAdapter oDa = new SqlDataAdapter();
            oDa.SelectCommand = oCmd;

            try
            {
                oDa.Fill(dt);
                Response.Write(dt.Rows[0]["SALIDA"].ToString());
                //gvDatos.DataSource = dt;
                //gvDatos.DataBind();
            }
            catch( Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
            finally
            {
                oConn.Dispose();
                oCmd.Dispose();
                dt.Dispose();
                oDa.Dispose();
            }
        }
        private void ActualizarLibro(int IdLibro,string NombreLibro)
        {
            SqlConnection oConn = new SqlConnection();
            oConn.ConnectionString = "Data Source=DANIHDZ/DANIHDEZ;Initial Catalog=DB_PROG_WEB;User ID=sa;Password=1234";

            SqlCommand oCmd = new SqlCommand();
            oCmd.CommandType = System.Data.CommandType.StoredProcedure;
            oCmd.Connection = oConn;
            oCmd.CommandText = "ACTUALIZA_LIBRO";

            //Paso de parametros al procedimiento almacenado
            oCmd.Parameters.Add("ID_LIBRO", SqlDbType.Int);
            oCmd.Parameters["ID_LIBRO"].Value = IdLibro;

            oCmd.Parameters.Add("LIBRO", SqlDbType.VarChar, 40);
            oCmd.Parameters["LIBRO"].Value = NombreLibro;

            DataTable dt = new DataTable();

            SqlDataAdapter oDa = new SqlDataAdapter();
            oDa.SelectCommand = oCmd;

            try
            {
                oDa.Fill(dt);
                Response.Write(dt.Rows[0]["SALIDA"].ToString());
            }
            
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
            finally
            {
                oConn.Dispose();
                oCmd.Dispose();
                dt.Dispose();
                oDa.Dispose();
            }
        }
        private void EliminarLibro(int IdLibro)
        {
            SqlConnection oConn = new SqlConnection();
            oConn.ConnectionString = "Data Source=DANIHDZ/DANIHDEZ;Initial Catalog=DB_PROG_WEB;User ID=sa;Password=1234";

            SqlCommand oCmd = new SqlCommand();
            oCmd.CommandType = System.Data.CommandType.StoredProcedure;
            oCmd.Connection = oConn;
            oCmd.CommandText = "ELIMINA_LIBRO_LOG";

            //Paso de parametros al procedimiento almacenado
            oCmd.Parameters.Add("ID_LIBRO", SqlDbType.Int);
            oCmd.Parameters["ID_LIBRO"].Value = IdLibro;

            DataTable dt = new DataTable();

            SqlDataAdapter oDa = new SqlDataAdapter();
            oDa.SelectCommand = oCmd;

            try
            {
                oDa.Fill(dt);
                Response.Write(dt.Rows[0]["SALIDA"].ToString());
            }

            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
            finally
            {
                oConn.Dispose();
                oCmd.Dispose();
                dt.Dispose();
                oDa.Dispose();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ConsultarLibros();
            }
            
            
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //Inserción
            if (ddwLibros.SelectedIndex == 0)
            {
                AgregarLibro(txtLibro.Text);
            }
            else
            {
                ActualizarLibro(int.Parse(ddwLibros.SelectedItem.Value), txtLibro.Text);
            }
            ConsultarLibros();
        }

        protected void ddwLibros_SelectedIndexChanged(object sender, EventArgs e)
        {
            //preguntar si es el primer registro
           
            if (ddwLibros.SelectedIndex == 0)
            {
                txtLibro.Text = "";
            }
            else {
                txtLibro.Text = ddwLibros.SelectedItem.Text.ToString();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ddwLibros.SelectedIndex != 0)
            {
                EliminarLibro(int.Parse(ddwLibros.SelectedItem.Value));
                ConsultarLibros();
            }
            else
            {
                Response.Write("Favor de seleccionar un libro");    
            }
        }
        /**AUTOR: DANIEL HERNANDEZ CRUZ
         * FECHA: 18/06/2021
         * TEMA: EVENTO DE GRIDVIEW
         **/
        protected void gvDatos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                string activo;
                activo = (string)DataBinder.Eval(e.Row.DataItem, "ACTIVO");

                if(activo == "0")
                {
                    e.Row.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    e.Row.ForeColor = System.Drawing.Color.Blue;
                }
            }
        }

        protected void gvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDatos.PageIndex = e.NewPageIndex;
            ConsultarLibros();
        }
    }
    #endregion

}
