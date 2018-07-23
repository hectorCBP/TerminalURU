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
    public partial class AbmTerminales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Terminal"] = null;
                Limpiar();
            }
        }

        protected void imgBtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                lblError.Text = "";

                Terminal unaTerminal = null;
                unaTerminal = FabricaLogica.getLogicaTerminal().BuscarTerminalActiva(txtCodigo.Text.Trim());

                if (unaTerminal == null)
                {
                    btnAgregar.Enabled = true;
                }
                else
                {
                    btnModificar.Enabled = true;
                    btnEliminar.Enabled = true;

                    txtCodigo.Enabled = false;

                    Session["Terminal"] = unaTerminal;

                    txtCodigo.Text = unaTerminal.CodigoTerminal;
                    txtCiudad.Text = unaTerminal.Ciudad;
                    txtPais.Text = unaTerminal.Pais;

                    //cargar facilidades en el grid
                    List<Facilidad> _lista = unaTerminal.ListaFacilidades;
                    gvFacilidades.DataSource = _lista;
                    gvFacilidades.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void imgBtnLimpiar_Click(object sender, ImageClickEventArgs e)
        {

        }

        private void Limpiar()
        {
            txtCodigo.Text = "";
            txtCiudad.Text = "";
            txtPais.Text = "";

            //limpiar el grid

            txtCodigo.Enabled = true;

            btnAgregar.Enabled = false;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;

            lblError.Text = "";
        }

    }
}