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
    public class PersistenciaEmpleado : IPersistenciaEmpleado
    {
        #region"Singleton"
        private static PersistenciaEmpleado instancia = null;
        private PersistenciaEmpleado() { }
        public static PersistenciaEmpleado getInstancia()
        {
            if (instancia == null)
            {
                instancia = new PersistenciaEmpleado();
            }

            return instancia;
        }
        #endregion

        public Empleado LoginEmpleado(int pCedula, string pContrasena)
        {
            SqlDataReader dr;

            Empleado objEmpleado = null;

            SqlConnection oConexion = new SqlConnection(Conexion.Con);
            SqlCommand comando = new SqlCommand("Sp_Logueo", oConexion);

            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ciEmpleado", pCedula);
            comando.Parameters.AddWithValue("@clave", pContrasena);

            try
            {
                oConexion.Open();
                dr = comando.ExecuteReader();                


                if (dr.HasRows)
                {
                    dr.Read();

                    objEmpleado = new Empleado(int.Parse(dr["CiEmpleado"].ToString()), dr["NombreCompleto"].ToString(),
                        dr["Clave"].ToString());
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
            return objEmpleado;
        }

        internal Empleado BuscarEmpleado(int pCiEmpleado)
        {
            SqlDataReader dr;

            Empleado objEmpleado = null;

            SqlConnection oConexion = new SqlConnection(Conexion.Con);
            SqlCommand comando = new SqlCommand("Sp_BuscarEmpleado", oConexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ciEmpleado", pCiEmpleado);

            try
            {
                oConexion.Open();
                dr = comando.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();

                    objEmpleado = new Empleado(int.Parse(dr["CiEmpleado"].ToString()), dr["NombreCompleto"].ToString(),
                        dr["Clave"].ToString());
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
            return objEmpleado;
        } //Busca todos los Empleados

        public Empleado BuscarEmpleadoActivo(int pCiEmpleado)
        {
            SqlDataReader dr;

            Empleado objEmpleado = null;

            SqlConnection oConexion = new SqlConnection(Conexion.Con);
            SqlCommand comando = new SqlCommand("Sp_BuscarEmpleadoActivo", oConexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ciEmpleado", pCiEmpleado);

            try
            {
                oConexion.Open();
                dr = comando.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();

                    objEmpleado = new Empleado(int.Parse(dr["CiEmpleado"].ToString()), dr["NombreCompleto"].ToString(),
                        dr["Clave"].ToString());
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
            return objEmpleado;
        } //Busca lo Empleados activos

        public void AgregarEmpleado(Empleado unEmpleado)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Con);
            SqlCommand comando = new SqlCommand("Sp_AltaEmpleado", oConexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ciEmpleado", unEmpleado.Cedula);
            comando.Parameters.AddWithValue("@nombreCompleto", unEmpleado.Nombre);
            comando.Parameters.AddWithValue("@clave", unEmpleado.Contrasena);

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            comando.Parameters.Add(retorno);

            try
            {
                oConexion.Open();
                comando.ExecuteNonQuery();

                if ((int)retorno.Value == -1)
                    throw new Exception("No se pudo agregar el Empleado.");
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

        public void ModificarEmpleado(Empleado unEmpleado)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Con);
            SqlCommand comando = new SqlCommand("Sp_ModificarEmpleado", oConexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ciEmpleado", unEmpleado.Cedula);
            comando.Parameters.AddWithValue("@nombreCompleto", unEmpleado.Nombre);
            comando.Parameters.AddWithValue("@clave", unEmpleado.Contrasena);

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            comando.Parameters.Add(retorno);

            try
            {
                oConexion.Open();
                comando.ExecuteNonQuery();

                if ((int)retorno.Value == -1)
                    throw new Exception("Error al modificar el Empleado.");
                else if ((int)retorno.Value == -2)
                    throw new Exception("El Empleado no existe o no se encuentra activo.");
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

        public void EliminarEmpleado(Empleado unEmpleado)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Con);
            SqlCommand comando = new SqlCommand("Sp_EliminarEmpleado", oConexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ciEmpleado", unEmpleado.Cedula);

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            comando.Parameters.Add(retorno);

            try
            {
                oConexion.Open();
                comando.ExecuteNonQuery();

                if ((int)retorno.Value == -1)
                    throw new Exception("El Empleado no existe o no se encuentra activo.");
                else if ((int)retorno.Value == -2)
                    throw new Exception("No se pudo eliminar el Empleado.");
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
