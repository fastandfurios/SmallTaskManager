using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MetricsAgent.Repositories.DotNetMetricsRepository;
using MetricsAgent.Responses;
using MetricsAgent.Responses.DTO;
using Microsoft.Extensions.Logging;

namespace MetricsAgent.Controllers
{
	[Route("api/metrics")]
	[ApiController]
	public class DotNetMetricsController : ControllerBase
	{
		private readonly ILogger<DotNetMetricsController> _logger;
		private readonly IDotNetMetricsRepository _repository;
		private readonly IMapper _mapper;

		public DotNetMetricsController(ILogger<DotNetMetricsController> logger,
			IDotNetMetricsRepository repository, 
			IMapper mapper)
		{
			_logger = logger;
			_repository = repository;
			_mapper = mapper;
		}

		[HttpGet("dotnet/errors-count/from/{fromTime}/to/{toTime}")]
		public IActionResult GetMetricsFromAgent([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
		{
			fromTime = new DateTimeOffset(fromTime.UtcDateTime);
			toTime = new DateTimeOffset(toTime.UtcDateTime);

			_logger.LogInformation($"from: {fromTime} to {toTime}");

			var metrics = _repository.GetByTimePeriod(fromTime, toTime);

			var response = new DotNetMetricResponse()
			{
				Metrics = new List<DotNetMetricDto>()
			};

			foreach (var metric in metrics)
			{
				response.Metrics.Add(_mapper.Map<DotNetMetricDto>(metric));
			}

			return Ok(response);
		}
	}
}
