using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Persistencia.Interfaces;

namespace Persistencia
{
    public class FabricaPersistencia
    {
        public static IPersistenciaEmpleado getPersistenciaEmpleado()
        {
            return (PersistenciaEmpleado.getInstancia());
        }

        public static IPersistenciaTerminal getPersistenciaTerminal()
        {
            return (PersistenciaTerminal.getInstancia());
        }

        public static IPersistenciaCompania getPersistenciaCompania()
        {
            return (PersistenciaCompania.getInstancia());
        }

        public static IPersistenciaInternacional getPersistenciaInternacional()
        {
            return (PersistenciaInternacional.getInstancia());
        }

        public static IPersistenciaNacional getPersistenciaNacional()
        {
            return (PersistenciaNacional.getInstancia());
        }
    }
}
