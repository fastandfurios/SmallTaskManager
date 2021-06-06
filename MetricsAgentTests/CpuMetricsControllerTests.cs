using System;
using MetricsAgent.Controllers;
using Xunit;

namespace MetricsAgentTests
{
	public class CpuMetricsControllerTests
	{
		private CpuMetricsController _controller;

		protected CpuMetricsControllerTests() => _controller = new CpuMetricsController();

		[Fact]
		public void GetMetricsFromAgent_ReturnsOk()
		{
			var fromTime = TimeSpan.FromSeconds(0);
			var toTime = TimeSpan.FromSeconds(100);

			var result = _controller.GetMetricsFromAgent(fromTime, toTime);
		}
	}
}
