using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetricsAgent.Models;

namespace MetricsAgent.Repositories.NetworkMetricsRepository
{
    public class NetworkMetricsRepository : INetworkMetricsRepository
    {
	    public void Create(NetworkMetric item)
	    {
		    throw new NotImplementedException();
	    }

	    public IList<NetworkMetric> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
	    {
		    throw new NotImplementedException();
	    }
    }
}
