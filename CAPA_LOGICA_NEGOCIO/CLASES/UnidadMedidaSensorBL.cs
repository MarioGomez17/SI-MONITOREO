using CAPA_ACCESO_DATOS.CLASES;
using CAPA_ENTIDADES_NEGOCIO.CLASES;
using System.Collections.Generic;

namespace CAPA_LOGICA_NEGOCIO.CLASES
{
    public class UnidadMedidaSensorBL
    {

        public List<UnidadMedidaSensorBE> TraerUnidadesMedidaSensor()
        {
            UnidadMedidaSensorDA UnidadDA = new UnidadMedidaSensorDA();
            return UnidadDA.TraerUnidadesMedidaSensor();
        }

        public bool AgregarUnidadMedidaSensor(string UnidadMedida, string SimboloUnidad)
        {
            UnidadMedidaSensorDA UnidadMedidaSensorDA = new UnidadMedidaSensorDA();
            return UnidadMedidaSensorDA.AgregarUnidadMedidaSensor(UnidadMedida, SimboloUnidad);
        }
    }
}
