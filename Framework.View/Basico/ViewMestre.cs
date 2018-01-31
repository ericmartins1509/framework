using Framework.Modelo.Entidade.Basico;
using Framework.View.MasterPage.Basico;
using System;
using System.Web.UI.HtmlControls;

namespace Framework.View.Basico
{
    public abstract partial class ViewMestre<T> : System.Web.UI.Page where T : CadastroBasico
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadTela(sender, e);
            if (!IsPostBack)
            {
                LimpaTela();
            }
        }

        public virtual void LoadTela(object sender, EventArgs e)
        {
            SetupTela();
        }

        public virtual void SetupTela()
        {
        }

        public virtual void LimpaTela()
        {
        }

        public virtual ViewMasterMestre MasterMestre()
        {
            return ((ViewMasterMestre)Master);
        }

        public void SetTitulo(String titulo)
        {
        }
    }
}
