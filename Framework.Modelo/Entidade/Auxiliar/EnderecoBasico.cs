using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Modelo.Entidade.Basico;

namespace Framework.Modelo.Entidade.Auxiliar
{
    public abstract class EnderecoBasico : CadastroDetalhe
    {
        public virtual String CEP { get; set; }
        public virtual String Logradouro { get; set; }
        public virtual String Endereco { get; set; }
        public virtual String Numero { get; set; }
        public virtual String Complemento { get; set; }
        public virtual String Bairro { get; set; }
        public virtual String RegiaoAdministratriva { get; set; }
        public virtual String Municipio { get; set; }
        public virtual String Estado { get; set; }
        public virtual String Pais { get; set; }
    }
}
