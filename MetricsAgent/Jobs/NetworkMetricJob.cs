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
    public class NetworkMetricJob : IJob
    {
	    private readonly INetworkMetricsRepository _repository;
	    private readonly PerformanceCounter _counter;

	    public NetworkMetricJob(INetworkMetricsRepository repository)
	    {
		    _repository = repository;

		    if (OperatingSystem.IsWindows())
			    _counter = new PerformanceCounter("Network Interface", "Bytes Sent/sec", "Realtek PCIe GbE Family Controller _2");
	    }

	    public Task Execute(IJobExecutionContext context)
	    {
		    if (OperatingSystem.IsWindows())
		    {
			    var networkUsageInPercent = Convert.ToInt32(_counter.NextValue());
			    var time = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

				_repository.Create(new NetworkMetric
				{
					Value = networkUsageInPercent,
					Time = time
				});
		    }

		    return Task.CompletedTask;
	    }
    }
}
