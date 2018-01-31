using Framework.Infraestrutura.Servico.Basico;
using Framework.Modelo.Entidade;
using Framework.View.Basico;

namespace Framework.View.Pesquisa
{
    public class ViewPesquisaTipoPessoa : ViewPesquisa<TipoPessoa>
    {
        public override TipoPessoa GetEntidade()
        {
            return new TipoPessoa();
        }

        public override ServicoBasico<TipoPessoa> GetServico()
        {
            return new ServicoPesquisa<TipoPessoa>();
        }
    }
}
