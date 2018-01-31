using Framework.Infraestrutura.Repositorio.Basico;
using Framework.Modelo.Entidade.Basico;

namespace Framework.Infraestrutura.Servico.Basico
{
    public class ServicoCadastroMestreLista<T> : ServicoCadastroMestre<T> where T : CadastroRelacionamentoMestreLista
    {
        public override RepositorioBasico<T> GetRepositorio()
        {
            return new RepositorioRelacionamentoMestreLista<T>();
        }
    }
}
