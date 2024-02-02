using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_ENTIDADES_NEGOCIO.CLASES
{
    public class PlantaBE_TipoPlantaBE_UnidadMedidaPlantaBE_UnidadTiempoPlantaBE_AmbienteBE
    {

        public PlantaBE Planta {  get; set; }

        public List<TipoPlantaBE> Tipos { get; set; }

        public List<UnidadMedidaPlantaBE> UnidadesM { get; set; }

        public List<UnidadTiempoPlantaBE> UnidadesT { get; set; }

        public List<AmbienteBE> AmbienteBE { get; set;}

        public string RolUsuarioEnSesion { get; set; }

    }
}
