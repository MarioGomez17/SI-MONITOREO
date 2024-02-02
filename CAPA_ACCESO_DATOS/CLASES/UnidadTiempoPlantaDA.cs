using CAPA_ENTIDADES_NEGOCIO.CLASES;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_ACCESO_DATOS.CLASES
{
    public class UnidadTiempoPlantaDA
    {

        public List<UnidadTiempoPlantaBE> TraerUnidadesTiempoPlanta()
        {
            List<UnidadTiempoPlantaBE> Unidades = new List<UnidadTiempoPlantaBE>();
            string SQL = "SELECT si_cultivo_hidroponico.unidad_tiempo_planta.Id_Unidad_Tiempo_Planta, " +
                "si_cultivo_hidroponico.unidad_tiempo_planta.Nombre_Unidad_Tiempo_Planta " +
                "FROM si_cultivo_hidroponico.unidad_tiempo_planta " +
                "ORDER BY si_cultivo_hidroponico.unidad_tiempo_planta.Id_Unidad_Tiempo_Planta ASC";
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
                        UnidadTiempoPlantaBE UnidadBE = new UnidadTiempoPlantaBE
                        {
                            Id_Unidad_Ttimepo_Planta = int.Parse(Reader.GetString(0)),
                            Nombre_Unidad_Tiempo_Planta = Reader.GetString(1),
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

        public bool AgregarUnidadTiempoPlanta(string UnidadTiempo)
        {
            string SQL = "INSERT INTO si_cultivo_hidroponico.unidad_tiempo_planta " +
                "(si_cultivo_hidroponico.unidad_tiempo_planta.Nombre_Unidad_tiempo_Planta) VALUES (" +
                "'" + UnidadTiempo + "')";
            return ConexionDA.EjecutarSentenciasNonQuery(SQL);
        }

    }
}
