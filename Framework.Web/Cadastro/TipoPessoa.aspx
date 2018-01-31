<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Basico/CadastroMestreListaGrid.master" AutoEventWireup="true"
    Inherits="Framework.View.Cadastro.ViewTipoPessoa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCadastroMestreListaGridTabsTitle" runat="server">
    <li class="nav-item">
        <a href="#2a" data-toggle="tab" class="nav-link active">Tipos de Documento</a>
    </li>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphCadastroMestreListaGridTabsBody" runat="server">
    <asp:ScriptManager runat="server" />
    <div class="tab-pane " id="2a">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="row">
                    <asp:GridView runat="server" ID="grdLista" AutoGenerateColumns="False" CssClass="table table-hover table-striped" GridLines="None">
                        <Columns>
                            <asp:BoundField HeaderText="obg" DataField="Obrigatorio" Visible="false" />
                            <asp:BoundField HeaderText="Identificador" DataField="Detalhe.Identificador" Visible="false" />
                            <asp:TemplateField HeaderText="Obrigatório">
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkObrigatorio" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tipo de Documento">
                                <ItemTemplate>
                                    <asp:DropDownList runat="server" ID="ddlTipoDocumento" DataTextField="Descricao" DataValueField="Identificador" CssClass="dropdown" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Excluir">
                                <ItemTemplate>
                                    <asp:Button runat="server" ID="btnExcluirLinha" Text="-" CssClass="btn btn-danger btn-mini" OnClick="btnExcluirLinha_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:Button runat="server" ID="btnIncluirLinha" Text="+ Linha" CssClass="btn btn-success btn-mini" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
