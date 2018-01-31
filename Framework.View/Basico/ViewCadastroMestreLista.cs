using Framework.Modelo.Entidade.Basico;
using Framework.View.MasterPage.Basico;
using System.Collections.Generic;

namespace Framework.View.Basico
{
     public abstract class ViewCadastroMestreLista<T> : ViewCadastroMestre<T> where T : CadastroRelacionamentoMestreLista
    {
        #region Evento
        #endregion

        #region MasterPages
        public override ViewMasterMestre MasterMestre()
        {
            return ((ViewMasterMestre)((ViewMasterCadastro)((ViewMasterCadastroMestre)Master).Master).Master);
        }

        public override ViewMasterCadastro MasterCadastro()
        {
            return ((ViewMasterCadastro)((ViewMasterCadastroMestre)Master).Master);
        }

        public override ViewMasterCadastroMestre MasterCadastroMestre()
        {
            return ((ViewMasterCadastroMestre)Master);
        }
        #endregion

        #region Tela
        public abstract MestreDetalhe GetEntidadeDetalhe();
 
        public override void GetControles(T entidade)
        {
            base.GetControles(entidade);

            {
                GetControlesLista(entidade.Detalhes);
            }
        }

        public override void SetControles(T entidade)
        {
            base.SetControles(entidade);

            {
                SetControlesLista(entidade.Detalhes);
            }
        }

        protected abstract void GetControlesLista(IList<MestreDetalhe> entidades);

        protected abstract void SetControlesLista(IList<MestreDetalhe> entidades);
        #endregion
    }
}
