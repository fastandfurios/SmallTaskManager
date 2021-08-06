using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MetricsManager.DAL.Interfaces;
using MetricsManager.Responses;
using MetricsManager.Responses.DTO;
using Microsoft.Extensions.Logging;

namespace MetricsManager.Controllers
{
	[Route("api/metrics/network")]
	[ApiController]
	public class NetworkMetricsController : ControllerBase
	{
		private readonly ILogger<NetworkMetricsController> _logger;
        private readonly INetworkMetricsRepository _repository;
        private readonly IMapper _mapper;

		public NetworkMetricsController(ILogger<NetworkMetricsController> logger,
            INetworkMetricsRepository repository,
            IMapper mapper)
		{
			_logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

		[HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
		public IActionResult GetMetricsFromAgent([FromRoute] int agentId, [FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
		{
            _logger.LogInformation($"id {agentId} from {fromTime} to {toTime}");

            var metrics = _repository.GetMetricsFromAgent(agentId, fromTime, toTime);

            var response = new NetworkMetricResponse()
            {
                Metrics = new List<NetworkMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<NetworkMetricDto>(metric));
            }

			return Ok(response);
		}

		[HttpGet("cluster/from/{fromTime}/to/{toTime}")]
		public IActionResult GetMetricsFromAllCluster([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
		{
			_logger.LogInformation($"from {fromTime} to {toTime}");

            var metrics = _repository.GetMetricsFromAllCluster(fromTime, toTime);

            var response = new NetworkMetricResponse()
            {
                Metrics = new List<NetworkMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<NetworkMetricDto>(metric));
            }

			return Ok(response);
		}
	}
}
