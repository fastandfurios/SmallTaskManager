using System.Collections.Generic;

namespace MetricsManager.DAL.Interfaces
{
    public interface IRepository<T, in D> where T : class
    {
	    void Create(T item);
	    T EnableAgent(D item);
	    T DisableAgent(D item);
	    IList<T> GetRegisterObjects();
    }
}
