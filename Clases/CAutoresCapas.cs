using Proyecto1.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Proyecto1.Clases
{
    public class CAutoresCapas
    {
        private CDatosSQL _ODatos;
        private DataTable _dt;

        private string _CadenaConexion;

        public string Error { get; set; }

        public CAutoresCapas()
        {
            Error = "";
            _CadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
        }

        public DataTable ObtenAutores()
        {
            _ODatos = new CDatosSQL(_CadenaConexion);

            _dt = _ODatos.RegresaDT("CONSULTA_AUTOR");

            if (_ODatos.RegresaError().ToString() != "")
            {
                Error = _ODatos.RegresaError().ToString();
                _ODatos = null;
                return null;
            }
            _ODatos = null;
            return _dt;
        }

        public string AgregaAutor(MAutores datos)
        {
            string resultado = "";
            _ODatos = new CDatosSQL(_CadenaConexion);
            _ODatos.AgregaParametro("AUTOR", SqlDbType.VarChar, ParameterDirection.Input, datos.Autor, 50);
            _ODatos.AgregaParametro("TELEFONO", SqlDbType.VarChar, ParameterDirection.Input, datos.Telefono, 14);
            _ODatos.AgregaParametro("FEC_NAC", SqlDbType.Date, ParameterDirection.Input, datos.Fec_Nac);


            resultado = _ODatos.RegresaValor("AGREGA_AUTOR", "SALIDA");

            if (_ODatos.RegresaError().ToString() != "")
            {
                Error = _ODatos.RegresaError().ToString();
                _ODatos = null;
                return null;
            }
            _ODatos = null;

            return resultado;
        }

        public string ActualizaAutor(MAutores datos)
        {
            string resultado = "";
            _ODatos = new CDatosSQL(_CadenaConexion);

            _ODatos.AgregaParametro("ID_AUTOR", SqlDbType.Int, ParameterDirection.Input, datos.IdAutor);
            _ODatos.AgregaParametro("AUTOR", SqlDbType.VarChar, ParameterDirection.Input, datos.Autor, 50);
            _ODatos.AgregaParametro("TELEFONO", SqlDbType.VarChar, ParameterDirection.Input, datos.Telefono, 14);
            _ODatos.AgregaParametro("FEC_NAC", SqlDbType.Date, ParameterDirection.Input, datos.Fec_Nac);


            resultado = _ODatos.RegresaValor("ACTUALIZA_AUTOR", "SALIDA");

            if (_ODatos.RegresaError().ToString() != "")
            {
                Error = _ODatos.RegresaError().ToString();
                _ODatos = null;
                return null;
            }
            _ODatos = null;

            return resultado;
        }

        public string EliminaAutor(MAutores datos)
        {
            string resultado = "";
            _ODatos = new CDatosSQL(_CadenaConexion);

            _ODatos.AgregaParametro("ID_AUTOR", SqlDbType.Int, ParameterDirection.Input, datos.IdAutor);

            resultado = _ODatos.RegresaValor("ELIMINA_AUTOR_LOG", "SALIDA");

            if (_ODatos.RegresaError().ToString() != "")
            {
                Error = _ODatos.RegresaError().ToString();
                _ODatos = null;
                return null;
            }
            _ODatos = null;

            return resultado;
        }

    }
}