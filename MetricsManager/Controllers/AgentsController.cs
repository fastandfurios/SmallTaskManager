using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsManager.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using MetricsManager.DAL.Models;

namespace MetricsManager.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AgentsController : ControllerBase
	{
		private readonly ILogger<AgentsController> _logger;
		private readonly IAgentsRepository _repository;

		public AgentsController(ILogger<AgentsController> logger, IAgentsRepository repository)
		{
			_logger = logger;
			_repository = repository;
		}

		[HttpPost("register")]
		public IActionResult RegisterAgent([FromBody] Agents agent)
		{
			_logger.LogInformation($"agent {agent.AgentId} {agent.AgentUrl} {agent.Enabled}");

			_repository.Create(new Agents
			{
				AgentId = agent.AgentId,
				AgentUrl = agent.AgentUrl,
				Enabled = agent.Enabled
			});

			return Ok(agent);
		}

		[HttpPut("enable/{agentId}")]
		public IActionResult EnableAgentById([FromRoute] int agentId)
		{
			_logger.LogInformation($"id {agentId}");

			var agent = _repository.EnableAgent(agentId);

			return Ok(agent);
		}

		[HttpPut("disable/{agentId}")]
		public IActionResult DisableAgentById([FromRoute] int agentId)
		{
			_logger.LogInformation($"id {agentId}");

			var agent = _repository.DisableAgent(agentId);

			return Ok(agent);
		}

		[HttpGet("objects")]
		public IActionResult GetRegisterObjects()
		{
			var agents = _repository.GetRegisterObjects();
			return Ok(agents);
		}
	}
}
