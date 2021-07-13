using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricsManager.DAL.Interfaces
{
    public interface IMetricsRepository<T>
    {
	    void Create(T item);
	    DateTimeOffset GetMaxDate();
	    IList<T> GetMetricsFromAgent(int agentId, DateTimeOffset fromTime, DateTimeOffset toTime);
	    IList<T> GetMetricsFromAllCluster(DateTimeOffset fromTime, DateTimeOffset toTime);
    }
}
