using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System;
using Entity;
using Datos;

namespace Logica
{
   public class SitioService{
       private readonly ConnectionManager _conexion;
        private readonly SitioRepository _repositorio;
        public SitioService (string connectionString) {
            _conexion = new ConnectionManager (connectionString);
            _repositorio = new SitioRepository (_conexion);
        }
        public GuardarSitioResponse Guardar (Sitio sitio) {
            
            try {
                    _conexion.Open ();
                    _repositorio.Guardar (sitio);
                    _conexion.Close ();
                    return new GuardarSitioResponse (sitio);   
            } catch (Exception e) {
                return new GuardarSitioResponse ($"Error de la Aplicacion: {e.Message}");
            } finally { _conexion.Close (); }
        }
        public List<Sitio> ConsultarTodos () {
            _conexion.Open ();
            List<Sitio> sitios = _repositorio.ConsultarTodos ();
            _conexion.Close ();
            return sitios;
        }
   }
   public class GuardarSitioResponse {
        public GuardarSitioResponse (Sitio sitio) {
            Error = false;
            Sitio = sitio;
        }
        public GuardarSitioResponse (string mensaje) {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Sitio Sitio { get; set; }
    }
}
