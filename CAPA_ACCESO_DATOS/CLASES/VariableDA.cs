using CAPA_ENTIDADES_NEGOCIO.CLASES;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CAPA_ACCESO_DATOS.CLASES
{
    public class VariableDA
    {

        public List<VariableBE> TraerVariables()
        {
            List<VariableBE> Variables = new List<VariableBE>();
            string SQL = "SELECT si_cultivo_hidroponico.variable.Id_Variable, " +
                "si_cultivo_hidroponico.variable.Nombre_Variable " +
                "FROM si_cultivo_hidroponico.variable " +
                "ORDER BY si_cultivo_hidroponico.variable.Id_Variable ASC";
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
                        VariableBE VariableBE = new VariableBE
                        {
                            Id_Variable = int.Parse(Reader.GetString(0)),
                            Nombre_Variable = Reader.GetString(1),
                        };
                        Variables.Add(VariableBE);
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

    }
}
