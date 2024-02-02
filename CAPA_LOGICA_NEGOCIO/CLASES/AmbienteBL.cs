using CAPA_ACCESO_DATOS.CLASES;
using CAPA_ENTIDADES_NEGOCIO.CLASES;
using System;
using System.Collections.Generic;

namespace CAPA_LOGICA_NEGOCIO.CLASES
{
    public class AmbienteBL
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public List<AmbienteBE> VerAmbiente()
        {
            Console.WriteLine("Hello World!");
            AmbienteDA AmbienteDA = new AmbienteDA();
            return AmbienteDA.VerAmbiente();
        }

        public void ActualizarVariablesAmbiente(string TemperaturaSensor, string HumedadSensor, string ConductividadSesnor, int IdUsuario)
        {
            AmbienteDA AmbienteDA = new AmbienteDA();
            ReporteBL ReporteBL = new ReporteBL();
            string[] Variables = AmbienteDA.ObtenerValoresActuales();
            string TemperaturaActual = Variables[0];
            string HumedadActual = Variables[1];
            string ConductividadActual = Variables[2];

            if ((TemperaturaSensor != TemperaturaActual) || (HumedadSensor != HumedadActual) || (ConductividadSesnor != ConductividadActual))
            {
                ReporteBL.GuardarReporte(TemperaturaSensor, HumedadSensor, ConductividadSesnor, IdUsuario);
                AmbienteDA.ActualizarVariablesAmbiente(TemperaturaSensor, HumedadSensor, ConductividadSesnor);
            }
        }
        
        public string[] ActualizarVariables(int IdUsuario)
        {
            SensorBL SensorBL = new SensorBL();
            SensorBL.CapturarVariables(IdUsuario);
            AmbienteDA AmbienteDA = new AmbienteDA();
            return AmbienteDA.ObtenerValoresActuales();
        }

    }
}
