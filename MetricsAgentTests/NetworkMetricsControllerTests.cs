using System;
using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MetricsAgentTests
{
    public class NetworkMetricsControllerTests
    {
	    private readonly NetworkMetricsController _controller;

	    public NetworkMetricsControllerTests(){}

		[Fact]
		public void GetMetricsFromAgent_ReturnsOk()
		{
			//var fromTime = TimeSpan.FromSeconds(0);
			//var toTime = TimeSpan.FromSeconds(150);

			//var result = _controller.GetMetricsFromAgent(fromTime, toTime);

			//_ = Assert.IsAssignableFrom<IActionResult>(result);
		}
	}
}
