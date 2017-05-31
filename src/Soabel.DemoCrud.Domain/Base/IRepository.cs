using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soabel.DemoCrud.Domain.Base
{
    public interface IRepository<T>
    {
        IQueryable<T> Query();     
        void Add(T entity);
        void Remove(T entity);

    }
}
