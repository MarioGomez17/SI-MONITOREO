using CAPA_ACCESO_DATOS.CLASES;
using CAPA_ENTIDADES_NEGOCIO.CLASES;
using System.Collections.Generic;

namespace CAPA_LOGICA_NEGOCIO.CLASES
{
    public class ReporteBL
    {

        public bool GuardarReporte(string TemperaturaSensor, string HumedadSensor, string ConductividadSesnor, int IdUsuario)
        {
            ReporteDA ReporteDA = new ReporteDA();
            return ReporteDA.GuardarReporte(TemperaturaSensor, HumedadSensor, ConductividadSesnor, IdUsuario);
        }

        public List<ReporteBE> GenerarReporte(int IdUsuario)
        {
            ReporteDA ReporteDA = new ReporteDA();
            return ReporteDA.GenerarReporte(IdUsuario);
        }

    }
}
