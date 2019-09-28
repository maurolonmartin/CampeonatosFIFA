<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucDecidir.ascx.cs" Inherits="ucDecidir" %>

    <asp:Button ID="btnDecision" runat="server" style="display:none" />
    <script type="text/javascript">
        $("[id*=btnDecision]").live("click", function () {
            $("#cajaDecision").dialog({
                title: '<%=lblTitulo.Text%>',
                //buttons: {
                //    Close: function () {
                //        $(this).dialog('close');
                //    }
                //},
                open: function (type, data) {
                    $(this).parent().appendTo("form");
                },
                closeOnEscape: false,
                resizable: false,
                draggable: false,
                modal: true
            });
            return false;
        });
    </script>

    <div id="cajaDecision" style="display: none">
        <asp:Label ID="lblTitulo" runat="server" Text="Titulo" style="display:none"></asp:Label>
        <asp:Label ID="lblMensaje" runat="server" Text="Mensaje"></asp:Label>
        <br />
        <asp:ImageButton ID="btnSi" ImageUrl="Imagenes/Si.png" 
                        ToolTip="Sí" runat="server" 
                        onclick="btnSi_Click" Height="32px" Width="32px"/>
        <asp:ImageButton ID="btnNo" ImageUrl="Imagenes/No.png" 
                        ToolTip="No" runat="server" 
                        onclick="btnNo_Click" Height="32px" Width="32px"/>
    </div>