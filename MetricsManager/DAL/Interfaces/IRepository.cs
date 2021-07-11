using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricsManager.DAL.Interfaces
{
    public interface IRepository<T, in D> where T : class
    {
	    void Create(T item);
	    T GetEnabledAgent(D item);
	    T GetDisabledAgent(D item);
	    IList<T> GetRegisterObjects();
    }
}
