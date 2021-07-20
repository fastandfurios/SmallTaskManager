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
        CpuMetricsApiResponse GetAllCpuMetrics(CpuMetricsApiRequest request);
    }
}
