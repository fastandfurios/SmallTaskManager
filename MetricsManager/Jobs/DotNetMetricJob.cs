using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public class DotNetMetricJob : IJob
    {
		private readonly IAgentsRepository _agentsRepository;
		private readonly IDotNetMetricsRepository _dotNetMetricsRepository;
		private readonly IMetricsAgentClient _metricsAgentClient;
		private readonly IMapper _mapper;

        public DotNetMetricJob(IAgentsRepository agentsRepository,
			IDotNetMetricsRepository dotNetMetricsRepository,
			IMetricsAgentClient metricsAgentClient,
			IMapper mapper)
        {
			_agentsRepository = agentsRepository;
			_dotNetMetricsRepository = dotNetMetricsRepository;
			_metricsAgentClient = metricsAgentClient;
			_mapper = mapper;
		}

		public Task Execute(IJobExecutionContext context)
	    {
			var maxDate = _dotNetMetricsRepository.GetMaxDate();

			var registerObjects = _agentsRepository.GetRegisterObjects();

			var metrics = new DotNetMetricsApiResponse();

			foreach (var registerObject in registerObjects)
			{
				metrics = _metricsAgentClient.GetDotNetMetrics(new DotNetHeapMetricsApiRequest
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
						_dotNetMetricsRepository.Create(_mapper.Map<DotNetMetric>(metric));
					}
				}
			}

			return Task.CompletedTask;
		}
    }
}
