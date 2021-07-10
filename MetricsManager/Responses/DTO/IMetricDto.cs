using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricsManager.Responses.DTO
{
    public interface IMetricDto
    {
        int AgentId { get; set; }
        int Value { get; set; }
        DateTimeOffset Time { get; set; }
    }
}
