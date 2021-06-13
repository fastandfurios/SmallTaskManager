using System;
using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MetricsAgentTests
{
    public class DotNetMetricsControllerTests
    {
	    private readonly DotNetMetricsController _controller;

	    public DotNetMetricsControllerTests()
	    {
	    }

		[Fact]
		public void GetMetricsFromAgent_ReturnsOk()
		{
			//var fromTime = TimeSpan.FromSeconds(0);
			//var toTime = TimeSpan.FromSeconds(50);

			//var result = _controller.GetMetricsFromAgent(fromTime, toTime);

			//_ = Assert.IsAssignableFrom<IActionResult>(result);
		}
	}
}
