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
	public class HddMetricsController : ControllerBase
	{
		[HttpGet("hdd/left")]
		public IActionResult GetMetricsFromAgent([FromRoute] int freeSpace)
		{
			return Ok();
		}
	}
}
