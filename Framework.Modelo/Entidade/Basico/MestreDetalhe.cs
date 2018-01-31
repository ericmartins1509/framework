using System;

namespace Framework.Modelo.Entidade.Basico
{
    public abstract class MestreDetalhe : CadastroBasico
    {
        public virtual CadastroMestre Mestre { get; set; }
        public virtual CadastroMestre Detalhe { get; set; }
    }
}
