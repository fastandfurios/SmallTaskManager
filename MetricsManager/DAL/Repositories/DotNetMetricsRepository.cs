using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetricsManager.DAL.Interfaces;
using MetricsManager.DAL.Models;

namespace MetricsManager.DAL.Repositories
{
    public class DotNetMetricsRepository : IDotNetMetricsRepository
    {
	    public void Create(DotNetMetric item)
	    {
		    throw new NotImplementedException();
	    }

	    public DateTimeOffset GetMaxDate()
	    {
		    throw new NotImplementedException();
	    }

	    public IList<DotNetMetric> GetMetricsFromAgent(int agentId, DateTimeOffset fromTime, DateTimeOffset toTime)
	    {
		    throw new NotImplementedException();
	    }

	    public IList<DotNetMetric> GetMetricsFromAllCluster(DateTimeOffset fromTime, DateTimeOffset toTime)
	    {
		    throw new NotImplementedException();
	    }
    }
}
