using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Nacional : Viaje
    {
        //ATRIBUTOS
        private int _paradasIntermedias;

        //PROPIEDADES
        public int ParadasIntermedias
        {
            get { return _paradasIntermedias; }
            set
            {   // check ParadasIntermedias numero positivo
                if (value < 0)
                    throw new Exception("Las Paradas no pueden ser menor a cero.");
                else
                    _paradasIntermedias = value;
            }
        }

        //CONSTRUCTOR
        public Nacional(int pNumero, DateTime pFHSalida, DateTime pFHLlegada, int pAsientos, Empleado pEmpleado, Terminal pTerminal, Compania pCompania, int pParadasIntermedias)
            : base(pNumero, pFHSalida, pFHLlegada, pAsientos, pEmpleado, pTerminal, pCompania)
        {
            NumeroViaje = pNumero;
            FHSalida = pFHSalida;
            FHLlegada = pFHLlegada;
            Asientos = pAsientos;
            Empleado = pEmpleado;
            Terminal = pTerminal;
            Compania = pCompania;
            ParadasIntermedias = pParadasIntermedias;
        }
    }
}
