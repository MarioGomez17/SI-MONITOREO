using MySql.Data.MySqlClient;
using System;

namespace CAPA_ACCESO_DATOS.CLASES
{
    public class ConexionDA
    {
        public static MySqlConnection Conectar()
        {
            String servidor = "localhost";
            String bd = "si_cultivo_hidroponico";
            String usuario = "root";
            String contrasena = "M@rio1002960089";
            String cadena_conexion = "database = " + bd + "; Data Source = " + servidor + "; User Id = " + usuario + "; Password = " + contrasena + "";

            try
            {
                MySqlConnection conexionBD = new MySqlConnection(cadena_conexion);
                return conexionBD;
            }
            catch (MySqlException ex)
            {
                return null;
            }
        }
        
        public static Boolean EjecutarSentenciasNonQuery(String SQL)
        {
            Boolean bandera = false;
            MySqlConnection conexion = Conectar();
            conexion.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexion);
                comando.ExecuteNonQuery();
                bandera = true;
            }
            catch (MySqlException ex){}
            finally
            {
                conexion.Close();
            }
            return bandera;
        }
    }
}
