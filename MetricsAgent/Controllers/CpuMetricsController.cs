using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsAgent.Models;
using MetricsAgent.Repositories.CpuMetricsRepository;
using MetricsAgent.Responses;
using MetricsAgent.Responses.DTO;
using Microsoft.Extensions.Logging;

namespace MetricsAgent.Controllers
{
	[Route("api/metrics")]
	[ApiController]
	public class CpuMetricsController : ControllerBase
	{
		private readonly ILogger<CpuMetricsController> _logger;
		private readonly ICpuMetricsRepository _repository;

		public CpuMetricsController(ILogger<CpuMetricsController> logger, ICpuMetricsRepository repository)
		{
			_logger = logger;
			_repository = repository;
		}

		[HttpGet("cpu/from/{fromTime}/to/{toTime}")]
		public IActionResult GetMetricsFromAgent([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
		{
			fromTime = fromTime.UtcDateTime;
			toTime = toTime.UtcDateTime;

			_logger.LogInformation($"from: {fromTime} to: {toTime}");

			var metrics = _repository.GetByTimePeriod(fromTime, toTime);

			var response = new CpuMetricsResponse
			{
				Metrics = new List<CpuMetricDto>()
			};

			foreach (var metric in metrics)
			{
				response.Metrics.Add(new CpuMetricDto
				{
					Id = metric.Id,
					Value = metric.Value,
					Time = metric.Time
				});
			}

			return Ok(response);
		}
	}
}
