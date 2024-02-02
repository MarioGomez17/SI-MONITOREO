using CAPA_ENTIDADES_NEGOCIO.CLASES;
using CAPA_LOGICA_NEGOCIO.CLASES;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace APLICACION_CULTIVO_HIDROPONICO.Controllers
{
    public class AmbienteController : Controller
    {

        private UsuarioBE DatosUsuarioSesion()
        {
            var Identity = HttpContext.User.Identity as ClaimsIdentity;
            if (Identity.FindFirst(ClaimTypes.UserData) != null)
            {
                var DatosUsuarioJson = Identity.FindFirst(ClaimTypes.UserData).Value;
                return JsonConvert.DeserializeObject<UsuarioBE>(DatosUsuarioJson);
            }
            else
            {
                return new UsuarioBE();
            }
        }

        public IActionResult PaginaInicio()
        {

            AmbienteBL AmbienteBL = new();
            List<AmbienteBE> AmbienteBE = AmbienteBL.VerAmbiente();
            return View(AmbienteBE);
        }

        public IActionResult Error()
        {
            return View();
        }

        public JsonResult ActualizarVariables()
        {
            AmbienteBL AmbienteBL = new();
            var Valores = Json(AmbienteBL.ActualizarVariables(DatosUsuarioSesion().Id_Usuario));
            return Valores;
        }

    }
}
