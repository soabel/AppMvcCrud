using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soabel.DemoCrud.Persistence
{
    public interface IUnitOfWork: IDisposable
    {
        void Commit();
    }
}
