<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.master" AutoEventWireup="true" CodeFile="FrmEstadios.aspx.cs" Inherits="FrmEstadios" %>

<%@ Register Src="~/ucMensaje.ascx" TagPrefix="uc1" TagName="ucMensaje" %>
<%@ Register Src="~/ucDecidir.ascx" TagPrefix="uc1" TagName="ucDecidir" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ucDecidir runat="server" ID="dEliminar" />
<uc1:ucMensaje runat="server" ID="mensaje" />
<table>
    <tr>
        <td>
            <asp:GridView ID="gvEstadio" runat="server" AllowPaging="True" CssClass="Rejilla" OnPageIndexChanging="gvEstadio_PageIndexChanging" PageSize="5">
                <AlternatingRowStyle CssClass="alterno" />
                <Columns>
                    <asp:CommandField ButtonType="Button" HeaderText="Seleccionar" SelectText="" ShowSelectButton="True" />
                </Columns>
                <PagerStyle CssClass="pie" />
                <SelectedRowStyle CssClass="filaSeleccionada" />
            </asp:GridView>
        </td>
        <td rowspan="2">
            <asp:Panel ID="pnlEdicionEstadio" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td colspan="2" bgcolor="#033060">
                            <asp:Label ID="lblTituloEdicion" runat="server" Text="Label" ForeColor="White"></asp:Label>
                        </td>
                    <tr>
                        <td bgcolor="#999999">Estadio</td>
                        <td bgcolor="#DDDDDD">
                            <asp:TextBox ID="txtEstadio" runat="server"></asp:TextBox></td>
                        
                    </tr>
                    <tr>
                        <td bgcolor="#999999">Ciudad</td>
                        <td bgcolor="#DDDDDD">
                            <asp:DropDownList ID="ddlCiudad" runat="server"></asp:DropDownList></td>
                        
                    </tr>
                    <tr>
                        <td bgcolor="#999999">Capacidad</td>
                        <td bgcolor="#DDDDDD">
                            <asp:TextBox ID="txtCapacidad" runat="server"></asp:TextBox></td>
                        
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:ImageButton ID="btnAceptar" runat="server" ImageUrl="~/imagenes/Iconos/Aceptar.png" OnClick="btnAceptar_Click" />
                            <asp:ImageButton ID="btnCancelar" runat="server" ImageUrl="~/imagenes/Iconos/Cancelar.png" OnClick="btnCancelar_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>

        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="pnlBotones" runat="server">
            <asp:ImageButton ID="btnAgregar" runat="server" ImageUrl="~/imagenes/Iconos/Agregar.png" OnClick="btnAgregar_Click" />
            <asp:ImageButton ID="btnModificar" runat="server" ImageUrl="~/imagenes/Iconos/Editar.png" OnClick="btnModificar_Click" style="height: 32px" />
            <asp:ImageButton ID="btnEliminar" runat="server" ImageUrl="~/imagenes/Iconos/Eliminar.png" OnClick="btnEliminar_Click" />
            </asp:Panel>
        </td>
    </tr>
</table>
</asp:Content>
