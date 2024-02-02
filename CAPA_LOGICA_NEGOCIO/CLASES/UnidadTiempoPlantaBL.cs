using CAPA_ACCESO_DATOS.CLASES;
using CAPA_ENTIDADES_NEGOCIO.CLASES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_LOGICA_NEGOCIO.CLASES
{
    public class UnidadTiempoPlantaBL
    {

        public List<UnidadTiempoPlantaBE> TraerUnidadesTiempoPlanta()
        {
            UnidadTiempoPlantaDA UTPDA = new UnidadTiempoPlantaDA();
            return UTPDA.TraerUnidadesTiempoPlanta();
        }

        public bool AgregarUnidadTiempoPlanta(string UnidadTiempo)
        {
            UnidadTiempoPlantaDA UnidadTiempoPlantaDA = new UnidadTiempoPlantaDA();
            return UnidadTiempoPlantaDA.AgregarUnidadTiempoPlanta(UnidadTiempo);
        }

    }
}
