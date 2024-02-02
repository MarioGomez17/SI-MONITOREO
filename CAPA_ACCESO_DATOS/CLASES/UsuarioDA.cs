using CAPA_ENTIDADES_NEGOCIO.CLASES;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace CAPA_ACCESO_DATOS.CLASES
{
    public class UsuarioDA
    {

        public bool RegistrarUsuario(string NombreUsuario, string ApellidoUsuario, string TelefonoUsuario, string CorreoUsuario, string ContrasenaUsuario)
        {
            string SQL = "INSERT INTO si_cultivo_hidroponico.usuario " +
                "(si_cultivo_hidroponico.usuario.Nombre_Usuario, " +
                "si_cultivo_hidroponico.usuario.Apellido_Usuario, " +
                "si_cultivo_hidroponico.usuario.Telefono_Usuario, " +
                "si_cultivo_hidroponico.usuario.Correo_Usuario, " +
                "si_cultivo_hidroponico.usuario.Contrasena_Usuario) " +
                "VALUES ('" + NombreUsuario + "', " +
                "'" + ApellidoUsuario + "', " +
                "'" + TelefonoUsuario + "', " +
                "'" +CorreoUsuario + "', " +
                "SHA('" + ContrasenaUsuario + "'))";
            return ConexionDA.EjecutarSentenciasNonQuery(SQL);
        }

        public UsuarioBE TraerUsuario(string Correo, string Contrasena)
        {

            UsuarioBE UsuarioBE = null;

            string SQL = "SELECT si_cultivo_hidroponico.usuario.Id_Usuario, " +
                         "si_cultivo_hidroponico.usuario.Nombre_Usuario, " +
                         "si_cultivo_hidroponico.usuario.Apellido_Usuario, " +
                         "si_cultivo_hidroponico.usuario.Telefono_Usuario, " +
                         "si_cultivo_hidroponico.usuario.Correo_Usuario, " +
                         "si_cultivo_hidroponico.usuario.Contrasena_Usuario, " +
                         "si_cultivo_hidroponico.Rol.Nombre_Rol, " +
                         "si_cultivo_hidroponico.Estado.Nombre_Estado " +
                         "FROM si_cultivo_hidroponico.usuario " +
                         "INNER JOIN si_cultivo_hidroponico.rol " +
                         "ON si_cultivo_hidroponico.usuario.Id_Rol_Usuario = si_cultivo_hidroponico.rol.Id_Rol " +
                         "INNER JOIN si_cultivo_hidroponico.estado " +
                         "ON si_cultivo_hidroponico.usuario.Id_Estado_Usuario = si_cultivo_hidroponico.estado.Id_Estado " +
                         "WHERE si_cultivo_hidroponico.usuario.Correo_Usuario = '" + Correo + "'" +
                         "AND si_cultivo_hidroponico.usuario.Contrasena_Usuario = SHA ('" + Contrasena + "')";

            MySqlConnection Conexion = ConexionDA.Conectar();
            Conexion.Open();
            try
            {
                MySqlCommand Comando = new MySqlCommand(SQL, Conexion);
                MySqlDataReader Reader = Comando.ExecuteReader();
                if (Reader.HasRows)
                {
                    UsuarioBE = new UsuarioBE();
                    while (Reader.Read())
                    {
                        UsuarioBE.Id_Usuario = int.Parse(Reader.GetString(0));
                        UsuarioBE.Nombre_Usuario = Reader.GetString(1);
                        UsuarioBE.Apellido_Usuario = Reader.GetString(2);
                        UsuarioBE.Telefono_Usuario = Reader.GetString(3);
                        UsuarioBE.Correo_Usuario = Reader.GetString(4);
                        UsuarioBE.Contrasena_Usuario = Reader.GetString(5);
                        UsuarioBE.Rol_Usuario = Reader.GetString(6);
                        UsuarioBE.Estado_Usuario = Reader.GetString(7);
                    }
                }
            }
            catch (Exception ex){}
            finally
            {
                Conexion.Close();
            }

            return UsuarioBE;

        }

        public UsuarioBE BuscarUsuario(string CorreoUsuario)
        {
            UsuarioBE UsuarioBE = null;

            string SQL = "SELECT si_cultivo_hidroponico.usuario.Id_Usuario, " +
                         "si_cultivo_hidroponico.usuario.Nombre_Usuario, " +
                         "si_cultivo_hidroponico.usuario.Apellido_Usuario, " +
                         "si_cultivo_hidroponico.usuario.Telefono_Usuario, " +
                         "si_cultivo_hidroponico.usuario.Correo_Usuario, " +
                         "si_cultivo_hidroponico.usuario.Contrasena_Usuario, " +
                         "si_cultivo_hidroponico.Rol.Nombre_Rol, " +
                         "si_cultivo_hidroponico.Estado.Nombre_Estado " +
                         "FROM si_cultivo_hidroponico.usuario " +
                         "INNER JOIN si_cultivo_hidroponico.rol " +
                         "ON si_cultivo_hidroponico.usuario.Id_Rol_Usuario = si_cultivo_hidroponico.rol.Id_Rol " +
                         "INNER JOIN si_cultivo_hidroponico.estado " +
                         "ON si_cultivo_hidroponico.usuario.Id_Estado_Usuario = si_cultivo_hidroponico.estado.Id_Estado " +
                         "WHERE si_cultivo_hidroponico.usuario.Correo_Usuario = '" + CorreoUsuario + "'";
            MySqlConnection Conexion = ConexionDA.Conectar();
            Conexion.Open();
            try
            {
                MySqlCommand Comando = new MySqlCommand(SQL, Conexion);
                MySqlDataReader Reader = Comando.ExecuteReader();
                if (Reader.HasRows)
                {
                    UsuarioBE = new UsuarioBE();
                    while (Reader.Read())
                    {
                        UsuarioBE.Id_Usuario = int.Parse(Reader.GetString(0));
                        UsuarioBE.Nombre_Usuario = Reader.GetString(1);
                        UsuarioBE.Apellido_Usuario = Reader.GetString(2);
                        UsuarioBE.Telefono_Usuario = Reader.GetString(3);
                        UsuarioBE.Correo_Usuario = Reader.GetString(4);
                        UsuarioBE.Contrasena_Usuario = Reader.GetString(5);
                        UsuarioBE.Rol_Usuario = Reader.GetString(6);
                        UsuarioBE.Estado_Usuario = Reader.GetString(7);
                    }
                }
            }
            catch (Exception ex){}
            finally
            {
                Conexion.Close();
            }

            return UsuarioBE;
        }

        public UsuarioBE ObtenerUsuario(int IdUsuario)
        {
            UsuarioBE UsuarioBE = null;

            string SQL = "SELECT si_cultivo_hidroponico.usuario.Id_Usuario, " +
                         "si_cultivo_hidroponico.usuario.Nombre_Usuario, " +
                         "si_cultivo_hidroponico.usuario.Apellido_Usuario, " +
                         "si_cultivo_hidroponico.usuario.Telefono_Usuario, " +
                         "si_cultivo_hidroponico.usuario.Correo_Usuario, " +
                         "si_cultivo_hidroponico.usuario.Contrasena_Usuario, " +
                         "si_cultivo_hidroponico.Rol.Nombre_Rol, " +
                         "si_cultivo_hidroponico.Estado.Nombre_Estado " +
                         "FROM si_cultivo_hidroponico.usuario " +
                         "INNER JOIN si_cultivo_hidroponico.rol " +
                         "ON si_cultivo_hidroponico.usuario.Id_Rol_Usuario = si_cultivo_hidroponico.rol.Id_Rol " +
                         "INNER JOIN si_cultivo_hidroponico.estado " +
                         "ON si_cultivo_hidroponico.usuario.Id_Estado_Usuario = si_cultivo_hidroponico.estado.Id_Estado " +
                         "WHERE si_cultivo_hidroponico.usuario.Id_Usuario = " + IdUsuario;
            MySqlConnection Conexion = ConexionDA.Conectar();
            Conexion.Open();
            try
            {
                MySqlCommand Comando = new MySqlCommand(SQL, Conexion);
                MySqlDataReader Reader = Comando.ExecuteReader();
                if (Reader.HasRows)
                {
                    UsuarioBE = new UsuarioBE();
                    while (Reader.Read())
                    {
                        UsuarioBE.Id_Usuario = int.Parse(Reader.GetString(0));
                        UsuarioBE.Nombre_Usuario = Reader.GetString(1);
                        UsuarioBE.Apellido_Usuario = Reader.GetString(2);
                        UsuarioBE.Telefono_Usuario = Reader.GetString(3);
                        UsuarioBE.Correo_Usuario = Reader.GetString(4);
                        UsuarioBE.Contrasena_Usuario = Reader.GetString(5);
                        UsuarioBE.Rol_Usuario = Reader.GetString(6);
                        UsuarioBE.Estado_Usuario = Reader.GetString(7);
                    }
                }
            }
            catch (Exception ex){}
            finally
            {
                Conexion.Close();
            }

            return UsuarioBE;
        }

        public bool CambiarNombreUsuario(string NombreUsuario, int IdUsuario)
        {
            string SQL = "UPDATE si_cultivo_hidroponico.usuario " +
                "SET si_cultivo_hidroponico.usuario.Nombre_Usuario = '" + NombreUsuario + "' " +
                "WHERE si_cultivo_hidroponico.usuario.Id_Usuario = " + IdUsuario;
            return ConexionDA.EjecutarSentenciasNonQuery(SQL);
        }

        public bool CambiarApellidoUsuario(string ApeliidoUsuario, int IdUsuario)
        {
            string SQL = "UPDATE si_cultivo_hidroponico.usuario " +
                "SET si_cultivo_hidroponico.usuario.Apellido_Usuario = '" + ApeliidoUsuario + "' " +
                "WHERE si_cultivo_hidroponico.usuario.Id_Usuario = " + IdUsuario;
            return ConexionDA.EjecutarSentenciasNonQuery(SQL);
        }

        public bool CambiarTelefonoUsuario(string TelefonoUsuario, int IdUsuario)
        {
            string SQL = "UPDATE si_cultivo_hidroponico.usuario " +
                "SET si_cultivo_hidroponico.usuario.Telefono_Usuario = '" + TelefonoUsuario + "' " +
                "WHERE si_cultivo_hidroponico.usuario.Id_Usuario = " + IdUsuario;
            return ConexionDA.EjecutarSentenciasNonQuery(SQL);
        }

        public bool CompararContrasenasUsuario(string ContrasenaUsuario, int IdUsuario)
        {
            bool bandera = false;
            string SQL = "SELECT si_cultivo_hidroponico.usuario.Contrasena_Usuario " +
                "FROM si_cultivo_hidroponico.usuario " +
                "WHERE si_cultivo_hidroponico.usuario.Contrasena_Usuario = SHA('" + ContrasenaUsuario + "') " +
                "AND si_cultivo_hidroponico.usuario.Id_Estado_Usuario = " + IdUsuario;
            MySqlConnection Conexion = ConexionDA.Conectar();
            Conexion.Open();
            try
            {
                MySqlCommand Comando = new MySqlCommand(SQL, Conexion);
                MySqlDataReader Reader = Comando.ExecuteReader();
                if (Reader.HasRows)
                {
                    bandera = true;
                }
            }
            catch (Exception ex){}
            finally
            {
                Conexion.Close();
            }
            return bandera;
        }

        public bool CambiarContrasenaUsuario(string ContrasenaUsuario, int IdUsuario)
        {
            string SQL = "UPDATE si_cultivo_hidroponico.usuario " +
                "SET si_cultivo_hidroponico.usuario.Contrasena_Usuario = SHA('" + ContrasenaUsuario + "') " +
                "WHERE si_cultivo_hidroponico.usuario.Id_Usuario = " + IdUsuario;
            return ConexionDA.EjecutarSentenciasNonQuery(SQL);
        }

        public bool ValidarUsuario(string CorreoUsuario)
        {
            return BuscarUsuario(CorreoUsuario) == null;
        }

        public bool EliminarUsuario(int IdUsuario)
        {
            string SQL = "UPDATE si_cultivo_hidroponico.usuario " +
                "SET si_cultivo_hidroponico.usuario.Id_Estado_Usuario = " + 2 + " " +
                "WHERE si_cultivo_hidroponico.usuario.Id_Usuario = " + IdUsuario;
            return ConexionDA.EjecutarSentenciasNonQuery(SQL);
        }

        public bool CambiarRolUsuario(int IdUsuario, int IdRol)
        {
            string SQL = "UPDATE si_cultivo_hidroponico.usuario " +
                "SET si_cultivo_hidroponico.usuario.Id_Rol_Usuario = " + IdRol + " " +
                "WHERE si_cultivo_hidroponico.usuario.Id_Usuario = " + IdUsuario;
            return ConexionDA.EjecutarSentenciasNonQuery(SQL);
        }

        public List<UsuarioBE> ObtenerUsuarios()
        {
            List<UsuarioBE> Usuarios = new List<UsuarioBE>();

            string SQL = "SELECT si_cultivo_hidroponico.usuario.Id_Usuario, " +
                         "si_cultivo_hidroponico.usuario.Nombre_Usuario, " +
                         "si_cultivo_hidroponico.usuario.Apellido_Usuario, " +
                         "si_cultivo_hidroponico.usuario.Telefono_Usuario, " +
                         "si_cultivo_hidroponico.usuario.Correo_Usuario, " +
                         "si_cultivo_hidroponico.Rol.Nombre_Rol, " +
                         "si_cultivo_hidroponico.Estado.Nombre_Estado " +
                         "FROM si_cultivo_hidroponico.usuario " +
                         "INNER JOIN si_cultivo_hidroponico.rol " +
                         "ON si_cultivo_hidroponico.usuario.Id_Rol_Usuario = si_cultivo_hidroponico.rol.Id_Rol " +
                         "INNER JOIN si_cultivo_hidroponico.estado " +
                         "ON si_cultivo_hidroponico.usuario.Id_Estado_Usuario = si_cultivo_hidroponico.estado.Id_Estado ";

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
                        UsuarioBE UsuarioBE = new UsuarioBE
                        {
                            Id_Usuario = int.Parse(Reader.GetString(0)),
                            Nombre_Usuario = Reader.GetString(1),
                            Apellido_Usuario = Reader.GetString(2),
                            Telefono_Usuario = Reader.GetString(3),
                            Correo_Usuario = Reader.GetString(4),
                            Rol_Usuario = Reader.GetString(5),
                            Estado_Usuario = Reader.GetString(6)
                        };

                        Usuarios.Add(UsuarioBE);

                    }
                }
            }
            catch (Exception ex){}
            finally
            {
                Conexion.Close();
            }

            return Usuarios
;        }

    }
}
