using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MetricsAgent.Controllers
{
	[Route("api/metrics")]
	[ApiController]
	public class DotNetMetricsController : ControllerBase
	{
		private readonly ILogger<DotNetMetricsController> _logger;

		public DotNetMetricsController(ILogger<DotNetMetricsController> logger)
		{
			_logger = logger;
		}

		[HttpGet("dotnet/errors-count/from/{fromTime}/to/{toTime}")]
		public IActionResult GetMetricsFromAgent([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
		{
			_logger.LogInformation($"from: {fromTime} to {toTime}");
			return Ok();
		}
	}
}
