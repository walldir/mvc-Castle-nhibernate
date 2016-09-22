using System;
using System.Linq;
using MVCCastleNHibernate.Core.Data.Entities;
using MVCCastleNHibernate.Core.Data.Repositories;
using NHibernate;
using NHibernate.Linq;

namespace MVCCastleNHibernate.Data.NHibernate
{
    public abstract class NhRepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>
    {
        protected ISession Session { get { return NhUnitOfWork.Current.Session; } }

        public IQueryable<TEntity> GetAll()
        {
            return Session.Query<TEntity>();
        }

        public TEntity Get(TPrimaryKey key)
        {
            return Session.Get<TEntity>(key);
        }

        public void Insert(TEntity entity)
        {
            Session.Save(entity);
        }

        public void Update(TEntity entity)
        {
            Session.Update(entity);
        }

        public void Delete(TPrimaryKey id)
        {
            Session.Delete(Session.Load<TEntity>(id));
        }
    }
}
