using System.Collections.Generic;

namespace Framework.Modelo.Entidade.Basico
{
    public abstract class CadastroRelacionamentoMestreLista : CadastroDetalhe
    {
        public virtual IList<MestreDetalhe> Detalhes { get; set; }

        public CadastroRelacionamentoMestreLista()
        {
            Detalhes = new List<MestreDetalhe>();
        }
    }
}
