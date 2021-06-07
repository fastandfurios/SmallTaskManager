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
			var freeSpace = 100000;

			var result = _controller.GetMetricsFromAgent(freeSpace);

			_ = Assert.IsAssignableFrom<IActionResult>(result);
		}
	}
}
