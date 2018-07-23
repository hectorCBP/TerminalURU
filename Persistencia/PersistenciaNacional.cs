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
    public class PersistenciaNacional : IPersistenciaNacional
    {
        #region"Singleton"
        private static PersistenciaNacional instancia = null;
        private PersistenciaNacional () {}
        public static PersistenciaNacional getInstancia()
        {
            if (instancia == null)
            {
                instancia = new PersistenciaNacional();
            }

            return instancia;
        }
        #endregion

        public Nacional BuscarNacional(int pNumeroViaje)
        {
            SqlDataReader dr;

            Nacional unNacional = null;

            Empleado unEmpelado = null;
            Terminal unaTerminal = null;
            Compania unaCompania = null;

            SqlConnection oConexion = new SqlConnection(Conexion.Con);
            SqlCommand comando = new SqlCommand("Sp_BuscarNacionales", oConexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@numeroViaje", pNumeroViaje);

            try
            {

                dr = comando.ExecuteReader();

                if(dr.HasRows)
                {
                    while (dr.Read())
                    {
                        unEmpelado = PersistenciaEmpleado.getInstancia().BuscarEmpleado(int.Parse(dr["CiEmpleado"].ToString()));

                        unaTerminal = PersistenciaTerminal.getInstancia().BuscarTerminal(dr["CodigoTerminal"].ToString());

                        unaCompania = PersistenciaCompania.getInstancia().BuscarCompania(dr["NombreCompania"].ToString());

                        unNacional = new Nacional(int.Parse(dr["NumeroViaje"].ToString()), DateTime.Parse(dr["FHSalida"].ToString()),
                            DateTime.Parse(dr["FHLlegada"].ToString()), int.Parse(dr["Asientos"].ToString()),
                            unEmpelado, unaTerminal, unaCompania, int.Parse(dr["ParadasIntermedias"].ToString()));
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
            return unNacional;
        }

        public void AgregarNacional(Nacional unNacional)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Con);
            SqlCommand comando = new SqlCommand("Sp_AltaNacional", oConexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@numeroViaje", unNacional.NumeroViaje);
            comando.Parameters.AddWithValue("@FHSalida", unNacional.FHSalida);
            comando.Parameters.AddWithValue("@FHLlegada", unNacional.FHLlegada);
            comando.Parameters.AddWithValue("@asientos", unNacional.Asientos);
            comando.Parameters.AddWithValue("@ciEmpleado", unNacional.Empleado.Cedula);
            comando.Parameters.AddWithValue("@codigoTerminal", unNacional.Terminal.CodigoTerminal);
            comando.Parameters.AddWithValue("@nombreCompania", unNacional.Compania.Nombre);
            comando.Parameters.AddWithValue("@paradasIntermedias", unNacional.ParadasIntermedias);


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
                    throw new Exception("No se pudo agregar el Viaje en Nacionales.");
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

        public void ModificarNacional(Nacional unNacional)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Con);
            SqlCommand comando = new SqlCommand("Sp_ModificarNacional", oConexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@numeroViaje", unNacional.NumeroViaje);
            comando.Parameters.AddWithValue("@FHSalida", unNacional.FHSalida);
            comando.Parameters.AddWithValue("@FHLlegada", unNacional.FHLlegada);
            comando.Parameters.AddWithValue("@asientos", unNacional.Asientos);
            comando.Parameters.AddWithValue("@ciEmpleado", unNacional.Empleado.Cedula);
            comando.Parameters.AddWithValue("@codigoTerminal", unNacional.Terminal.CodigoTerminal);
            comando.Parameters.AddWithValue("@nombreCompania", unNacional.Compania.Nombre);
            comando.Parameters.AddWithValue("@paradasIntermedias", unNacional.ParadasIntermedias);

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            comando.Parameters.Add(retorno);

            try
            {
                oConexion.Open();
                comando.ExecuteNonQuery();

                int r = (int)retorno.Value;

                if (r == -1)
                    throw new Exception("No se pudo encontrar el Viaje en Nacionales.");
                else if (r == -2)
                    throw new Exception("No se pudo modificar el Viaje en Nacionales.");
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

        public void EliminarNacional(Nacional unNacional)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Con);
            SqlCommand comando = new SqlCommand("Sp_EliminarNacional", oConexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@numeroViaje", unNacional.NumeroViaje);

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            comando.Parameters.Add(retorno);

            try
            {
                oConexion.Open();
                comando.ExecuteNonQuery();

                if ((int)retorno.Value == -1)
                    throw new Exception("No se pudo encontrar el Viaje en Nacionales.");
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

        public List<Nacional> ListadoNacionales()
        {
            Nacional unNacional = null;
            List<Nacional> listaNacionales = new List<Nacional>();

            SqlConnection oConexion = new SqlConnection(Conexion.Con);
            SqlCommand comando = new SqlCommand("Sp_ListarNacionales", oConexion);
            comando.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                SqlDataReader dr = comando.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        unNacional = new Nacional((int)dr["NumeroViaje"], (DateTime)dr["FHSalida"], (DateTime)dr["FHLlegada"],
                            (int)dr["Asientos"], PersistenciaEmpleado.getInstancia().BuscarEmpleado((int)dr["CiEmpleado"]),
                            PersistenciaTerminal.getInstancia().BuscarTerminal((string)dr["CodigoTerminal"]),
                            PersistenciaCompania.getInstancia().BuscarCompania((string)dr["NombreCompania"]), (int)dr["ParadasIntermedias"]);

                        listaNacionales.Add(unNacional);
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
            return listaNacionales;
        }
    }
}
