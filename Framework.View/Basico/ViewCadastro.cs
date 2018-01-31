using Framework.Infraestrutura.Servico.Basico;
using Framework.Modelo.Entidade.Basico;
using Framework.View.MasterPage.Basico;
using System;
using System.Web.UI.HtmlControls;

namespace Framework.View.Basico
{
    public abstract class ViewCadastro<T> : ViewMestre<T> where T : CadastroBasico
    {
        #region Evento

        public virtual EventHandler GetEventoClickbtnGravar()
        {
            return Gravar;
        }

        public virtual EventHandler GetEventoClickbtnExcluir()
        {
            return Excluir;
        }

        public virtual EventHandler GetEventoTextChangedtxtID()
        {
            return GetIdentificador;
        }

        public virtual void Gravar(object sender, EventArgs e)
        {
            T entidade = GetEntidade();

            GetControles(entidade);

            var servico = GetServico();

            servico.Salvar(entidade);

            LimpaTela();
        }

        public virtual void Excluir(object sender, EventArgs e)
        {
            T entidade = GetEntidade();

            GetControles(entidade);

            var servico = GetServico();

            servico.Excluir(entidade);

            LimpaTela();
        }

        public virtual void GetIdentificador(object sender, EventArgs e)
        {
            if (MasterCadastro().txtIdentificador.Text.ToString() != "")
            {
                var servico = GetServico();

                T entidade = servico.Obter(Convert.ToInt32(MasterCadastro().txtIdentificador.Text.ToString()), null);

                if (entidade != null)
                {
                    SetControles(entidade);
                }
                else
                {
                    LimpaTela(false);
                }
            }
        }
        #endregion

        #region Tela
        public abstract ServicoCadastro<T> GetServico();

        public abstract T GetEntidade();

        //private static T GetInstanciaDoTipo<T>(string nomeTipo)
        //{
        //    return
        //        (T)Assembly.GetExecutingAssembly()
        //            .GetTypes()
        //            .Where(t => t.Name == nomeTipo)
        //            .Where(t => typeof(T).IsAssignableFrom(t))
        //            .Select(Activator.CreateInstance)
        //            .First();
        //}

        //public virtual T GetEntidade()
        //{
        //    return GetInstanciaDoTipo<T>("TipoDocumento");
        //}

        public override ViewMasterMestre MasterMestre()
        {
            return ((ViewMasterMestre)((ViewMasterCadastro)Master).Master);
        }

        public virtual ViewMasterCadastro MasterCadastro()
        {
            return ((ViewMasterCadastro)Master);
        }

        public override void SetupTela()
        {
            base.SetupTela();

            MasterCadastro().lblIdentificador.Text = "Identificador";
            MasterCadastro().lblIdentificadorErro.Text = "Identificador não encontrado";
            MasterCadastro().lblDescricao.Text = "Descrição";
            MasterCadastro().lblObservacao.Text = "Observação";
            MasterCadastro().chkInativo.Text = "Inativo";
            MasterCadastro().btnGravar.Text = "Gravar";
            MasterCadastro().btnExcluirSim.Text = "Sim";
            MasterCadastro().btnExcluirNao.Text = "Não";

            MasterCadastro().txtIdentificador.TextChanged += GetIdentificador;
            MasterCadastro().btnGravar.Click += GetEventoClickbtnGravar();
            MasterCadastro().btnExcluirSim.Click += GetEventoClickbtnExcluir();

            MasterCadastro().ifPesquisa.Src = GetPesquisa();
        }

        public abstract string GetPesquisa();

        public override void LimpaTela()
        {
            LimpaTela(true);
        }

        private void LimpaTela(Boolean limpaIdentificador)
        {
            if (limpaIdentificador)
            {
                MasterCadastro().txtIdentificador.Text = String.Empty;
                MasterCadastro().lblIdentificadorErro.Visible = false;
            }
            else
            {
                MasterCadastro().lblIdentificadorErro.Visible = true;
            }

            LimpaCampos();
        }

        public virtual void LimpaCampos()
        {
            MasterCadastro().txtDescricao.Text = String.Empty;
            MasterCadastro().txtObservacao.Text = String.Empty;
            MasterCadastro().chkInativo.Checked = false;
        }

        public virtual void GetControles(T entidade)
        {
            if (entidade != null)
            {
                if (MasterCadastro().txtIdentificador.Text.ToString() != "")
                {
                    entidade.Identificador = Convert.ToInt32(MasterCadastro().txtIdentificador.Text.ToString());
                }
                entidade.Descricao = MasterCadastro().txtDescricao.Text.ToString();
                entidade.Observacao = MasterCadastro().txtObservacao.Text.ToString();
                entidade.Inativo = MasterCadastro().chkInativo.Checked;
            }
        }

        public virtual void SetControles(T entidade)
        {
            LimpaTela();

            MasterCadastro().txtIdentificador.Text = entidade.Identificador.ToString();
            MasterCadastro().txtDescricao.Text = entidade.Descricao;
            MasterCadastro().txtObservacao.Text = entidade.Observacao;
            MasterCadastro().chkInativo.Checked = entidade.Inativo;
        }
        #endregion
    }
}
