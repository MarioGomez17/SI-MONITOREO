using CAPA_ENTIDADES_NEGOCIO.CLASES;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_ACCESO_DATOS.CLASES
{
    public class UnidadMedidaPlantaDA
    {
        public List<UnidadMedidaPlantaBE> TraerUnidadesMedidasPlanta()
        {
            List<UnidadMedidaPlantaBE> Unidades = new List<UnidadMedidaPlantaBE>();
            string SQL = "SELECT si_cultivo_hidroponico.unidad_medida_planta.Id_Unidad_Medida_Planta, " +
                "si_cultivo_hidroponico.unidad_medida_planta.Nombre_Unidad_Medida_Planta, " +
                "si_cultivo_hidroponico.unidad_medida_planta.Simbolo_Unidad_Medida_Planta " +
                "FROM si_cultivo_hidroponico.unidad_medida_planta " +
                "ORDER BY si_cultivo_hidroponico.unidad_medida_planta.Id_Unidad_Medida_Planta ASC";
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
                        UnidadMedidaPlantaBE UnidadBE = new UnidadMedidaPlantaBE
                        {
                            Id_Unidad_Medida_Planta = int.Parse(Reader.GetString(0)),
                            Nombre_Unidad_Medida_Planta = Reader.GetString(1),
                            Simbolo_Unidad_Medida_Planta = Reader.GetString(2)
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

        public bool AgregarUnidadMedidaPlanta(string UnidadMedida, string SimboloUnidad)
        {
            string SQL = "INSERT INTO si_cultivo_hidroponico.unidad_medida_planta " +
                "(si_cultivo_hidroponico.unidad_medida_planta.Nombre_Unidad_Medida_Planta, " +
                "si_cultivo_hidroponico.unidad_medida_planta.Simbolo_Unidad_Medida_Planta) VALUES (" +
                "'" + UnidadMedida + "', '" + SimboloUnidad + "')";
            return ConexionDA.EjecutarSentenciasNonQuery(SQL);
        }
    }
}
