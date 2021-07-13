using System;
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
		    var fromParameter = request.FromTime.ToUnixTimeSeconds();
		    var toParameter = request.ToTime.ToUnixTimeSeconds();

		    return null;
	    }

	    public DotNetMetricsApiResponse GetDotNetMetrics(DotNetHeapMetricsApiRequest request)
	    {
		    throw new NotImplementedException();
	    }

	    public AllHddMetricsApiResponse GetAllHddMetrics(GetAllHddMetricsApiRequest request)
	    {
		    var fromParameter = request.FromTime.ToUnixTimeSeconds();
		    var toParameter = request.ToTime.ToUnixTimeSeconds();

		    var httpRequest = new HttpRequestMessage(HttpMethod.Get, 
			    $"{request.ClientBaseAddress}/api/hdd/left/from/{fromParameter}/to/{toParameter}");

		    try
		    {
			    var response = _httpClient.SendAsync(httpRequest).Result;

			    using var responseStream = response.Content.ReadAsStreamAsync().Result;

				var result = JsonSerializer.DeserializeAsync<AllHddMetricsApiResponse>(responseStream).Result;

				return result;
		    }
		    catch (Exception e)
		    {
			    _logger.LogError(e.Message);
		    }

		    return null;
	    }

	    public AllNetworkMetricsApiResponse GetAllNetworkMetrics(GetAllNetworkMetricsApiRequest request)
	    {
		    throw new NotImplementedException();
	    }

	    public AllRamMetricsApiResponse GetAllRamMetrics(GetAllRamMetricsApiRequest request)
	    {
		    throw new NotImplementedException();
	    }
    }
}
