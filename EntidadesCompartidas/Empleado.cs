using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Empleado
    {
        //ATRIBUTOS
        private int _cedula;
        private string _nombre;
        private string _contrasena;

        //PROPIEDADES
        public int Cedula
        {
            get { return _cedula; }
            set
            {   // check CI rango
                if (value > 10000000 && value < 99999999)
                    _cedula = value;
                else
                    throw new Exception("La cédula no es válida.");
            }
        }

        public string Nombre
        {
            get { return _nombre; }
            set
            {   // check Nombre menor a 50 caracteres
                if (value.Trim().Length > 50)
                    throw new Exception("El Nombre debe ser menor a 50 caracteres.");
                else
                    _nombre = value;
            }
        }

        public string Contrasena
        {
            get { return _contrasena; }
            set
            {   // check Contrasena 6 caracteres exacto
                if (value.Trim().Length != 6)
                    throw new Exception("La Contraseña debe tener 6 caracteres.");
                else
                    _contrasena = value;
            }
        }

        //CONSTRUCTOR
        public Empleado(int pCedula, string pNombre, string pContrasena)
        {
            Cedula = pCedula;
            Nombre = pNombre;
            Contrasena = pContrasena;
        }
    }
}
