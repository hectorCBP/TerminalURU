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
    internal class LogicaTerminal : ILogicaTerminal
    {
        #region"Singleton"
        private static LogicaTerminal _instancia = null;
        private LogicaTerminal() {}

        public static LogicaTerminal getInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaTerminal();

            return _instancia;
        }        
        #endregion

        public Terminal BuscarTerminalActiva(string pCodigo)
        {
            return (FabricaPersistencia.getPersistenciaTerminal().BuscarTerminalActiva(pCodigo));
        }

        public void AgregarTerminal(Terminal unaTerminal)
        {
            FabricaPersistencia.getPersistenciaTerminal().AgregarTerminal(unaTerminal);
        }

        public void ModificarTerminal(Terminal unaTerminal)
        {
            FabricaPersistencia.getPersistenciaTerminal().ModificarTerminal(unaTerminal);
        }

        public void EliminarTerminal(Terminal unaTerminal)
        {
            FabricaPersistencia.getPersistenciaTerminal().EliminarTerminal(unaTerminal);
        }
    }
}
