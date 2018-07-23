using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Logica.Interfaces;

namespace Logica
{
    public class FabricaLogica
    {
        public static ILogicaEmpleado getLogicaEmpleado()
        {
            return (LogicaEmpleado.getInstancia());
        }

        public static ILogicaCompania getLogicaCompania()
        {
            return (LogicaCompania.getInstancia());
        }

        public static ILogicaViaje getLogicaViaje()
        {
            return (LogicaViaje.getInstancia());
        }

        public static ILogicaTerminal getLogicaTerminal()
        {
            return (LogicaTerminal.getInstancia());
        }
    }
}
