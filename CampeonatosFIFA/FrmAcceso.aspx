<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="FrmAcceso.aspx.cs" Inherits="FrmAcceso" %>

<%@ Register Src="~/ucMensaje.ascx" TagPrefix="uc1" TagName="ucMensaje" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ucMensaje runat="server" ID="mensaje" />
    
    <div class="fLogin">
        <p class="field">
            <asp:TextBox ID="txtUsuario" runat="server"
                class="field"
                placeholder="Nombre Usuario"></asp:TextBox>
            <i>
                <img src="imagenes/Usuario.png" />
            </i>
        </p>
        <p class="field">
            <asp:TextBox ID="txtClave" runat="server"
                class="field"
                TextMode="Password"
                placeholder="Contraseña"></asp:TextBox>
            <i>
                <img src="imagenes/Clave.png" />
            </i>
        </p>
        <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" 
            CssClass="button" OnClick="btnIngresar_Click"/>

    </div>
</asp:Content>

