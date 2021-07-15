using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MetricsManager.Client;
using MetricsManager.DAL.Interfaces;
using MetricsManager.DAL.Models;
using MetricsManager.Requests.ApiRequests;
using MetricsManager.Responses.ApiResponses;
using Quartz;

namespace MetricsManager.Jobs
{
	[DisallowConcurrentExecution]
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
		    var maxDate = _hddMetricsRepository.GetMaxDate();

		    var registerObjects = _agentsRepository.GetRegisterObjects();

		    IList<AllHddMetricsApiResponse> responses = null;

			foreach (var registerObject in registerObjects)
		    {
				responses = _metricsAgentClient.GetAllHddMetrics(new GetAllHddMetricsApiRequest
			    {
					ClientBaseAddress = new Uri(registerObject.AgentUrl),
					FromTime = maxDate,
					ToTime = DateTimeOffset.UtcNow
			    });
		    }

			foreach (var response in responses)
			{
				_hddMetricsRepository.Create(
					new HddMetric
					{
						Id = response.Id,
						Value = response.Value,
						Time = response.Time.ToUnixTimeSeconds()
					});
			}

		    return Task.CompletedTask;
	    }
    }
}
