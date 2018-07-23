using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;

namespace Logica.Interfaces
{
    public interface ILogicaViaje
    {
        Viaje BuscarViaje(int pNumeroViaje);

        void AgregarViaje(Viaje unViaje);

        void ModificarViaje(Viaje unViaje);

        void EliminarViaje(Viaje unViaje);

        List<Viaje> ListarViajes();
    }
}
