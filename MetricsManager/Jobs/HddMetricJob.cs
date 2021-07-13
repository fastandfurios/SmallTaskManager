using System;
using System.Threading.Tasks;
using MetricsManager.Client;
using MetricsManager.DAL.Interfaces;
using MetricsManager.Requests.ApiRequests;
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
		    var maxDate = _hddMetricsRepository.GetMaxDate();

		    foreach (var registerObject in _agentsRepository.GetRegisterObjects())
		    {
			     var response = _metricsAgentClient.GetAllHddMetrics(new GetAllHddMetricsApiRequest
			     {
				     FromTime = maxDate,
				     ClientBaseAddress = new Uri(registerObject.AgentUrl),
				     ToTime = DateTimeOffset.UtcNow
			     });
		    }

		    return Task.CompletedTask;
	    }
    }
}
