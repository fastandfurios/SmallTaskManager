using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NetworkMetricsController : ControllerBase
	{
		[HttpGet("network/from/{fromTime}/to/{toTime}")]
		public IActionResult GetMetricsFromAgent([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
		{
			return Ok();
		}
	}
}
