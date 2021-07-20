using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MetricsManagerClient.Client;
using MetricsManagerClient.DTO;
using MetricsManagerClient.Models;
using MetricsManagerClient.Requests;
using MetricsManagerClient.Responses.ApiResponses;
using Quartz;

namespace MetricsManagerClient.Jobs
{
    [DisallowConcurrentExecution]
    public class CpuMetricJob : IJob
    {
        private readonly IMetricsAgentClient _agentClient;
        private readonly IMapper _mapper;

        public CpuMetricJob(IMetricsAgentClient agentClient, IMapper mapper)
        {
            _agentClient = agentClient;
            _mapper = mapper;
        }

        public Task Execute(IJobExecutionContext context)
        {
            var metrics = new CpuMetricsApiResponse();

            metrics = _agentClient.GetAllCpuMetrics(new CpuMetricsApiRequest
            {
                FromTime = DateTimeOffset.UtcNow,
                ToTime = DateTimeOffset.UtcNow
            });

            foreach (var metric in metrics.Metrics)
            {
                _mapper.Map<CpuMetricDto>(metric);
            }

            return Task.CompletedTask;
        }
    }
}
