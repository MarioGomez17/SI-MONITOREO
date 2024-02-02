using CAPA_ENTIDADES_NEGOCIO.CLASES;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CAPA_ACCESO_DATOS.CLASES
{
    public class SensorDA
    {

        public List<SensorBE> ObtenerSensores(int IdUsuario)
        {
            List<SensorBE> Sensores = new List<SensorBE>();

            string SQL = "SELECT si_cultivo_hidroponico.sensor.Id_Sensor, " +
                "si_cultivo_hidroponico.sensor.Nombre_Sensor, " +
                "si_cultivo_hidroponico.variable.Nombre_Variable, " +
                "si_cultivo_hidroponico.sensor.Rango_Inferior_Sensor, " +
                "si_cultivo_hidroponico.sensor.Rango_Superior_Sensor, " +
                "si_cultivo_hidroponico.unidad_medida_sensor.Nombre_Unidad_Medida_Sensor, " +
                "si_cultivo_hidroponico.unidad_medida_sensor.Simbolo_Unidad_Medida_Sensor, " +
                "si_cultivo_hidroponico.estado.Nombre_Estado " +
                "FROM si_cultivo_hidroponico.sensor " +
                "INNER JOIN si_cultivo_hidroponico.variable " +
                "ON si_cultivo_hidroponico.sensor.Id_Variable_Sensor = si_cultivo_hidroponico.variable.Id_Variable " +
                "INNER JOIN si_cultivo_hidroponico.unidad_medida_sensor " +
                "ON si_cultivo_hidroponico.variable.Id_Unidad_Medida_Sensor_Variable = si_cultivo_hidroponico.unidad_medida_sensor.Id_Unidad_Medida_Sensor " +
                "INNER JOIN si_cultivo_hidroponico.estado " +
                "ON si_cultivo_hidroponico.sensor.Id_Estado_Sensor = si_cultivo_hidroponico.estado.Id_Estado " +
                "WHERE si_cultivo_hidroponico.sensor.Id_Usuario_Sensor = " + IdUsuario + " " +
                "ORDER BY si_cultivo_hidroponico.sensor.Id_Sensor ASC";

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
                        SensorBE SensorBE = new SensorBE
                        {
                            Id_Sensor = int.Parse(Reader.GetString(0)),
                            Nombre_Sensor = Reader.GetString(1),
                            Variable_Sensor = Reader.GetString(2),
                            Rango_Inferior_Sensor = Reader.GetString(3),
                            Rango_Superior_Sensor = Reader.GetString(4),
                            Unidad_Medida_Sensor = Reader.GetString(5),
                            Simbolo_Unidad_Medida_Sensor = Reader.GetString(6),
                            Estado_Sensor = Reader.GetString(7)
                        };
                        Sensores.Add(SensorBE);
                    }
                }
            }
            catch (Exception ex){}
            finally
            {
                Conexion.Close();
            }
            return Sensores;
        }

        public SensorBE ObtenerSensor(int IdSesnor)
        {
            SensorBE SensorBE = null;

            string SQL = "SELECT si_cultivo_hidroponico.sensor.Id_Sensor, " +
                "si_cultivo_hidroponico.sensor.Nombre_Sensor, " +
                "si_cultivo_hidroponico.variable.Nombre_Variable, " +
                "si_cultivo_hidroponico.sensor.Rango_Inferior_Sensor, " +
                "si_cultivo_hidroponico.sensor.Rango_Superior_Sensor, " +
                "si_cultivo_hidroponico.unidad_medida_sensor.Nombre_Unidad_Medida_Sensor, " +
                "si_cultivo_hidroponico.unidad_medida_sensor.Simbolo_Unidad_Medida_Sensor, " +
                "si_cultivo_hidroponico.estado.Nombre_Estado " +
                "FROM si_cultivo_hidroponico.sensor " +
                "INNER JOIN si_cultivo_hidroponico.variable " +
                "ON si_cultivo_hidroponico.sensor.Id_Variable_Sensor = si_cultivo_hidroponico.variable.Id_Variable " +
                "INNER JOIN si_cultivo_hidroponico.unidad_medida_sensor " +
                "ON si_cultivo_hidroponico.variable.Id_Unidad_Medida_Sensor_Variable = si_cultivo_hidroponico.unidad_medida_sensor.Id_Unidad_Medida_Sensor " +
                "INNER JOIN si_cultivo_hidroponico.estado " +
                "ON si_cultivo_hidroponico.sensor.Id_Estado_Sensor = si_cultivo_hidroponico.estado.Id_Estado " +
                "WHERE si_cultivo_hidroponico.sensor.Id_Sensor = " + IdSesnor;

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
                        SensorBE = new SensorBE
                        {
                            Id_Sensor = int.Parse(Reader.GetString(0)),
                            Nombre_Sensor = Reader.GetString(1),
                            Variable_Sensor = Reader.GetString(2),
                            Rango_Inferior_Sensor = Reader.GetString(3),
                            Rango_Superior_Sensor = Reader.GetString(4),
                            Unidad_Medida_Sensor = Reader.GetString(5),
                            Simbolo_Unidad_Medida_Sensor = Reader.GetString(6),
                            Estado_Sensor = Reader.GetString(7)
                        };
                    }
                }
            }
            catch (Exception ex){}
            finally
            {
                Conexion.Close();
            }

            return SensorBE;

        }

        public bool CambiarNombreSensor(string NombreSensor, int IdSensor)
        {
            string SQL = "UPDATE si_cultivo_hidroponico.sensor " +
                "SET si_cultivo_hidroponico.sensor.Nombre_Sensor = '" + NombreSensor + "' " +
                "WHERE si_cultivo_hidroponico.sensor.Id_Sensor = " + IdSensor;
            return ConexionDA.EjecutarSentenciasNonQuery(SQL); ;
        }

        public bool CambiarRangoInferiorSensor(string RangoInferior, int IdSensor)
        {
            string SQL = "UPDATE si_cultivo_hidroponico.sensor " +
                "SET si_cultivo_hidroponico.sensor.Rango_Inferior_Sensor = '" + RangoInferior + "' " +
                "WHERE si_cultivo_hidroponico.sensor.Id_Sensor = " + IdSensor;
            return ConexionDA.EjecutarSentenciasNonQuery(SQL); ;
        }

        public bool CambiarRangoSuperiorSensor(string RangoSuperior, int IdSensor)
        {
            string SQL = "UPDATE si_cultivo_hidroponico.sensor " +
                "SET si_cultivo_hidroponico.sensor.Rango_Superior_Sensor = '" + RangoSuperior + "' " +
                "WHERE si_cultivo_hidroponico.sensor.Id_Sensor = " + IdSensor;
            return ConexionDA.EjecutarSentenciasNonQuery(SQL); ;
        }

        public bool CambiarVariableSensor(int IdVariable, int IdSensor)
        {
            string SQL = "UPDATE si_cultivo_hidroponico.sensor " +
                "SET si_cultivo_hidroponico.sensor.Id_Variable_Sensor = " + IdVariable + " " +
                "WHERE si_cultivo_hidroponico.sensor.Id_Sensor = " + IdSensor;
            return ConexionDA.EjecutarSentenciasNonQuery(SQL); ;
        }

        public bool CambiarUnidadMedidaSensor(int UnidadMedidaSensor, int IdVariable)
        {
            string SQL = "UPDATE si_cultivo_hidroponico.variable " +
                "SET si_cultivo_hidroponico.variable.Id_Unidad_Medida_Sensor_Variable = '" + UnidadMedidaSensor + "' " +
                "WHERE si_cultivo_hidroponico.variable.Id_Variable = " + IdVariable;
            return ConexionDA.EjecutarSentenciasNonQuery(SQL);
        }

        public bool EliminarSensor(int IdSensor)
        {
            string SQL = "UPDATE si_cultivo_hidroponico.sensor " +
                "SET si_cultivo_hidroponico.sensor.Id_Estado_Sensor = " + 2 + " " +
                "WHERE si_cultivo_hidroponico.sensor.Id_Sensor = " + IdSensor;
            return ConexionDA.EjecutarSentenciasNonQuery(SQL); ;
        }
    }
}
