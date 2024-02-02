using System.Collections.Generic;

namespace CAPA_ENTIDADES_NEGOCIO.CLASES
{
    public class SensorBE_VariableBE_UnidadMedidaSensorBE
    {

        public SensorBE Sensor { get; set; }

        public List<VariableBE> Variables { get; set; }

        public List<UnidadMedidaSensorBE> Unidades { get; set; }

        public string RolUsuarioEnSesion { get; set; }
    }
}
