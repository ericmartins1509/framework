<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Basico/CadastroMestre.master" AutoEventWireup="true"
    Inherits="Framework.View.Cadastro.ViewPessoa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCadastroMestreTabsTitle" runat="server">
    <li class="nav-item">
        <a href="#2a" data-toggle="tab" class="nav-link active">Tipos de Documento</a>
    </li>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphCadastroMestreBody" runat="server">

    <div class="row">
        <div class="form-group col-md-2">
            <asp:Label runat="server" ID="lblTipoPessoa" CssClass="control-label" />
            <asp:DropDownList runat="server" ID="ddlTipoPessoa" AutoPostBack="true" CssClass="dropdown form-control" />
        </div>
    </div>

    <div class="row">
        <div class="form-group col-md-4">
            <asp:GridView runat="server" ID="grdListaDocumento" AutoGenerateColumns="False" CssClass="table-bordered table-hover"
                DataKeyNames="Identificador, DocumentoIdentificador">
                <Columns>
                    <asp:BoundField HeaderText="" DataField="Identificador" Visible="false" />
                    <asp:BoundField HeaderText="" DataField="Descricao" Visible="false" />
                    <asp:BoundField HeaderText="" DataField="Observacao" Visible="false" />
                    <asp:BoundField HeaderText="" DataField="DocumentoIdentificador" Visible="false" />
                    <asp:BoundField HeaderText="" DataField="Documento.Obrigatorio" Visible="false" />
                    <asp:BoundField HeaderText="Tipo" DataField="DocumentoDetalheDescricao" HeaderStyle-Width="100" />
                    <asp:TemplateField HeaderText="Documento" HeaderStyle-Width="200">
                        <ItemTemplate>
                            <div class="row">
                                <div class="form-group col-md-8">
                                    <asp:Label runat="server" ID="lblTipoPessoa" CssClass="control-label" Text="Documento" />
                                    <asp:TextBox runat="server" ID="txtDocumento" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-md-8">
                                    <asp:Label runat="server" ID="lblObservacao" CssClass="control-label" Text="Observação" />
                                    <asp:TextBox runat="server" ID="txtObservacao" CssClass="form-control" />
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div>
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="teste" runat="server">
                    <asp:Button runat="server" ID="btteste" Text="teste" />
                </asp:View>
            </asp:MultiView>
        </div>
    </div>
</asp:Content>
