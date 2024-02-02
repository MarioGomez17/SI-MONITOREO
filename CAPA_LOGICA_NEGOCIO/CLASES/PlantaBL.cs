using CAPA_ACCESO_DATOS.CLASES;
using CAPA_ENTIDADES_NEGOCIO.CLASES;
using CAPA_LOGICA_NEGOCIO.WS_Altura_Planta;
using System;
using System.Collections.Generic;

namespace CAPA_LOGICA_NEGOCIO.CLASES
{
    public class PlantaBL
    {

        public List<PlantaBE> ObtenerPlantas(int IdUsuario)
        {
            PlantaDA PlantaDA = new PlantaDA();
            List<PlantaBE> Plantas = PlantaDA.ObtenerPlantas(IdUsuario);
            for (int i = 0; i < Plantas.Count; i++)
            {
                if (Plantas[i].Estado_Planta == "Eliminado")
                {
                    Plantas.RemoveAt(i);
                }
            }
            return Plantas;
        }

        public PlantaBE ObtenerPlanta(int IdPlanta)
        {
            PlantaDA PlantaDA = new PlantaDA();
            return PlantaDA.ObtenerPlanta(IdPlanta);
        }

        public bool CambiarNombrePlanta(string NombrePlanta, int IdPlanta)
        {
            PlantaDA PlantaDA = new PlantaDA();
            return PlantaDA.CambiarNombrePlanta(NombrePlanta, IdPlanta);
        }

        public bool CambiarDiametroTalloPlanta(double DiametroTallo, int IdPlanta)
        {
            PlantaDA PlantaDA = new PlantaDA();
            return PlantaDA.CambiarDiametroTalloPlanta(DiametroTallo, IdPlanta);
        }

        public bool CambiarTiempoCultivoPlanta(double TiempoCultivo, int IdPlanta)
        {
            PlantaDA PlantaDA = new PlantaDA();
            return PlantaDA.CambiarTiempoCultivoPlanta(TiempoCultivo, IdPlanta);
        }

        public bool CambiarCantidadHojasPlanta(int CanitdadHojas, int IdPlanta)
        {
            PlantaDA PlantaDA = new PlantaDA();
            return PlantaDA.CambiarCantidadHojasPlanta(CanitdadHojas, IdPlanta);
        }

        public bool CambiarTipoPlanta(int TipoPlanta, int IdPlanta)
        {
            PlantaDA PlantaDA = new PlantaDA();
            return PlantaDA.CambiarTipoPlanta(TipoPlanta, IdPlanta);
        }

        public bool CambiarUnidadMedidaPlanta(int UnidadMedidaPlanta, int IdPlanta)
        {
            PlantaDA PlantaDA = new PlantaDA();
            return PlantaDA.CambiarUnidadMedidaPlanta(UnidadMedidaPlanta, IdPlanta);
        }

        public bool CambiarUnidadTiempoPlanta(int UnidadTiempoPlanta, int IdPlanta)
        {
            PlantaDA PlantaDA = new PlantaDA();
            return PlantaDA.CambiarUnidadTiempoPlanta(UnidadTiempoPlanta, IdPlanta);
        }

        public bool EliminarPlanta(int IdPlanta)
        {
            PlantaDA PlantaDA = new PlantaDA();
            return PlantaDA.EliminarPlanta(IdPlanta);
        }

        public bool RegistrarPlanta(string NombrePlanta, double DiametroTallo, double TiempoCultivo, int CantidadHojas, int IdUsuario, int TipoPlanta, int UnidadMeida, int UnidadTiempo)
        {
            PlantaDA PlantaDA = new PlantaDA();
            if (PlantaDA.ValidarPlanta(NombrePlanta))
            {
                return PlantaDA.RegistrarPlanta(NombrePlanta, DiametroTallo, TiempoCultivo, CantidadHojas, IdUsuario, TipoPlanta, UnidadMeida, UnidadTiempo);
            }
            else
            {
                return false;
            }
        }

        public bool CambiarAlturaPlanta(int IdPlanta, double AlturaPlanta)
        {
            PlantaDA PlantaDA = new PlantaDA();
            return PlantaDA.CambiarAlturaPlanta(AlturaPlanta, IdPlanta);
        }

    }
}
