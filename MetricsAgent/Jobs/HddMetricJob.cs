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
    public class HddMetricJob : IJob
    {
	    private readonly IHddMetricsRepository _repository;
	    private readonly PerformanceCounter _hddCounter;

	    public HddMetricJob(IHddMetricsRepository repository)
	    {
		    _repository = repository;

		    if (OperatingSystem.IsWindows())
			    _hddCounter = new PerformanceCounter("PhysicalDisk", "% Disk Time", "0 C:");
	    }

	    public Task Execute(IJobExecutionContext context)
	    {
		    if (OperatingSystem.IsWindows())
		    {
			    var hddUsageInPercents = Convert.ToInt32(_hddCounter.NextValue());
			    var time = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

				_repository.Create(new HddMetric
				{
					Time = time,
					Value = hddUsageInPercents
				});
		    }

		    return Task.CompletedTask;
	    }
    }
}
