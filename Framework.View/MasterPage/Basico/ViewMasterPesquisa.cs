using System.Web.UI.WebControls;

namespace Framework.View.MasterPage.Basico
{
    public abstract class ViewMasterPesquisa : ViewMasterMestre
    {
        #region Propriedades
        public TextBox txtPesquisa { get; set; }
        public Button btnPesquisa { get; set; }
        public GridView grdPesquisa { get; set; }
        #endregion
    }
}