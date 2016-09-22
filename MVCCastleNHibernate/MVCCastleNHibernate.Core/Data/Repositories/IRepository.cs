using System.Linq;
using MVCCastleNHibernate.Core.Data.Entities;

namespace MVCCastleNHibernate.Core.Data.Repositories
{
    public interface IRepository
    {

    }

    public interface IRepository<TEntity, TPrimaryKey> : IRepository where TEntity : Entity<TPrimaryKey>
    {
        IQueryable<TEntity> GetAll();

        TEntity Get(TPrimaryKey key);

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TPrimaryKey id);
    }
}
