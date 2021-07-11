using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace MetricsManager.Jobs
{
    public class DotNetMetricJob : IJob
    {
	    public Task Execute(IJobExecutionContext context)
	    {
		    throw new NotImplementedException();
	    }
    }
}
