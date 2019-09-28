using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ucDecidir : System.Web.UI.UserControl
{
    public event System.EventHandler Decidir;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //Variable interna para guardar la decision del usuario
    private bool decision = false;

    //Propiedad que devuelve la decision del usuario
    public bool Decision
    {
        get
        { return decision; }
    }

    public void Mostrar(String Titulo, String Mensaje)
    {
        lblTitulo.Text = Titulo;
        lblMensaje.Text = Mensaje;

        Page.ClientScript.RegisterStartupScript(this.GetType(), "Decision", "$('[id$=btnDecision]').click()", true);
    }
    protected void btnSi_Click(object sender, ImageClickEventArgs e)
    {
        //El usuario decide afirmativamente
        decision = true;
        //Activar evento para futuro codigo
        this.Decidir(this, new EventArgs());
        //Cerrar ventana modal
        Page.ClientScript.RegisterStartupScript(this.GetType(), "CerrarDecision", "$('#cajaDecision').dialog('close');", true);
    }
    protected void btnNo_Click(object sender, ImageClickEventArgs e)
    {
        //El usuario decide negativamente
        decision = false;
        //Activar evento para futuro codigo
        this.Decidir(this, new EventArgs());
        //Cerrar ventana modal
        Page.ClientScript.RegisterStartupScript(this.GetType(), "CerrarDecision", "$('#cajaDecision').dialog('close');", true);
    }
}