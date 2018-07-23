using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public abstract class Viaje
    {
        //ATRIBUTOS
        private int _numeroViaje;
        private DateTime _FHSalida;
        private DateTime _FHLlegada;
        private int _asientos;
        private Empleado _empleado;
        private Terminal _terminal;
        private Compania _compania;

        //PROPIEDADES
        public int NumeroViaje
        {
            get { return _numeroViaje; }
            set
            {   // check NumeroViaje numero positivio
                if (value < 1)
                    throw new Exception("El Número de viaje debe ser positivo.");
                else
                    _numeroViaje = value; 
            }
        }

        public DateTime FHSalida
        {
            get { return _FHSalida; }
            set { _FHSalida = value; }            
        }

        public DateTime FHLlegada
        {
            get { return _FHLlegada; }
            set
            {   // check FHLlegada mayor a FHSalida
                if (value < FHSalida)
                    throw new Exception("La Fecha de llegada debe ser mayor a la de Salida.");
                else
                    _FHLlegada = value;
            }
        }

        public int Asientos
        {
            get { return _asientos; }
            set
            {   // check Asientos numero positivo
                if (value < 1)
                    throw new Exception("El viaje debe tener 1 o más asientos.");
                _asientos = value;
            }
        }

        public Empleado Empleado
        {
            get { return _empleado; }
            set
            {   // check Empleado null
                if (value != null)
                    _empleado = value;
                else
                    throw new Exception("El Empleado no puede ser vacío.");
            }
        }

        public Terminal Terminal
        {
            get { return _terminal; }
            set
            {   // check Terminal null
                if (value != null)
                    _terminal = value;
                else
                    throw new Exception("La Terminal no puede ser vacía.");
            }
        }

        public Compania Compania
        {
            get { return _compania; }
            set
            {   // check Terminal null
                if (value != null)
                    _compania = value;
                else
                    throw new Exception("La Compania no puede ser vacía.");
            }
        }

        //CONSTRUCTOR
        public Viaje(int pNumero, DateTime pFHSalida, DateTime pFHLlegada, int pAsientos, Empleado pEmpleado, Terminal pTerminal, Compania pCompania)
        {
            NumeroViaje = pNumero;
            FHSalida = pFHSalida;
            FHLlegada = pFHLlegada;
            Asientos = pAsientos;
            Empleado = pEmpleado;
            Terminal = pTerminal;
            Compania = pCompania;
        }
    }
}
