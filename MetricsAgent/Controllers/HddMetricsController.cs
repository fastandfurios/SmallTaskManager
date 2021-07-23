using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.DAL.Models;
using MetricsAgent.Responses;
using MetricsAgent.Responses.DTO;
using Microsoft.Extensions.Logging;

namespace MetricsAgent.Controllers
{
	[Route("api/metrics")]
	[ApiController]
	public class HddMetricsController : ControllerBase
	{

	  private readonly ILogger<HddMetricsController> _logger;
	  private readonly IHddMetricsRepository _repository;
	  private readonly IMapper _mapper;
  
	  public HddMetricsController(ILogger<HddMetricsController> logger,
		  IHddMetricsRepository repository,
		  IMapper mapper)
		{
			_logger = logger;
			_repository = repository;
			_mapper = mapper;
		}

		[HttpGet("hdd/left/from/{fromTime}/to/{toTime}")]
		public IActionResult GetMetricsFromAgent([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
		{
			_logger.LogInformation($"fromTime {fromTime} toTime {toTime}");

			var metrics = _repository.GetByTimePeriod(fromTime, toTime);

			var response = new HddMetricResponse()
			{
				Metrics = new List<HddMetricDto>()
			};

			foreach (var metric in metrics)
			{
				response.Metrics.Add(_mapper.Map<HddMetricDto>(metric));
			}

			return Ok(response);
		}
	}
}
