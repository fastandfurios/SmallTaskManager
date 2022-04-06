using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MetricsManager.Client;
using MetricsManager.DAL.Interfaces;
using MetricsManager.DAL.Models;
using MetricsManager.DAL.Repositories.Connection;
using MetricsManager.Requests.ApiRequests;
using MetricsManager.Responses.ApiResponses;
using Quartz;

namespace MetricsManager.Jobs
{
	[DisallowConcurrentExecution]
    public class NetworkMetricJob : IJob
    {
        private readonly IAgentsRepository _agentsRepository;
        private readonly INetworkMetricsRepository _networkMetricsRepository;
        private readonly IMetricsAgentClient _metricsAgentClient;
        private readonly IMapper _mapper;

        public NetworkMetricJob(IAgentsRepository agentsRepository,
            INetworkMetricsRepository networkMetricsRepository,
            IMetricsAgentClient metricsAgentClient,
            IMapper mapper)
        {
            _agentsRepository = agentsRepository;
            _networkMetricsRepository = networkMetricsRepository;
            _metricsAgentClient = metricsAgentClient;
            _mapper = mapper;
        }

	    public async Task Execute(IJobExecutionContext context)
	    {
			var maxDate = _networkMetricsRepository.GetMaxDate();

            var registerObjects = _agentsRepository.GetRegisterObjects();

            var metrics = new AllNetworkMetricsApiResponse();

            foreach (var registerObject in registerObjects)
            {
                metrics = await _metricsAgentClient.GetAllNetworkMetrics(new GetAllNetworkMetricsApiRequest()
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
                        _networkMetricsRepository.Create(_mapper.Map<NetworkMetric>(metric));
                    }
                }
            }
        }
    }
}
