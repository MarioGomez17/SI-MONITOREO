using CAPA_ENTIDADES_NEGOCIO.CLASES;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_ACCESO_DATOS.CLASES
{
    public class RolDA
    {

        public List<RolBE> TraerRoles()
        {
            List<RolBE> Roles = new List<RolBE>();

            string SQL = "SELECT si_cultivo_hidroponico.rol.Id_Rol, " +
                "si_cultivo_hidroponico.rol.Nombre_Rol " +
                "FROM si_cultivo_hidroponico.rol";

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
                        RolBE RolBE = new RolBE
                        {
                            Id_Rol = int.Parse(Reader.GetString(0)),
                            Nombre_Rol = Reader.GetString(1)
                        };

                        Roles.Add(RolBE);

                    }
                }
            }
            catch (Exception ex){}
            finally
            {
                Conexion.Close();
            }

            return Roles;
        }

    }
}
