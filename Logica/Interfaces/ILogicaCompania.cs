using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;

namespace Logica.Interfaces
{
    public interface ILogicaCompania
    {
        Compania BuscarCompaniaActiva(string pNombreCompania);

        void AgregarCompania(Compania unaCompania);
        
        void ModificarCompania(Compania unaCompania);

        void EliminarCompania(Compania unaCompania);
    }
}
