using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Logica.Interfaces;

using EntidadesCompartidas;
using Persistencia;
using Persistencia.Interfaces;

namespace Logica
{
    internal class LogicaViaje : ILogicaViaje
    {
        #region"Singleton"
        private static LogicaViaje _instancia = null;
        private LogicaViaje() {}

        public static LogicaViaje getInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaViaje();

            return _instancia;
        }        
        #endregion

        public Viaje BuscarViaje(int pNumeroViaje)
        {
            Viaje unViaje = null;

            unViaje = (Viaje)PersistenciaNacional.getInstancia().BuscarNacional(pNumeroViaje);

            if (unViaje == null)
            {
                unViaje = (Viaje)PersistenciaInternacional.getInstancia().BuscarInternacional(pNumeroViaje);
            }

            return unViaje;
        }

        public void AgregarViaje(Viaje unViaje)
        {
            if (unViaje is Nacional)
            {
                FabricaPersistencia.getPersistenciaNacional().AgregarNacional((Nacional)unViaje);
            }
            else
            {
                FabricaPersistencia.getPersistenciaInternacional().AgregarInternacional((Internacional)unViaje);
            }
        }

        public void ModificarViaje(Viaje unViaje)
        {
            if (unViaje is Nacional)
            {
                FabricaPersistencia.getPersistenciaNacional().ModificarNacional((Nacional)unViaje);
            }
            else
            {
                FabricaPersistencia.getPersistenciaInternacional().ModificarInternacional((Internacional)unViaje);
            }
        }

        public void EliminarViaje(Viaje unViaje)
        {
            if (unViaje is Nacional)
            {
                FabricaPersistencia.getPersistenciaNacional().EliminarNacional((Nacional)unViaje);
            }
            else
            {
                FabricaPersistencia.getPersistenciaInternacional().EliminarInternacional((Internacional)unViaje);
            }
        }

        public List<Viaje> ListarViajes()
        {
            List<Viaje> listaViajes = new List<Viaje>();
            listaViajes.AddRange(FabricaPersistencia.getPersistenciaNacional().ListadoNacionales());
            listaViajes.AddRange(FabricaPersistencia.getPersistenciaInternacional().ListadoInternacionales());
            
            return listaViajes;
        }
    }
}
