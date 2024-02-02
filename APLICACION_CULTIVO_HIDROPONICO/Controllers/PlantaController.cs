using CAPA_ENTIDADES_NEGOCIO.CLASES;
using CAPA_LOGICA_NEGOCIO.CLASES;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using WS_Altura_Planta;

namespace APLICACION_CULTIVO_HIDROPONICO.Controllers
{
    [Authorize]
    public class PlantaController : Controller
    {
        private UsuarioBE DatosUsuarioSesion()
        {
            var Identity = HttpContext.User.Identity as ClaimsIdentity;
            var DatosUsuarioJson = Identity.FindFirst(ClaimTypes.UserData).Value;
            return JsonConvert.DeserializeObject<UsuarioBE>(DatosUsuarioJson);
        }

        public IActionResult VerPlantas()
        {
            PlantaBL PlantaBL = new();
            List<PlantaBE> ListaPlantas = PlantaBL.ObtenerPlantas(DatosUsuarioSesion().Id_Usuario);

            VariableBL VariableBL = new();
            List<VariableBE> Variables = VariableBL.TraerVariables();

            AmbienteBL AmbienteBL = new();
            List<AmbienteBE> AmbienteBE = AmbienteBL.VerAmbiente();

            PlantaBE_VariablesBE_AmbienteBE PV = new()
            {
                Plantas = ListaPlantas,
                Variables = Variables,
                Ambiente = AmbienteBE
            };

            return View(PV);
        }

        public IActionResult VerPlanta(int IdPlanta)
        {
            PlantaBL PlantaBL = new();
            PlantaBE PlantaBE = PlantaBL.ObtenerPlanta(IdPlanta);

            UnidadMedidaPlantaBL UMPBL = new();
            List<UnidadMedidaPlantaBE> UMPBE = UMPBL.TraerUnidadesMedidasPlanta();

            UnidadTiempoPlantaBL UTPBL = new();
            List<UnidadTiempoPlantaBE> UTPBE = UTPBL.TraerUnidadesTiempoPlanta();

            TipoPlantaBL TPPBL = new();
            List<TipoPlantaBE> TPBE = TPPBL.TraerTiposPlantas();

            AmbienteBL AmbienteBL = new();
            List<AmbienteBE> AmbienteBE = AmbienteBL.VerAmbiente();

            PlantaBE_TipoPlantaBE_UnidadMedidaPlantaBE_UnidadTiempoPlantaBE_AmbienteBE PTMT = new()
            {
                Planta = PlantaBE,
                UnidadesM = UMPBE,
                UnidadesT = UTPBE,
                Tipos = TPBE,
                AmbienteBE = AmbienteBE,
                RolUsuarioEnSesion = DatosUsuarioSesion().Rol_Usuario
            };
            return View(PTMT);
        }

        public IActionResult CambiarNombrePlanta(string NombrePlanta, int IdPlanta)
        {
            PlantaBL PlantaBL = new();
            PlantaBL.CambiarNombrePlanta(NombrePlanta, IdPlanta);
            VerPlanta(IdPlanta);
            return View("VerPlanta");
        }

        public IActionResult CambiarDiametroTalloPlanta(double DiametroTalloPlanta, int IdPlanta, int UnidadMedidaPlanta)
        {
            PlantaBL PlantaBL = new();
            PlantaBL.CambiarDiametroTalloPlanta(DiametroTalloPlanta, IdPlanta);
            PlantaBL.CambiarUnidadMedidaPlanta(UnidadMedidaPlanta, IdPlanta);

            VerPlanta(IdPlanta);
            return View("VerPlanta");
        }

        public IActionResult CambiarTiempoCultivoPlanta(double TiempoCultivoPlanta, int IdPlanta, int UnidadTiempoPlanta)
        {
            PlantaBL PlantaBL = new();
            PlantaBL.CambiarTiempoCultivoPlanta(TiempoCultivoPlanta, IdPlanta);
            PlantaBL.CambiarUnidadTiempoPlanta(UnidadTiempoPlanta, IdPlanta);
            VerPlanta(IdPlanta);
            return View("VerPlanta");
        }

        public IActionResult CambiarCantidadHojasPlanta(int CantidadHojasPlanta, int IdPlanta)
        {
            PlantaBL PlantaBL = new();
            PlantaBL.CambiarCantidadHojasPlanta(CantidadHojasPlanta, IdPlanta);
            VerPlanta(IdPlanta);
            return View("VerPlanta");
        }

        public IActionResult CambiarTipoPlanta(int TipoPlanta, int IdPlanta)
        {
            PlantaBL PlantaBL = new();
            PlantaBL.CambiarTipoPlanta(TipoPlanta, IdPlanta);
            VerPlanta(IdPlanta);
            return View("VerPlanta");
        }

        public IActionResult EliminarPlanta(int IdPlanta)
        {
            PlantaBL PlantaBL = new();
            PlantaBL.EliminarPlanta(IdPlanta);
            VerPlantas();
            return View("VerPlantas");
        }

        public IActionResult RegistarPlanta()
        {
            TipoPlantaBL TipoPlantaBL = new();
            UnidadMedidaPlantaBL UnidadMedidaPlantaBL = new();
            UnidadTiempoPlantaBL UnidadTiempoPlantaBL = new();
            TipoPlantaBE_UnidadMedidaPlantaBE_UnidadTiempoPlantaBE TPUMUT = new()
            {
                UnidadMedidaPlantaBE = UnidadMedidaPlantaBL.TraerUnidadesMedidasPlanta(),
                UnidadTiempoPlantaBE = UnidadTiempoPlantaBL.TraerUnidadesTiempoPlanta(),
                TipoPlantaBE = TipoPlantaBL.TraerTiposPlantas()
            };
            return View(TPUMUT);
        }

        public IActionResult CrearPlanta(string NombrePlanta, double DiametroTallo, double TiempoCultivo, int CantidadHojas, int TipoPlanta, int UnidadMeida, int UnidadTiempo)
        {
            PlantaBL PlantaBL = new();
            PlantaBL.RegistrarPlanta(NombrePlanta, DiametroTallo, TiempoCultivo, CantidadHojas, DatosUsuarioSesion().Id_Usuario, TipoPlanta, UnidadMeida, UnidadTiempo);
            VerPlantas();
            return View("VerPlantas");
        }

        public IActionResult CapturarAlturaPlanta(int IdPlanta)
        {
            double AlturaPlanta = 0;
            try
            {
                CapturarAlturaClient ClienteALturaPlanta = new();
                AlturaPlanta = ClienteALturaPlanta.AlturaValorClienteAsync().Result.@return;
                Console.WriteLine(AlturaPlanta);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            PlantaBL PlantaBL = new();
            PlantaBL.CambiarAlturaPlanta(IdPlanta, AlturaPlanta);
            VerPlanta(IdPlanta);
            return View("VerPlanta");
        }

        public IActionResult AgregarUnidadMedidaPlanta(string UnidadMedida, string SimboloUnidad, int IdPlanta)
        {
            UnidadMedidaPlantaBL UnidadMedidaPlantaBL = new();
            UnidadMedidaPlantaBL.AgregarUnidadMedidaPlanta(UnidadMedida, SimboloUnidad);
            VerPlanta(IdPlanta);
            return View("VerPlanta");
        }

        public IActionResult AgregarUnidadTiempoPlanta(string UnidadTiempo, int IdPlanta)
        {
            UnidadTiempoPlantaBL UnidadTiempoPlantaBL = new();
            UnidadTiempoPlantaBL.AgregarUnidadTiempoPlanta(UnidadTiempo);
            VerPlanta(IdPlanta);
            return View("VerPlanta");
        }
    }
}
