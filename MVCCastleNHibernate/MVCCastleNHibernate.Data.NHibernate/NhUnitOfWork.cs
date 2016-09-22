using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCCastleNHibernate.Core.Data;
using NHibernate;

namespace MVCCastleNHibernate.Data.NHibernate
{
    public class NhUnitOfWork : IUnitOfWork
    {
        [ThreadStatic]
        private static NhUnitOfWork _current;

        public static NhUnitOfWork Current
        {
            get { return _current; }
            set { _current = value; }
        }

        public  ISession Session { get; private set; }

        public readonly ISessionFactory _sessionFactory;

        private ITransaction _transaction;

        public NhUnitOfWork(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public void BeginTransaction()
        {
            Session = _sessionFactory.OpenSession();
            _transaction = Session.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            finally
            {
                Session.Close();
            }
        }

        public void Rollback()
        {
            try
            {
                _transaction.Rollback();
            }
            finally
            {
                Session.Close();
            }
        }
    }
}
