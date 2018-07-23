using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Internacional : Viaje
    {
        //ATRIBUTOS
        private bool _servicioABordo;
        private string _documentacion;

        //PROPIEDADES
        public bool ServicioABordo
        {
            get { return _servicioABordo; }
            set { _servicioABordo = value; }
        }

        public string Documentacion
        {
            get { return _documentacion; }
            set
            {   // check Documentacion menor a 140 caracteres
                if (value.Trim().Length > 140)
                    throw new Exception("La Documentación debe ser menor a 140 caracteres.");
                else
                    _documentacion = value;
            }
        }

        //CONSTRUCTOR
        public Internacional(int pNumero, DateTime pFHSalida, DateTime pFHLlegada, int pAsientos, Empleado pEmpleado, Terminal pTerminal, Compania pCompania, bool pServicioABordo, string pDocumentacion)
            : base(pNumero, pFHSalida, pFHLlegada, pAsientos, pEmpleado, pTerminal, pCompania)
        {
            NumeroViaje = pNumero;
            FHSalida = pFHSalida;
            FHLlegada = pFHLlegada;
            Asientos = pAsientos;
            Empleado = pEmpleado;
            Terminal = pTerminal;
            Compania = pCompania;
            ServicioABordo = pServicioABordo;
            Documentacion = pDocumentacion;
        }
    }
}
