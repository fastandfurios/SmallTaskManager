using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MetricsManager.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AgentsController : ControllerBase
	{
		private readonly Agents _agents;
		private readonly ILogger<AgentsController> _logger;

		public AgentsController(ILogger<AgentsController> logger)
		{
			_logger = logger;
			_agents = new Agents();
		}

		[HttpPost("register")]
		public IActionResult RegisterAgent([FromBody] AgentInfo agentInfo)
		{
			_logger.LogInformation($"agent {agentInfo.AgentId} {agentInfo.AgentAddress}");
			return Ok();
		}

		[HttpPut("enable/{agentId}")]
		public IActionResult EnableAgentById([FromRoute] int agentId)
		{
			_logger.LogInformation($"id {agentId}");
			return Ok();
		}

		[HttpPut("disable/{agentId}")]
		public IActionResult DisableAgentById([FromRoute] int agentId)
		{
			_logger.LogInformation($"id {agentId}");
			return Ok();
		}

		[HttpGet("objects")]
		public IActionResult GetRegisterObjects()
		{
			foreach (var agentInfo in _agents.ListAgents)
			{
				_logger.LogInformation($"agent {agentInfo.AgentId} {agentInfo.AgentAddress}");
			}
			return Ok(_agents.ListAgents);
		}
	}
}
