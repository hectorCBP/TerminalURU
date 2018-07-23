using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Terminal
    {
        //ATRIBUTOS
        private string _codigoTerminal;
        private string _ciudad;
        private string _pais;
        private List<Facilidad> _listaFacilidades;

        //PROPIEDADES
        public string CodigoTerminal
        {
            get { return _codigoTerminal; }
            set
            {   // check CodigoTerminal 3 caracteres exacto
                if (value.Trim().Length != 3)
                    throw new Exception("El Código debe tener 3 caracteres.");
                else
                    _codigoTerminal = value;
            }
        }

        public string Ciudad
        {
            get { return _ciudad; }
            set
            {   // check Ciudad menor a 50 caracteres
                if (value.Trim().Length > 50)
                    throw new Exception("La Ciudad debe ser menor a 50 caracteres.");
                else
                    _ciudad = value;
            }
        }

        public string Pais
        {
            get { return _pais; }
            set
            {
                // check Pais es del mercosur
                if (value.Trim().ToUpper() != "ARGENTINA" && value.Trim().ToUpper() != "BRASIL"
                    && value.Trim().ToUpper() != "PARAGUAY" && value.Trim().ToUpper() != "URUGUAY")
                {
                    throw new Exception("El País no es válido.");
                }

                else
                    _pais = value;
            }
        }

        public List<Facilidad> ListaFacilidades
        {
            get { return _listaFacilidades; }
            set
            {   // check listaFaciliadaes null
                if (value == null)
                    throw new Exception("No se agregaron facilidades a la Terminal.");
                else
                    _listaFacilidades = value;
            }
        }

        public Terminal(string pCodigo, string pCiudad, string pPais, List<Facilidad> pListaFacilidades)
        {
            CodigoTerminal = pCodigo;
            Ciudad = pCiudad;
            Pais = pPais;
            _listaFacilidades = pListaFacilidades;
        }

        //OPERACIONES
        public void AgregarFacilidad(string pUnaFacilidad)
        {
            _listaFacilidades.Add(new Facilidad(pUnaFacilidad));
        }

        public void EliminarTodasLasFacilidades()
        {
            _listaFacilidades.Clear();
        }
    }
}
