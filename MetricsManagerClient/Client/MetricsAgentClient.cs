using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MetricsManagerClient.Requests;
using MetricsManagerClient.Responses.ApiResponses;

namespace MetricsManagerClient.Client
{
    public class MetricsAgentClient : IMetricsAgentClient
    {
        private readonly HttpClient _httpClient;
        private Uri ClientBaseAddress => new("http://localhost:61461");

        public MetricsAgentClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TResponse> GetAllMetrics<TResponse>(Object request, string keyword)
        {
            Type type = request.GetType();
            DateTimeOffset fromTimeTemp = (DateTimeOffset)type.GetProperty("FromTime")?.GetValue(request);
            DateTimeOffset toTimeTemp = (DateTimeOffset)type.GetProperty("ToTime")?.GetValue(request);
            var fromTime = fromTimeTemp.ToString("s");
            var toTime = toTimeTemp.ToString("s");

            var httpRequest = new HttpRequestMessage(HttpMethod.Get,
                $"{ClientBaseAddress}api/metrics/{keyword}/cluster/from/{fromTime}/to/{toTime}");

            try
            {
                var response = await _httpClient.SendAsync(httpRequest);

                await using var responseStream = await response.Content.ReadAsStreamAsync();

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                return await JsonSerializer.DeserializeAsync<TResponse>(responseStream, options);
            }
            catch (Exception e)
            {
                Debug.Write(e);
            }

            return default;
        }
    }
}
