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

        /// <summary>
        /// Регистрирует агентов и сохраняет их
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST Agents/register
        ///		{
        ///			"agentId":1,
        ///			"agentUrl":"http://example",
        ///			"enabled":true
		///		}
        ///
        /// </remarks>
        /// <returns>Зарегистрированного агента</returns>
        /// <response code="200">если все хорошо</response>
        /// <response code="400">если передали не правильные параметры</response>
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

		/// <summary>
		/// Включает агента по его Id
		/// </summary>
		/// <remarks>
		/// Пример запроса:
		///
		///     PUT Agents/enable/128
		///
		/// </remarks>
		/// <returns>Включенного агента</returns>
		/// <param name="agentId">Id агента</param>
        /// <response code="200">если все хорошо</response>
		/// <response code="400">если передали не правильные параметры</response>
		[HttpPut("enable/{agentId}")]
		public IActionResult EnableAgentById([FromRoute] int agentId)
		{
			_logger.LogInformation($"id {agentId}");

			var agent = _repository.EnableAgent(agentId);

			return Ok(agent);
		}

        /// <summary>
        /// Выключает агента по его Id
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT Agents/disable/50
        ///
        /// </remarks>
        /// <returns>Выключенного агента</returns>
        /// <param name="agentId">Id агента</param>
        /// <response code="200">если все хорошо</response>
        /// <response code="400">если передали не правильные параметры</response>
		[HttpPut("disable/{agentId}")]
		public IActionResult DisableAgentById([FromRoute] int agentId)
		{
			_logger.LogInformation($"id {agentId}");

			var agent = _repository.DisableAgent(agentId);

			return Ok(agent);
		}

        /// <summary>
        /// Получает список всех агентов
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     GET Agents/objects
        ///
        /// </remarks>
        /// <returns>Выключенного агента</returns>
        /// <response code="200">если все хорошо</response>
        /// <response code="400">если передали не правильные параметры</response>
		[HttpGet("objects")]
		public IActionResult GetRegisterObjects()
		{
			var agents = _repository.GetRegisterObjects();
			return Ok(agents);
		}
	}
}
