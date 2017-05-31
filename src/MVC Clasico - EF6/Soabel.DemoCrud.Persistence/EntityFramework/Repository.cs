using Soabel.DemoCrud.Domain.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
        

        public IQueryable<T> Query()
        {
            return this.dbSet;
        }

        public void Remove(T entity)
        {
            this.dbSet.Remove(entity);
        }
        
    }
}
