using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Controllers
{
	[Route("api/metrics")]
	[ApiController]
	public class HddMetricsController : ControllerBase
	{
		[HttpGet("hdd/left/from/{fromTime}/to/{toTime}")]
		public IActionResult GetMetricsFromAgent([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
		{
			return Ok();
		}
	}
}
