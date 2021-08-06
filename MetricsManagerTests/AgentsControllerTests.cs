using System;
using MetricsManager;
using MetricsManager.Controllers;
using MetricsManager.DAL.Interfaces;
using MetricsManager.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Xunit;

namespace MetricsManagerTests
{
	public class AgentsControllerTests
	{
		private readonly AgentsController _controller;
		private readonly ILogger<AgentsController> _logger;
		private readonly IAgentsRepository _repository;

		public AgentsControllerTests()
		{
			_logger = new Logger<AgentsController>(new LoggerFactory());
			_controller = new AgentsController(_logger, _repository);
		}

		[Fact]
		public void RegisterAgent_ResultOk()
		{
			var agent = new MetricsManager.DAL.Models.Agents();

			var result = _controller.RegisterAgent(agent);

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
