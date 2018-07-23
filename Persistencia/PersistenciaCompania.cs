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
    public class PersistenciaCompania : IPersistenciaCompania
    {
        #region"Singleton"
        private static PersistenciaCompania instancia = null;
        private PersistenciaCompania () {}
        public static PersistenciaCompania getInstancia()
        {
            if (instancia == null)
            {
                instancia = new PersistenciaCompania();
            }

            return instancia;
        }
        #endregion

        internal Compania BuscarCompania(string pNombreCompania)
        {
            SqlDataReader dr;

            Compania objCompania = null;

            SqlConnection oConexion = new SqlConnection(Conexion.Con);
            SqlCommand comando = new SqlCommand("Sp_BuscarCompania", oConexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombreCompania", pNombreCompania);

            try
            {
                oConexion.Open();
                dr = comando.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();

                    objCompania = new Compania(dr["NombreCompania"].ToString(), dr["Direccion"].ToString(),
                        int.Parse(dr["Telefono"].ToString()));
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
            return objCompania;
        }

        public Compania BuscarCompaniaActiva(string pNombreCompania)
        {
            SqlDataReader dr;

            Compania objCompania = null;

            SqlConnection oConexion = new SqlConnection(Conexion.Con);
            SqlCommand comando = new SqlCommand("Sp_BuscarCompaniaActiva", oConexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombreCompania", pNombreCompania);

            try
            {
                oConexion.Open();
                dr = comando.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();

                    objCompania = new Compania(dr["NombreCompania"].ToString(), dr["Direccion"].ToString(),
                        int.Parse(dr["Telefono"].ToString()));
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
            return objCompania;
        }

        public void AgregarCompania(Compania unaCompania)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Con);
            SqlCommand comando = new SqlCommand("Sp_AltaCompania", oConexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombreCompania", unaCompania.Nombre);
            comando.Parameters.AddWithValue("@direccion", unaCompania.Direccion);
            comando.Parameters.AddWithValue("@telefono", unaCompania.Telefono);

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            comando.Parameters.Add(retorno);

            try
            {
                oConexion.Open();
                comando.ExecuteNonQuery();

                if ((int)retorno.Value == -1)
                    throw new Exception("La Compania ya existe.");
                else if ((int)retorno.Value == -2)
                    throw new Exception("No se pudo agregar la Compania.");
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

        public void ModificarCompania(Compania unaCompania)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Con);
            SqlCommand comando = new SqlCommand("Sp_ModificarCompania", oConexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombreCompania", unaCompania.Nombre);
            comando.Parameters.AddWithValue("@direccion", unaCompania.Direccion);
            comando.Parameters.AddWithValue("@telefono", unaCompania.Telefono);

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            comando.Parameters.Add(retorno);

            try
            {
                oConexion.Open();
                comando.ExecuteNonQuery();

                if ((int)retorno.Value == -1)
                    throw new Exception("No se pudo modificar la Compania.");
                else if ((int)retorno.Value == -2)
                    throw new Exception("La Compania no existe o no se encuentra aciva.");
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

        public void EliminarCompania(Compania unaCompania)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Con);
            SqlCommand comando = new SqlCommand("Sp_EliminarCompania", oConexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombreCompania", unaCompania.Nombre);

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            comando.Parameters.Add(retorno);

            try
            {
                oConexion.Open();
                comando.ExecuteNonQuery();

                if ((int)retorno.Value == -1)
                    throw new Exception("La Compania no existe o no se encuentra activa.");
                else if ((int)retorno.Value == -2)
                    throw new Exception("No se pudo cambiar el estado de la Compania.");
                else if ((int)retorno.Value == -3)
                    throw new Exception("No se pudo eliminar la Compania.");
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
    }
}
