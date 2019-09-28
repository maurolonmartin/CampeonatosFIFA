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
        //Definir subprograma para el evento cuando se decida eliminar
        dEliminar.Decidir += new EventHandler(dEliminar_Decidir);

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
        switch (numero)
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
        if (gvEstadio.SelectedIndex >= 0)
        {
            MostrarPanel(1);
            Estadio.IniciarEdicion((int)gvEstadio.SelectedDataKey.Value,
                                    txtEstadio,
                                    ddlCiudad,
                                    txtCapacidad);
            lblTituloEdicion.Text = "Editando datos de [<STRONG>" +
                txtEstadio.Text + "</ STRONG >]";
        }
        else
        {
            mensaje.Mostrar("ERROR", "Debe seleccionar un estadio");
        }
    }

    protected void btnAceptar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            //verificar si pudo actualiar el registro
            if (Estadio.Guardar(txtEstadio, ddlCiudad, txtCapacidad))
            {
                MostrarPanel(0);
                gvEstadio.DataSource = Estadio.Obtener();
                gvEstadio.DataKeyNames = new String[] { "Id" };
                gvEstadio.DataBind();
            }
            else
            {
                mensaje.Mostrar("ERROR", "No se pudo actualizar la información");
            }

        }
        catch (Exception ex)
        {
            mensaje.Mostrar("ERROR", ex.Message);
        }
    }

    protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
    {
        MostrarPanel(0);
    }

    protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
    {
        MostrarPanel(1);
        Estadio.IniciarEdicion(-1,
                                txtEstadio,
                                ddlCiudad,
                                txtCapacidad);
        lblTituloEdicion.Text = "Agregando datos de un nuevo estadio";
    }

    protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
    {
        if (gvEstadio.SelectedIndex >= 0)
        {
            dEliminar.Mostrar("Eliminando Estadio", "¿Está seguro de eliminar datos?");
        }
        else
        {
            mensaje.Mostrar("ERROR", "Debe seleccionar un estadio");
        }
    }
    //Evento de usuario
    protected void dEliminar_Decidir(object sender, EventArgs e)
    {
        //El usuario eligio Afirmativamente?
        if(dEliminar.Decision)
        {
            try
            {
                if (Estadio.Eliminar((int)gvEstadio.SelectedDataKey.Value))
                {
                    //Actualizar la lista de estadios
                    gvEstadio.DataSource = Estadio.Obtener();
                    gvEstadio.DataBind();

                    mensaje.Mostrar("MENSAJE", "El estadio fue eliminado");
                    MostrarPanel(0);
                }
            }
            catch (Exception ex)
            {
                mensaje.Mostrar("ERROR", ex.Message);
            }
        }
        else
        {

        }
    }
}