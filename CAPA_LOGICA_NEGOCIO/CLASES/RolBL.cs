using CAPA_ACCESO_DATOS.CLASES;
using CAPA_ENTIDADES_NEGOCIO.CLASES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_LOGICA_NEGOCIO.CLASES
{
    public class RolBL
    {

        public List<RolBE> TraerRoles()
        {
            RolDA RolDA = new RolDA();
            return RolDA.TraerRoles();
        }
    }
}
