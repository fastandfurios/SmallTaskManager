
using System.Collections.Generic;
using MetricsManager.Requests.ApiRequests;
using MetricsManager.Responses.ApiResponses;

namespace MetricsManager.Client
{
    public interface IMetricsAgentClient
    {
	    AllCpuMetricsApiResponse GetAllCpuMetrics(GetAllCpuMetricsApiRequest request);
	    DotNetMetricsApiResponse GetDotNetMetrics(DotNetHeapMetricsApiRequest request);
	    IList<AllHddMetricsApiResponse> GetAllHddMetrics(GetAllHddMetricsApiRequest request);
	    AllNetworkMetricsApiResponse GetAllNetworkMetrics(GetAllNetworkMetricsApiRequest request);
	    AllRamMetricsApiResponse GetAllRamMetrics(GetAllRamMetricsApiRequest request);
    }
}
