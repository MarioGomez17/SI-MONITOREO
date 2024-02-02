using CAPA_ENTIDADES_NEGOCIO.CLASES;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_ACCESO_DATOS.CLASES
{
    public class UnidadMedidaSensorDA
    {

        public List<UnidadMedidaSensorBE> TraerUnidadesMedidaSensor()
        {
            List<UnidadMedidaSensorBE> Unidades = new List<UnidadMedidaSensorBE>();
            string SQL = "SELECT si_cultivo_hidroponico.unidad_medida_sensor.Id_Unidad_Medida_Sensor, " +
                "si_cultivo_hidroponico.unidad_medida_sensor.Nombre_Unidad_Medida_Sensor, " +
                "si_cultivo_hidroponico.unidad_medida_sensor.Simbolo_Unidad_Medida_Sensor " +
                "FROM si_cultivo_hidroponico.unidad_medida_sensor " +
                "ORDER BY si_cultivo_hidroponico.unidad_medida_sensor.Id_Unidad_Medida_Sensor ASC";
            MySqlConnection Conexion = ConexionDA.Conectar();
            Conexion.Open();
            try
            {
                MySqlCommand Comando = new MySqlCommand(SQL, Conexion);
                MySqlDataReader Reader = Comando.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        UnidadMedidaSensorBE UnidadBE = new UnidadMedidaSensorBE
                        {
                            Id_unidad = int.Parse(Reader.GetString(0)),
                            Nombre_unidad = Reader.GetString(1),
                            Simbolo_Unidad = Reader.GetString(2)
                        };
                        Unidades.Add(UnidadBE);
                    }
                }
            }
            catch (Exception ex){}
            finally
            {
                Conexion.Close();
            }

            return Unidades;
        }

        public bool AgregarUnidadMedidaSensor(string UnidadMedida, string SimboloUnidad)
        {
            string SQL = "INSERT INTO si_cultivo_hidroponico.unidad_medida_sensor " +
                "(si_cultivo_hidroponico.unidad_medida_sensor.Nombre_Unidad_Medida_Sensor, " +
                "si_cultivo_hidroponico.unidad_medida_sensor.Simbolo_Unidad_Medida_Sensor) VALUES (" +
                "'" + UnidadMedida + "', '" + SimboloUnidad + "')";
            return ConexionDA.EjecutarSentenciasNonQuery(SQL);
        }

    }
}
