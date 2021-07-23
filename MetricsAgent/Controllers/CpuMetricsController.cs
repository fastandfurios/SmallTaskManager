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
	public class CpuMetricsController : ControllerBase
	{
		private readonly ILogger<CpuMetricsController> _logger;
		private readonly ICpuMetricsRepository _repository;
		private readonly IMapper _mapper;

		public CpuMetricsController(ILogger<CpuMetricsController> logger,
									ICpuMetricsRepository repository,
									IMapper mapper)
		{
			_logger = logger;
			_repository = repository;
			_mapper = mapper;
		}

		[HttpGet("cpu/from/{fromTime}/to/{toTime}")]
		public IActionResult GetMetricsFromAgent([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
		{
			fromTime = new DateTimeOffset(fromTime.UtcDateTime);
			toTime = new DateTimeOffset(toTime.UtcDateTime);

			_logger.LogInformation($"from: {fromTime} to: {toTime}");

			var metrics = _repository.GetByTimePeriod(fromTime, toTime);

			var response = new CpuMetricsResponse
			{
				Metrics = new List<CpuMetricDto>()
			};

			foreach (var metric in metrics)
			{
				response.Metrics.Add(_mapper.Map<CpuMetricDto>(metric));
			}

			return Ok(response);
		}
	}
}
