using System;

namespace MVCCastleNHibernate.Core.Data.Entities
{
    public class Cliente : Entity<int>
    {
        public virtual string Nome { get; set; }
        public virtual string Telefone { get; set; }
        public virtual string Endereco { get; set; }
    }
}
