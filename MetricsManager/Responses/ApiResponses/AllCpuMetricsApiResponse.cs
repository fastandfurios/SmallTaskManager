using System.Collections.Generic;
using MetricsManager.DAL.Models.ApiModels;

namespace MetricsManager.Responses.ApiResponses
{
    public class AllCpuMetricsApiResponse
    {
        public List<CpuMetricApiModel> Metrics { get; set; }
    }
}
