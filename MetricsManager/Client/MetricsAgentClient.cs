using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using MetricsManager.Requests.ApiRequests;
using MetricsManager.Responses.ApiResponses;
using Microsoft.Extensions.Logging;

namespace MetricsManager.Client
{
    public class MetricsAgentClient : IMetricsAgentClient
    {
	    private readonly HttpClient _httpClient;
	    private readonly ILogger _logger;

	    public MetricsAgentClient(HttpClient httpHttpClient, ILogger<MetricsAgentClient> logger)
	    {
		    _httpClient = httpHttpClient;
		    _logger = logger; 
	    }

	    public AllCpuMetricsApiResponse GetAllCpuMetrics(GetAllCpuMetricsApiRequest request)
	    {
		    var fromTime = request.FromTime.ToString("u");
		    var toTime = request.ToTime.ToString("u");

			var httpRequest = new HttpRequestMessage(HttpMethod.Get,
				$"{request.ClientBaseAddress}api/metrics/cpu/from/{fromTime}/to/{toTime}");

            try
            {
				var response = _httpClient.SendAsync(httpRequest).Result;

				using var responseStream = response.Content.ReadAsStreamAsync().Result;

				var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                return JsonSerializer.DeserializeAsync<AllCpuMetricsApiResponse>(responseStream, options).Result;
            }
            catch (Exception e)
            {
				_logger.LogError(e.Message);
			}

            return null;
	    }

	    public DotNetMetricsApiResponse GetDotNetMetrics(DotNetHeapMetricsApiRequest request)
	    {
			var fromTime = request.FromTime.ToString("u");
			var toTime = request.ToTime.ToString("u");

			var httpRequest = new HttpRequestMessage(HttpMethod.Get,
				$"{request.ClientBaseAddress}api/metrics/dotnet/errors-count/from/{fromTime}/to/{toTime}");

			try
			{
				var response = _httpClient.SendAsync(httpRequest).Result;

				using var responseStream = response.Content.ReadAsStreamAsync().Result;

				var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

				return JsonSerializer.DeserializeAsync<DotNetMetricsApiResponse>(responseStream, options).Result;
			}
			catch (Exception e)
			{
				_logger.LogError(e.Message);
			}

			return null;
		}

	    public AllHddMetricsApiResponse GetAllHddMetrics(GetAllHddMetricsApiRequest request)
	    {
		    var fromTime = request.FromTime.ToString("u");
		    var toTime = request.ToTime.ToString("u");

		    var httpRequest = new HttpRequestMessage(HttpMethod.Get, 
			    $"{request.ClientBaseAddress}api/metrics/hdd/left/from/{fromTime}/to/{toTime}");

		    try
		    {
			    var response = _httpClient.SendAsync(httpRequest).Result;

			    using var responseStream = response.Content.ReadAsStreamAsync().Result;

			    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

				return JsonSerializer.DeserializeAsync<AllHddMetricsApiResponse>(responseStream, options).Result;
		    }
		    catch (Exception e)
		    {
			    _logger.LogError(e.Message);
		    }

		    return null;
	    }

	    public AllNetworkMetricsApiResponse GetAllNetworkMetrics(GetAllNetworkMetricsApiRequest request)
	    {
			var fromTime = request.FromTime.ToString("u");
			var toTime = request.ToTime.ToString("u");

			var httpRequest = new HttpRequestMessage(HttpMethod.Get,
				$"{request.ClientBaseAddress}api/metrics/network/from/{fromTime}/to/{toTime}");

			try
			{
				var response = _httpClient.SendAsync(httpRequest).Result;

				using var responseStream = response.Content.ReadAsStreamAsync().Result;

				var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

				return JsonSerializer.DeserializeAsync<AllNetworkMetricsApiResponse>(responseStream, options).Result;
			}
			catch (Exception e)
			{
				_logger.LogError(e.Message);
			}

			return null;
		}

	    public AllRamMetricsApiResponse GetAllRamMetrics(GetAllRamMetricsApiRequest request)
	    {
			var fromTime = request.FromTime.ToString("u");
			var toTime = request.ToTime.ToString("u");

			var httpRequest = new HttpRequestMessage(HttpMethod.Get,
				$"{request.ClientBaseAddress}api/metrics/ram/available/from/{fromTime}/to/{toTime}");

			try
			{
				var response = _httpClient.SendAsync(httpRequest).Result;

				using var responseStream = response.Content.ReadAsStreamAsync().Result;

				var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

				return JsonSerializer.DeserializeAsync<AllRamMetricsApiResponse>(responseStream, options).Result;
			}
			catch (Exception e)
			{
				_logger.LogError(e.Message);
			}

			return null;
		}

		
    }
}
