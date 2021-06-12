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
	public class HddMetricsController : ControllerBase
	{
		private readonly ILogger<HddMetricsController> _logger;

		public HddMetricsController(ILogger<HddMetricsController> logger)
		{
			_logger = logger;
		}

		[HttpGet("hdd/left/{freeSpace}")]
		public IActionResult GetMetricsFromAgent([FromRoute] long freeSpace)
		{
			_logger.LogInformation($"freeSpace: {freeSpace}");
			return Ok();
		}
	}
}
