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
    internal class LogicaCompania : ILogicaCompania
    {
        #region"Singleton"
        private static LogicaCompania _instancia = null;
        private LogicaCompania() {}

        public static LogicaCompania getInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaCompania();

            return _instancia;
        }        
        #endregion

        public Compania BuscarCompaniaActiva(string pNombreCompania)
        {
            return (FabricaPersistencia.getPersistenciaCompania().BuscarCompaniaActiva(pNombreCompania));
        }

        public void AgregarCompania(Compania unaCompania)
        {
            FabricaPersistencia.getPersistenciaCompania().AgregarCompania(unaCompania);
        }

        public void ModificarCompania(Compania unaCompania)
        {
            FabricaPersistencia.getPersistenciaCompania().ModificarCompania(unaCompania);
        }

        public void EliminarCompania(Compania unaCompania)
        {
            FabricaPersistencia.getPersistenciaCompania().EliminarCompania(unaCompania);
        }
    }
}
