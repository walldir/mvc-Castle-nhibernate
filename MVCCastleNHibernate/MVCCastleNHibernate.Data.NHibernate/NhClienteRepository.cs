using MVCCastleNHibernate.Core.Data.Entities;
using MVCCastleNHibernate.Core.Data.Repositories;

namespace MVCCastleNHibernate.Data.NHibernate
{
    public class NhClienteRepository : NhRepositoryBase<Cliente, int>, IClienteRepository
    {
    }
}
