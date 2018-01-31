using Framework.Modelo.Entidade.Basico;
using System;

namespace Framework.Modelo.Entidade.Pessoa
{
    public class PessoaDocumento : CadastroDetalhe
    {
        public virtual RelacionamentoTipoPessoaTipoDocumento Documento { get; set; }
        public virtual Int32 TipoDocumentoIdentificador { get { return Documento.Identificador; } }
        public virtual String TipoDocumentoDetalheDescricao { get { return Documento.DetalheDescricao; } }
        
        public PessoaDocumento()
        {
            Documento = new RelacionamentoTipoPessoaTipoDocumento();
        }

        public override void CloneEntidade<T>(T entidade)
        {
            base.CloneEntidade<T>(entidade);

            PessoaDocumento pessoaDocumento = (entidade as PessoaDocumento);
        } 
    }
}
