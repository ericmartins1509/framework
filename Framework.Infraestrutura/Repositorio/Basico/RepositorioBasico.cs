using Framework.Infraestrutura.NHibernate.Repositorio.NHibernate;
using Framework.Modelo.Entidade.Basico;

namespace Framework.Infraestrutura.Repositorio.Basico
{
    public class RepositorioBasico<T> : RepositorioNHibernate<T> where T : CadastroBasico
    {
    }
}
