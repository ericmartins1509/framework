using Framework.Modelo.Entidade.Basico;
using System;

namespace Framework.Modelo.Entidade.ControleAcesso
{
    public class Permissao : MestreDetalhe
    {
        public virtual Boolean Consultar { get; set; }
        public virtual Boolean Gravar { get; set; }
        public virtual Boolean Excluir { get; set; }      
    }
}
