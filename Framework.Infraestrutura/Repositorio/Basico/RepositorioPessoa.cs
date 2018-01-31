using Framework.Infraestrutura.Servico.Basico;
using Framework.Modelo.Entidade.Pessoa;
using System.Collections.Generic;
using System.Linq;
using Framework.Infraestrutura.Repositorio.Basico;
using NHibernate;

namespace Framework.Infraestrutura.Repositorio.Basico
{
    public class RepositorioPessoa<T> : RepositorioBasico<T> where T : Pessoa
    {
        public override T AntesPersistir(T entidade, ISession sessao)
        {
            T retorno;

            entidade.TipoPessoa.Mestre = entidade;

            if (entidade.Identificador != 0)
            {
                ServicoCadastroMestre<T> servico = new ServicoCadastroMestre<T>();
                retorno = servico.Obter(entidade.Identificador, sessao);
                if (retorno != null)
                {
                    retorno.CloneEntidade(entidade);

                    TrataDocumentos(entidade, retorno);
                    TrataEnderecos(entidade, retorno);
                }
                else
                {
                    retorno = entidade;
                }
            }
            else
            {
                retorno = entidade;
            }

            foreach (var documento in retorno.Documentos)
            {
                documento.Mestre = retorno;
            }

            foreach (var endereco in retorno.Enderecos)
            {
                endereco.Mestre = retorno;
            }

            return retorno;
        }

        private static void TrataDocumentos(T entidade, T retorno)
        {
            var documentosQueNaoSeraoRemovidos = retorno.Documentos.Where(t => entidade.Documentos.Any(a => a.Identificador == t.Identificador)).ToList();
            var documentosQueSeraoAdicionados = entidade.Documentos.Where(t => !retorno.Documentos.Any(a => a.Identificador == t.Identificador)).ToList();

            if (retorno.Documentos == null)
            {
                retorno.Documentos = new List<PessoaDocumento>();
            }
            else
            {
                retorno.Documentos.Clear();
            }

            foreach (var documento in documentosQueNaoSeraoRemovidos)
            {
                var documentoQueNaoSeraRemovido = entidade.Documentos.
                    FirstOrDefault(t => t.Documento.Identificador == documento.Documento.Identificador);

                documento.CloneEntidade(documentoQueNaoSeraRemovido);

                documento.Mestre = entidade;

                retorno.Documentos.Add(documento);
            }

            foreach (var documento in documentosQueSeraoAdicionados)
            {
                retorno.Documentos.Add(documento);
            }
        }

        private static void TrataEnderecos(T entidade, T retorno)
        {
            var enderecosQueNaoSeraoRemovidos = retorno.Enderecos.Where(t => entidade.Enderecos.Any(a => a.Identificador == t.Identificador)).ToList();
            var enderecosQueSeraoAdicionados = entidade.Enderecos.Where(t => !retorno.Enderecos.Any(a => a.Identificador == t.Identificador)).ToList();

            if (retorno.Enderecos == null)
            {
                retorno.Enderecos = new List<PessoaEndereco>();
            }
            else
            {
                retorno.Enderecos.Clear();
            }

            foreach (var endereco in enderecosQueNaoSeraoRemovidos)
            {
                var enderecoQueNaoSeraRemovido = entidade.Enderecos.
                    FirstOrDefault(t => t.Identificador == endereco.Identificador);

                endereco.CloneEntidade(enderecoQueNaoSeraRemovido);

                endereco.Mestre = entidade;

                retorno.Enderecos.Add(endereco);
            }

            foreach (var endereco in enderecosQueSeraoAdicionados)
            {
                retorno.Enderecos.Add(endereco);
            }
        }
    }
}
