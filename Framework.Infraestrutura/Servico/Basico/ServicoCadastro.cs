using Framework.Modelo.Entidade.Basico;

namespace Framework.Infraestrutura.Servico.Basico
{
    public abstract class ServicoCadastro<T> : ServicoBasico<T> where T : CadastroBasico
    {
    }
}
