using MetricsManager.DAL.Models.ApiModels;
using System;
using System.Collections.Generic;

namespace MetricsManager.Responses.ApiResponses
{
    public class DotNetMetricsApiResponse
    {
        public List<DotNetMetricApiModel> Metrics { get; set; }
    }
}
