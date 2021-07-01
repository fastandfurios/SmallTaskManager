using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricsAgent.Repositories
{
    public interface IRepository<T> where T : class
    {
	    void Create(T item);
	    IList<T> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime);
    }
}
