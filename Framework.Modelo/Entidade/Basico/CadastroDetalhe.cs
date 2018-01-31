
namespace Framework.Modelo.Entidade.Basico
{
    public abstract class CadastroDetalhe : CadastroMestre
    {
        public virtual CadastroMestre Mestre { get; set; }
    }
}