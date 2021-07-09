using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.DAL.Models;
using Quartz;

namespace MetricsAgent.Jobs
{
    public class DotNetMetricJob : IJob
    {
	    private readonly IDotNetMetricsRepository _repository;
	    private readonly PerformanceCounter _counter;

	    public DotNetMetricJob(IDotNetMetricsRepository repository)
	    {
		    _repository = repository;

		    if (OperatingSystem.IsWindows())
			    _counter = new PerformanceCounter("ASP.NET", "Error Events Raised");
	    }

	    public Task Execute(IJobExecutionContext context)
	    {
		    if (OperatingSystem.IsWindows())
		    {
			    var dotnetUsageInPercents = Convert.ToInt32(_counter.NextValue());
			    var time = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

				_repository.Create(new DotNetMetric
				{
					Value = dotnetUsageInPercents,
					Time = time
				});
		    }

		    return Task.CompletedTask;
	    }
    }
}
