using Framework.Infraestrutura.NHibernate.Repositorio.NHibernate;
using Framework.Infraestrutura.Repositorio.Basico;
using Framework.Modelo.Entidade.Basico;
using Framework.View.Basico;
using System;
using System.Web.UI.WebControls;

namespace Framework.View.BaseDados
{
    public class ViewDefaultBaseDados : ViewMestre<CadastroBasico>
    {
        public Button btnGerarBaseDados { get; set; }
        public Button btnAtualizarBaseDados { get; set; }

        public override void SetupTela()
        {
            base.SetupTela();

            btnGerarBaseDados.Text = "Gerar Base de Dados";
            btnGerarBaseDados.Click += GerarBaseDados;

            btnAtualizarBaseDados.Text = "Atualizar Base de Dados";
            btnAtualizarBaseDados.Click += AtualizarBaseDados;
        }

        private void GerarBaseDados(object sender, EventArgs e)
        {
            RepositorioNHibernate<CadastroBasico>.GerarBaseDados();
        }

        private void AtualizarBaseDados(object sender, EventArgs e)
        {
            RepositorioNHibernate<CadastroBasico>.AtualizarBaseDados();
        }
    }
}
