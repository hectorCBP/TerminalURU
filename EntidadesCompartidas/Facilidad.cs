using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Facilidad
    {
        //ATRIBUTOS
        string _facilidad;


        //PROPIEDADES
        public string FacilidadProp
        {
            get { return _facilidad; }

            set
            {   // check Facilidad menor a 50 caracteres
                if (value.Trim().Length > 50)
                    throw new Exception("La facilidad debe tener menos de 50 caracteres.");

                _facilidad = value;
            }
        }

        //CONSTRUCTOR
        public Facilidad(string pFacilidad)
        {
            FacilidadProp = pFacilidad;
        }

        //OPERACIONES
        public override string ToString()
        {
            return FacilidadProp;
        }    
    }
}
