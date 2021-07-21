using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
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

                var result = JsonSerializer.DeserializeAsync<CpuMetricsApiResponse>(responseStream, options).Result;

                return result;
            }
            catch (Exception e)
            {
                Debug.Write(e);
            }

            return null;
        }

        public DotNetMetricsApiResponse GetAllDotNetMetrics(DotNetMetricsApiRequest request)
        {
            throw new NotImplementedException();
        }

        public HddMetricsApiResponse GetAllHddMetrics(HddMetricsApiRequest request)
        {
            throw new NotImplementedException();
        }

        public NetworkMetricsApiResponse GetAllNetworkMetrics(NetworkMetricsApiRequest request)
        {
            throw new NotImplementedException();
        }

        public RamMetricsApiResponse GetAllRamMetrics(RamMetricsApiRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
