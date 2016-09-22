using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using  NHibernate;

namespace MVCCastleNHibernate.WebAPI.NHibernate
{
    public class SessionHelper
    {
        private NHibernateHelper _nHibernateHelper = null;

        public SessionHelper()
        {
            _nHibernateHelper = new NHibernateHelper();
        }

        public ISession Current
        {
            get { return _nHibernateHelper.GetCurrentSession(); }
        }

        public void CreateSession()
        {
            _nHibernateHelper.CreateSession();
        }

        public void ClearSession()
        {
            Current.Clear();
        }

        public void OpenSession()
        {
            _nHibernateHelper.OpenSession();
        }

        public void CloseSession()
        {
            _nHibernateHelper.CloseSession();
        }
    }
}