using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administracion
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // BOTON LOGIN
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //TO DO Validations
                int ciEmpleado = Convert.ToInt32(txtCiEmpleado.Text);

                Session["Usuario"] = Logica.FabricaLogica.getLogicaEmpleado().LoginEmpleado(ciEmpleado, txtClave.Text);

                if (Session["Usuario"] == null)
                    throw new Exception("ERROR - CI Empleado y/o Clave son incorrectos");
                else
                    Response.Redirect("~/AbmInternacionales.aspx");
            }
            catch (Exception ex)
            { lblError.Text = ex.Message; }
        }
    }
}