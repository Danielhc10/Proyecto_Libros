using Proyecto1.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Proyecto1.Clases
{
    public class CLibroCapas
    {
        private CDatosSQL _ODatos;
        private DataTable _dt;

        private string _CadenaConexion;

        public string Error {get; set;}

        public CLibroCapas()
        {
            Error = "";
            _CadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
        }
        public DataTable ObtenLibros()
        {
            _ODatos = new CDatosSQL(_CadenaConexion);
               
            _dt = _ODatos.RegresaDT("CONSULTA_LIBROS");

            if(_ODatos.RegresaError().ToString() != "")
            {
                Error = _ODatos.RegresaError().ToString();
                _ODatos = null;
                return null;
            }
            _ODatos = null;
            return _dt;
        }

        public string AgregaLibro(MLibro datos)
        {
            string resultado = "";
            _ODatos = new CDatosSQL(_CadenaConexion);
            _ODatos.AgregaParametro("LIBRO", SqlDbType.VarChar, ParameterDirection.Input, datos.Libro, 40);
            
            resultado = _ODatos.RegresaValor("AGREGA_LIBRO", "SALIDA");

            if (_ODatos.RegresaError().ToString() != "")
            {
                Error = _ODatos.RegresaError().ToString();
                _ODatos = null;
                return null;
            }
            _ODatos = null;

            return resultado;
        }

        public string ActualizaLibro(MLibro datos)
        {
            string resultado = "";
            _ODatos = new CDatosSQL(_CadenaConexion);

            _ODatos.AgregaParametro("ID_LIBRO", SqlDbType.Int, ParameterDirection.Input, datos.IdLibro);
            _ODatos.AgregaParametro("LIBRO", SqlDbType.VarChar, ParameterDirection.Input, datos.Libro, 40);

            resultado = _ODatos.RegresaValor("ACTUALIZA_LIBRO", "SALIDA");

            if (_ODatos.RegresaError().ToString() != "")
            {
                Error = _ODatos.RegresaError().ToString();
                _ODatos = null;
                return null;
            }
            _ODatos = null;

            return resultado;
        }

        public string EliminaLibro(MLibro datos)
        {
            string resultado = "";
            _ODatos = new CDatosSQL(_CadenaConexion);

            _ODatos.AgregaParametro("ID_LIBRO", SqlDbType.Int, ParameterDirection.Input, datos.IdLibro);

            resultado = _ODatos.RegresaValor("ELIMINA_LIBRO_LOG", "SALIDA");

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