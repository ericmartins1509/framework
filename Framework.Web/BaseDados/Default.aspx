<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Basico/Mestre.Master" AutoEventWireup="true"
    Inherits="Framework.View.BaseDados.ViewDefaultBaseDados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMestreHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMestreBody" runat="server">
    <p><asp:Button ID="btnGerarBaseDados" runat="server" />
    <p><asp:Button ID="btnAtualizarBaseDados" runat="server" />
</asp:Content>
