using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Modelo.Entidade.Basico;

namespace Framework.Modelo.Entidade.Auxiliar
{
    public abstract class TelefoneBasico : CadastroDetalhe
    {
        public virtual String Pais { get; set; }
        public virtual String DDD { get; set; }
        public virtual String Telefone { get; set; }
        public virtual String Complemento { get; set; }
    }
}
