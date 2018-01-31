using Framework.Infraestrutura.Servico.Basico;
using Framework.Modelo.Entidade.Basico;
using Framework.View.MasterPage.Basico;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Framework.View.Basico
{
    public abstract class ViewPesquisa<T> : ViewMestre<T> where T : CadastroMestre
    {
        IList<T> entidades;

        #region Evento
        private void GetIdentificador(object sender, EventArgs e)
        {
            entidades = Pesquisa(MasterPesquisa().txtPesquisa.Text.ToString());

            if (entidades != null)
            {
                SetControles(entidades);
            }
            else
            {
                LimpaTela(false);
            }

        }

        public virtual IList<T> Pesquisa(String pesquisa)
        {
            return GetServico().ObterTodosDescricaoObservacao(pesquisa);
        }

        protected void grdPesquisa_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            MasterPesquisa().grdPesquisa.PageIndex = e.NewPageIndex;
            MasterPesquisa().grdPesquisa.DataSource = entidades; //aqui a entidade não está populada para fazer a paginação
            MasterPesquisa().grdPesquisa.DataBind();
        }
        #endregion

        #region Tela
        public abstract ServicoBasico<T> GetServico();

        public abstract T GetEntidade();

        public virtual ViewMasterPesquisa MasterPesquisa()
        {
            return ((ViewMasterPesquisa)Master);
        }

        public virtual void SetControles(IList<T> entidades)
        {
            LimpaTela();

            MasterPesquisa().grdPesquisa.DataSource = entidades;
            MasterPesquisa().grdPesquisa.DataBind();
        }

        public override void SetupTela()
        {
            base.SetupTela();

            MasterPesquisa().btnPesquisa.Click += GetIdentificador;
            MasterPesquisa().grdPesquisa.RowDataBound += SetupLinhaGrid;

            MasterPesquisa().grdPesquisa.UseAccessibleHeader = true;

            if (MasterPesquisa().grdPesquisa.HeaderRow != null)
            {
                MasterPesquisa().grdPesquisa.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

            MasterPesquisa().grdPesquisa.PageIndexChanging += grdPesquisa_PageIndexChanging;
        }

        protected void SetupLinhaGrid(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow linha = e.Row;

                String identificador = DataBinder.Eval(linha.DataItem, "Identificador").ToString();

                linha.Attributes.Add("onclick", "btnSelecionarLinha_Click('" + identificador + "')");
            }
        }

        private void LimpaTela(Boolean limpaIdentificador)
        {
            MasterPesquisa().txtPesquisa.Text = String.Empty;
        }
        #endregion
    }
}
