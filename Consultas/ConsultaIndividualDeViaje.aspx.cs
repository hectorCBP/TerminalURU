using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Linq;
using EntidadesCompartidas;

namespace Consultas
{
    public partial class ConsultaIndividualDeViaje : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["numeroViaje"] == null)
                    Response.Redirect("~/ConsultaDeViajes.aspx");            

                var unViaje = (from viajes in ((List<Viaje>)Session["listaViajes"])
                                 where viajes.NumeroViaje.Equals(Convert.ToInt32(Session["numeroViaje"]))
                                 select viajes).First();

                Internacional viajeI = null;
                Nacional viajeN = null;
                if (unViaje is Internacional)
                    viajeI = (Internacional)unViaje;
                else
                    viajeN = (Nacional)unViaje;

                // datos de viaje
                lblNumViajeVal.Text = unViaje.NumeroViaje.ToString();
                lblFechaSalidaVal.Text = unViaje.FHSalida.ToShortDateString();
                lblFechaLlegadaVal.Text = unViaje.FHLlegada.ToShortDateString();
                lblAsientosVal.Text = unViaje.Asientos.ToString();
                
                if(viajeN != null)
                    lblParadasVal.Text = viajeN.ParadasIntermedias.ToString();

                if(viajeI != null)
                {
                    lblServicioVal.Text = viajeI.ServicioABordo ? "SI" : "NO";
                    txtAreaDocumentacion.InnerText = viajeI.Documentacion;
                }
                
                // datos de compania
                lblNomCompaniaVal.Text = unViaje.Compania.Nombre;
                lblDireccionVal.Text = unViaje.Compania.Direccion;
                lblTelefonoVal.Text = unViaje.Compania.Telefono.ToString();

                // datos de terminal
                lblCodigoVal.Text = unViaje.Terminal.CodigoTerminal;
                lblPaisVal.Text = unViaje.Terminal.Pais;
                lblCiudadVal.Text = unViaje.Terminal.Ciudad;
                GVFacilidades.DataSource = unViaje.Terminal.ListaFacilidades;
                GVFacilidades.DataBind();
            }

        }
    }
}