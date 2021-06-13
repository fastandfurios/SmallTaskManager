using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetricsAgent.Models;

namespace MetricsAgent.Repositories.DotNetMetricsRepository
{
    public class DotNetMetricsRepository : IDotNetMetricsRepository
    {
	    public void Create(DotNetMetric item)
	    {
		    throw new NotImplementedException();
	    }

	    public IList<DotNetMetric> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
	    {
		    throw new NotImplementedException();
	    }
    }
}
