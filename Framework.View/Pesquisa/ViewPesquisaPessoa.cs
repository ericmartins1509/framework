using Framework.Infraestrutura.Servico.Basico;
using Framework.Modelo.Entidade.Pessoa;
using Framework.View.Basico;

namespace Framework.View.Pesquisa
{
    public class ViewPesquisaPessoa : ViewPesquisa<Pessoa>
    {
        public override Pessoa GetEntidade()
        {
            return new Pessoa();
        }

        public override ServicoBasico<Pessoa> GetServico()
        {
            return new ServicoPesquisa<Pessoa>();
        }
    }
}
