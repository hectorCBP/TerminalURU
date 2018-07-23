using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using System.Data;
using System.Data.SqlClient;

using Persistencia.Interfaces;

namespace Persistencia
{
    public class PersistenciaInternacional : IPersistenciaInternacional
    {
        #region"Singleton"
        private static PersistenciaInternacional instancia = null;
        private PersistenciaInternacional () {}
        public static PersistenciaInternacional getInstancia()
        {
            if (instancia == null)
            {
                instancia = new PersistenciaInternacional();
            }

            return instancia;
        }
        #endregion

        public Internacional BuscarInternacional(int pNumeroViaje)
        {
            SqlDataReader dr;

            Internacional unInternacional = null;

            Empleado unEmpelado = null;
            Terminal unaTerminal = null;
            Compania unaCompania = null;

            SqlConnection oConexion = new SqlConnection(Conexion.Con);
            SqlCommand comando = new SqlCommand("Sp_BuscarInternacionales", oConexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@numeroViaje", pNumeroViaje);

            try
            {

                dr = comando.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        unEmpelado = PersistenciaEmpleado.getInstancia().BuscarEmpleado(int.Parse(dr["CiEmpleado"].ToString()));

                        unaTerminal = PersistenciaTerminal.getInstancia().BuscarTerminal(dr["CodigoTerminal"].ToString());

                        unaCompania = PersistenciaCompania.getInstancia().BuscarCompania(dr["NombreCompania"].ToString());

                        unInternacional = new Internacional(int.Parse(dr["NumeroViaje"].ToString()), DateTime.Parse(dr["FHSalida"].ToString()),
                            DateTime.Parse(dr["FHLlegada"].ToString()), int.Parse(dr["Asientos"].ToString()),
                            unEmpelado, unaTerminal, unaCompania, bool.Parse(dr["ServicioABordo"].ToString()),
                            dr["Documentacion"].ToString());
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return unInternacional;
        }

        public void AgregarInternacional(Internacional unInternacional)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Con);
            SqlCommand comando = new SqlCommand("Sp_AltaInternacionales", oConexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@numeroViaje", unInternacional.NumeroViaje);
            comando.Parameters.AddWithValue("@FHSalida", unInternacional.FHSalida);
            comando.Parameters.AddWithValue("@FHLlegada", unInternacional.FHLlegada);
            comando.Parameters.AddWithValue("@asientos", unInternacional.Asientos);
            comando.Parameters.AddWithValue("@ciEmpleado", unInternacional.Empleado.Cedula);
            comando.Parameters.AddWithValue("@codigoTerminal", unInternacional.Terminal.CodigoTerminal);
            comando.Parameters.AddWithValue("@nombreCompania", unInternacional.Compania.Nombre);
            comando.Parameters.AddWithValue("@servicioABordo", unInternacional.ServicioABordo);
            comando.Parameters.AddWithValue("@documentacion", unInternacional.Documentacion);


            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            comando.Parameters.Add(retorno);

            try
            {
                oConexion.Open();
                comando.ExecuteNonQuery();

                int r = (int)retorno.Value;

                if (r == -1)
                    throw new Exception("El Viaje ya existe.");
                else if (r == -2)
                    throw new Exception("La Terminal no existe.");
                else if (r == -3)
                    throw new Exception("La Compania no existe.");
                else if (r == -4)
                    throw new Exception("El Empleado no existe.");
                else if (r == -5)
                    throw new Exception("No se puedo agregar el Viaje.");
                else if (r == -6)
                    throw new Exception("No se pudo agregar el Viaje en Internacionales.");
                else if (r == -7)
                    throw new Exception("No se pudo agregar el Viaje, falló la transacción.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
        }

        public void ModificarInternacional(Internacional unInternacional)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Con);
            SqlCommand comando = new SqlCommand("Sp_ModificarInternacionales", oConexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@numeroViaje", unInternacional.NumeroViaje);
            comando.Parameters.AddWithValue("@FHSalida", unInternacional.FHSalida);
            comando.Parameters.AddWithValue("@FHLlegada", unInternacional.FHLlegada);
            comando.Parameters.AddWithValue("@asientos", unInternacional.Asientos);
            comando.Parameters.AddWithValue("@ciEmpleado", unInternacional.Empleado.Cedula);
            comando.Parameters.AddWithValue("@codigoTerminal", unInternacional.Terminal.CodigoTerminal);
            comando.Parameters.AddWithValue("@nombreCompania", unInternacional.Compania.Nombre);
            comando.Parameters.AddWithValue("@servicioABordo", unInternacional.ServicioABordo);
            comando.Parameters.AddWithValue("@documentacion", unInternacional.Documentacion);

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            comando.Parameters.Add(retorno);

            try
            {
                oConexion.Open();
                comando.ExecuteNonQuery();

                int r = (int)retorno.Value;

                if (r == -1)
                    throw new Exception("No se pudo encontrar el Viaje en Internacionales.");
                else if (r == -2)
                    throw new Exception("No se pudo modificar el Viaje en Internacionales.");
                else if (r == -3)
                    throw new Exception("No se pudo modificar el Viaje.");
                else if (r == -4)
                    throw new Exception("No se pudo modificar el Viaje, falló la transacción.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
        }

        public void EliminarInternacional(Internacional unInternacional)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Con);
            SqlCommand comando = new SqlCommand("Sp_EliminarInternacionales", oConexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@numeroViaje", unInternacional.NumeroViaje);

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            comando.Parameters.Add(retorno);

            try
            {
                oConexion.Open();
                comando.ExecuteNonQuery();

                if ((int)retorno.Value == -1)
                    throw new Exception("No se pudo encontrar el Viaje en Internacionales.");
                else if ((int)retorno.Value == -2)
                    throw new Exception("No se pudo eliminar el Viaje.");
                else if ((int)retorno.Value == -3)
                    throw new Exception("No se pudo eliminar el Viaje, falló la transacción.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
        }

        public List<Internacional> ListadoInternacionales()
        {
            Internacional unInternacional = null;
            List<Internacional> listaInternacionales = new List<Internacional>();

            SqlConnection oConexion = new SqlConnection(Conexion.Con);
            SqlCommand comando = new SqlCommand("Sp_ListarInternacionales", oConexion);
            comando.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                SqlDataReader dr = comando.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        unInternacional = new Internacional((int)dr["NumeroViaje"], (DateTime)dr["FHSalida"], (DateTime)dr["FHLlegada"],
                            (int)dr["Asientos"], PersistenciaEmpleado.getInstancia().BuscarEmpleado((int)dr["CiEmpleado"]),
                            PersistenciaTerminal.getInstancia().BuscarTerminal((string)dr["CodigoTerminal"]), 
                            PersistenciaCompania.getInstancia().BuscarCompania((string)dr["NombreCompania"]), (bool)dr["ServicioABordo"],
                            (string)dr["Documentacion"]);

                        listaInternacionales.Add(unInternacional);
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
            return listaInternacionales;
        }
    }
}
