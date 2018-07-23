using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;

namespace Logica.Interfaces
{
    public interface ILogicaEmpleado
    {
        Empleado LoginEmpleado(int pCedula, string pContrasena);

        Empleado BuscarEmpleadoActivo(int pCiEmpleado);

        void AgregarEmpleado(Empleado unEmpleado);

        void ModificarEmpleado(Empleado unEmpleado);

        void EliminarEmpleado(Empleado unEmpleado);
    }
}
