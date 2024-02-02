using CAPA_ACCESO_DATOS.CLASES;
using CAPA_ENTIDADES_NEGOCIO.CLASES;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;

namespace CAPA_LOGICA_NEGOCIO.CLASES
{
    public class SensorBL
    {        
        public List<SensorBE> ObtenerSensores(int IdUsuario)
        {
            SensorDA SensorDA = new SensorDA();
            List<SensorBE> Sesnores = SensorDA.ObtenerSensores(IdUsuario);
            for (int i = 0; i < Sesnores.Count; i++)
            {
                if (Sesnores[i].Estado_Sensor == "Eliminado")
                {
                    Sesnores.RemoveAt(i);
                }
            }
            return Sesnores;
        }

        public SensorBE ObtenerSensor(int IdSensor)
        {
            SensorDA SensorDA = new SensorDA();
            return SensorDA.ObtenerSensor(IdSensor);
        }

        public bool CambiarNombreSensor(string NombreSensor, int IdSensor)
        {
            SensorDA SensorDA = new SensorDA();
            return SensorDA.CambiarNombreSensor(NombreSensor, IdSensor);
        }

        public bool CambiarRangoInferiorSensor(string RangoInferior, int IdSensor)
        {
            SensorDA SensorDA = new SensorDA();
            return SensorDA.CambiarRangoInferiorSensor(RangoInferior, IdSensor);
        }

        public bool CambiarRangoSuperiorSensor(string RangoSuperior, int IdSensor)
        {
            SensorDA SensorDA = new SensorDA();
            return SensorDA.CambiarRangoSuperiorSensor(RangoSuperior, IdSensor);
        }

        public bool CambiarVariableSensor(int IdVariable, int IdSensor)
        {
            SensorDA SensorDA = new SensorDA();
            return SensorDA.CambiarVariableSensor(IdVariable, IdSensor);
        }

        public bool CambiarUnidadMedidaSensor(int UnidadMedida, int IdVariable)
        {
            SensorDA SensorDA = new SensorDA();
            return SensorDA.CambiarUnidadMedidaSensor(UnidadMedida, IdVariable);
        }

        public bool EliminarSensor(int IdSensor)
        {
            SensorDA SensorDA = new SensorDA();
            return SensorDA.EliminarSensor(IdSensor);
        }

        public void CapturarVariables(int IdUsuario)
        {
            AmbienteBL AmbienteBL = new AmbienteBL();
            SerialPort puertoArduino = new SerialPort
            {
                PortName = "COM8",
                BaudRate = 9600,
                ReadTimeout = 1000
            };
            try
            {
                puertoArduino.Open();
                String cadena = puertoArduino.ReadLine();
                string[] datos = cadena.Split(',');
                string TemperaturaSensor = datos[0];
                string HumedadSensor = datos[1];
                string Conductividad = datos[2];
                AmbienteBL.ActualizarVariablesAmbiente(TemperaturaSensor, HumedadSensor, Conductividad, IdUsuario);
            }
            catch (Exception)
            {
            }
            finally
            {
                puertoArduino.Close();
            }
        }
    }
}
