using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using Entity;

namespace Datos {
    public class SitioRepository {
        private SqlConnection _connection;
        SqlCommand command;
        private List<Sitio> _sitios = new List<Sitio> ();
        public SitioRepository (ConnectionManager connection) {
            _connection = connection._conexion;
            command = new SqlCommand ();
        }
        public void Guardar (Sitio sitio) {
            using (var command = _connection.CreateCommand ()) {
                command.CommandText = @"Insert Into Sitio (Nombre,Descripcion,Informacion,ImagenesPatch) 
                                        values (@Nombre,@Descripcion,@Informacion,@ImagenesPatch)";
                command.Parameters.AddWithValue ("@Nombre", sitio.Nombre);
                command.Parameters.AddWithValue ("@Descripcion", sitio.Descripcion);
                command.Parameters.AddWithValue ("@Informacion", sitio.Informacion);
                command.Parameters.AddWithValue ("@ImagenesPatch", sitio.ImagenesPath);
                //command.Parameters.AddWithValue ("@Ubicacion", sitio.Ubicacion);
                var filas = command.ExecuteNonQuery ();
            }
        }

        public List<Sitio> ConsultarTodos () {
            SqlDataReader dataReader;
            List<Sitio> sitios = new List<Sitio> ();
            using (var command = _connection.CreateCommand ()) {
                command.CommandText = "Select * from sitio";
                dataReader = command.ExecuteReader ();
                if (dataReader.HasRows) {
                    while (dataReader.Read ()) {
                        Sitio sitio = DataReaderMapToPerson (dataReader);
                        sitios.Add (sitio);
                    }
                }
            }
            return sitios;
        }

        private Sitio DataReaderMapToPerson (SqlDataReader dataReader) {
            if (!dataReader.HasRows) return null;
            Sitio sitio = new Sitio ();
            sitio.Nombre = (string) dataReader["Nombre"];
            sitio.Descripcion = (string) dataReader["Descripcion"];
            sitio.Informacion = (string) dataReader["Informacion"];
            sitio.ImagenesPath = (string) dataReader["ImagenesPath"];
            //sitio.Ubicacion = (string) dataReader["Ubicacion"];
            return sitio;
        }
    }
}