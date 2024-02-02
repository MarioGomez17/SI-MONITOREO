using CAPA_ACCESO_DATOS.CLASES;
using CAPA_ENTIDADES_NEGOCIO.CLASES;
using System;
using System.Collections.Generic;

namespace CAPA_LOGICA_NEGOCIO.CLASES
{
    public class UsuarioBL
    {

        public bool RegistrarUsuario(string NombreUsuario, string ApellidoUsuario, string TelefonoUsuario, string CorreoUsuario, string ContrasenaUsuario)
        {
            UsuarioDA UsuarioDA = new UsuarioDA();
            if (UsuarioDA.ValidarUsuario(CorreoUsuario))
            {
                return UsuarioDA.RegistrarUsuario(NombreUsuario, ApellidoUsuario, TelefonoUsuario, CorreoUsuario, ContrasenaUsuario);
            }
            else
            {
                return false;
            }
        }

        public UsuarioBE TraerUsuario(string Correo, string Contrasena)
        {
            UsuarioDA UsuarioDA = new UsuarioDA();
            return UsuarioDA.TraerUsuario(Correo, Contrasena);
        }

        public UsuarioBE ObtenerUsuario(int IdUsuario)
        {
            UsuarioDA UsuarioDA = new UsuarioDA();
            return UsuarioDA.ObtenerUsuario(IdUsuario);
        }

        public bool CambiarNombreUsuario(string NombreUsuario, int IdUsuario)
        {
            UsuarioDA UsuarioDA = new UsuarioDA();
            return UsuarioDA.CambiarNombreUsuario(NombreUsuario, IdUsuario);
        }

        public bool CambiarApellidoUsuario(string ApeliidoUsuario, int IdUsuario)
        {
            UsuarioDA UsuarioDA = new UsuarioDA();
            return UsuarioDA.CambiarApellidoUsuario(ApeliidoUsuario, IdUsuario);
        }

        public bool CambiarTelefonoUsuario(string TelefonoUsuario, int IdUsuario)
        {
            UsuarioDA UsuarioDA = new UsuarioDA();
            return UsuarioDA.CambiarTelefonoUsuario(TelefonoUsuario, IdUsuario);
        }

        public bool CambiarContrasenaUsuario(string ContrasenaUsuario, int IdUsuario, string ContrasenaNuevaUsuario)
        {
            UsuarioDA UsuarioDA = new UsuarioDA();

            if (UsuarioDA.CompararContrasenasUsuario(ContrasenaUsuario, IdUsuario))
            {
                return UsuarioDA.CambiarContrasenaUsuario(ContrasenaNuevaUsuario, IdUsuario);
            }
            else
            {
                return false;
            }
        }

        public bool EliminarUsuario(int IdUsuario)
        {
            UsuarioDA UsuarioDA = new UsuarioDA();
            return UsuarioDA.EliminarUsuario(IdUsuario);
        }

        public bool CambiarRolUsuario(int IdUsuario, int IdRol)
        {
            UsuarioDA UsuarioDA = new UsuarioDA();
            return UsuarioDA.CambiarRolUsuario(IdUsuario, IdRol);
        }

        public List<UsuarioBE> ObtenerUsuarios()
        {
            UsuarioDA UsuarioDA = new UsuarioDA();
            return UsuarioDA.ObtenerUsuarios();

        }
    }
}
