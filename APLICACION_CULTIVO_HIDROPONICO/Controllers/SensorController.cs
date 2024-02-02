using CAPA_ENTIDADES_NEGOCIO.CLASES;
using CAPA_LOGICA_NEGOCIO.CLASES;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace APLICACION_CULTIVO_HIDROPONICO.Controllers
{
    [Authorize]
    public class SensorController : Controller
    {
        private UsuarioBE DatosUsuarioSesion()
        {
            var Identity = HttpContext.User.Identity as ClaimsIdentity;
            var DatosUsuarioJson = Identity.FindFirst(ClaimTypes.UserData).Value;
            return JsonConvert.DeserializeObject<UsuarioBE>(DatosUsuarioJson);
        }

        public IActionResult VerSensores()
        {
            SensorBL SensorBL = new();
            List<SensorBE> ListaSensores = SensorBL.ObtenerSensores(DatosUsuarioSesion().Id_Usuario);
            return View(ListaSensores);
        }

        public IActionResult VerSensor(int IdSensor)
        {
            SensorBL SensorBL = new();
            SensorBE SensorBE = SensorBL.ObtenerSensor(IdSensor);
            VariableBL VariableBL = new();
            List< VariableBE > Variables = VariableBL.TraerVariables();
            UnidadMedidaSensorBL UnidadMedidaSensorBL = new();
            List<UnidadMedidaSensorBE> Unidades = UnidadMedidaSensorBL.TraerUnidadesMedidaSensor();
            SensorBE_VariableBE_UnidadMedidaSensorBE SensorVarialbe = new()
            {
                Variables = Variables,
                Sensor = SensorBE,
                Unidades = Unidades,
                RolUsuarioEnSesion = DatosUsuarioSesion().Rol_Usuario
            };
            return View(SensorVarialbe);
        }

        public IActionResult CambiarNombreSensor(string NombreSensor, int IdSensor)
        {
            SensorBL SensorBL = new();
            SensorBL.CambiarNombreSensor(NombreSensor, IdSensor);
            VerSensor(IdSensor);
            return View("VerSensor");
        }

        public IActionResult CambiarRangoInferiorSensor(string RangoInferior, int IdSensor)
        {
            SensorBL SensorBL = new();
            SensorBL.CambiarRangoInferiorSensor(RangoInferior, IdSensor);
            VerSensor(IdSensor);
            return View("VerSensor");
        }

        public IActionResult CambiarRangoSuperiorSensor(string RangoSuperior, int IdSensor)
        {
            SensorBL SensorBL = new();
            SensorBL.CambiarRangoSuperiorSensor(RangoSuperior, IdSensor);
            VerSensor(IdSensor);
            return View("VerSensor");
        }

        public IActionResult CambiarVariableSensor(int VariableSensor, int IdSensor, int UnidadesSensor)
        {
            SensorBL SensorBL = new();
            SensorBL.CambiarVariableSensor(VariableSensor, IdSensor);
            SensorBL.CambiarUnidadMedidaSensor(UnidadesSensor, VariableSensor);
            VerSensor(IdSensor);
            return View("VerSensor");
        }

        public IActionResult EliminarSensor(int IdSensor)
        {
            SensorBL SensorBL = new();
            SensorBL.EliminarSensor(IdSensor);
            VerSensores();
            return View("VerSensores");
        }

        public IActionResult AgregarUnidadMedidaSensor(string UnidadMedida, string SimboloUnidad, int IdSensor)
        {
            UnidadMedidaSensorBL UnidadMedidaSensorBL = new();
            UnidadMedidaSensorBL.AgregarUnidadMedidaSensor(UnidadMedida, SimboloUnidad);
            VerSensor(IdSensor);
            return View("VerSensor");
        }
    }
}
