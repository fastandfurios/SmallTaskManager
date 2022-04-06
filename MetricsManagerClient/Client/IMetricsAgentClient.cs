using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetricsManagerClient.Requests;
using MetricsManagerClient.Responses.ApiResponses;

namespace MetricsManagerClient.Client
{
    public interface IMetricsAgentClient
    {
        Task<TResponse> GetAllMetrics<TResponse>(Object request, string keyword);
    }
}
