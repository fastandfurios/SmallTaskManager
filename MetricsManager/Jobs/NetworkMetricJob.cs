using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace MetricsManager.Jobs
{
	[DisallowConcurrentExecution]
    public class NetworkMetricJob : IJob
    {
	    public Task Execute(IJobExecutionContext context)
	    {
		    throw new NotImplementedException();
	    }
    }
}
