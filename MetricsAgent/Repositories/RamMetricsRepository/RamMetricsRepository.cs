using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetricsAgent.Models;

namespace MetricsAgent.Repositories.RamMetricsRepository
{
    public class RamMetricsRepository : IRamMetricsRepository
    {
	    public void Create(RamMetric item)
	    {
		    throw new NotImplementedException();
	    }

	    public IList<RamMetric> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
	    {
		    throw new NotImplementedException();
	    }
    }
}
