using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;

namespace Persistencia.Interfaces
{
    public interface IPersistenciaCompania
    {
        Compania BuscarCompaniaActiva(string pCompania);

        void AgregarCompania(Compania unaCompania);

        void ModificarCompania(Compania unaCompania);

        void EliminarCompania(Compania unaCompania);
    }
}
