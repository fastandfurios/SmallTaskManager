using System.Collections.Generic;

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
