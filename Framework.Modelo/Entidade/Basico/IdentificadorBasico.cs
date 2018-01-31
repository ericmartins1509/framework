using System;

namespace Framework.Modelo.Entidade.Basico
{
    public abstract class IdentificadorBasico
    {
        public virtual Int32 Identificador { get; set; }

        public virtual void CloneEntidade<T>(T entidade) where T : IdentificadorBasico
        {
            //Identificador = entidade.Identificador;
        }
    }
}
