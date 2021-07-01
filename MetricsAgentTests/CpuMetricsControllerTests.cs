using System;
using System.Collections.Generic;
using MetricsAgent.Controllers;
using MetricsAgent.Models;
using MetricsAgent.Repositories.CpuMetricsRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Xunit;

namespace MetricsAgentTests
{
	public class CpuMetricsControllerTests
	{
		private readonly CpuMetricsController _controller;
		private readonly Mock<ICpuMetricsRepository> _mock;
		private readonly Mock<ILogger<CpuMetricsController>> _mockLogger; 

		public CpuMetricsControllerTests()
		{
			_mock = new Mock<ICpuMetricsRepository>();
			_mockLogger = new Mock<ILogger<CpuMetricsController>>();
			_controller = new CpuMetricsController(_mockLogger.Object, _mock.Object);
		}
		

		[Fact]
		public void GetMetricsFromAgent_ShouldCall_GetByTimePeriod_From_Repository()
		{
			var fromTime = DateTimeOffset.FromUnixTimeSeconds(0);
			var toTime = DateTimeOffset.FromUnixTimeSeconds(100);

			_mock.Setup(r => r.GetByTimePeriod(fromTime, toTime)).Returns(new List<CpuMetric>());

			var result = _controller.GetMetricsFromAgent(fromTime, toTime);

			_mock.Verify(r => r.GetByTimePeriod(fromTime, toTime), Times.AtMostOnce());
		}
	}
}
