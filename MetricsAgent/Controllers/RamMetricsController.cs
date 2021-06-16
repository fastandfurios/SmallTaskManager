using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsAgent.Repositories.RamMetricsRepository;
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

		public RamMetricsController(ILogger<RamMetricsController> logger, IRamMetricsRepository repository)
		{
			_logger = logger;
			_repository = repository;
		}

		[HttpGet("ram/available/from/{fromTime}/to/{toTime}")]
		public IActionResult GetMetricsFromAgent([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
		{
			fromTime = fromTime.UtcDateTime;
			toTime = toTime.UtcDateTime;

			_logger.LogInformation($"fromTime {fromTime} toTime {toTime}");

			var metrics = _repository.GetByTimePeriod(fromTime, toTime);

			var response = new RamMetricResponse()
			{
				Metrics = new List<RamMetricDto>()
			};

			foreach (var metric in metrics)
			{
				response.Metrics.Add(new RamMetricDto()
				{
					Id = metric.Id,
					Value = metric.Value,
					Time = metric.Time
				});
			}

			return Ok();
		}
	}
}
