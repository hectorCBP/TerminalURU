using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

namespace Administracion
{
    public partial class AbmEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Empleado"] = null;
                Limpiar();
            }
        }

        protected void imgBtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                lblError.Text = "";

                Empleado unEmpleado = null;
                unEmpleado = FabricaLogica.getLogicaEmpleado().BuscarEmpleadoActivo(Convert.ToInt32(txtCedula.Text.Trim()));

                if (unEmpleado == null)
                {
                    btnAgregar.Enabled = true;
                }
                else
                {
                    btnModificar.Enabled = true;
                    btnEliminar.Enabled = true;

                    txtCedula.Enabled = false;

                    Session["Empleado"] = unEmpleado;

                    txtCedula.Text = unEmpleado.Cedula.ToString();
                    txtNombre.Text = unEmpleado.Nombre;
                    txtClave.Text = unEmpleado.Contrasena;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Empleado unEmpleado = null;
                unEmpleado = new Empleado(Convert.ToInt32(txtCedula.Text.Trim()), txtNombre.Text.Trim(), txtClave.Text.Trim());
                FabricaLogica.getLogicaEmpleado().AgregarEmpleado(unEmpleado);

                Limpiar();

                lblError.Text = "Empleado agregado correctamente.";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Empleado unEmpleado = (Empleado)Session["Empleado"];
                unEmpleado.Nombre = txtNombre.Text.Trim();
                unEmpleado.Contrasena = txtClave.Text.Trim();

                FabricaLogica.getLogicaEmpleado().ModificarEmpleado(unEmpleado);
                
                Limpiar();

                lblError.Text = "Empleado modificado correctamente.";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Empleado unEmpleado = (Empleado)Session["Empleado"];
            FabricaLogica.getLogicaEmpleado().EliminarEmpleado(unEmpleado);

            Limpiar();

            lblError.Text = "Empleado eliminado correctamente.";
        }

        protected void imgBtnLimpiar_Click(object sender, ImageClickEventArgs e)
        {
            Limpiar();
            Session["Empleado"] = null;
            txtCedula.Enabled = true;
        }

        private void Limpiar()
        {
            txtCedula.Text = "";
            txtNombre.Text = "";
            txtClave.Text = "";

            txtCedula.Enabled = true;

            btnAgregar.Enabled = false;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;

            lblError.Text = "";
        }



        
    }
}