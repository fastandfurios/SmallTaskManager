using System;
using System.Collections.Generic;
using MetricsManager.DAL.Models.ApiModels;

namespace MetricsManager.Responses.ApiResponses
{
    public class AllHddMetricsApiResponse
    {
        public List<HddMetricApiModel> Metrics { get; set; }
    }
}
