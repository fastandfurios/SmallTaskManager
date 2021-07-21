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

                return JsonSerializer.DeserializeAsync<CpuMetricsApiResponse>(responseStream, options).Result;
            }
            catch (Exception e)
            {
                Debug.Write(e);
            }

            return null;
        }

        public DotNetMetricsApiResponse GetAllDotNetMetrics(DotNetMetricsApiRequest request)
        {
            var fromTime = request.FromTime.ToString("u");
            var toTime = request.ToTime.ToString("u");

            var httpRequest = new HttpRequestMessage(HttpMethod.Get,
                $"{ClientBaseAddress}api/metrics/dotnet/cluster/from/{fromTime}/to/{toTime}");

            try
            {
                var response = _httpClient.SendAsync(httpRequest).Result;

                using var responseStream = response.Content.ReadAsStreamAsync().Result;

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                return JsonSerializer.DeserializeAsync<DotNetMetricsApiResponse>(responseStream, options).Result;
            }
            catch (Exception e)
            {
                Debug.Write(e);
            }

            return null;
        }

        public HddMetricsApiResponse GetAllHddMetrics(HddMetricsApiRequest request)
        {
            var fromTime = request.FromTime.ToString("u");
            var toTime = request.ToTime.ToString("u");

            var httpRequest = new HttpRequestMessage(HttpMethod.Get,
                $"{ClientBaseAddress}api/metrics/hdd/cluster/from/{fromTime}/to/{toTime}");

            try
            {
                var response = _httpClient.SendAsync(httpRequest).Result;

                using var responseStream = response.Content.ReadAsStreamAsync().Result;

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                return JsonSerializer.DeserializeAsync<HddMetricsApiResponse>(responseStream, options).Result;
            }
            catch (Exception e)
            {
                Debug.Write(e);
            }

            return null;
        }

        public NetworkMetricsApiResponse GetAllNetworkMetrics(NetworkMetricsApiRequest request)
        {
            var fromTime = request.FromTime.ToString("u");
            var toTime = request.ToTime.ToString("u");

            var httpRequest = new HttpRequestMessage(HttpMethod.Get,
                $"{ClientBaseAddress}api/metrics/network/cluster/from/{fromTime}/to/{toTime}");

            try
            {
                var response = _httpClient.SendAsync(httpRequest).Result;

                using var responseStream = response.Content.ReadAsStreamAsync().Result;

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                return JsonSerializer.DeserializeAsync<NetworkMetricsApiResponse>(responseStream, options).Result;
            }
            catch (Exception e)
            {
                Debug.Write(e);
            }

            return null;
        }

        public RamMetricsApiResponse GetAllRamMetrics(RamMetricsApiRequest request)
        {
            var fromTime = request.FromTime.ToString("u");
            var toTime = request.ToTime.ToString("u");

            var httpRequest = new HttpRequestMessage(HttpMethod.Get,
                $"{ClientBaseAddress}api/metrics/ram/cluster/from/{fromTime}/to/{toTime}");

            try
            {
                var response = _httpClient.SendAsync(httpRequest).Result;

                using var responseStream = response.Content.ReadAsStreamAsync().Result;

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                return JsonSerializer.DeserializeAsync<RamMetricsApiResponse>(responseStream, options).Result;
            }
            catch (Exception e)
            {
                Debug.Write(e);
            }

            return null;
        }
    }
}
