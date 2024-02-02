using CAPA_ENTIDADES_NEGOCIO.CLASES;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_ACCESO_DATOS.CLASES
{
    public class TipoPlantaDA
    {

        public List<TipoPlantaBE> TraerTiposlPanta()
        {
            List<TipoPlantaBE> tipos = new List<TipoPlantaBE>();
            string SQL = "SELECT si_cultivo_hidroponico.tipo_planta.Id_Tipo_Planta, " +
                "si_cultivo_hidroponico.tipo_planta.Nombre_Tipo_Planta " +
                "FROM si_cultivo_hidroponico.tipo_planta " +
                "ORDER BY si_cultivo_hidroponico.tipo_planta.Id_Tipo_Planta ASC";
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
                        TipoPlantaBE TipoBE = new TipoPlantaBE
                        {
                            Id_Tipo_Planta = int.Parse(Reader.GetString(0)),
                            Nombre_Tipo_Planta = Reader.GetString(1),
                        };
                        tipos.Add(TipoBE);
                    }
                }
            }
            catch (Exception ex){}
            finally
            {
                Conexion.Close();
            }

            return tipos;
        }

    }
}
