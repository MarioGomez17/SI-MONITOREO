namespace CAPA_ENTIDADES_NEGOCIO.CLASES
{
    public class SensorBE
    {

        public int Id_Sensor { get; set; }

        public string Nombre_Sensor { get; set; }

        public string Rango_Inferior_Sensor { get; set; }

        public string Rango_Superior_Sensor { get; set; }

        public int Id_Usuario_Sensor { get; set; }

        public string Estado_Sensor { get; set; }

        public string Variable_Sensor { get; set; }

        public string Unidad_Medida_Sensor { get; set; }

        public string Simbolo_Unidad_Medida_Sensor { get; set; }

    }
}
