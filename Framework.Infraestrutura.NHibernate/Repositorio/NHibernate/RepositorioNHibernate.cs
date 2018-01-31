using Framework.Modelo.Entidade.Basico;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Linq;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Infraestrutura.NHibernate.Repositorio.NHibernate
{
    public abstract class RepositorioNHibernate<T> where T : CadastroBasico
    {
        private static readonly ISessionFactory SessionFactory = Configurar().BuildSessionFactory();

        private static Configuration Configurar()
        {
            Configuration configuration = new Configuration();

            configuration.Configure();

# if DEBUG
            String conexao = @"Data Source=DESKTOP-B0UTKNJ;Initial Catalog=ericrm;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
#else
            String conexao = @"Data Source=mssql6.gear.host;Initial Catalog=ericrm;Persist Security Info=True;User ID=ericrm;Password=Erm1509@";
#endif

            configuration.SetProperty("connection.connection_string", conexao);

            return configuration;
        }

        protected static ISession GetSessao()
        {
            return SessionFactory.OpenSession();
        }

        public static void GerarBaseDados()
        {
            SchemaExport schemaExport = new SchemaExport(Configurar());

            //schemaExport.SetOutputFile("Script.SQL");

            schemaExport.Execute(true, true, false);
        }

        public static void AtualizarBaseDados()
        {
            SchemaUpdate schemaUpdate = new SchemaUpdate(Configurar());

            schemaUpdate.Execute(true, true);
        }

        public T Obter(Int32 identificador, ISession sessao)
        {
            try
            {
                if (sessao == null)
                {
                    return GetSessao().Get<T>(identificador);
                }
                else
                {
                    return sessao.Get<T>(identificador);
                }
            }
            catch
            {
                throw;
            }
        }

        public T Obter(Int32 identificador)
        {
            try
            {
                return GetSessao().Get<T>(identificador);
            }
            catch
            {
                throw;
            }
        }

        public IList<T> ObterTodos()
        {
            try
            {
                return (from m
                        in GetSessao().
                           Query<T>()
                        select m).ToList<T>();
            }
            catch
            {
                throw;
            }
        }

        public IList<T> ObterTodosDescricao(String busca)
        {
            try
            {
                return (from m in GetSessao().
                           Query<T>().
                              Where<T>(m => m.Descricao.Contains(busca))
                        select m).ToList<T>();
            }
            catch
            {
                throw;
            }
        }

        public IList<T> ObterTodosDescricaoObservacao(String busca)
        {
            try
            {
                return (from m in GetSessao().
                           Query<T>().
                              Where<T>(m => m.Descricao.Contains(busca) || m.Observacao.Contains(busca))
                        select m).ToList<T>();
            }
            catch
            {
                throw;
            }
        }

        public void Salvar(T entidade)
        {
            using (var session = GetSessao())
            {
                session.BeginTransaction();
                try
                {
                    entidade = AntesPersistir(entidade, session);
                    session.SaveOrUpdate(entidade);
                    DepoisPersistir(entidade);
                    session.Transaction.Commit();
                }
                catch
                {
                    session.Transaction.Rollback();
                    throw;
                }
            }
        }

        public void SalvarLista(IList<T> entidades)
        {
            using (var session = GetSessao())
            {
                session.BeginTransaction();

                try
                {
                    AntesPersistirLista(entidades);
                    foreach (T entidade in entidades)
                    {
                        Salvar(entidade);
                    }
                    DepoisPersistirLista(entidades);
                    session.Transaction.Commit();
                }
                catch
                {
                    session.Transaction.Rollback();
                    throw;
                }
            }
        }

        public void Inserir(T entidade)
        {
            using (var session = SessionFactory.OpenSession())
            {
                session.BeginTransaction();
                try
                {
                    //AntesPersistir(entidade);
                    session.Save(entidade);
                    DepoisPersistir(entidade);
                    session.Transaction.Commit();
                }
                catch
                {
                    session.Transaction.Rollback();
                    throw;
                }
            }
        }

        public void Alterar(T entidade)
        {
            using (var session = SessionFactory.OpenSession())
            {
                session.BeginTransaction();

                try
                {
                    //AntesPersistir(entidade);
                    session.Update(entidade);
                    DepoisPersistir(entidade);
                    session.Transaction.Commit();
                }
                catch
                {
                    session.Transaction.Rollback();
                    throw;
                }
            }
        }

        public void Excluir(T entidade)
        {
            using (var session = SessionFactory.OpenSession())
            {
                session.BeginTransaction();

                try
                {
                    entidade = AntesPersistir(entidade, session);
                    session.Delete(entidade);
                    DepoisPersistir(entidade);
                    session.Transaction.Commit();
                }
                catch
                {
                    session.Transaction.Rollback();
                    throw;
                }
            }
        }

        public virtual T AntesPersistir(T entidade, ISession sessao)
        {
            return entidade;
        }

        private void AntesPersistirLista(IList<T> entidades)
        {
            foreach (T entidade in entidades)
            {
                //AntesPersistir(entidade);
            }
        }

        public virtual void DepoisPersistir(T entidade)
        {
        }

        private void DepoisPersistirLista(IList<T> entidades)
        {
            foreach (T entidade in entidades)
            {
                DepoisPersistir(entidade);
            }
        }
    }
}
