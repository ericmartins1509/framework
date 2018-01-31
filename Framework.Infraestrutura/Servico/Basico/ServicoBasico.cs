using Framework.Infraestrutura.Repositorio.Basico;
using Framework.Modelo.Entidade.Basico;
using NHibernate;
using System;
using System.Collections.Generic;

namespace Framework.Infraestrutura.Servico.Basico
{
    public abstract class ServicoBasico<T> where T : CadastroBasico
    {
        public virtual RepositorioBasico<T> GetRepositorio()
        {
            return new RepositorioBasico<T>();
        }

        public T Obter(Int32 identificador, ISession sessao)
        {
            return GetRepositorio().Obter(identificador, sessao);
        }

        public T Obter(Int32 identificador)
        {
            return GetRepositorio().Obter(identificador);
        }

        public IList<T> ObterTodos()
        {
            return GetRepositorio().ObterTodos();
        }

        public IList<T> ObterTodosDescricao(String descricao)
        {
            return GetRepositorio().ObterTodosDescricao(descricao);
        }

        public IList<T> ObterTodosDescricaoObservacao(String descricao)
        {
            return GetRepositorio().ObterTodosDescricaoObservacao(descricao);
        }

        public void Salvar(T entidade)
        {
            GetRepositorio().Salvar(entidade);
        }

        public void Excluir(T entidade)
        {
            GetRepositorio().Excluir(entidade);
        }
    }
}
