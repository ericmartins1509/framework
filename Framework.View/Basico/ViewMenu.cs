using Framework.Modelo.Entidade.Basico;
using Framework.View.MasterPage.Basico;
using System;

namespace Framework.View.Basico
{
    public abstract partial class ViewMenu<T> : ViewMestre<T> where T : CadastroBasico
    {
    }
}
