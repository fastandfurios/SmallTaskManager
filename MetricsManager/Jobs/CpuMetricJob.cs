using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetricsManager.Client;
using MetricsManager.DAL.Interfaces;
using Quartz;

namespace MetricsManager.Jobs
{
    public class CpuMetricJob : IJob
    {
	    private readonly IAgentsRepository _agentsRepository;
	    private readonly ICpuMetricsRepository _cpuMetricsRepository;
	    private readonly IMetricsAgentClient _agentClient;

	    public CpuMetricJob(IAgentsRepository agentsRepository,
		    ICpuMetricsRepository cpuMetricsRepository,
		    IMetricsAgentClient agentClient)
	    {
		    _agentsRepository = agentsRepository;
		    _cpuMetricsRepository = cpuMetricsRepository;
		    _agentClient = agentClient;
	    }

	    public Task Execute(IJobExecutionContext context)
	    {


		    return Task.CompletedTask;
	    }
    }
}
