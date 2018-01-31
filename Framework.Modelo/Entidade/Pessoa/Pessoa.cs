using Framework.Modelo.Entidade.Basico;
using System.Collections.Generic;

namespace Framework.Modelo.Entidade.Pessoa
{
    public class Pessoa : CadastroMestre
    {
        public virtual TipoPessoa TipoPessoa { get; set; }
        public virtual IList<PessoaDocumento> Documentos { get; set; }
        public virtual IList<PessoaEndereco> Enderecos { get; set; }
        //public virtual IList<PessoaEmail> Emails { get; set; }
        //public virtual IList<PessoaTelefone> Telefones { get; set; }

        public override void CloneEntidade<T>(T entidade)
        {
            base.CloneEntidade(entidade);

            Pessoa pessoa = (entidade as Pessoa);
            TipoPessoa = pessoa.TipoPessoa;
        }

        public Pessoa()
        {
            TipoPessoa = new TipoPessoa();
            Documentos = new List<PessoaDocumento>();
            Enderecos = new List<PessoaEndereco>();
        }
    }
}
