using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MetricsManagerClient.Requests;
using MetricsManagerClient.Responses.ApiResponses;
using Microsoft.Extensions.Logging;

namespace MetricsManagerClient.Client
{
    public class MetricsAgentClient : IMetricsAgentClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger _logger;
        public Uri ClientBaseAddress => new ("http://localhost:61461");

        public MetricsAgentClient(HttpClient httpClient, ILogger<MetricsAgentClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public CpuMetricsApiResponse GetAllCpuMetrics(CpuMetricsApiRequest request)
        {
            var fromTime = request.FromTime.ToString("u");
            var toTime = request.ToTime.ToString("u");

            var httpRequest = new HttpRequestMessage(HttpMethod.Get, 
                $"{ClientBaseAddress}api/metrics/cpu/cluster/from/{fromTime}/to/{toTime}");

            try
            {
                var response = _httpClient.SendAsync(httpRequest).Result;

                using var responseStream = response.Content.ReadAsStreamAsync().Result;

                var options = new JsonSerializerOptions {PropertyNameCaseInsensitive = true};

                return JsonSerializer.DeserializeAsync<CpuMetricsApiResponse>(responseStream, options).Result;
            }
            catch (Exception e)
            {
               _logger.LogError(e.Message);
            }

            return null;
        }
    }
}
