using Framework.Modelo.Entidade.Basico;
using System;

namespace Framework.Modelo.Entidade
{
    public class RelacionamentoTipoPessoaTiposDocumento : MestreDetalhe
    {
        public virtual Boolean Obrigatorio { get; set; }

        public override void CloneEntidade<T>(T entidade)
        {
            RelacionamentoTipoPessoaTiposDocumento relacionamentoTipoPessoaTiposDocumento = (entidade as RelacionamentoTipoPessoaTiposDocumento);

            Obrigatorio = relacionamentoTipoPessoaTiposDocumento.Obrigatorio;
        }

        public RelacionamentoTipoPessoaTiposDocumento()
        {
            Mestre = new TipoPessoa();
            Detalhe = new TipoDocumento();
        }

        //public override CadastroMestre GetMeste()
        //{
        //    return new TipoPessoa();
        //}

        //public override CadastroMestre GetDetalhe()
        //{
        //    return new TipoDocumento();
        //}
    }
}
