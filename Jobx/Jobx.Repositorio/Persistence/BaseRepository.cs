using Jobx.Repositorio.Contracts;
using Jobx.Repositorio.Util;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobx.Repositorio.Persistence
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        public virtual void Insert(T obj)
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                var t = s.BeginTransaction();
                s.Save(obj);
                t.Commit();
            }
        }

        public virtual void Update(T obj)
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                var t = s.BeginTransaction();
                s.Update(obj);
                t.Commit();
            }
        }

        public virtual void Delete(T obj)
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                var t = s.BeginTransaction();
                s.Delete(obj);
                t.Commit();
            }
        }

        public virtual List<T> FindAll()
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                return s.Query<T>().ToList();
            }
        }

        public virtual T FindById(int id)
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                return s.Get<T>(id);
            }
        }
    }
}
