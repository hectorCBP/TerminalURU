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
    public class PersistenciaTerminal : IPersistenciaTerminal
    {
        #region"Singleton"
        private static PersistenciaTerminal instancia = null;
        private PersistenciaTerminal() { }
        public static PersistenciaTerminal getInstancia()
        {
            if (instancia == null)
            {
                instancia = new PersistenciaTerminal();
            }

            return instancia;
        }
        #endregion

        internal Terminal BuscarTerminal(string pCodigoTerminal)
        {
            SqlDataReader dr;

            Terminal objTerminal = null;

            SqlConnection oConexion = new SqlConnection(Conexion.Con);
            SqlCommand comando = new SqlCommand("Sp_BuscarTerminal", oConexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@codigoTerminal", pCodigoTerminal);

            try
            {
                oConexion.Open();
                dr = comando.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();

                    objTerminal = new Terminal(dr["CodigoTerminal"].ToString(), dr["Ciudad"].ToString(),
                        dr["Pais"].ToString(), PersistenciaFacilidad.ListarFacilidades(dr["CodigoTerminal"].ToString()));
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
            return objTerminal;
        }

        public Terminal BuscarTerminalActiva(string pCodigoTerminal)
        {
            SqlDataReader dr;

            Terminal objTerminal = null;

            SqlConnection oConexion = new SqlConnection(Conexion.Con);
            SqlCommand comando = new SqlCommand("Sp_BuscarTerminalActiva", oConexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@codigoTerminal", pCodigoTerminal);

            try
            {
                oConexion.Open();
                dr = comando.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();

                    objTerminal = new Terminal(dr["CodigoTerminal"].ToString(), dr["Ciudad"].ToString(),
                        dr["Pais"].ToString(), PersistenciaFacilidad.ListarFacilidades(dr["CodigoTerminal"].ToString()));
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
            return objTerminal;
        }

        public void AgregarTerminal(Terminal unaTerminal)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Con);

            SqlCommand comando = new SqlCommand("Sp_AltaTerminal", oConexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@codigoTerminal", unaTerminal.CodigoTerminal);
            comando.Parameters.AddWithValue("@ciudad", unaTerminal.Ciudad);
            comando.Parameters.AddWithValue("@pais", unaTerminal.Pais);

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            comando.Parameters.Add(retorno);

            SqlTransaction _miTransaccion = null;

            try
            {
                oConexion.Open();

                _miTransaccion = oConexion.BeginTransaction();

                comando.Transaction = _miTransaccion;
                comando.ExecuteNonQuery();

                if ((int)retorno.Value == -1)
                    throw new Exception("La Terminal ya existe.");
                else if ((int)retorno.Value == -2)
                    throw new Exception("No se pudo agregar la Terminal.");

                foreach (Facilidad unaFacilidad in unaTerminal.ListaFacilidades)
                    PersistenciaFacilidad.AltaFacilidad(unaFacilidad, unaTerminal.CodigoTerminal, _miTransaccion);

                _miTransaccion.Commit();
            }
            catch (Exception ex)
            {
                _miTransaccion.Rollback();
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
        }

        public void ModificarTerminal(Terminal unaTerminal)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Con);
            SqlCommand comando = new SqlCommand("Sp_ModificarTerminal", oConexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@codigoTerminal", unaTerminal.CodigoTerminal);
            comando.Parameters.AddWithValue("@ciudad", unaTerminal.Ciudad);
            comando.Parameters.AddWithValue("@pais", unaTerminal.Pais);

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            comando.Parameters.Add(retorno);

            SqlTransaction _miTransaccion = null;

            try
            {
                oConexion.Open();

                _miTransaccion = oConexion.BeginTransaction();

                comando.Transaction = _miTransaccion;
                comando.ExecuteNonQuery();

                if ((int)retorno.Value == -1)
                    throw new Exception("No se pudo modificar la Terminal.");
                else if ((int)retorno.Value == -2)
                    throw new Exception("La Terminal no existe o no se encuentra activa.");


                PersistenciaFacilidad.EliminarFacilidades(unaTerminal, _miTransaccion);

                foreach (Facilidad unaFacilidad in unaTerminal.ListaFacilidades)
                {
                    PersistenciaFacilidad.AltaFacilidad(unaFacilidad, unaTerminal.CodigoTerminal, _miTransaccion);
                }

                _miTransaccion.Commit();
            }
            catch (Exception ex)
            {
                _miTransaccion.Rollback();
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
        }

        public void EliminarTerminal(Terminal unaTerminal)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Con);
            SqlCommand comando = new SqlCommand("Sp_EliminarTerminal", oConexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@codigoTerminal", unaTerminal.CodigoTerminal);

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            comando.Parameters.Add(retorno);

            try
            {
                oConexion.Open();
                comando.ExecuteNonQuery();

                int r = (int)retorno.Value;

                if (r == -1)
                    throw new Exception("La Terminal no existe o no se encuentra activa.");
                else if (r == -2)
                    throw new Exception("No se pudo eliminar la Terminal.");
                else if (r == -3)
                    throw new Exception("No se pudo eliminar las Facilidades de la Terminal.");
                else if (r == -4)
                    throw new Exception("No se pudo eliminar la Terminal.");
                else if (r == -5)
                    throw new Exception("No se pudo eliminar la Terminal, falló la transacción.");
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
