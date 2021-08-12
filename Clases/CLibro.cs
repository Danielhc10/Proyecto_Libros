using Proyecto1.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto1.Clases
{
    public class CLibro
    {
        private string _Error;
        private string _CadenaConexion;
        //Objetos del cliente de SQL
        private SqlConnection oConn;
        private SqlCommand oCmd;
        private DataTable dt;
        private SqlDataAdapter oDa;
        //Constructor - Incializar valores de entrada de mi clase 
        public CLibro(string CadConexion)
        {
            _Error = "false";
            _CadenaConexion = CadConexion;
        }
        public string RegresaError()
        {
            return _Error;
        }
        //Propiedades 
        public string StrError { get; set; }
        public DataTable ConsultarLibros()
        {
            oConn = new SqlConnection();
            oConn.ConnectionString = _CadenaConexion;

            oCmd = new SqlCommand();
            oCmd.CommandType = System.Data.CommandType.StoredProcedure;
            oCmd.Connection = oConn;
            oCmd.CommandText = "CONSULTA_LIBROS";

            dt = new DataTable();

            oDa = new SqlDataAdapter();
            oDa.SelectCommand = oCmd;

            try
            {
                oDa.Fill(dt);

            }
            catch (SqlException ex)
            {
                _Error=ex.Message.ToString();   
                StrError = ex.Message.ToString();
            }
            catch (Exception ex)
            {
                _Error=ex.Message.ToString();
                StrError = ex.Message.ToString();
            }
            finally
            {
                oConn.Dispose();
                oCmd.Dispose();
                dt.Dispose();
                oDa.Dispose();
            }
            return dt;
        }

        public String AgregaLibro(string NombreLibro)
        {
            string salida="";
            oConn = new SqlConnection();
            oConn.ConnectionString = _CadenaConexion;

            oCmd = new SqlCommand();
            oCmd.CommandType = System.Data.CommandType.StoredProcedure;
            oCmd.Connection = oConn;
            oCmd.CommandText = "AGREGA_LIBRO";

            oCmd.Parameters.Add("LIBRO", SqlDbType.VarChar, 40);
            oCmd.Parameters["LIBRO"].Value = NombreLibro;

            dt = new DataTable();

            oDa = new SqlDataAdapter();
            oDa.SelectCommand = oCmd;

            try
            {
                oDa.Fill(dt);
                salida = dt.Rows[0]["SALIDA"].ToString();
            }
            catch (SqlException ex)
            {
                _Error = ex.Message.ToString();
                StrError = ex.Message.ToString();
            }
            catch (Exception ex)
            {
                _Error = ex.Message.ToString();
                StrError = ex.Message.ToString();
            }
            finally
            {
                oConn.Dispose();
                oCmd.Dispose();
                dt.Dispose();
                oDa.Dispose();
            }
            return salida;
        }

        public String ActualizaLibro(MLibro datos)
        {
            string salida = "";
            oConn = new SqlConnection();
            oConn.ConnectionString = _CadenaConexion;

            oCmd = new SqlCommand();
            oCmd.CommandType = System.Data.CommandType.StoredProcedure;
            oCmd.Connection = oConn;
            oCmd.CommandText = "ACTUALIZA_LIBRO";

            oCmd.Parameters.Add("ID_LIBRO", SqlDbType.Int);
            oCmd.Parameters["ID_LIBRO"].Value = datos.IdLibro;

            oCmd.Parameters.Add("LIBRO", SqlDbType.VarChar, 40);
            oCmd.Parameters["LIBRO"].Value = datos.Libro;

            dt = new DataTable();

            oDa = new SqlDataAdapter();
            oDa.SelectCommand = oCmd;

            try
            {
                oDa.Fill(dt);
                salida = dt.Rows[0]["SALIDA"].ToString();
            }
            catch (SqlException ex)
            {
                _Error = ex.Message.ToString();
                StrError = ex.Message.ToString();
            }
            catch (Exception ex)
            {
                _Error = ex.Message.ToString();
                StrError = ex.Message.ToString();
            }
            finally
            {
                oConn.Dispose();
                oCmd.Dispose();
                dt.Dispose();
                oDa.Dispose();
            }
            return salida;
        }

        public String EliminaLibro(MLibro datos)
        {
            string salida = "";
            oConn = new SqlConnection();
            oConn.ConnectionString = _CadenaConexion;

            oCmd = new SqlCommand();
            oCmd.CommandType = System.Data.CommandType.StoredProcedure;
            oCmd.Connection = oConn;
            oCmd.CommandText = "ELIMINA_LIBRO_LOG";

            oCmd.Parameters.Add("ID_LIBRO", SqlDbType.Int);
            oCmd.Parameters["ID_LIBRO"].Value = datos.IdLibro;


            dt = new DataTable();

            oDa = new SqlDataAdapter();
            oDa.SelectCommand = oCmd;

            try
            {
                oDa.Fill(dt);
                salida = dt.Rows[0]["SALIDA"].ToString();
            }
            catch (SqlException ex)
            {
                _Error = ex.Message.ToString();
                StrError = ex.Message.ToString();
            }
            catch (Exception ex)
            {
                _Error = ex.Message.ToString();
                StrError = ex.Message.ToString();
            }
            finally
            {
                oConn.Dispose();
                oCmd.Dispose();
                dt.Dispose();
                oDa.Dispose();
            }
            return salida;
        }
    }
}