using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.DAL.Models;
using Quartz;

namespace MetricsAgent.Jobs
{
    public class CpuMetricJob : IJob
    {
	    private readonly ICpuMetricsRepository _repository;
	    private readonly PerformanceCounter _cpuCounter;

	    public CpuMetricJob(ICpuMetricsRepository repository)
	    {
		    _repository = repository;

		    if (OperatingSystem.IsWindows())
			    _cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
	    }

	    public Task Execute(IJobExecutionContext context)
	    {
		    if (OperatingSystem.IsWindows())
		    {
			    var cpuUsageInPercents = Convert.ToInt32(_cpuCounter.NextValue());
			    var time = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

				_repository.Create(new CpuMetric
				{
					Time = time,
					Value = cpuUsageInPercents
				});
			}

		    return Task.CompletedTask;
	    }
    }
}
