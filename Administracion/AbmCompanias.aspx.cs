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
    public partial class AbmCompanias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Compania"] = null;
                Limpiar();
            }
        }

        protected void imgBtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                lblError.Text = "";

                Compania unaCompania = null;
                unaCompania = FabricaLogica.getLogicaCompania().BuscarCompaniaActiva(txtNombre.Text.Trim());

                if (unaCompania == null)
                {
                    btnAgregar.Enabled = true;
                }
                else
                {
                    btnModificar.Enabled = true;
                    btnEliminar.Enabled = true;

                    txtNombre.Enabled = false;

                    Session["Compania"] = unaCompania;

                    txtNombre.Text = unaCompania.Nombre;
                    txtDireccion.Text = unaCompania.Direccion;
                    txtTelefono.Text = unaCompania.Telefono.ToString();
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
                Compania unaCompania = null;
                unaCompania = new Compania(txtNombre.Text.Trim(), txtDireccion.Text.Trim(), Convert.ToInt32(txtTelefono.Text.Trim()));
                FabricaLogica.getLogicaCompania().AgregarCompania(unaCompania);

                Limpiar();

                lblError.Text = "Companía agregada correctamente.";
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
                Compania unaCompania = (Compania)Session["Compania"];
                unaCompania.Direccion = txtDireccion.Text.Trim(); ;
                unaCompania.Telefono = Convert.ToInt32(txtTelefono.Text.Trim());

                FabricaLogica.getLogicaCompania().ModificarCompania(unaCompania);
                
                Limpiar();

                lblError.Text = "Companía modificada correctamente.";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Compania unaCompania = (Compania)Session["Compania"];
                FabricaLogica.getLogicaCompania().EliminarCompania(unaCompania);

                Limpiar();

                lblError.Text = "Companía eliminada correctamente.";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void imgBtnLimpiar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Limpiar();
                Session["Compania"] = null;
                txtNombre.Enabled = true;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private void Limpiar()
        {
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";

            txtNombre.Enabled = true;

            btnAgregar.Enabled = false;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;

            lblError.Text = "";
        }

    }
}