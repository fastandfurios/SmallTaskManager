using System;
using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MetricsAgentTests
{
    public class HddMetricsControllerTests
    {
	    private readonly HddMetricsController _controller;

	    public HddMetricsControllerTests()
	    {
	    }

	    [Fact]
		public void GetMetricsFromAgent_ReturnsOk()
		{
			//var freeSpace = 5000000;

			//var result = _controller.GetMetricsFromAgent(freeSpace);

			//_ = Assert.IsAssignableFrom<IActionResult>(result);
		}
	}
}
