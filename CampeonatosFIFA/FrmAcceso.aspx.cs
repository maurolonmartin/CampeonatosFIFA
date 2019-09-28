using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrmAcceso : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        try
        {
            String nombreUsuario = Usuario.ValidarAcceso(txtUsuario.Text,
                txtClave.Text);

            if (nombreUsuario.Equals(""))
            {
                mensaje.Mostrar("Error", "Credenciales no validas");
            }
            else
            {
                Response.Redirect("FrmInicio.aspx");
            }
        }
        catch (Exception ex)
        {
            mensaje.Mostrar("ERROR GRAVE", "No fue posible la conexion a la BD:<br>" + ex);
        }
    }
}