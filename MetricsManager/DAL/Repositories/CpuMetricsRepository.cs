using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetricsManager.DAL.Interfaces;
using MetricsManager.DAL.Models;

namespace MetricsManager.DAL.Repositories
{
    public class CpuMetricsRepository : ICpuMetricsRepository
    {
	    public void Create(CpuMetric item)
	    {
		    throw new NotImplementedException();
	    }

	    public DateTimeOffset GetMaxDate()
	    {
		    throw new NotImplementedException();
	    }

	    public IList<CpuMetric> GetMetricsFromAgent(int agentId, DateTimeOffset fromTime, DateTimeOffset toTime)
	    {
		    throw new NotImplementedException();
	    }

	    public IList<CpuMetric> GetMetricsFromAllCluster(DateTimeOffset fromTime, DateTimeOffset toTime)
	    {
		    throw new NotImplementedException();
	    }
    }
}
