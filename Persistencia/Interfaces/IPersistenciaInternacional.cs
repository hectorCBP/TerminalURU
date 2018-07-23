using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;

namespace Persistencia.Interfaces
{
    public interface IPersistenciaInternacional
    {
        Internacional BuscarInternacional(int pNumeroViaje);

        void AgregarInternacional(Internacional unInternacional);

        void ModificarInternacional(Internacional unInternacional);

        void EliminarInternacional(Internacional unInternacional);

        List<Internacional> ListadoInternacionales();
    }
}
