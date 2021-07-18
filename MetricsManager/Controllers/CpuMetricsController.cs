﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using MetricsManager.DAL.Interfaces;
using MetricsManager.Responses;
using MetricsManager.Responses.DTO;
using Microsoft.Extensions.Logging;

namespace MetricsManager.Controllers
{
	[Route("api/metrics/cpu")]
	[ApiController]
	public class CpuMetricsController : ControllerBase
	{
		private readonly ILogger<CpuMetricsController> _logger;
        private readonly ICpuMetricsRepository _repository;
        private readonly IMapper _mapper;

		public CpuMetricsController(ILogger<CpuMetricsController> logger,
            ICpuMetricsRepository repository,
            IMapper mapper)
		{
			_logger = logger;
            _repository = repository;
            _mapper = mapper;
        }


        /// <summary>
        /// Получает метрики CPU на заданном диапазоне времени и номер агента, который эти метрики собрал
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     GET agent/1/from/1970.01.01 00:00:00/to/1970.01.01 00:10:00
        ///
        /// </remarks>
        /// <param name="agentId">начальная метрка времени</param>
        /// <param name="fromTime">начальная метрка времени</param>
        /// <param name="toTime">конечная метрка времени</param>
        /// <returns>Список метрик, которые были сохранены в заданном диапазоне времени</returns>
        /// <response code="200">если все хорошо</response>
        /// <response code="400">если передали не правильные параметры</response>
        [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
		public IActionResult GetMetricsFromAgent([FromRoute] int agentId, [FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
		{
			_logger.LogInformation($"id {agentId} from {fromTime} to {toTime}");

            var metrics = _repository.GetMetricsFromAgent(agentId, fromTime, toTime);

            var response = new CpuMetricResponse()
            {
                Metrics = new List<CpuMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<CpuMetricDto>(metric));
            }


			return Ok(response);
		}

        /// <summary>
        /// Получает метрики CPU на заданном диапазоне времени
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     GET agent/1/from/1970.01.01 00:00:00/to/1970.01.01 00:10:00
        ///
        /// </remarks>
        /// <param name="fromTime">начальная метрка времени</param>
        /// <param name="toTime">конечная метрка времени</param>
        /// <returns>Список метрик, которые были сохранены в заданном диапазоне времени</returns>
        /// <response code="200">если все хорошо</response>
        /// <response code="400">если передали не правильные параметры</response>
		[HttpGet("cluster/from/{fromTime}/to/{toTime}")]
		public IActionResult GetMetricsFromAllCluster([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
		{
            _logger.LogInformation($"from {fromTime} to {toTime}");

            var metrics = _repository.GetMetricsFromAllCluster(fromTime, toTime);

            var response = new CpuMetricResponse()
            {
                Metrics = new List<CpuMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<CpuMetricDto>(metric));
            }

			return Ok(response);
		}
	}
}
