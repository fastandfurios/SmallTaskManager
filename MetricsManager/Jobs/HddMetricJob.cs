using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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
		private readonly IMapper _mapper;

	    public HddMetricJob(IAgentsRepository agentsRepository,
		    IHddMetricsRepository hddMetricsRepository,
		    IMetricsAgentClient metricsAgentClient,
			IMapper mapper)
	    {
		    _agentsRepository = agentsRepository;
		    _hddMetricsRepository = hddMetricsRepository;
		    _metricsAgentClient = metricsAgentClient;
			_mapper = mapper;
	    }

	    public async Task Execute(IJobExecutionContext context)
	    {
		    var maxDate = _hddMetricsRepository.GetMaxDate();

		    var registerObjects = _agentsRepository.GetRegisterObjects();

			var metrics = new AllHddMetricsApiResponse();

			foreach (var registerObject in registerObjects)
		    {
				metrics = await _metricsAgentClient.GetAllHddMetrics(new GetAllHddMetricsApiRequest
			    {
					ClientBaseAddress = new Uri(registerObject.AgentUrl),
					FromTime = maxDate,
					ToTime = DateTimeOffset.UtcNow
			    });

				if (registerObject.Enabled)
				{
					foreach (var metric in metrics.Metrics)
					{
						metric.AgentId = registerObject.AgentId;
						_hddMetricsRepository.Create(_mapper.Map<HddMetric>(metric));
					}
				}
			}
        }
    }
}
