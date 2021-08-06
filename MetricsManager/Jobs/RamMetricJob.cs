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
    public class RamMetricJob : IJob
    {
        private readonly IAgentsRepository _agentsRepository;
        private readonly IRamMetricsRepository _ramMetricsRepository;
        private readonly IMetricsAgentClient _metricsAgentClient;
        private readonly IMapper _mapper;

        public RamMetricJob(IAgentsRepository agentsRepository,
            IRamMetricsRepository ramMetricsRepository,
            IMetricsAgentClient metricsAgentClient,
            IMapper mapper)
        {
            _agentsRepository = agentsRepository;
            _ramMetricsRepository = ramMetricsRepository;
            _metricsAgentClient = metricsAgentClient;
            _mapper = mapper;
        }

		public Task Execute(IJobExecutionContext context)
	    {
			var maxDate = _ramMetricsRepository.GetMaxDate();

            var registerObjects = _agentsRepository.GetRegisterObjects();

            var metrics = new AllRamMetricsApiResponse();

            foreach (var registerObject in registerObjects)
            {
                metrics = _metricsAgentClient.GetAllRamMetrics(new GetAllRamMetricsApiRequest()
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
                        _ramMetricsRepository.Create(_mapper.Map<RamMetric>(metric));
                    }
                }
            }

            return Task.CompletedTask;
		}
    }
}
