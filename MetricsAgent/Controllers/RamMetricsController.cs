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
	public class RamMetricsController : ControllerBase
	{
		private readonly ILogger<RamMetricsController> _logger;
		private readonly IRamMetricsRepository _repository;
		private readonly IMapper _mapper;

		public RamMetricsController(ILogger<RamMetricsController> logger,
			IRamMetricsRepository repository,
			IMapper mapper)
		{
			_logger = logger;
			_repository = repository;
			_mapper = mapper;
		}

		[HttpGet("ram/available/from/{fromTime}/to/{toTime}")]
		public IActionResult GetMetricsFromAgent([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
		{
			_logger.LogInformation($"fromTime {fromTime} toTime {toTime}");

			var metrics = _repository.GetByTimePeriod(fromTime, toTime);

			var response = new RamMetricResponse()
			{
				Metrics = new List<RamMetricDto>()
			};

			foreach (var metric in metrics)
			{
				response.Metrics.Add(_mapper.Map<RamMetricDto>(metric));
			}

			return Ok(response);
		}
	}
}
