using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Compania
    {
        //ATRIBUTOS
        private string _nombre;
        private string _direccion;
        private int _telefono;

        //PROPIEDADES
        public string Nombre
        {
            get { return _nombre; }
            set
            {
                // check NombreCompania menor a 50 caracteres
                if (value.Trim().Length > 50)
                    throw new Exception("El Nombre debe ser menor a 50 caracteres.");
                else
                    _nombre = value;
            }
        }

        public string Direccion
        {
            get { return _direccion; }
            set
            {   // check Direccion menor a 100 caracteres
                if (value.Trim().Length > 100)
                    throw new Exception("La Dirección debe ser menor a 100 caracteres.");
                else
                    _direccion = value;
            }
        }

        public int Telefono
        {
            get { return _telefono; }
            set
            {   // check Telefono rango
                if (value > 20000000 && value < 99999999) 
                    _telefono = value;
                else
                    throw new Exception("El teléfono debe tener 8 dígitos (2*******).");
            }
        }

        //CONSTRUCTOR
        public Compania(string pNombre, string pDireccion, int pTelefono)
        {
            Nombre = pNombre;
            Direccion = pDireccion;
            Telefono = pTelefono;
        }
    }
}
