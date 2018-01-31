using Framework.Infraestrutura.Servico.Basico;
using Framework.Modelo.Entidade;
using Framework.View.Basico;

namespace Framework.View.Cadastro
{
    public class ViewTipoDocumento : ViewCadastroMestre<TipoDocumento>
    {
        public override TipoDocumento GetEntidade()
        {
            return new TipoDocumento();
        }

        public override ServicoCadastro<TipoDocumento> GetServico()
        {
            return new ServicoCadastroMestre<TipoDocumento>();
        }

        public override void SetupTela()
        {
            base.SetupTela();

            MasterCadastro().lblIdentificador.Text = "Identificador";
        }

        public override string GetPesquisa()
        {
            return "../../Pesquisa/PesquisaTipoDocumento.aspx";
        }
    }
}
