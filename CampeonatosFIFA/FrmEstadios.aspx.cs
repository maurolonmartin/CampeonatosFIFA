using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrmEstadios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Verificar si se esta ejecutando por vez primera
        if (!IsPostBack)
        {
            //Llenar controles enlazados a datos
            Estadio.Preparar(ddlCiudad, 
                            gvEstadio);
            MostrarPanel(0);
        }
        else
        {
        }
    }

    private void MostrarPanel(int numero)
    {
        //Inicialmente todos los paneles invisibles
        pnlEdicionEstadio.Visible = false;
        gvEstadio.Enabled = false;
        pnlBotones.Visible = false;
        switch(numero)
        {
            case 0:
                gvEstadio.Enabled = true;
                pnlBotones.Visible = true;
                break;
            case 1:
                pnlEdicionEstadio.Visible = true;
                break;
        }

    }
    protected void gvEstadio_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEstadio.DataSource = Estadio.Obtener();
        //Asignar la página seleccionada
        gvEstadio.PageIndex = e.NewPageIndex;
        //Refrescar la página
        gvEstadio.DataBind();
    }

    protected void btnModificar_Click(object sender, ImageClickEventArgs e)
    {
        //Validar qye se haya seleccionado un registro
        if (gvEstadio.SelectedIndex>=0)
        {
            MostrarPanel(1);
            Estadio.IniciarEdicion((int)gvEstadio.SelectedDataKey.Value,
                                    txtEstadio,
                                    ddlCiudad,
                                    txtCapacidad);
            lblTituloEdicion.Text = "Edititando datos de <STRONG>N° " +
                txtEstadio.Text + "</ STRONG >";
        }
        else
        {
            mensaje.Mostrar("ERROR", "Debe seleccionar un estadio");
        }
    }
}