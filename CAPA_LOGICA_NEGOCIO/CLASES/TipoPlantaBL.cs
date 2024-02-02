using CAPA_ACCESO_DATOS.CLASES;
using CAPA_ENTIDADES_NEGOCIO.CLASES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_LOGICA_NEGOCIO.CLASES
{
    public class TipoPlantaBL
    {

        public List<TipoPlantaBE> TraerTiposPlantas()
        {
            TipoPlantaDA TPDA = new TipoPlantaDA();
            return TPDA.TraerTiposlPanta();
        }

    }
}
