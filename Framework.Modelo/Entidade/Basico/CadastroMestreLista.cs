using System.Collections.Generic;

namespace Framework.Modelo.Entidade.Basico
{
    public abstract class CadastroMestreLista : CadastroMestre
    {
        public virtual IList<MestreDetalhe> Detalhes { get; set; }

        //public abstract IList<MestreDetalhe> GetDetalhes();

        //public CadastroMestreLista()
        //{
        //    Detalhes = GetDetalhes();
        //}

        public CadastroMestreLista()
        {
            Detalhes = new List<MestreDetalhe>();
        }
    }
}
