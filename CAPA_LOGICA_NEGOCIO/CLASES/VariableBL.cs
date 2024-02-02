using CAPA_ACCESO_DATOS.CLASES;
using CAPA_ENTIDADES_NEGOCIO.CLASES;
using System.Collections.Generic;

namespace CAPA_LOGICA_NEGOCIO.CLASES
{
    public class VariableBL
    {

        public List<VariableBE> TraerVariables()
        {
            VariableDA VariableDA = new VariableDA();
            List<VariableBE> Variables = VariableDA.TraerVariables();
            return Variables;
        }

    }
}
