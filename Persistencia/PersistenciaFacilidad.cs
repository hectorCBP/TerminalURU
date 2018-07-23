using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia
{
    internal class PersistenciaFacilidad
    {
        internal static void AltaFacilidad(Facilidad unaFacilidad, string pCodigoTerminal, SqlTransaction _pTransaccion)
        {
            SqlCommand comando = new SqlCommand("Sp_AltaFacilidades", _pTransaccion.Connection);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@codigoTerminal", pCodigoTerminal);
            comando.Parameters.AddWithValue("@facilidad", unaFacilidad.FacilidadProp);
            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            comando.Parameters.Add(retorno);

            try
            {
                comando.Transaction = _pTransaccion;

                comando.ExecuteNonQuery();

                if ((int)retorno.Value == -1)
                    throw new Exception("La Facilidad ya existe.");
                else if ((int)retorno.Value == -2)
                    throw new Exception("La Terminal no existe o no está activa.");
                else if ((int)retorno.Value == -3)
                    throw new Exception("No se pudo agregar la Facilidad.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static List<Facilidad> ListarFacilidades(string pCodigoTerminal)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Con);
            SqlCommand comando = new SqlCommand("Sp_FacilidadesDeUnaTerminal", oConexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@codigoTerminal", pCodigoTerminal);

            List<Facilidad> listaFacilidades = null;

            try
            {
                oConexion.Open();
                SqlDataReader dr = comando.ExecuteReader();

                if (dr.HasRows)
                {
                    listaFacilidades = new List<Facilidad>();

                    while (dr.Read())
                    {
                        listaFacilidades.Add(new Facilidad(dr["Facilidad"].ToString()));
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
            return listaFacilidades;
        }

        internal static void EliminarFacilidades(Terminal unaTerminal, SqlTransaction _pTransaccion)
        {
            SqlCommand comando = new SqlCommand("Sp_EliminarFacilidadesDeUnaTerminal", _pTransaccion.Connection);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@codigoTerminal", unaTerminal.CodigoTerminal);
            
            try
            {
                comando.Transaction = _pTransaccion;

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
