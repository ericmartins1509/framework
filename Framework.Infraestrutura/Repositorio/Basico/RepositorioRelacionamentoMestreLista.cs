using Framework.Infraestrutura.Servico.Basico;
using Framework.Modelo.Entidade.Basico;
using NHibernate;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Infraestrutura.Repositorio.Basico
{
    public class RepositorioRelacionamentoMestreLista<T> : RepositorioBasico<T> where T : CadastroRelacionamentoMestreLista
    {
        public override T AntesPersistir(T entidade, ISession sessao)
        {
            T retorno;

            if (entidade.Identificador != 0)
            {
                ServicoCadastroMestreLista<T> servico = new ServicoCadastroMestreLista<T>();
                retorno = servico.Obter(entidade.Identificador, sessao);
                if (retorno != null)
                {
                    retorno.CloneEntidade(entidade);

                    var detalhesQueNaoSeraoRemovidos = retorno.Detalhes.Where(t => entidade.Detalhes.Any(a => a.Detalhe.Identificador == t.Detalhe.Identificador)).ToList();
                    var detalhesQueSeraoAdicionados = entidade.Detalhes.Where(t => !retorno.Detalhes.Any(a => a.Detalhe.Identificador == t.Detalhe.Identificador)).ToList();

                    if (retorno.Detalhes == null)
                    {
                        retorno.Detalhes = new List<MestreDetalhe>();
                    }
                    else
                    {
                        retorno.Detalhes.Clear();
                    }

                    foreach (var detalhe in detalhesQueNaoSeraoRemovidos)
                    {
                        var detalheQueNaoSeraRemovido = entidade.Detalhes.
                            FirstOrDefault(t => t.Detalhe.Identificador == detalhe.Detalhe.Identificador);

                        detalhe.CloneEntidade(detalheQueNaoSeraRemovido);

                        detalhe.Mestre = entidade;

                        retorno.Detalhes.Add(detalhe);
                    }

                    foreach (var detalhe in detalhesQueSeraoAdicionados)
                    {
                        retorno.Detalhes.Add(detalhe);
                    }
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

            foreach (var detalhe in retorno.Detalhes)
            {
                detalhe.Mestre = entidade;
            }

            return retorno; //.As<T>();
        }
    }
}
