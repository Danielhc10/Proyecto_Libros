using Proyecto1.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto1.Clases
{
    public class CAutores
    {
        private string _Error;
        private string _CadenaConexion;
        //Objetos del cliente de SQL
        private SqlConnection oConn;
        private SqlCommand oCmd;
        private DataTable dt;
        private SqlDataAdapter oDa;
        //Constructor - Incializar valores de entrada de mi clase 
        public CAutores(string CadConexion)
        {
            _Error = "false";
            _CadenaConexion = CadConexion;
        }
        public string RegError()
        {
            return _Error;
        }
        //Propiedades 
        public string StrErrorA { get; set; }

        public DataTable ConsultarAutores()
        {
            oConn = new SqlConnection();
            oConn.ConnectionString = _CadenaConexion;

            oCmd = new SqlCommand();
            oCmd.CommandType = System.Data.CommandType.StoredProcedure;
            oCmd.Connection = oConn;
            oCmd.CommandText = "CONSULTA_AUTOR";

            dt = new DataTable();

            oDa = new SqlDataAdapter();
            oDa.SelectCommand = oCmd;

            try
            {
                oDa.Fill(dt);

            }
            catch (SqlException ex)
            {
                _Error = ex.Message.ToString();
                StrErrorA = ex.Message.ToString();
            }
            catch (Exception ex)
            {
                _Error = ex.Message.ToString();
                StrErrorA = ex.Message.ToString();
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


        public String AgregaAutor(MAutores datos)
        {
            string salida = "";
            oConn = new SqlConnection();
            oConn.ConnectionString = _CadenaConexion;

            oCmd = new SqlCommand();
            oCmd.CommandType = System.Data.CommandType.StoredProcedure;
            oCmd.Connection = oConn;
            oCmd.CommandText = "AGREGA_AUTOR";

            oCmd.Parameters.Add("AUTOR", SqlDbType.VarChar, 50);
            oCmd.Parameters["AUTOR"].Value = datos.Autor;

            oCmd.Parameters.Add("TELEFONO", SqlDbType.VarChar, 14);
            oCmd.Parameters["TELEFONO"].Value = datos.Telefono;

            oCmd.Parameters.Add("FEC_NAC", SqlDbType.Date);
            oCmd.Parameters["FEC_NAC"].Value = datos.Fec_Nac;

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
                StrErrorA = ex.Message.ToString();
            }
            catch (Exception ex)
            {
                _Error = ex.Message.ToString();
                StrErrorA = ex.Message.ToString();
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

        public String ActualizaAutor(MAutores datos)
        {
            string salida = "";
            oConn = new SqlConnection();
            oConn.ConnectionString = _CadenaConexion;

            oCmd = new SqlCommand();
            oCmd.CommandType = System.Data.CommandType.StoredProcedure;
            oCmd.Connection = oConn;
            oCmd.CommandText = "ACTUALIZA_AUTOR";

            oCmd.Parameters.Add("ID_AUTOR", SqlDbType.Int);
            oCmd.Parameters["ID_AUTOR"].Value = datos.IdAutor;

            oCmd.Parameters.Add("AUTOR", SqlDbType.VarChar, 50);
            oCmd.Parameters["AUTOR"].Value = datos.Autor;

            oCmd.Parameters.Add("TELEFONO", SqlDbType.VarChar, 14);
            oCmd.Parameters["TELEFONO"].Value = datos.Telefono;

            oCmd.Parameters.Add("FEC_NAC", SqlDbType.Date);
            oCmd.Parameters["FEC_NAC"].Value = datos.Fec_Nac;

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
                StrErrorA = ex.Message.ToString();
            }
            catch (Exception ex)
            {
                _Error = ex.Message.ToString();
                StrErrorA = ex.Message.ToString();
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

        public String EliminaAutor(MAutores datos)
        {
            string salida = "";
            oConn = new SqlConnection();
            oConn.ConnectionString = _CadenaConexion;

            oCmd = new SqlCommand();
            oCmd.CommandType = System.Data.CommandType.StoredProcedure;
            oCmd.Connection = oConn;
            oCmd.CommandText = "ELIMINA_AUTOR_LOG";

            oCmd.Parameters.Add("ID_LIBRO", SqlDbType.Int);
            oCmd.Parameters["ID_LIBRO"].Value = datos.IdAutor;


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
                StrErrorA = ex.Message.ToString();
            }
            catch (Exception ex)
            {
                _Error = ex.Message.ToString();
                StrErrorA = ex.Message.ToString();
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