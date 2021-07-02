using System;
using System.Collections.Generic;
using AutoMapper;
using MetricsAgent.Controllers;
using MetricsAgent.Models;
using MetricsAgent.Repositories.NetworkMetricsRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace MetricsAgentTests
{
    public class NetworkMetricsControllerTests
    {
	    private readonly NetworkMetricsController _controller;
	    private readonly Mock<ILogger<NetworkMetricsController>> _mockLogger;
	    private readonly Mock<INetworkMetricsRepository> _mock;
	    private readonly Mock<IMapper> _mockMapper;

	    public NetworkMetricsControllerTests()
	    {
		    _mock = new Mock<INetworkMetricsRepository>();
		    _mockLogger = new Mock<ILogger<NetworkMetricsController>>();
		    _controller = new NetworkMetricsController(_mockLogger.Object, _mock.Object, _mockMapper.Object);
	    }

	    [Fact]
	    public void GetMetricsFromAgent_ShouldCall_GetByTimePeriod_From_Repository()
	    {
		    var fromTime = DateTimeOffset.FromUnixTimeSeconds(0);
		    var toTime = DateTimeOffset.FromUnixTimeSeconds(100);

		    _mock.Setup(r => r.GetByTimePeriod(fromTime, toTime)).Returns(new List<NetworkMetric>());

		    var result = _controller.GetMetricsFromAgent(fromTime, toTime);

			_mock.Verify(r => r.GetByTimePeriod(fromTime, toTime), Times.AtMostOnce());
	    }
	}
}
