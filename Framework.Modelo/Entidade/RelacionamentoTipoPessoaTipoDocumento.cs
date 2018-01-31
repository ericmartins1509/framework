using Framework.Modelo.Entidade.Basico;
using System;

namespace Framework.Modelo.Entidade
{
    public class RelacionamentoTipoPessoaTipoDocumento : MestreDetalhe
    {
        public virtual Boolean Obrigatorio { get; set; }

        public virtual String DetalheDescricao { get { return Detalhe.Descricao; } }


        public override void CloneEntidade<T>(T entidade)
        {
            base.CloneEntidade(entidade);

            RelacionamentoTipoPessoaTipoDocumento relacionamentoTipoPessoaTiposDocumento = (entidade as RelacionamentoTipoPessoaTipoDocumento);

            Obrigatorio = relacionamentoTipoPessoaTiposDocumento.Obrigatorio;
        }

        public RelacionamentoTipoPessoaTipoDocumento()
        {
            Mestre = new TipoPessoa();
            Detalhe = new TipoDocumento();
        }
    }
}
