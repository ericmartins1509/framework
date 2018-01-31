using System;

namespace Framework.Modelo.Entidade.Basico
{
    public abstract class CadastroBasico : IdentificadorBasico
    {
        public virtual String Descricao { get; set; }
        public virtual String Observacao { get; set; }
        public virtual Boolean Inativo { get; set; }

        public override void CloneEntidade<T>(T entidade)
        {
            base.CloneEntidade(entidade);

            CadastroBasico cadastrobasico = (entidade as CadastroBasico);

            Descricao = cadastrobasico.Descricao;
            Observacao = cadastrobasico.Observacao;
            Inativo = cadastrobasico.Inativo;
        }
    }
}
