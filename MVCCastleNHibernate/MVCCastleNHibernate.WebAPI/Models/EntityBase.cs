using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCastleNHibernate.WebAPI.Models
{
    public abstract class EntityBase
    {
        public virtual int Id { get; private set; }
    }
}