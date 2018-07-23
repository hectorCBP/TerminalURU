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
    public partial class ConsultaDeViajes : System.Web.UI.Page
    {
        // OBTENER DATOS DESDE BD
        private void cargarInfo() 
        {
            ddlTerminal.Items.Clear();
            ddlCompania.Items.Clear();

            try
            {
                // obtengo todos los viajes y filtro los que aun no salieron
                List<Viaje> resultado = (from viajes in (Logica.FabricaLogica.getLogicaViaje().ListarViajes())
                                         where viajes.FHSalida >= DateTime.Now
                                         select viajes).ToList<Viaje>();

                // guardo resultado en session
                Session["listaViajes"] = resultado;
                
                // cargo el control repeater
                repeaterViajes.DataSource = (List<Viaje>)Session["listaViajes"];
                repeaterViajes.DataBind();

                // cargo las terminales pais / ciudad en session y dropdownlist
                List<Terminal> listaTerminales = (from viajes in ((List<Viaje>)Session["listaViajes"])
                                                  select viajes.Terminal).ToList<Terminal>();
                Session["listaTerminales"] = listaTerminales;
                ddlTerminal.Items.Add(new ListItem("- Terminales -", "-1"));
                foreach (Terminal t in (List<Terminal>)Session["listaTerminales"])             
                    ddlTerminal.Items.Add(new ListItem(t.Pais + " / " + t.Ciudad, t.CodigoTerminal));


                // cargo las companias nombre en session y dropdownlist
                List<Compania> listaCompanias = (from viajes in ((List<Viaje>)Session["listaViajes"])
                                                 select viajes.Compania).ToList<Compania>();
                Session["listaCompanias"] = listaCompanias;
                ddlCompania.Items.Add(new ListItem("- Companias -", "-1"));
                foreach (Compania c in (List<Compania>)Session["listaCompanias"])
                    ddlCompania.Items.Add(c.Nombre);
            }
            catch (Exception ex)
            { lblError.Text = ex.Message; }            
        }

        // LIMPIAR FILTROS
        private void limpiarFiltros()
        {
            // limpiar los campos
            ddlTerminal.SelectedValue = "-1";
            ddlCompania.SelectedValue = "-1";
            txtDesde.Text = String.Empty;
            txtHasta.Text = String.Empty;
            lblError.Text = String.Empty;
        }

        // INICIO DE PAGINA
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
                cargarInfo();

        }

        // MANEJO DE CONTROLES
        protected void btnDesde_Click(object sender, ImageClickEventArgs e)
        {
            calendarDesde.Visible = calendarDesde.Visible == true ? false : true;
        }
        protected void btnHasta_Click(object sender, ImageClickEventArgs e)
        {
            calendarHasta.Visible = calendarHasta.Visible == true ? false : true;
        }
        protected void calendarDesde_SelectionChanged(object sender, EventArgs e)
        {
            txtDesde.Text = calendarDesde.SelectedDate.ToShortDateString();
            calendarDesde.Visible = false;
        }
        protected void calendarHasta_SelectionChanged(object sender, EventArgs e)
        {
            txtHasta.Text = calendarHasta.SelectedDate.ToShortDateString();
            calendarHasta.Visible = false;
        }

        // FILTROS
        protected void btnImgBuscar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                lblError.Text = String.Empty;

                if (ddlTerminal.SelectedValue == "-1")
                    throw new Exception("ERROR - se debe seleccionar una Terminal");

                // obtengo viajes a un pais
                List<Viaje> resultado = (from viajes in ((List<Viaje>)Session["listaViajes"])
                                         where viajes.Terminal.CodigoTerminal.Contains(ddlTerminal.SelectedValue)
                                         select viajes).ToList<Viaje>();
                
                // obtengo viajes a un pais por una compania
                if (ddlCompania.SelectedValue != "-1")
                {
                    // filtro por companias en base a pais
                    resultado = (from viajes in resultado
                                 where viajes.Compania.Nombre.Contains(ddlCompania.SelectedItem.Text)
                                 select viajes).ToList<Viaje>();

                    if (resultado.Count == 0)
                        resultado.Clear();
                }

                // obtengo viajes a un pais por una compania entre un periodo de fecha
                if (String.IsNullOrEmpty(txtDesde.Text) && !String.IsNullOrEmpty(txtHasta.Text))
                { 
                    // ERROR si fecha hasta es menor o igual a fecha ahora
                    DateTime fechaHasta = DateTime.Parse(txtHasta.Text);
                    if(fechaHasta <= DateTime.Now)
                        throw new Exception("ERROR - Ha seleccionado un criterio de fecha no válido");
                   
                    // filtro entre today y fechaHasta en base a pais y/o compania
                    resultado = (from viajes in resultado
                                 where viajes.FHSalida > DateTime.Now && viajes.FHLlegada <= fechaHasta
                                 select viajes).ToList<Viaje>();

                    if (resultado.Count == 0)
                        resultado.Clear();
                }
                else if (!String.IsNullOrEmpty(txtDesde.Text) && String.IsNullOrEmpty(txtHasta.Text))
                {
                    // ERROR si fecha es menor o igual a fecha ahora
                    DateTime fechaDesde = DateTime.Parse(txtDesde.Text);
                    if (fechaDesde <= DateTime.Now)
                        throw new Exception("ERROR - Ha seleccionado un criterio de fecha no válido");

                    // filtro entre fechaDesde y el ultimo registro en base a pais y/o compania
                    resultado = (from viajes in resultado
                                 where viajes.FHSalida > fechaDesde
                                 select viajes).ToList<Viaje>();

                    if (resultado.Count == 0)
                        resultado.Clear();
                }
                else if (!String.IsNullOrEmpty(txtDesde.Text) && !String.IsNullOrEmpty(txtHasta.Text))
                {
                    // ERROR - si fechaDesde es menor o igual a fecha ahora y si es fechaDesde es mayor a fechaHasta
                    DateTime fechaDesde = DateTime.Parse(txtDesde.Text);
                    DateTime fechaHasta = DateTime.Parse(txtHasta.Text);
                    if(fechaDesde <= DateTime.Now && fechaDesde > fechaHasta)
                        throw new Exception("ERROR - Ha seleccionado un criterio de fecha no válido");

                    // filtro entre periodo de fechas en base a pais y/o compania
                    resultado = (from viajes in resultado
                                 where viajes.FHSalida < fechaHasta && viajes.FHLlegada > fechaDesde
                                 select viajes).ToList<Viaje>();

                    if (resultado.Count == 0)
                        resultado.Clear();
                }

                // ERROR si no cumple criterio de filtro 
                if (resultado.Count == 0)
                    throw new Exception("ERROR - no existen viajes con estos criterios");
                else
                {
                    // completar repeater
                    repeaterViajes.DataSource = resultado;
                    repeaterViajes.DataBind();
                }
            }
            catch (Exception ex)
            { lblError.Text = ex.Message; }
        }
        
        // LIMPIAR
        protected void btnImgLimpiar_Click(object sender, ImageClickEventArgs e)
        {
            cargarInfo();
            limpiarFiltros();
        }

        // BOTON VER MAS
        protected void repeaterViajes_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                // si evento se dispara del boton
                if (e.CommandName == "Info")
                {
                    // guardo en session el control 
                    // que contiene el nuemro de viaje
                    // y redirecciono
                    Session["numeroViaje"] = ((TextBox)(e.Item.FindControl("numeroViaje"))).Text;

                    Response.Redirect("~/ConsultaIndividualDeViaje.aspx");
                }
            }
            catch (Exception ex)
            { lblError.Text = ex.Message; }          
        }
    }
}