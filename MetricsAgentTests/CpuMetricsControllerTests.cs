using System;
using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MetricsAgentTests
{
	public class CpuMetricsControllerTests
	{
		private readonly CpuMetricsController _controller;

		public CpuMetricsControllerTests() => _controller = new CpuMetricsController();

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
