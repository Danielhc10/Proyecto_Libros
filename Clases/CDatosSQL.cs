using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto1.Clases
{
    public class CDatosSQL
    {
        private DataTable _dt;
        private SqlConnection _oConn;
        private SqlCommand _oCmd;
        private SqlDataAdapter _oDa;

        private SqlParameter _Parametro;
        private List<SqlParameter> _ListaParametros;

        private string _CadenaConexion;
        private string _Error;

        public CDatosSQL(string CadenaConexion)
        {
            _Error = "";
            //Error = ""; property
            _CadenaConexion = CadenaConexion;
            _ListaParametros = new List<SqlParameter>();
        }

        private void ConfiguraConexion()
        {
            _oConn = new SqlConnection();
            _oConn.ConnectionString = _CadenaConexion;

        }
        private void ConfiguraComando(string NombreSP)
        {
            _oCmd = new SqlCommand();
            _oCmd.CommandType = System.Data.CommandType.StoredProcedure;
            _oCmd.Connection = _oConn;
            _oCmd.CommandText = NombreSP; 

            if(_ListaParametros != null)
            {
                foreach(var param in _ListaParametros)
                {
                    _oCmd.Parameters.Add(param);
                }
            }

        }
        private void ConfiguraSqlDA()
        {
            _oDa = new SqlDataAdapter();
            _oDa.SelectCommand = _oCmd;
        }

        private void LiberaRecursos()
        {
            _oConn.Dispose();
            _oCmd.Dispose();
            _oDa.Dispose();
            _Parametro = null;
            _ListaParametros.Clear();
            //_ListaParametros = null;
        }
        //public String Error { get; set; }
        public string RegresaError()
        {
            return _Error;
        }

        public void AgregaParametro(string NombreParametro, SqlDbType TipoParametro, ParameterDirection DireccionParametro,
                                    Object ValorParametro, int TamanioParametro = 0)
        {
            _Parametro = new SqlParameter();
            _Parametro.ParameterName = NombreParametro;
            _Parametro.SqlDbType = TipoParametro;
            _Parametro.Value = ValorParametro;
            _Parametro.Direction = DireccionParametro;

            if (TamanioParametro != 0)
            {
                _Parametro.Size = TamanioParametro;
            }
            _ListaParametros.Add(_Parametro);
        }

        public DataTable RegresaDT(string NombreSP)
        {
            ConfiguraConexion();
            ConfiguraComando(NombreSP);
            ConfiguraSqlDA();

            try
            {
                _dt = new DataTable();
                _oDa.Fill(_dt);
                
            }
            catch(Exception ex)
            {
                //Error = ex.Message.ToString(); property
                _Error = ex.Message.ToString();
            }
            finally
            {
                LiberaRecursos();
            }

            return _dt;
        }

        public string RegresaValor(string NombreSP, string MsgSalidaSP)
        {
            string resultado = "";
            ConfiguraConexion();
            ConfiguraComando(NombreSP);
            ConfiguraSqlDA(); 

            try
            {
                _dt = new DataTable();
                _oDa.Fill(_dt);
                resultado = _dt.Rows[0][MsgSalidaSP].ToString();
            }
            catch (Exception ex)
            {
                //Error = ex.Message.ToString(); property
                _Error = ex.Message.ToString();
            }
            finally
            {
                LiberaRecursos();
            }

            return resultado;
        }
    }
}