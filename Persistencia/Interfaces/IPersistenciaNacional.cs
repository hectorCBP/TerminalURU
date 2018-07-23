using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;

namespace Persistencia.Interfaces
{
    public interface IPersistenciaNacional
    {
        Nacional BuscarNacional(int pNumero);

        void AgregarNacional(Nacional unNacional);

        void ModificarNacional(Nacional unNacional);

        void EliminarNacional(Nacional unNacional);

        List<Nacional> ListadoNacionales();
    }
}
