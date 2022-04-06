using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
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

	    public async  Task<AllCpuMetricsApiResponse> GetAllCpuMetrics(GetAllCpuMetricsApiRequest request)
	    {
		    var fromTime = request.FromTime.ToString("u");
		    var toTime = request.ToTime.ToString("u");

			var httpRequest = new HttpRequestMessage(HttpMethod.Get,
				$"{request.ClientBaseAddress}api/metrics/cpu/from/{fromTime}/to/{toTime}");

            try
            {
				var response = await _httpClient.SendAsync(httpRequest);

				using var responseStream = await response.Content.ReadAsStreamAsync();

				var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                return await JsonSerializer.DeserializeAsync<AllCpuMetricsApiResponse>(responseStream, options);
            }
            catch (Exception e)
            {
				_logger.LogError(e.Message);
			}

            return null;
	    }

	    public async Task<DotNetMetricsApiResponse> GetDotNetMetrics(DotNetHeapMetricsApiRequest request)
	    {
			var fromTime = request.FromTime.ToString("u");
			var toTime = request.ToTime.ToString("u");

			var httpRequest = new HttpRequestMessage(HttpMethod.Get,
				$"{request.ClientBaseAddress}api/metrics/dotnet/errors-count/from/{fromTime}/to/{toTime}");

			try
			{
				var response = await _httpClient.SendAsync(httpRequest);

				using var responseStream = await response.Content.ReadAsStreamAsync();

				var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

				return await JsonSerializer.DeserializeAsync<DotNetMetricsApiResponse>(responseStream, options);
			}
			catch (Exception e)
			{
				_logger.LogError(e.Message);
			}

			return null;
		}

	    public async Task<AllHddMetricsApiResponse> GetAllHddMetrics(GetAllHddMetricsApiRequest request)
	    {
		    var fromTime = request.FromTime.ToString("u");
		    var toTime = request.ToTime.ToString("u");

		    var httpRequest = new HttpRequestMessage(HttpMethod.Get, 
			    $"{request.ClientBaseAddress}api/metrics/hdd/left/from/{fromTime}/to/{toTime}");

		    try
		    {
			    var response = await _httpClient.SendAsync(httpRequest);

			    using var responseStream = await response.Content.ReadAsStreamAsync();

			    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

				return await JsonSerializer.DeserializeAsync<AllHddMetricsApiResponse>(responseStream, options);
		    }
		    catch (Exception e)
		    {
			    _logger.LogError(e.Message);
		    }

		    return null;
	    }

	    public async Task<AllNetworkMetricsApiResponse> GetAllNetworkMetrics(GetAllNetworkMetricsApiRequest request)
	    {
			var fromTime = request.FromTime.ToString("u");
			var toTime = request.ToTime.ToString("u");

			var httpRequest = new HttpRequestMessage(HttpMethod.Get,
				$"{request.ClientBaseAddress}api/metrics/network/from/{fromTime}/to/{toTime}");

			try
			{
				var response = await _httpClient.SendAsync(httpRequest);

				using var responseStream = await response.Content.ReadAsStreamAsync();

				var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

				return await JsonSerializer.DeserializeAsync<AllNetworkMetricsApiResponse>(responseStream, options);
			}
			catch (Exception e)
			{
				_logger.LogError(e.Message);
			}

			return null;
		}

	    public async Task<AllRamMetricsApiResponse> GetAllRamMetrics(GetAllRamMetricsApiRequest request)
	    {
			var fromTime = request.FromTime.ToString("u");
			var toTime = request.ToTime.ToString("u");

			var httpRequest = new HttpRequestMessage(HttpMethod.Get,
				$"{request.ClientBaseAddress}api/metrics/ram/available/from/{fromTime}/to/{toTime}");

			try
			{
				var response = await _httpClient.SendAsync(httpRequest);

				using var responseStream = await response.Content.ReadAsStreamAsync();

				var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

				return await JsonSerializer.DeserializeAsync<AllRamMetricsApiResponse>(responseStream, options);
			}
			catch (Exception e)
			{
				_logger.LogError(e.Message);
			}

			return null;
		}

		
    }
}
