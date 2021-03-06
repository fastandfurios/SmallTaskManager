using System;
using MetricsManager;
using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Xunit;

namespace MetricsManagerTests
{
	public class AgentsControllerTests
	{
		private readonly AgentsController _controller;
		private readonly ILogger<AgentsController> _logger;

		public AgentsControllerTests()
		{
			_logger = new Logger<AgentsController>(new LoggerFactory());
			_controller = new AgentsController(_logger);
		}

		[Fact]
		public void RegisterAgent_ResultOk()
		{
			var agentInfo = new AgentInfo();

			var result = _controller.RegisterAgent(agentInfo);

			_ = Assert.IsAssignableFrom<IActionResult>(result);
		}

		[Fact]
		public void EnableAgentById_ResultOk()
		{
			var agentId = 10;

			var result = _controller.EnableAgentById(agentId);

			_ = Assert.IsAssignableFrom<IActionResult>(result);
		}

		[Fact]
		public void DisableAgentById_ResultOk()
		{
			var agentId = 11;

			var result = _controller.EnableAgentById(agentId);

			_ = Assert.IsAssignableFrom<IActionResult>(result);
		}

		[Fact]
		public void GetRegisterObjects_ResultOk()
		{
			var result = _controller.GetRegisterObjects();

			_ = Assert.IsAssignableFrom<IActionResult>(result);
		}
	}
}
