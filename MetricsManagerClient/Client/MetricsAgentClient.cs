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
        public Uri ClientBaseAddress => new("http://localhost:61461");

        public MetricsAgentClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public TResponse GetAllMetrics<TResponse>(Object request, string keyword)
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
                var response = _httpClient.SendAsync(httpRequest).Result;

                using var responseStream = response.Content.ReadAsStreamAsync().Result;

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                return JsonSerializer.DeserializeAsync<TResponse>(responseStream, options).Result;
            }
            catch (Exception e)
            {
                Debug.Write(e);
            }

            return default;
        }
    }
}
