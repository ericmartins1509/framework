using Framework.Infraestrutura.Servico.Basico;
using Framework.Modelo.Entidade;
using Framework.Modelo.Entidade.Basico;
using Framework.View.Basico;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Framework.View.Cadastro
{
    public class ViewTipoPessoa : ViewCadastroMestreListaGrid<TipoPessoa>
    {
        #region Propriedades
        public GridView grdLista { get; set; }
        public Button btnIncluirLinha { get; set; }

        String ddlTipoDocumento = "ddlTipoDocumento";
        String chkObrigatorio = "chkObrigatorio";
        #endregion

        public override TipoPessoa GetEntidade()
        {
            return new TipoPessoa();
        }

        public override ServicoCadastro<TipoPessoa> GetServico()
        {
            return new ServicoCadastroMestreLista<TipoPessoa>();
        }

        public override MestreDetalhe GetEntidadeDetalhe()
        {
            return new RelacionamentoTipoPessoaTipoDocumento();
        }

        public override void SetupTela()
        {
            grdLista.RowDataBound += SetupLinhaGrid;
            btnIncluirLinha.Click += IncluirLinhaGrid;

            base.SetupTela();
        }

        public override MestreDetalhe GetControlesItemGrid(GridViewRow Linha)
        {
            MestreDetalhe entidade = GetEntidadeDetalhe();

            DropDownList ddl = (DropDownList)Linha.FindControl(ddlTipoDocumento);

            if ((Linha.Visible) &&
                (ddl != null) &&
                (Convert.ToInt32(ddl.SelectedValue) != 0))
            {
                ((RelacionamentoTipoPessoaTipoDocumento)entidade).Obrigatorio = ((CheckBox)Linha.FindControl(chkObrigatorio)).Checked;

                entidade.Detalhe.Identificador = Convert.ToInt32(ddl.SelectedValue);

                return entidade;
            }
            return null;
        }

        public override void SetupLinhaGrid(GridViewRow Linha)
        {
            CheckBox chk = (CheckBox)Linha.FindControl(chkObrigatorio);
            try
            {
                chk.Checked = Convert.ToBoolean(DataBinder.Eval(Linha.DataItem, "Obrigatorio"));
            }
            catch (Exception)
            {
                chk.Checked = false;
            }

            DropDownList ddl = (DropDownList)Linha.FindControl(ddlTipoDocumento);
            if (ddl != null)
            {
                var servico = new ServicoCadastroMestre<TipoDocumento>();

                IList<TipoDocumento> tiposDocumento = servico.ObterTodos();

                tiposDocumento.Add(new TipoDocumento
                {
                    Identificador = 0,
                    Descricao = "Selecione um Documento"
                });

                ddl.DataTextField = "Descricao";
                ddl.DataValueField = "Identificador";

                ddl.DataSource = tiposDocumento;
                ddl.DataBind();

                if (DataBinder.Eval(Linha.DataItem, "Detalhe.Identificador").ToString() != "")
                {
                    ddl.Items.FindByValue(DataBinder.Eval(Linha.DataItem, "Detalhe.Identificador").ToString()).Selected = true;
                }
                else
                {
                    ddl.Items.FindByValue("0").Selected = true;
                }
            }
        }

        protected void btnExcluirLinha_Click(object sender, EventArgs e)
        {
            Button btnPressed = (Button)sender;
            GridViewRow row = (GridViewRow)btnPressed.NamingContainer;
            row.Visible = false;
        }

        public override GridView GetGridView()
        {
            return grdLista;
        }

        public override string GetPesquisa()
        {
            return "../../Pesquisa/PesquisaTipoPessoa.aspx";
        }
    }
}
