using System;
using System.Collections.Generic;
using MetricsAgent.Controllers;
using MetricsAgent.Models;
using MetricsAgent.Repositories.RamMetricsRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace MetricsAgentTests
{
    public class RamMetricsControllerTests
    {
	    private readonly RamMetricsController _controller;
	    private readonly Mock<ILogger<RamMetricsController>> _mockLogger;
	    private readonly Mock<IRamMetricsRepository> _mock;

	    public RamMetricsControllerTests()
	    {
		    _mock = new Mock<IRamMetricsRepository>();
		    _mockLogger = new Mock<ILogger<RamMetricsController>>();
		    _controller = new RamMetricsController(_mockLogger.Object, _mock.Object);
	    }

	    [Fact]
	    public void GetMetricsFromAgent_ShouldCall_GetByTimePeriod_From_Repository()
	    {
		    var fromTime = DateTimeOffset.FromUnixTimeSeconds(0);
		    var toTime = DateTimeOffset.FromUnixTimeSeconds(100);

		    _mock.Setup(r => r.GetByTimePeriod(fromTime, toTime)).Returns(new List<RamMetric>());

		    var result = _controller.GetMetricsFromAgent(fromTime, toTime);

			_mock.Verify(r => r.GetByTimePeriod(fromTime, toTime), Times.AtMostOnce());
	    }
	}
}
