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
		[HttpGet("hdd/left/{freeSpace}")]
		public IActionResult GetMetricsFromAgent([FromRoute] long freeSpace)
		{
			return Ok();
		}
	}
}
