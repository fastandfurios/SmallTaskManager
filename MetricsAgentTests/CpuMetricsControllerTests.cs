using System;
using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MetricsAgentTests
{
	public class CpuMetricsControllerTests
	{
		private readonly CpuMetricsController _controller;

		public CpuMetricsControllerTests()
		{
		}
		

		[Fact]
		public void GetMetricsFromAgent_ReturnsOk()
		{
			//var fromTime = TimeSpan.FromSeconds(0);
			//var toTime = TimeSpan.FromSeconds(100);

			//var result = _controller.GetMetricsFromAgent(fromTime, toTime);

			//_ = Assert.IsAssignableFrom<IActionResult>(result);
		}
	}
}
