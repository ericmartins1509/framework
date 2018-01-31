<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Basico/CadastroMestre.master" AutoEventWireup="true"
    Inherits="Framework.View.Cadastro.ViewPessoa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCadastroMestreTabsTitle" runat="server">
    <li class="nav-item">
        <a href="#2a" data-toggle="tab" class="nav-link">Documentos</a>
    </li>
    <li class="nav-item">
        <a href="#3a" data-toggle="tab" class="nav-link">Endereços</a>
    </li>
    <li class="nav-item">
        <a href="#4a" data-toggle="tab" class="nav-link">Telefones</a>
    </li>
    <li class="nav-item">
        <a href="#5a" data-toggle="tab" class="nav-link">E-mails</a>
    </li>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cphCadastroMestreTabsBody" runat="server">
    <asp:ScriptManager runat="server" EnablePageMethods="true" />
    <div class="tab-pane" id="2a">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="row">
                    <div class="form-group col-md-4">
                        <asp:Label runat="server" ID="lblTipoPessoa" CssClass="control-label" />
                        <asp:DropDownList runat="server" ID="ddlTipoPessoa" AutoPostBack="true" CssClass="dropdown form-control" />
                    </div>
                </div>
                <div class="row">
                    <asp:GridView runat="server" ID="grdListaDocumento" AutoGenerateColumns="False"
                        DataKeyNames="Identificador, TipoDocumentoIdentificador" 
                        CssClass="table table-hover table-striped" GridLines="None">
                        <Columns>
                            <asp:BoundField DataField="Identificador" Visible="false" />
                            <asp:BoundField DataField="Descricao" Visible="false" NullDisplayText="" />
                            <asp:BoundField DataField="Observacao" Visible="false" NullDisplayText="" />
                            <asp:BoundField DataField="TipoDocumentoIdentificador" Visible="false" />
                            <asp:BoundField DataField="Documento.Obrigatorio" Visible="false" />
                            <asp:BoundField HeaderText="Tipo" DataField="TipoDocumentoDetalheDescricao" HeaderStyle-Width="100" />
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
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="tab-pane" id="3a">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="row">
                    <asp:GridView runat="server" ID="grdListaEndereco" AutoGenerateColumns="False"
                        CssClass="table table-hover table-striped" GridLines="None"
                        OnRowCommand="grdListaEndereco_RowCommand">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="Identificador" Visible="true" ItemStyle-Width="0px" />
                            <asp:BoundField HeaderText="desc" DataField="Descricao" Visible="true" ItemStyle-Width="0px" />
                            <asp:BoundField HeaderText="obs" DataField="Observacao" Visible="true" ItemStyle-Width="0px" />
                            <%--                            <asp:BoundField DataField="Inativo" Visible="false" />
                            <asp:BoundField DataField="CEP" Visible="false" />
                            <asp:BoundField DataField="Logradouro" Visible="false" />
                            <asp:BoundField DataField="Endereco" Visible="false" />
                            <asp:BoundField DataField="Numero" Visible="false" />
                            <asp:BoundField DataField="Complemento" Visible="false" />
                            <asp:BoundField DataField="Bairro" Visible="false" />
                            <asp:BoundField DataField="RegiaoAdministrativa" Visible="false" />
                            <asp:BoundField DataField="Municipio" Visible="false" />
                            <asp:BoundField DataField="Estado" Visible="false" />
                            <asp:BoundField DataField="Pais" Visible="false" />--%>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="AddButton" runat="server"
                                        CommandName="editar"
                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                        Text="editar" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:Button runat="server" ID="btnIncluirLinhaEndereco" Text="+ Linha" CssClass="btn btn-success btn-mini" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="modal fade" id="enderecomodal" role="dialog">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" id="btnFecharPesquisa" class="close" data-dismiss="modal">X</button>
                            <h4 class="modal-title" id="modalLabel">Editar Endereço</h4>
                        </div>
                        <div class="modal-body">
                            <asp:Label runat="server" ID="lblEnderecoLinha" Visible="false" />
                            <asp:Label runat="server" ID="lblEnderecoIdentificador" Visible="false" />
                            <div class="row">
                                <div class="form-group col-md-4">
                                    <asp:Label runat="server" ID="lblEnderecoDescricao" CssClass="control-label" Text="DESCRICAO" />
                                    <asp:TextBox runat="server" ID="txtEnderecoDescricao" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-md-4">
                                    <asp:Label runat="server" ID="lblEnderecoObservacao" CssClass="control-label" />
                                    <asp:TextBox runat="server" ID="txtEnderecoObservacao" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-md-4 checkbox">
                                    <asp:CheckBox runat="server" ID="chkInativo" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-md-4">
                                    <asp:Label runat="server" ID="lblEnderecoCEP" CssClass="control-label" />
                                    <asp:TextBox runat="server" ID="txtEnderecoCEP" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-md-4">
                                    <asp:Label runat="server" ID="lblEnderecoLogradouro" CssClass="control-label" />
                                    <asp:TextBox runat="server" ID="txtEnderecoLogradouro" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-md-4">
                                    <asp:Label runat="server" ID="lblEnderecoEndereco" CssClass="control-label" />
                                    <asp:TextBox runat="server" ID="txtEnderecoEndereco" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-md-4">
                                    <asp:Label runat="server" ID="lblEnderecoNumero" CssClass="control-label" />
                                    <asp:TextBox runat="server" ID="txtEnderecoNumero" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-md-4">
                                    <asp:Label runat="server" ID="lblEnderecoComplemento" CssClass="control-label" />
                                    <asp:TextBox runat="server" ID="txtEnderecoComplemento" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-md-4">
                                    <asp:Label runat="server" ID="lblEnderecoBairro" CssClass="control-label" />
                                    <asp:TextBox runat="server" ID="txtEnderecoBairro" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-md-4">
                                    <asp:Label runat="server" ID="lblEnderecoRegiaoAdministrativa" CssClass="control-label" />
                                    <asp:TextBox runat="server" ID="txtEnderecoRegiaoAdministrativa" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-md-4">
                                    <asp:Label runat="server" ID="lblEnderecoMunicipio" CssClass="control-label" />
                                    <asp:TextBox runat="server" ID="txtEnderecoMunicipio" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-md-4">
                                    <asp:Label runat="server" ID="lblEnderecoEstado" CssClass="control-label" />
                                    <asp:TextBox runat="server" ID="txtEnderecoEstado" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-md-4">
                                    <asp:Label runat="server" ID="lblEnderecoPais" CssClass="control-label" />
                                    <asp:TextBox runat="server" ID="txtEnderecoPais" CssClass="form-control" />
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnEditarEnderecoOK" CssClass="btn  btn-primary" runat="server" data-toggle="modal" data-target="#enderecomodal" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="tab-pane" id="4a">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="row">
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="tab-pane" id="5a">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="row">
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
