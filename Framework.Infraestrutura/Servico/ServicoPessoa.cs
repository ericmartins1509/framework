using Framework.Infraestrutura.Repositorio.Basico;
using Framework.Modelo.Entidade.Basico;
using Framework.Modelo.Entidade.Pessoa;

namespace Framework.Infraestrutura.Servico.Basico
{
    public class ServicoPessoa<T> : ServicoCadastroMestre<T> where T : Pessoa
    {
        public override RepositorioBasico<T> GetRepositorio()
        {
            return new RepositorioPessoa<T>();
        }
    }
}
