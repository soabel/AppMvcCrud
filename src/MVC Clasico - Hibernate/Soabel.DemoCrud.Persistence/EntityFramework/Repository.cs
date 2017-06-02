using Soabel.DemoCrud.Domain.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Soabel.DemoCrud.Persistence.EntityFramework
{
    public class Repository<T>: IRepository<T> where T: class
    {

        private readonly DbSet<T> dbSet;

        public Repository(IUnitOfWork unitOfWork) {
            var localUnitOfWork = unitOfWork as UnitOfWork;
            if (localUnitOfWork == null) throw new Exception("Must be UnitOfWork");
            dbSet = localUnitOfWork.GetDbSet<T>();
        }

        public void Add(T entity)
        {
            this.dbSet.Add(entity);
        }        

        public IEnumerable<T> Query(Expression<Func<T, bool>> expresion=null)
        {
            if (expresion == null)
                return this.dbSet.AsEnumerable();
            return this.dbSet.Where(expresion).AsEnumerable();
        }

        public void Remove(T entity)
        {
            this.dbSet.Remove(entity);
        }

        public void Update(T entity)
        {   
        }
    }
}
