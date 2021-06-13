using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetricsAgent.Models;

namespace MetricsAgent.Repositories.HddMetricsRepository
{
    public class HddMetricsRepository : IHddMetricsRepository
    {
	    public void Create(HddMetric item)
	    {
		    throw new NotImplementedException();
	    }

	    public IList<HddMetric> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
	    {
		    throw new NotImplementedException();
	    }
    }
}
