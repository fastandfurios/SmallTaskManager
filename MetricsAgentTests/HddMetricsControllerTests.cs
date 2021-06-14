using System;
using MetricsAgent.Controllers;
using MetricsAgent.Repositories.HddMetricsRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace MetricsAgentTests
{
    public class HddMetricsControllerTests
    {
	    private readonly HddMetricsController _controller;
	    private readonly Mock<ILogger<HddMetricsController>> _mockLogger;
	    private readonly Mock<IHddMetricsRepository> _mock;

	    public HddMetricsControllerTests()
	    {
		    _mock = new Mock<IHddMetricsRepository>();
		    _mockLogger = new Mock<ILogger<HddMetricsController>>();
		    _controller = new HddMetricsController(_mockLogger.Object, _mock.Object);
	    }

	    [Fact]
	    public void GetMetricsFromAgent_ShouldCall_GetByTimePeriod_From_Repository()
	    {
		    var fromTime = DateTimeOffset.FromUnixTimeSeconds(0);
		    var toTime = DateTimeOffset.FromUnixTimeSeconds(100);

		    _mock.Setup(r => r.GetByTimePeriod(fromTime, toTime)).Verifiable();

		    _mock.Verify(r => r.GetByTimePeriod(fromTime, toTime), Times.AtMostOnce());
	    }
	}
}
