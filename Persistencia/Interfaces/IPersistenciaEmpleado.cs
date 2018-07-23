using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;

namespace Persistencia.Interfaces
{
    public interface IPersistenciaEmpleado
    {
        Empleado LoginEmpleado(int pCedula, string pContrasena);

        Empleado BuscarEmpleadoActivo(int pCedula);

        void AgregarEmpleado(Empleado unEmpleado);

        void ModificarEmpleado(Empleado unEmpleado);

        void EliminarEmpleado(Empleado unEmpelado);
    }
}
