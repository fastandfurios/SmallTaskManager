
using System.Collections.Generic;
using System.Threading.Tasks;
using MetricsManager.Requests.ApiRequests;
using MetricsManager.Responses.ApiResponses;

namespace MetricsManager.Client
{
    public interface IMetricsAgentClient
    {
	    Task<AllCpuMetricsApiResponse> GetAllCpuMetrics(GetAllCpuMetricsApiRequest request);
	    Task<DotNetMetricsApiResponse> GetDotNetMetrics(DotNetHeapMetricsApiRequest request);
	    Task<AllHddMetricsApiResponse> GetAllHddMetrics(GetAllHddMetricsApiRequest request);
	    Task<AllNetworkMetricsApiResponse> GetAllNetworkMetrics(GetAllNetworkMetricsApiRequest request);
	    Task<AllRamMetricsApiResponse> GetAllRamMetrics(GetAllRamMetricsApiRequest request);
    }
}
