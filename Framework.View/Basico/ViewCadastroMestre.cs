using Framework.Infraestrutura.Servico.Basico;
using Framework.Modelo.Entidade.Basico;
using Framework.View.MasterPage.Basico;
using System;

namespace Framework.View.Basico
{
    public abstract class ViewCadastroMestre<T> : ViewCadastro<T> where T : CadastroMestre
    {
        #region Evento
        #endregion

        #region Tela
        public override ViewMasterMestre MasterMestre()
        {
            return ((ViewMasterMestre)((ViewMasterCadastro)((ViewMasterCadastroMestre)Master).Master).Master);
        }

        public override ViewMasterCadastro MasterCadastro()
        {
            return ((ViewMasterCadastro)((ViewMasterCadastroMestre)Master).Master);
        }

        public virtual ViewMasterCadastroMestre MasterCadastroMestre()
        {
            return ((ViewMasterCadastroMestre)Master);
        }
        #endregion
    }
}
