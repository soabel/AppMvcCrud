using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Soabel.DemoCrud.Domain.Base
{
    public interface IRepository<T>
    {
        IEnumerable<T> Query(Expression<Func<T, bool>> expresion=null);     
        void Add(T entity);
        void Remove(T entity);

        void Update(T entity);

    }
}
