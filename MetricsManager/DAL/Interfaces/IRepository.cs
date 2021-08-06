using System.Collections.Generic;

namespace MetricsManager.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
	    void Create(T item);
	    T EnableAgent(int item);
	    T DisableAgent(int item);
	    IEnumerable<T> GetRegisterObjects();
    }
}
