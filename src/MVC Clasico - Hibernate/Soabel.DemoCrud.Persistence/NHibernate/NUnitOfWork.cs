using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soabel.DemoCrud.Persistence.NHibernate
{
    public class NUnitOfWork : IUnitOfWork, IDisposable
    {
        //TODO: PENDIENTE - El UnitOfWork debe aplicar solo para los cas transaccionales, no para los queries
        private ISession session;
        public NUnitOfWork() {
            this.session = NHibernateHelperExtend.GetSession();
        }
        public void Commit()
        {
            throw new NotImplementedException("No implementado");
        }

        public void Commit(Action action)
        {            
            using (ITransaction tx = session.BeginTransaction()) {
                action.Invoke();
                tx.Commit();
            }
        }

        public ISession GetSession() {
            return this.session;
        }
        
        public void Dispose()
        {}
    }
}
