using CAPA_ENTIDADES_NEGOCIO.CLASES;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CAPA_ACCESO_DATOS.CLASES
{
    public class AmbienteDA
    {

        public List<AmbienteBE> VerAmbiente()
        {
            List<AmbienteBE> AmbienteBE = new List<AmbienteBE>();
            string SQL = "SELECT si_cultivo_hidroponico.ambiente.Id_Ambiente, " +
                "si_cultivo_hidroponico.ambiente.Nombre_Variable_Ambiente, " +
                "si_cultivo_hidroponico.ambiente.Valor_Variable_Ambiente, " +
                "si_cultivo_hidroponico.unidad_medida_sensor.Simbolo_Unidad_Medida_Sensor, " +
                "si_cultivo_hidroponico.sensor.Nombre_Sensor " +
                "FROM si_cultivo_hidroponico.ambiente " +
                "INNER JOIN si_cultivo_hidroponico.sensor " +
                "ON si_cultivo_hidroponico.ambiente.Id_Sensor_Ambiente = si_cultivo_hidroponico.sensor.Id_Sensor " +
                "INNER JOIN si_cultivo_hidroponico.variable " +
                "ON si_cultivo_hidroponico.sensor.Id_Variable_Sensor = si_cultivo_hidroponico.variable.Id_Variable " +
                "INNER JOIN si_cultivo_hidroponico.unidad_medida_sensor " +
                "ON si_cultivo_hidroponico.variable.Id_Unidad_Medida_Sensor_Variable = si_cultivo_hidroponico.unidad_medida_sensor.Id_Unidad_Medida_Sensor";

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
                        AmbienteBE Ambiente = new AmbienteBE
                        {
                            Id_Ambiente = int.Parse(Reader.GetString(0)),
                            Nombre_Variable_Ambiente = Reader.GetString(1),
                            Valor_Variable_Ambiente = Reader.GetString(2),
                            Simbolo_Unidad_Medida = Reader.GetString(3),
                            Sensor_Ambiente = Reader.GetString(4),
                        };
                        AmbienteBE.Add(Ambiente);
                    }
                }
            }
            catch (Exception ex){}
            finally
            {
                Conexion.Close();
            }

            return AmbienteBE;
        }

        public string[] ObtenerValoresActuales()
        {
            string[] Variables = new string[3];

            string SQL = "SELECT si_cultivo_hidroponico.ambiente.Valor_Variable_Ambiente " +
                         "FROM si_cultivo_hidroponico.ambiente";
            MySqlConnection Conexion = ConexionDA.Conectar();
            Conexion.Open();
            try
            {
                MySqlCommand Comando = new MySqlCommand(SQL, Conexion);
                MySqlDataReader Reader = Comando.ExecuteReader();
                if (Reader.HasRows)
                {
                    int cont = 0;
                    while (Reader.Read())
                    {
                        Variables[cont] = Reader.GetString(0);
                        cont++;
                    }
                }
            }
            catch (Exception ex){}
            finally
            {
                Conexion.Close();
            }
            return Variables;
        }

        public void ActualizarVariablesAmbiente(string TemperaturaAmbiente, string HumedadAmbiente, string ConductividadAmbiente)
        {

            string SQL = "UPDATE si_cultivo_hidroponico.ambiente " +
                "SET si_cultivo_hidroponico.ambiente.Valor_Variable_Ambiente = '" + TemperaturaAmbiente + "' " +
                "WHERE si_cultivo_hidroponico.ambiente.Id_Ambiente = 1;" +
                "UPDATE si_cultivo_hidroponico.ambiente " +
                "SET si_cultivo_hidroponico.ambiente.Valor_Variable_Ambiente = '" + HumedadAmbiente + "' " +
                "WHERE si_cultivo_hidroponico.ambiente.Id_Ambiente = 2; " +
                "UPDATE si_cultivo_hidroponico.ambiente " +
                "SET si_cultivo_hidroponico.ambiente.Valor_Variable_Ambiente = '" + ConductividadAmbiente + "' " +
                "WHERE si_cultivo_hidroponico.ambiente.Id_Ambiente = 3";
            ConexionDA.EjecutarSentenciasNonQuery(SQL);

        }

    }
}
