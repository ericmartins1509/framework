using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Framework.View.MasterPage.Basico
{
    public abstract class ViewMasterCadastro : ViewMasterMestre
    {
        #region Propriedades
        public Label lblIdentificador { get; set; }
        public TextBox txtIdentificador { get; set; }
        public Label lblIdentificadorErro { get; set; }
        public Label lblDescricao { get; set; }
        public TextBox txtDescricao { get; set; }
        public Label lblObservacao { get; set; }
        public TextBox txtObservacao { get; set; }
        public Label lblInativo { get; set; }
        public CheckBox chkInativo { get; set; }

        public Button btnGravar { get; set; }

        public Button btnGravar2 { get; set; }

        //public Button btnExcluir { get; set; }
        public Button btnExcluirSim { get; set; }
        public Button btnExcluirNao { get; set; }

        public HtmlIframe ifPesquisa { get; set; }
        #endregion
    }
}
