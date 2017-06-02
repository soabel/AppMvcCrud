using NHibernate;
using Soabel.DemoCrud.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Soabel.DemoCrud.Persistence.NHibernate
{
    public class NRepository<T> : IRepository<T> where T : class
    {
        private IUnitOfWork unitOfWork;
        public NRepository(IUnitOfWork unitOfWork) {
            this.unitOfWork = unitOfWork;
        }
        public void Add(T entity)
        {
            ((NUnitOfWork)unitOfWork).GetSession().Save(entity);
        }

        public IEnumerable<T> Query(Expression<Func<T, bool>> expresion=null)
        {
            var query = ((NUnitOfWork)unitOfWork).GetSession().QueryOver<T>();
            if (expresion != null)             
                query.Where(expresion);
            return query.Future();
        }

        public void Remove(T entity)
        {
            ((NUnitOfWork)this.unitOfWork).GetSession().Delete(entity);
        }

        public void Update(T entity)
        {
            ((NUnitOfWork)this.unitOfWork).GetSession().Update(entity);
        }
    }
}
