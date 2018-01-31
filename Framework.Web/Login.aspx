<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Basico/Mestre.Master" AutoEventWireup="true"
    Inherits="Framework.View.ViewLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMestreHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMestreHeader" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMestreBody" runat="server">
    <div class="container">
        <div class="form-login">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <div class="panel-title">Login do Sistema</div>
                </div>

                <div style="padding-top: 30px" class="panel-body">
                    <div style="display: none" id="result" class="alert alert-danger col-sm-12">
                    </div>

                    <div style="margin-bottom: 25px" class="input-group">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                        @Html.EditorFor(model => model.EMAIL, new { htmlAttributes = new { @class = "form-control input-lg", placeholder = "E-mail", autofocus = true } })
                          @Html.ValidationMessageFor(model => model.EMAIL, "", new { @class = "text-danger" })
                    </div>

                    <div style="margin-bottom: 25px" class="input-group">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                        @Html.EditorFor(model => model.SENHA, new { htmlAttributes = new { @class = "form-control input-lg", placeholder = "Senha" } })
                          @Html.ValidationMessageFor(model => model.SENHA, "", new { @class = "text-danger" })
                    </div>

                    <div style="margin-top: 10px" class="form-group">

                        <div class="col-sm-12 controls">
                            <input type="submit" value="Acessar" class="btn primary btn-lg" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphMestreFooter" runat="server">
</asp:Content>
