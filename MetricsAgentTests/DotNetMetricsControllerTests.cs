using System;
using System.Collections.Generic;
using AutoMapper;
using MetricsAgent.Controllers;
using MetricsAgent.Models;
using MetricsAgent.Repositories.DotNetMetricsRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace MetricsAgentTests
{
    public class DotNetMetricsControllerTests
    {
	    private readonly DotNetMetricsController _controller;
	    private readonly Mock<ILogger<DotNetMetricsController>> _mockLogger;
	    private readonly Mock<IDotNetMetricsRepository> _mock;
	    private readonly Mock<IMapper> _mockMapper;

	    public DotNetMetricsControllerTests()
	    {
		    _mock = new Mock<IDotNetMetricsRepository>();
		    _mockLogger = new Mock<ILogger<DotNetMetricsController>>();
		    _controller = new DotNetMetricsController(_mockLogger.Object, _mock.Object, _mockMapper.Object);
	    }

	    [Fact]
	    public void GetMetricsFromAgent_ShouldCall_GetByTimePeriod_From_Repository()
	    {
		    var fromTime = DateTimeOffset.FromUnixTimeSeconds(0);
		    var toTime = DateTimeOffset.FromUnixTimeSeconds(100);

		    _mock.Setup(r => r.GetByTimePeriod(fromTime, toTime)).Returns(new List<DotNetMetric>());

		    var result = _controller.GetMetricsFromAgent(fromTime, toTime);

			_mock.Verify(r => r.GetByTimePeriod(fromTime, toTime), Times.AtMostOnce());
	    }
	}
}
