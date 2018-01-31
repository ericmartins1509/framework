using Framework.Infraestrutura.Servico.Basico;
using Framework.Modelo.Entidade;
using Framework.View.Basico;

namespace Framework.View.Pesquisa
{
    public class ViewPesquisaTipoDocumento : ViewPesquisa<TipoDocumento>
    {
        public override TipoDocumento GetEntidade()
        {
            return new TipoDocumento();
        }

        public override ServicoBasico<TipoDocumento> GetServico()
        {
            return new ServicoPesquisa<TipoDocumento>();
        }
    }
}
