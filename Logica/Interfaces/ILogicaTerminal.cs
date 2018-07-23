using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;

namespace Logica.Interfaces
{
    public interface ILogicaTerminal
    {
        Terminal BuscarTerminalActiva(string pCodigo);

        void AgregarTerminal(Terminal unaTerminal);

        void ModificarTerminal(Terminal unaTerminal);

        void EliminarTerminal(Terminal unaTerminal);
    }
}
