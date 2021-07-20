using System;

namespace MetricsManagerClient.DTO
{
    public class CpuMetricDto
    {
        public int AgentId { get; set; }
        public int Value { get; set; }
        public DateTimeOffset Time { get; set; }
    }
}
