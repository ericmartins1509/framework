using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Modelo.Entidade.Basico;

namespace Framework.Modelo.Entidade.Auxiliar
{
    public abstract class EmailBasico : CadastroDetalhe
    {
        public virtual String Email { get; set; }
    }
}
