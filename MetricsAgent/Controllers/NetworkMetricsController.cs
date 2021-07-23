using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.Responses;
using MetricsAgent.Responses.DTO;
using Microsoft.Extensions.Logging;

namespace MetricsAgent.Controllers
{
	[Route("api/metrics")]
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

		[HttpGet("network/from/{fromTime}/to/{toTime}")]
		public IActionResult GetMetricsFromAgent([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
		{
			_logger.LogInformation($"fromTime {fromTime} toTime {toTime}");

			var metrics = _repository.GetByTimePeriod(fromTime, toTime);

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
