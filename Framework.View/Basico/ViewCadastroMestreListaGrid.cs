using Framework.Modelo.Entidade.Basico;
using Framework.View.MasterPage.Basico;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Framework.View.Basico
{
    public abstract class ViewCadastroMestreListaGrid<T> : ViewCadastroMestreLista<T> where T : CadastroRelacionamentoMestreLista
    {
        #region Evento
        #endregion

        #region MasterPages
        public override ViewMasterMestre MasterMestre()
        {
            return ((ViewMasterMestre)((ViewMasterCadastro)((ViewMasterCadastroMestre)((ViewMasterCadastroMestreListaGrid)Master).Master).Master).Master);
        }

        public override ViewMasterCadastro MasterCadastro()
        {
            return ((ViewMasterCadastro)((ViewMasterCadastroMestre)((ViewMasterCadastroMestreListaGrid)Master).Master).Master);
        }

        public override ViewMasterCadastroMestre MasterCadastroMestre()
        {
            return ((ViewMasterCadastroMestre)((ViewMasterCadastroMestreListaGrid)Master).Master);
        }

        public virtual ViewMasterCadastroMestreListaGrid MasterCadastroMestreListaGrid()
        {
            return ((ViewMasterCadastroMestreListaGrid)Master);
        }
        #endregion

        #region Tela
        public abstract GridView GetGridView();

        protected override void GetControlesLista(IList<MestreDetalhe> entidades)
        {
            GridView grid = GetGridView();

            foreach (GridViewRow linha in grid.Rows)
            {
                MestreDetalhe entidade = GetControlesItemGrid(linha);

                if (entidade != null)
                {
                    entidades.Add(entidade);
                }
            }
        }

        protected override void SetControlesLista(IList<MestreDetalhe> entidades)
        {
            if (entidades.Count == 0)
            {
                entidades.Add(GetEntidadeDetalhe());
            }


            GetGridView().DataSource = entidades;
            GetGridView().DataBind();
        }
        
        public abstract MestreDetalhe GetControlesItemGrid(GridViewRow Linha);

        public override void LimpaCampos()
        {
            base.LimpaCampos();

            LimpaGrid();
        }

        public virtual void LimpaGrid()
        {
            SetControlesLista(GetEntidade().Detalhes);
        }

        public abstract void SetupLinhaGrid(GridViewRow Linha);

        protected void SetupLinhaGrid(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow Linha = e.Row;

                SetupLinhaGrid(Linha);
            }
        }

        protected void IncluirLinhaGrid(object sender, EventArgs e)
        {
            IList<MestreDetalhe> detalhes = GetEntidade().Detalhes;

            GetControlesLista(detalhes);

            detalhes.Add(GetEntidadeDetalhe());
            
            SetControlesLista(detalhes);
        }
        #endregion
    }
}
