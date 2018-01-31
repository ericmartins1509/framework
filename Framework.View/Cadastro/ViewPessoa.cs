using Framework.Infraestrutura.Servico.Basico;
using Framework.Modelo.Entidade;
using Framework.Modelo.Entidade.Basico;
using Framework.Modelo.Entidade.Pessoa;
using Framework.View.Basico;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Framework.View.Cadastro
{
    public class ViewPessoa : ViewCadastroMestre<Pessoa>
    {
        #region Propriedades
        public Label lblTipoPessoa { get; set; }
        public DropDownList ddlTipoPessoa { get; set; }
        public GridView grdListaDocumento { get; set; }
        public GridView grdListaEndereco { get; set; }
        public Button btnIncluirLinhaEndereco { get; set; }
        //public ScriptManager ScriptManager1 { get; set; }

        String txtDocumento = "txtDocumento";
        String txtObservacao = "txtObservacao";

        #region Endereco
        public Label lblEnderecoLinha { get; set; }
        public Label lblEnderecoIdentificador { get; set; }
        public Label lblEnderecoDescricao { get; set; }
        public TextBox txtEnderecoDescricao { get; set; }
        public Label lblEnderecoObservacao { get; set; }
        public TextBox txtEnderecoObservacao { get; set; }
        public CheckBox chkInativo { get; set; }
        public Label lblEnderecoCEP { get; set; }
        public TextBox txtEnderecoCEP { get; set; }
        public Label lblEnderecoLogradouro { get; set; }
        public TextBox txtEnderecoLogradouro { get; set; }
        public Label lblEnderecoEndereco { get; set; }
        public TextBox txtEnderecoEndereco { get; set; }
        public Label lblEnderecoNumero { get; set; }
        public TextBox txtEnderecoNumero { get; set; }
        public Label lblEnderecoComplemento { get; set; }
        public TextBox txtEnderecoComplemento { get; set; }
        public Label lblEnderecoBairro { get; set; }
        public TextBox txtEnderecoBairro { get; set; }
        public Label lblEnderecoRegiaoAdministrativa { get; set; }
        public TextBox txtEnderecoRegiaoAdministrativa { get; set; }
        public Label lblEnderecoMunicipio { get; set; }
        public TextBox txtEnderecoMunicipio { get; set; }
        public Label lblEnderecoEstado { get; set; }
        public TextBox txtEnderecoEstado { get; set; }
        public Label lblEnderecoPais { get; set; }
        public TextBox txtEnderecoPais { get; set; }
        public Button btnEditarEnderecoOK { get; set; }
        #endregion
        #endregion

        public override Pessoa GetEntidade()
        {
            return new Pessoa();
        }

        public override ServicoCadastro<Pessoa> GetServico()
        {
            return new ServicoPessoa<Pessoa>();
        }

        public override void SetupTela()
        {
            lblTipoPessoa.Text = "Tipo de Pessoa";
            SetupTipoPessoa();

            grdListaDocumento.RowDataBound += SetupLinhaGridDocumento;

            grdListaEndereco.RowDataBound += SetupLinhaGridEndereco;
            btnIncluirLinhaEndereco.Click += IncluirLinhaGridEndereco;

            btnEditarEnderecoOK.Click += btnEditarEnderecoOK_Click;

            base.SetupTela();
        }

        private void btnEditarEnderecoOK_Click(object sender, EventArgs e)
        {
            Int32 linha = Convert.ToInt32(lblEnderecoLinha.Text);
            grdListaEndereco.Rows[linha].Cells[0].Text = lblEnderecoIdentificador.Text;
            grdListaEndereco.Rows[linha].Cells[1].Text = txtEnderecoDescricao.Text;
            grdListaEndereco.Rows[linha].Cells[2].Text = txtEnderecoObservacao.Text;
            //grdListaEndereco.Rows[linha].Cells[3].Text = chkInativo.Text;
            //grdListaEndereco.Rows[linha].Cells[4].Text = txtEnderecoCEP.Text;
            //grdListaEndereco.Rows[linha].Cells[5].Text = txtEnderecoLogradouro.Text;
            //grdListaEndereco.Rows[linha].Cells[6].Text = txtEnderecoEndereco.Text;
            //grdListaEndereco.Rows[linha].Cells[7].Text = txtEnderecoNumero.Text;
            //grdListaEndereco.Rows[linha].Cells[8].Text = txtEnderecoComplemento.Text;
            //grdListaEndereco.Rows[linha].Cells[9].Text = txtEnderecoBairro.Text;
            //grdListaEndereco.Rows[linha].Cells[10].Text = txtEnderecoRegiaoAdministrativa.Text;
            //grdListaEndereco.Rows[linha].Cells[11].Text = txtEnderecoMunicipio.Text;
            //grdListaEndereco.Rows[linha].Cells[12].Text = txtEnderecoEstado.Text;
            //grdListaEndereco.Rows[linha].Cells[13].Text = txtEnderecoPais.Text;
        }

        private void IncluirLinhaGridEndereco(object sender, EventArgs e)
        {
            IList<PessoaEndereco> enderecos = new List<PessoaEndereco>();

            GetControlesEndereco(enderecos);

            enderecos.Add(GetEntidadeEndereco());

            SetControlesEndereco(enderecos);
        }

        private void SetupLinhaGridEndereco(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow linha = e.Row;
            }
        }

        protected void grdListaEndereco_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            PessoaEndereco pessoaEndereco = GetControlesEnderecoLinha(Convert.ToInt32(e.CommandArgument));

            lblEnderecoLinha.Text = e.CommandArgument.ToString();
            lblEnderecoIdentificador.Text = pessoaEndereco.Identificador.ToString();
            txtEnderecoDescricao.Text = pessoaEndereco.Descricao;
            txtEnderecoObservacao.Text = pessoaEndereco.Observacao;
            //chkInativo.Text = grdListaEndereco.Rows[linha].Cells[3].Text;
            //txtEnderecoCEP.Text = _linha.Cells[4].Text;
            //txtEnderecoCEP.Text = grdListaEndereco.Rows[linha].Cells[4].Text;
            //txtEnderecoLogradouro.Text = grdListaEndereco.Rows[linha].Cells[5].Text;
            //txtEnderecoEndereco.Text = grdListaEndereco.Rows[linha].Cells[6].Text;
            //txtEnderecoNumero.Text = grdListaEndereco.Rows[linha].Cells[7].Text;
            //txtEnderecoComplemento.Text = grdListaEndereco.Rows[linha].Cells[8].Text;
            //txtEnderecoBairro.Text = grdListaEndereco.Rows[linha].Cells[9].Text;
            //txtEnderecoRegiaoAdministrativa.Text = grdListaEndereco.Rows[linha].Cells[10].Text;
            //txtEnderecoMunicipio.Text = grdListaEndereco.Rows[linha].Cells[11].Text;
            //txtEnderecoEstado.Text = grdListaEndereco.Rows[linha].Cells[12].Text;
            //txtEnderecoPais.Text = grdListaEndereco.Rows[linha].Cells[13].Text;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#enderecomodal').modal('show');</script>", false);
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();

            ddlTipoPessoa.SelectedValue = "0";
            ddlTipoPessoa_SelectedIndexChanged(null, null);
        }

        private void SetupTipoPessoa()
        {
            ddlTipoPessoa.SelectedIndexChanged += ddlTipoPessoa_SelectedIndexChanged;

            var servico = new ServicoCadastroMestre<TipoPessoa>();

            IList<TipoPessoa> tiposPessoa = servico.ObterTodos();

            tiposPessoa.Add(new TipoPessoa
            {
                Identificador = 0,
                Descricao = "Selecione um Tipo"
            });

            ddlTipoPessoa.DataTextField = "Descricao";
            ddlTipoPessoa.DataValueField = "Identificador";

            String tipopessoa = ddlTipoPessoa.SelectedValue;

            ddlTipoPessoa.DataSource = tiposPessoa;
            ddlTipoPessoa.DataBind();

            if (IsPostBack)
            {
                ddlTipoPessoa.SelectedValue = tipopessoa;
            }
            else
            {
                ddlTipoPessoa.SelectedValue = "0";
                ddlTipoPessoa_SelectedIndexChanged(null, null);
            }
        }

        void ddlTipoPessoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddlTipoPessoa.SelectedValue) != 0)
            {
                var servico = new ServicoCadastroMestre<TipoPessoa>();
                TipoPessoa tipoPessoa = servico.Obter(Convert.ToInt32(ddlTipoPessoa.SelectedValue));

                IList<PessoaDocumento> documentos = new List<PessoaDocumento>();

                foreach (MestreDetalhe mestreDetalhe in tipoPessoa.Detalhes)
                {
                    documentos.Add(new PessoaDocumento { Documento = (mestreDetalhe as RelacionamentoTipoPessoaTipoDocumento) });
                }

                if (documentos.Count > 0)
                {
                    grdListaDocumento.Visible = true;
                    grdListaDocumento.DataSource = documentos;
                    grdListaDocumento.DataBind();
                }
                else
                {
                    grdListaDocumento.Visible = false;
                }
            }
            else
            {
                IList<PessoaDocumento> documentos = new List<PessoaDocumento>();
                documentos.Add(new PessoaDocumento { Documento = new RelacionamentoTipoPessoaTipoDocumento() });

                grdListaDocumento.DataSource = documentos;
                grdListaDocumento.DataBind();

                grdListaDocumento.Visible = false;
            }
        }

        private void SetupLinhaGridDocumento(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow linha = e.Row;

                if ((sender as GridView).ID == "grdListaDocumento")
                {
                    SetupLinhaGridDocumento(e, linha);
                }
            }
        }

        private void SetupLinhaGridDocumento(GridViewRowEventArgs e, GridViewRow linha)
        {
            if (DataBinder.Eval(linha.DataItem, "Descricao") != null)
            {
                TextBox txtDescricaoDocumento = (TextBox)linha.FindControl(txtDocumento);
                txtDescricaoDocumento.Text = DataBinder.Eval(linha.DataItem, "Descricao").ToString();
            }

            if (DataBinder.Eval(linha.DataItem, "Observacao") != null)
            {
                TextBox txtObservacaoDocumento = (TextBox)linha.FindControl(txtObservacao);
                txtObservacaoDocumento.Text = DataBinder.Eval(linha.DataItem, "Observacao").ToString();
            }

            if ((DataBinder.Eval(linha.DataItem, "Documento.Obrigatorio") != null)
                && (Convert.ToBoolean(DataBinder.Eval(linha.DataItem, "Documento.Obrigatorio"))))
            {
                //e.Row.BackColor = System.Drawing.Color.AliceBlue;
                e.Row.CssClass += "alert-error";
            }
        }

        public override void GetControles(Pessoa entidade)
        {
            base.GetControles(entidade);

            entidade.TipoPessoa.Identificador = Convert.ToInt32(ddlTipoPessoa.SelectedValue);

            GetControlesDocumento(entidade.Documentos);
            GetControlesEndereco(entidade.Enderecos);
        }

        private void GetControlesDocumento(IList<PessoaDocumento> documentos)
        {
            foreach (GridViewRow linha in grdListaDocumento.Rows)
            {
                if ((linha.Visible)
                    && ((((TextBox)linha.FindControl(txtDocumento)).Text != "")
                       || (((TextBox)linha.FindControl(txtObservacao)).Text != "")
                      )
                   )
                {
                    PessoaDocumento pessoaDocumento = new PessoaDocumento();
                    pessoaDocumento.Identificador = Convert.ToInt32(grdListaDocumento.DataKeys[linha.RowIndex].Values["Identificador"].ToString());
                    pessoaDocumento.Descricao = ((TextBox)linha.FindControl(txtDocumento)).Text;
                    pessoaDocumento.Observacao = ((TextBox)linha.FindControl(txtObservacao)).Text;
                    pessoaDocumento.Documento.Identificador = Convert.ToInt32(grdListaDocumento.DataKeys[linha.RowIndex].Values["TipoDocumentoIdentificador"].ToString());
                    documentos.Add(pessoaDocumento);
                }
            }
        }

        private void GetControlesEndereco(IList<PessoaEndereco> enderecos)
        {
            foreach (GridViewRow linhaRow in grdListaEndereco.Rows)
            {
                if (linhaRow.Visible)
                {
                    PessoaEndereco pessoaEndereco = new PessoaEndereco();
                    
                    enderecos.Add(GetControlesEnderecoLinha(linhaRow.RowIndex));
                }
            }
        }

        private PessoaEndereco GetControlesEnderecoLinha(Int32 linha)
        {
            PessoaEndereco pessoaEndereco = GetEntidadeEndereco();
            pessoaEndereco.Identificador = Convert.ToInt32(ConverterParaNulo(grdListaEndereco.Rows[linha].Cells[0].Text));
            pessoaEndereco.Descricao = ConverterParaNulo(grdListaEndereco.Rows[linha].Cells[1].Text);
            pessoaEndereco.Observacao = ConverterParaNulo(grdListaEndereco.Rows[linha].Cells[2].Text);
            //pessoaEndereco.Inativo = ConverterParaNulo(grdListaEndereco.Rows[linha].Cells[3].Text);
            //pessoaEndereco.CEP = ConverterParaNulo(grdListaEndereco.Rows[linha].Cells[4].Text);
            //pessoaEndereco.Logradouro = ConverterParaNulo(grdListaEndereco.Rows[linha].Cells[5].Text);
            //pessoaEndereco.Endereco = ConverterParaNulo(grdListaEndereco.Rows[linha].Cells[6].Text);
            //pessoaEndereco.Numero = ConverterParaNulo(grdListaEndereco.Rows[linha].Cells[7].Text);
            //pessoaEndereco.Complemento = ConverterParaNulo(grdListaEndereco.Rows[linha].Cells[8].Text);
            //pessoaEndereco.Bairro = ConverterParaNulo(grdListaEndereco.Rows[linha].Cells[9].Text);
            //pessoaEndereco.RegiaoAdministratriva = ConverterParaNulo(grdListaEndereco.Rows[linha].Cells[10].Text);
            //pessoaEndereco.Municipio = ConverterParaNulo(grdListaEndereco.Rows[linha].Cells[11].Text);
            //pessoaEndereco.Estado = ConverterParaNulo(grdListaEndereco.Rows[linha].Cells[12].Text);
            //pessoaEndereco.Pais = ConverterParaNulo(grdListaEndereco.Rows[linha].Cells[13].Text);

            return pessoaEndereco;
        }

        public String ConverterParaNulo(String valor)
        {
            if (valor == "&nbsp;")
            {
                return null;
            }
            return valor;
        }

        private PessoaEndereco GetEntidadeEndereco()
        {
            return new PessoaEndereco();
        }

        public override void SetControles(Pessoa entidade)
        {
            base.SetControles(entidade);

            SetControlesDocumento(entidade);
            SetControlesEndereco(entidade.Enderecos);
        }

        private void SetControlesDocumento(Pessoa entidade)
        {
            ddlTipoPessoa.SelectedValue = entidade.TipoPessoa.Identificador.ToString();

            var servico = new ServicoCadastroMestre<TipoPessoa>();
            TipoPessoa tipoPessoa = servico.Obter(Convert.ToInt32(ddlTipoPessoa.SelectedValue));

            IList<PessoaDocumento> pessoaDocumentos = new List<PessoaDocumento>();

            foreach (RelacionamentoTipoPessoaTipoDocumento relacionamentoTipoPessoaTipoDocumento in tipoPessoa.Detalhes)
            {
                PessoaDocumento documento = new PessoaDocumento { Documento = relacionamentoTipoPessoaTipoDocumento };

                foreach (PessoaDocumento pessoaDocumento in entidade.Documentos)
                {
                    if (pessoaDocumento.Documento.Identificador == documento.Documento.Identificador)
                    {
                        documento = pessoaDocumento;
                    }
                }

                pessoaDocumentos.Add(documento);
            }

            grdListaDocumento.DataSource = pessoaDocumentos;
            grdListaDocumento.DataBind();
            grdListaDocumento.Visible = true;
        }

        private void SetControlesEndereco(IList<PessoaEndereco> enderecos)
        {
            if (enderecos.Count == 0)
            {
                enderecos.Add(GetEntidadeEndereco());
            }

            grdListaEndereco.DataSource = enderecos;
            grdListaEndereco.DataBind();
        }

        public override string GetPesquisa()
        {
            return "../../Pesquisa/PesquisaPessoa.aspx";
        }
    }
}
