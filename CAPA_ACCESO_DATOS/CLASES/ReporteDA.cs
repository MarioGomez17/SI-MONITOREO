using CAPA_ENTIDADES_NEGOCIO.CLASES;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CAPA_ACCESO_DATOS.CLASES
{
    public class ReporteDA
    {

        public bool GuardarReporte(string Temperatura, string Humedad, string Conductividad, int Id_Usuario)
        {
            string SQL = "INSERT INTO si_cultivo_hidroponico.reporte" +
                "(Temperatura_Reporte, Humedad_Reporte, Conductividad_Reporte, Id_Usuario_Reporte) VALUES" +
                "('" + Temperatura + "', '" + Humedad + "', '" + Conductividad  + "'," + Id_Usuario + ")";
            return ConexionDA.EjecutarSentenciasNonQuery(SQL);
        }

        public List<ReporteBE> GenerarReporte(int IdUsuario)
        {
            List<ReporteBE> ReportesBE = new List<ReporteBE>();

            string SQL = "SELECT si_cultivo_hidroponico.reporte.Id_Reporte, " +
                "si_cultivo_hidroponico.reporte.Temperatura_Reporte, " +
                "si_cultivo_hidroponico.reporte.Humedad_Reporte, " +
                "si_cultivo_hidroponico.reporte.Conductividad_Reporte, " +
                "si_cultivo_hidroponico.reporte.Fecha_Reporte " +
                "FROM si_cultivo_hidroponico.reporte " +
                "WHERE si_cultivo_hidroponico.reporte.Id_Usuario_Reporte = " + IdUsuario +
                " ORDER BY si_cultivo_hidroponico.reporte.Id_Reporte ASC";

            
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
                        ReporteBE ReporteBE = new ReporteBE
                        {
                            Id_Reporte = int.Parse(Reader.GetString(0)),
                            Temperatura_Reporte = Reader.GetString(1),
                            Humedad_Reporte = Reader.GetString(2),
                            Conductividad_Reporte = Reader.GetString(3),
                            Fecha_Reporte = Reader.GetString(4)
                            
                        };
                        ReportesBE.Add(ReporteBE);
                    }
                }
            }
            catch (Exception ex) { }
            finally
            {
                Conexion.Close();
            }
            return ReportesBE;
        }

    }
}
