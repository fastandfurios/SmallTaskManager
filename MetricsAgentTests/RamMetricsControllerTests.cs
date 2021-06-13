using System;
using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MetricsAgentTests
{
    public class RamMetricsControllerTests
    {
	    private readonly RamMetricsController _controller;

	    public RamMetricsControllerTests() => _controller = new RamMetricsController();

		[Fact]
		public void GetMetricsFromAgent_ReturnsOk()
		{
			var fromTime = DateTimeOffset.FromUnixTimeSeconds(0);
			var toTime = DateTimeOffset.FromUnixTimeSeconds(100);

			var result = _controller.GetMetricsFromAgent(fromTime, toTime);

			_ = Assert.IsAssignableFrom<IActionResult>(result);
		}
	}
}
