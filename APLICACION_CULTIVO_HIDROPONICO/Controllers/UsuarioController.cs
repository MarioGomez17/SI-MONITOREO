using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using CAPA_LOGICA_NEGOCIO.CLASES;
using CAPA_ENTIDADES_NEGOCIO.CLASES;
using Newtonsoft.Json;

namespace APLICACION_CULTIVO_HIDROPONICO.Controllers
{
    public class UsuarioController : Controller
    {

        private UsuarioBE DatosUsuarioSesion()
        {
            var Identity = HttpContext.User.Identity as ClaimsIdentity;
            var DatosUsuarioJson = Identity.FindFirst(ClaimTypes.UserData).Value;
            return JsonConvert.DeserializeObject<UsuarioBE>(DatosUsuarioJson);
        }

        public IActionResult IniciarSesion()
        {
            ClaimsPrincipal CP = HttpContext.User;
            if (CP != null)
            {
                if (CP.Identity.IsAuthenticated)
                {
                    return RedirectToAction("PaginaInicio", "Ambiente");
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Ingresar(string Correo, string Contrasena)
        {

            try
            {
                UsuarioBL UsuarioBL = new();
                UsuarioBE UsuarioBE = UsuarioBL.TraerUsuario(Correo, Contrasena);

                if (UsuarioBE != null && UsuarioBE.Estado_Usuario == "Activo")
                {
                    List<Claim> LC = new()
                    {
                        new Claim(ClaimTypes.NameIdentifier, UsuarioBE.Correo_Usuario)
                    };
                    ClaimsIdentity CI = new(LC, CookieAuthenticationDefaults.AuthenticationScheme);
                    Claim DatosUsuario = new(ClaimTypes.UserData, JsonConvert.SerializeObject(UsuarioBE));
                    CI.AddClaim(DatosUsuario);
                    AuthenticationProperties AP = new()
                    {
                        AllowRefresh = true,

                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(CI), AP);
                    return RedirectToAction("PaginaInicio", "Ambiente");
                }
                else
                {
                    return View("IniciarSesion");
                }
            }
            catch (System.Exception)
            {
                return View("IniciarSesion");
            }

        }

        public IActionResult RegistrarUsuario()
        {
            return View();
        }

        public IActionResult Registrar(string NombreUsuario, string ApellidoUsuario, string TelefonoUsuario, string CorreoUsuario, string ContrasenaUsuario)
        {
            UsuarioBL UsuarioBL = new();
            UsuarioBL.RegistrarUsuario(NombreUsuario, ApellidoUsuario, TelefonoUsuario, CorreoUsuario, ContrasenaUsuario);
            return View("IniciarSesion");
        }

        [Authorize]
        public async Task<IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View("IniciarSesion");
        }

        [Authorize]
        public IActionResult VerUsuario()
        {
            UsuarioBL UsuarioBL = new();
            UsuarioBE UsuarioBE = UsuarioBL.ObtenerUsuario(DatosUsuarioSesion().Id_Usuario);
            return View(UsuarioBE);
        }

        public IActionResult CambiarNombreUsuario(int IdUsuario, string NombreUsuario)
        {
            UsuarioBL UsuarioBL = new();
            UsuarioBL.CambiarNombreUsuario(NombreUsuario, IdUsuario);
            if (IdUsuario != DatosUsuarioSesion().Id_Usuario)
            {
                VerUsuarios();
                return View("VerUsuarios");
            }
            else
            {
                VerUsuario();
                return View("VerUsuario");
            }
        }

        public IActionResult CambiarApellidoUsuario(int IdUsuario, string ApellidoUsuario)
        {
            UsuarioBL UsuarioBL = new();
            UsuarioBL.CambiarApellidoUsuario(ApellidoUsuario, IdUsuario);
            if (IdUsuario != DatosUsuarioSesion().Id_Usuario)
            {
                VerUsuarios();
                return View("VerUsuarios");
            }
            else
            {
                VerUsuario();
                return View("VerUsuario");
            }
        }

        public IActionResult CambiarTelefonoUsuario(int IdUsuario, string TelefonoUsuario)
        {
            UsuarioBL UsuarioBL = new();
            UsuarioBL.CambiarTelefonoUsuario(TelefonoUsuario, IdUsuario);
            if (IdUsuario != DatosUsuarioSesion().Id_Usuario)
            {
                VerUsuarios();
                return View("VerUsuarios");
            }
            else
            {
                VerUsuario();
                return View("VerUsuario");
            }
        }

        public IActionResult CambiarContrasenaUsuario(string ContrasenaUsuario, string ContrasenaNuevaUsuario)
        {
            UsuarioBL UsuarioBL = new();
            UsuarioBL.CambiarContrasenaUsuario(ContrasenaUsuario, DatosUsuarioSesion().Id_Usuario, ContrasenaNuevaUsuario);
            VerUsuario();
            return View("VerUsuario");
        }

        public async Task<IActionResult> EliminarUsuario(int IdUsuario)
        {
            UsuarioBL UsuarioBL = new();
            UsuarioBL.EliminarUsuario(IdUsuario);
            await CerrarSesion();
            if (IdUsuario != DatosUsuarioSesion().Id_Usuario)
            {
                VerUsuarios();
                return View("VerUsuarios");
            }
            else
            {
                return View("IniciarSesion");
            }
        }

        public IActionResult VerUsuarios()
        {
            UsuarioBL UsuarioBL = new();
            List<UsuarioBE> Usuarios = UsuarioBL.ObtenerUsuarios();
            RolBL RolBL = new();
            List<RolBE> Roles = RolBL.TraerRoles();

            UsuarioBE_RolBE UR = new()
            {
                Usuarios = Usuarios,
                Roles = Roles
            };

            return View(UR);
        }

        public IActionResult CambiarRolUsuario(int IdUsuario, int IdRol)
        {
            UsuarioBL UsuarioBL = new();
            UsuarioBL.CambiarRolUsuario(IdUsuario, IdRol);
            VerUsuarios();
            return View("VerUsuarios");
        }

        public IActionResult GenerarReporte()
        {
            ReporteBL ReporteBL = new();
            List<ReporteBE> Reportes = ReporteBL.GenerarReporte(DatosUsuarioSesion().Id_Usuario);

            AmbienteBL AmbienteBL = new();
            List<AmbienteBE> AmbienteBE = AmbienteBL.VerAmbiente();

            ReporteBE_AmbienteBE ReporteBE_AmbienteBE = new()
            {
                Ambiente = AmbienteBE,
                Reportes = Reportes
            };

            return View(ReporteBE_AmbienteBE);
        }

    }
}
