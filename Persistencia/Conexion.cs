using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;

namespace Persistencia
{
    internal class Conexion
    {
        private static string _con = "Data Source=.; Initial Catalog =Terminal_uru; Integrated Security = true";
        
        public static string Con
        {
            get { return _con; }
        }
    }
}
