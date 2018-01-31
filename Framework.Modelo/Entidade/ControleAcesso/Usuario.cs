using Framework.Modelo.Entidade.Basico;
using System;

namespace Framework.Modelo.Entidade.ControleAcesso
{
    public class Usuario : IdentificadorBasico
    {
        public virtual Framework.Modelo.Entidade.Pessoa.Pessoa Pessoa { get; set; }
        public virtual String Senha { get; set; }
    }
}
