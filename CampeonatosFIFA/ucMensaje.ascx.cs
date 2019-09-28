using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ucMensaje : System.Web.UI.UserControl
{

    //declarar evento
    public event System.EventHandler AceptoMensaje;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Mostrar(String Titulo, String Mensaje)
    {
        this.lblTitulo.Text = Titulo;
        this.lblMensaje.Text = Mensaje;
        if (!Page.ClientScript.IsStartupScriptRegistered("Mensaje" + this.ClientID))
            Page.ClientScript.RegisterStartupScript(this.GetType(),
                "Mensaje" + this.ClientID,
                "$('[id*=btnVentanaMensaje]').click();", true);

    }

    protected void btnAceptar_Click(object sender, ImageClickEventArgs e)
    {
        //Activar evento
        if (this.AceptoMensaje != null)
        {
            this.AceptoMensaje(this, new EventArgs());
        }
    }
}