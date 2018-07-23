using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Logica.Interfaces;

using EntidadesCompartidas;
using Persistencia;
using Persistencia.Interfaces;

namespace Logica
{
    internal class LogicaEmpleado : ILogicaEmpleado
    {
        #region"Singleton"
        private static LogicaEmpleado _instancia = null;
        private LogicaEmpleado() {}
        
        public static LogicaEmpleado getInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaEmpleado();

            return _instancia;
        }        
        #endregion
        
        public Empleado LoginEmpleado(int pCedula, string pContrasena) 
        {
            return (FabricaPersistencia.getPersistenciaEmpleado().LoginEmpleado(pCedula, pContrasena));
        }

        public Empleado BuscarEmpleadoActivo(int pCiEmpleado)
        {
            return (FabricaPersistencia.getPersistenciaEmpleado().BuscarEmpleadoActivo(pCiEmpleado));
        }

        public void AgregarEmpleado(Empleado unEmpleado)
        {
            FabricaPersistencia.getPersistenciaEmpleado().AgregarEmpleado(unEmpleado);
        }

        public void ModificarEmpleado(Empleado unEmpleado)
        {
            FabricaPersistencia.getPersistenciaEmpleado().ModificarEmpleado(unEmpleado);
        }

        public void EliminarEmpleado(Empleado unEmpleado)
        {
            FabricaPersistencia.getPersistenciaEmpleado().EliminarEmpleado(unEmpleado);
        }
    }
}
