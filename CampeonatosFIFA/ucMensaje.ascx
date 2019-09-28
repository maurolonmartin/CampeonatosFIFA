<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucMensaje.ascx.cs" Inherits="ucMensaje" %>


    <asp:Button ID="btnVentanaMensaje" runat="server" style="display:none" />
    <script type="text/javascript">
        $("[id*=btnVentanaMensaje]").live("click", function () {
            $("#ventanaMensaje").dialog({
                title: '<%=lblTitulo.Text%>',
                //buttons: {
                //    Close: function () {
                //        $(this).dialog('close');
                //    }
                //},

                open: function (type, data) {
                    $(this).parent().appendTo("form:first");
                },
                closeOnEscape: false,
                resizable: false,
                draggable: false,
                modal: true
            });
            return false;
        });
    </script>

    <div id="ventanaMensaje" style="display: none">
        <asp:Label ID="lblTitulo" runat="server" Text="Titulo" style="display:none"></asp:Label>
        <asp:Label ID="lblMensaje" runat="server" Text="Mensaje"></asp:Label>
        <br />
        <asp:ImageButton ID="btnAceptar" ImageUrl="Imagenes/Aceptar.png" 
                ToolTip="Aceptar" runat="server" 
                onclick="btnAceptar_Click" Height="32px" Width="32px" />
    </div>
