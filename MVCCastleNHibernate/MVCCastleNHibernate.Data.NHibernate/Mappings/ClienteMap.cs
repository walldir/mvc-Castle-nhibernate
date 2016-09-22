using FluentNHibernate.Mapping;
using MVCCastleNHibernate.Core.Data.Entities;

namespace MVCCastleNHibernate.Data.NHibernate.Mappings
{
    public class ClienteMap : ClassMap<Cliente>
    {
        public ClienteMap()
        {
            Table("Cliente");
            Id(x => x.Id).Column("ClienteId");
            Map(x => x.Nome);
            Map(x => x.Endereco);
            Map(x => x.Telefone);
        }
    }
}
