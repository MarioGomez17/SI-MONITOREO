using CAPA_ACCESO_DATOS.CLASES;
using CAPA_ENTIDADES_NEGOCIO.CLASES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_LOGICA_NEGOCIO.CLASES
{
    public class UnidadMedidaPlantaBL
    {

        public List<UnidadMedidaPlantaBE> TraerUnidadesMedidasPlanta()
        {
            UnidadMedidaPlantaDA UMPDA = new UnidadMedidaPlantaDA();
            return UMPDA.TraerUnidadesMedidasPlanta();
        }

        public bool AgregarUnidadMedidaPlanta(string UnidadMedida, string SimboloUnidad)
        {
            UnidadMedidaPlantaDA UnidadMedidaPlantaDA = new UnidadMedidaPlantaDA();
            return UnidadMedidaPlantaDA.AgregarUnidadMedidaPlanta(UnidadMedida, SimboloUnidad);
        }

    }
}
