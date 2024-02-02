using CAPA_ENTIDADES_NEGOCIO.CLASES;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;

namespace CAPA_ACCESO_DATOS.CLASES
{
    public class PlantaDA
    {

        public List<PlantaBE> ObtenerPlantas(int IdUsuario)
        {
            List<PlantaBE> Plantas = new List<PlantaBE>();

            string SQL = "SELECT si_cultivo_hidroponico.planta.Id_Planta, " +
                "si_cultivo_hidroponico.tipo_planta.Nombre_Tipo_Planta, " +
                "si_cultivo_hidroponico.planta.Nombre_Planta, " +
                "si_cultivo_hidroponico.planta.Diametro_Tallo_Planta, " +
                "si_cultivo_hidroponico.unidad_medida_planta.Simbolo_Unidad_Medida_Planta, " +
                "si_cultivo_hidroponico.planta.Tiempo_Cultivo_Planta, " +
                "si_cultivo_hidroponico.unidad_tiempo_planta.Nombre_Unidad_Tiempo_Planta, " +
                "si_cultivo_hidroponico.planta.Cantidad_Hojas_Planta, " +
                "si_cultivo_hidroponico.planta.Altura_Planta, " +
                "si_cultivo_hidroponico.estado.Nombre_Estado " +
                "FROM si_cultivo_hidroponico.planta " +
                "INNER JOIN si_cultivo_hidroponico.tipo_planta " +
                "ON si_cultivo_hidroponico.planta.Id_Tipo_Planta_Planta = si_cultivo_hidroponico.tipo_planta.Id_Tipo_Planta " +
                "INNER JOIN si_cultivo_hidroponico.unidad_medida_planta " +
                "ON si_cultivo_hidroponico.planta.Id_Unidad_Medida_Planta_Planta = si_cultivo_hidroponico.unidad_medida_planta.Id_Unidad_Medida_Planta " +
                "INNER JOIN si_cultivo_hidroponico.unidad_tiempo_planta " +
                "ON si_cultivo_hidroponico.planta.Id_Unidad_Tiempo_Planta_Planta = si_cultivo_hidroponico.unidad_tiempo_planta.Id_Unidad_Tiempo_Planta " +
                "INNER JOIN si_cultivo_hidroponico.estado " +
                "ON si_cultivo_hidroponico.planta.Id_Estado_Planta = si_cultivo_hidroponico.estado.Id_Estado " +
                "WHERE si_cultivo_hidroponico.planta.Id_Usuario_Planta = " + IdUsuario + " " +
                "ORDER BY si_cultivo_hidroponico.planta.Id_Planta ASC";

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
                        PlantaBE PlantaBE = new PlantaBE
                        {
                            Id_Planta = int.Parse(Reader.GetString(0)),
                            Tipo_Planta_Planta = Reader.GetString(1),
                            Nombre_Planta = Reader.GetString(2),
                            Diametro_Tallo_Planta = double.Parse(Reader.GetString(3)),
                            Unidad_Medida_Planta_Planta = Reader.GetString(4),
                            Tiempo_Cultivo_Planta = double.Parse(Reader.GetString(5)),
                            Unidad_Tiempo_Planta_Planta = Reader.GetString(6),
                            Cantidad_Hojas_Planta = int.Parse(Reader.GetString(7)),
                            Altura_Planta = Reader.GetString(8),
                            Estado_Planta = Reader.GetString(9)
                        };

                        Plantas.Add(PlantaBE);

                    }
                }
            }
            catch (Exception ex){}
            finally
            {
                Conexion.Close();
            }

            return Plantas;
        }

        public PlantaBE ObtenerPlanta(int IdPlanta)
        {
            PlantaBE PlantaBE = null;

            string SQL = "SELECT si_cultivo_hidroponico.planta.Id_Planta, " +
                "si_cultivo_hidroponico.tipo_planta.Nombre_Tipo_Planta, " +
                "si_cultivo_hidroponico.planta.Nombre_Planta, " +
                "si_cultivo_hidroponico.planta.Diametro_Tallo_Planta, " +
                "si_cultivo_hidroponico.unidad_medida_planta.Simbolo_Unidad_Medida_Planta, " +
                "si_cultivo_hidroponico.planta.Tiempo_Cultivo_Planta, " +
                "si_cultivo_hidroponico.unidad_tiempo_planta.Nombre_Unidad_Tiempo_Planta, " +
                "si_cultivo_hidroponico.planta.Cantidad_Hojas_Planta, " +
                "si_cultivo_hidroponico.planta.Altura_Planta, " +
                "si_cultivo_hidroponico.estado.Nombre_Estado " +
                "FROM si_cultivo_hidroponico.planta " +
                "INNER JOIN si_cultivo_hidroponico.tipo_planta " +
                "ON si_cultivo_hidroponico.planta.Id_Tipo_Planta_Planta = si_cultivo_hidroponico.tipo_planta.Id_Tipo_Planta " +
                "INNER JOIN si_cultivo_hidroponico.unidad_medida_planta " +
                "ON si_cultivo_hidroponico.planta.Id_Unidad_Medida_Planta_Planta = si_cultivo_hidroponico.unidad_medida_planta.Id_Unidad_Medida_Planta " +
                "INNER JOIN si_cultivo_hidroponico.unidad_tiempo_planta " +
                "ON si_cultivo_hidroponico.planta.Id_Unidad_Tiempo_Planta_Planta = si_cultivo_hidroponico.unidad_tiempo_planta.Id_Unidad_Tiempo_Planta " +
                "INNER JOIN si_cultivo_hidroponico.estado " +
                "ON si_cultivo_hidroponico.planta.Id_Estado_Planta = si_cultivo_hidroponico.estado.Id_Estado " +
                "WHERE si_cultivo_hidroponico.planta.Id_Planta = " + IdPlanta + " " +
                "ORDER BY si_cultivo_hidroponico.planta.Id_Planta ASC";

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
                        PlantaBE = new PlantaBE
                        {
                            Id_Planta = int.Parse(Reader.GetString(0)),
                            Tipo_Planta_Planta = Reader.GetString(1),
                            Nombre_Planta = Reader.GetString(2),
                            Diametro_Tallo_Planta = double.Parse(Reader.GetString(3)),
                            Unidad_Medida_Planta_Planta = Reader.GetString(4),
                            Tiempo_Cultivo_Planta = double.Parse(Reader.GetString(5)),
                            Unidad_Tiempo_Planta_Planta = Reader.GetString(6),
                            Cantidad_Hojas_Planta = int.Parse(Reader.GetString(7)),
                            Altura_Planta = Reader.GetString(8),
                            Estado_Planta = Reader.GetString(9)
                        };
                    }
                }
            }
            catch (Exception ex){}
            finally
            {
                Conexion.Close();
            }

            return PlantaBE;
        }

        public PlantaBE BuscarPlanta(string NombrePlanta)
        {
            PlantaBE PlantaBE = null;

            string SQL = "SELECT si_cultivo_hidroponico.planta.Id_Planta, " +
                "si_cultivo_hidroponico.tipo_planta.Nombre_Tipo_Planta, " +
                "si_cultivo_hidroponico.planta.Nombre_Planta, " +
                "si_cultivo_hidroponico.planta.Diametro_Tallo_Planta, " +
                "si_cultivo_hidroponico.unidad_medida_planta.Simbolo_Unidad_Medida_Planta, " +
                "si_cultivo_hidroponico.planta.Tiempo_Cultivo_Planta, " +
                "si_cultivo_hidroponico.unidad_tiempo_planta.Nombre_Unidad_Tiempo_Planta, " +
                "si_cultivo_hidroponico.planta.Cantidad_Hojas_Planta, " +
                "si_cultivo_hidroponico.estado.Nombre_Estado " +
                "FROM si_cultivo_hidroponico.planta " +
                "INNER JOIN si_cultivo_hidroponico.tipo_planta " +
                "ON si_cultivo_hidroponico.planta.Id_Tipo_Planta_Planta = si_cultivo_hidroponico.tipo_planta.Id_Tipo_Planta " +
                "INNER JOIN si_cultivo_hidroponico.unidad_medida_planta " +
                "ON si_cultivo_hidroponico.planta.Id_Unidad_Medida_Planta_Planta = si_cultivo_hidroponico.unidad_medida_planta.Id_Unidad_Medida_Planta " +
                "INNER JOIN si_cultivo_hidroponico.unidad_tiempo_planta " +
                "ON si_cultivo_hidroponico.planta.Id_Unidad_Tiempo_Planta_Planta = si_cultivo_hidroponico.unidad_tiempo_planta.Id_Unidad_Tiempo_Planta " +
                "INNER JOIN si_cultivo_hidroponico.estado " +
                "ON si_cultivo_hidroponico.planta.Id_Estado_Planta = si_cultivo_hidroponico.estado.Id_Estado " +
                "WHERE si_cultivo_hidroponico.planta.Nombre_Planta = " + NombrePlanta + " " +
                "ORDER BY si_cultivo_hidroponico.planta.Id_Planta ASC";

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
                        PlantaBE = new PlantaBE
                        {
                            Id_Planta = int.Parse(Reader.GetString(0)),
                            Tipo_Planta_Planta = Reader.GetString(1),
                            Nombre_Planta = Reader.GetString(2),
                            Diametro_Tallo_Planta = double.Parse(Reader.GetString(3)),
                            Unidad_Medida_Planta_Planta = Reader.GetString(4),
                            Tiempo_Cultivo_Planta = double.Parse(Reader.GetString(5)),
                            Unidad_Tiempo_Planta_Planta = Reader.GetString(6),
                            Cantidad_Hojas_Planta = int.Parse(Reader.GetString(7)),
                            Estado_Planta = Reader.GetString(8)
                        };
                    }
                }
            }
            catch (Exception ex){}
            finally
            {
                Conexion.Close();
            }

            return PlantaBE;
        }

        public bool ValidarPlanta(string NombrePlanta)
        {
            return BuscarPlanta(NombrePlanta) == null;
        }

        public bool CambiarNombrePlanta(string NombrePlanta, int IdPlanta)
        {
            string SQL = "UPDATE si_cultivo_hidroponico.planta " +
                "SET si_cultivo_hidroponico.planta.Nombre_Planta = '" + NombrePlanta + "' " +
                "WHERE si_cultivo_hidroponico.planta.Id_Planta = " + IdPlanta;
            return ConexionDA.EjecutarSentenciasNonQuery(SQL);
        }

        public bool CambiarDiametroTalloPlanta(double DiametroTalloPlanta, int IdPlanta)
        {
            string SQL = "UPDATE si_cultivo_hidroponico.planta " +
                "SET si_cultivo_hidroponico.planta.Diametro_Tallo_Planta = '" + DiametroTalloPlanta + "' " +
                "WHERE si_cultivo_hidroponico.planta.Id_Planta = " + IdPlanta;
            return ConexionDA.EjecutarSentenciasNonQuery(SQL);
        }

        public bool CambiarTiempoCultivoPlanta(double Tiempo_Cultivo_Planta, int IdPlanta)
        {
            string SQL = "UPDATE si_cultivo_hidroponico.planta " +
                "SET si_cultivo_hidroponico.planta.Tiempo_Cultivo_Planta = '" + Tiempo_Cultivo_Planta + "' " +
                "WHERE si_cultivo_hidroponico.planta.Id_Planta = " + IdPlanta;
            return ConexionDA.EjecutarSentenciasNonQuery(SQL);
        }

        public bool CambiarCantidadHojasPlanta(int CantidadHojasPlanta, int IdPlanta)
        {
            string SQL = "UPDATE si_cultivo_hidroponico.planta " +
                "SET si_cultivo_hidroponico.planta.Cantidad_Hojas_Planta = '" + CantidadHojasPlanta + "' " +
                "WHERE si_cultivo_hidroponico.planta.Id_Planta = " + IdPlanta;
            return ConexionDA.EjecutarSentenciasNonQuery(SQL);
        }

        public bool CambiarTipoPlanta(int TipoPlanta, int IdPlanta)
        {
            string SQL = "UPDATE si_cultivo_hidroponico.planta " +
                "SET si_cultivo_hidroponico.planta.Id_Tipo_Planta_Planta = '" + TipoPlanta + "' " +
                "WHERE si_cultivo_hidroponico.planta.Id_Planta = " + IdPlanta;
            return ConexionDA.EjecutarSentenciasNonQuery(SQL);
        }

        public bool CambiarUnidadMedidaPlanta(int UnidadMedidaPlanta, int IdPlanta)
        {
            string SQL = "UPDATE si_cultivo_hidroponico.planta " +
                "SET si_cultivo_hidroponico.planta.Id_Unidad_Medida_Planta_Planta = '" + UnidadMedidaPlanta + "' " +
                "WHERE si_cultivo_hidroponico.planta.Id_Planta = " + IdPlanta;
            return ConexionDA.EjecutarSentenciasNonQuery(SQL);
        }

        public bool CambiarUnidadTiempoPlanta(int UnidadTiempoPlanta, int IdPlanta)
        {
            string SQL = "UPDATE si_cultivo_hidroponico.planta " +
                "SET si_cultivo_hidroponico.planta.Id_Unidad_Tiempo_Planta_Planta = '" + UnidadTiempoPlanta + "' " +
                "WHERE si_cultivo_hidroponico.planta.Id_Planta = " + IdPlanta;
            return ConexionDA.EjecutarSentenciasNonQuery(SQL);
        }

        public bool EliminarPlanta(int IdPlanta)
        {
            string SQL = "UPDATE si_cultivo_hidroponico.planta " +
                "SET si_cultivo_hidroponico.planta.Id_Estado_Planta = " + 2 + " " +
                "WHERE si_cultivo_hidroponico.planta.Id_Planta = " + IdPlanta;
            return ConexionDA.EjecutarSentenciasNonQuery(SQL);
        }

        public bool RegistrarPlanta(string NombrePlanta, double DiametroTallo, double TiempoCultivo, int CantidadHojas, int IdUsuario, int TipoPlanta, int UnidadMeida, int UnidadTiempo)
        {
            string SQL = "INSERT INTO si_cultivo_hidroponico.planta " +
                "(si_cultivo_hidroponico.planta.Nombre_Planta, si_cultivo_hidroponico.planta.Diametro_Tallo_Planta, " +
                "si_cultivo_hidroponico.planta.Tiempo_Cultivo_Planta,  si_cultivo_hidroponico.planta.Cantidad_Hojas_Planta, " +
                "si_cultivo_hidroponico.planta.Id_Usuario_Planta, si_cultivo_hidroponico.planta.Id_Tipo_Planta_Planta,  " +
                "si_cultivo_hidroponico.planta.Id_Unidad_Medida_Planta_Planta, " +
                "si_cultivo_hidroponico.planta.Id_Unidad_Tiempo_Planta_Planta) " +
                "VALUES ('" + NombrePlanta + "', " + DiametroTallo + "," + TiempoCultivo +
                "," + CantidadHojas +", " + IdUsuario + ", " + TipoPlanta + ", " + UnidadMeida + ", " + UnidadTiempo + ")";
            return ConexionDA.EjecutarSentenciasNonQuery(SQL);
        }

        public bool CambiarAlturaPlanta(double AlturaPlanta, int IdPlanta)
        {
            string SQL = "UPDATE si_cultivo_hidroponico.planta " +
                "SET si_cultivo_hidroponico.planta.Altura_Planta = '" + AlturaPlanta + "' " +
                "WHERE si_cultivo_hidroponico.planta.Id_Planta = " + IdPlanta;
            return ConexionDA.EjecutarSentenciasNonQuery(SQL);
        }

    }
}
