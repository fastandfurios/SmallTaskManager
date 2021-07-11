using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetricsManager.Client;
using MetricsManager.DAL.Interfaces;
using MetricsManager.DAL.Models;
using MetricsManager.Requests;
using MetricsManager.Responses;
using MetricsManager.Responses.DTO;
using Quartz;

namespace MetricsManager.Jobs
{
    public class HddMetricJob : IJob
    {
	    private readonly IAgentsRepository _agentsRepository;
	    private readonly IHddMetricsRepository _hddMetricsRepository;
	    private readonly IMetricsAgentClient _metricsAgentClient;

	    public HddMetricJob(IAgentsRepository agentsRepository,
		    IHddMetricsRepository hddMetricsRepository,
		    IMetricsAgentClient metricsAgentClient)
	    {
		    _agentsRepository = agentsRepository;
		    _hddMetricsRepository = hddMetricsRepository;
		    _metricsAgentClient = metricsAgentClient;
	    }

	    public Task Execute(IJobExecutionContext context)
	    {
		    foreach (var registerObject in _agentsRepository.GetRegisterObjects())
		    {
			    _metricsAgentClient.GetAllHddMetrics(new GetAllHddMetricsApiRequest
			    {
					
			    });
		    }


		    _metricsAgentClient.GetAllHddMetrics(new GetAllHddMetricsApiRequest
		    {
				
		    });

		    return Task.CompletedTask;
	    }
    }
}
