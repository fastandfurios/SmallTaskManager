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
    public class RamMetricJob : IJob
    {
	    private readonly IRamMetricsRepository _repository;
	    private readonly PerformanceCounter _ramCounter;

	    public RamMetricJob(IRamMetricsRepository repository)
	    {
		    _repository = repository;

			if(OperatingSystem.IsWindows())
				_ramCounter = new PerformanceCounter("Memory", "Available MBytes");
	    }

	    public Task Execute(IJobExecutionContext context)
	    {
		    if (OperatingSystem.IsWindows())
		    {
			    var ramUsageInPercents = Convert.ToInt32(_ramCounter.NextValue());
			    var time = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

				_repository.Create(new RamMetric
				{
					Time = time,
					Value = ramUsageInPercents
				});
		    }
		    
			return Task.CompletedTask;
	    }
    }
}
