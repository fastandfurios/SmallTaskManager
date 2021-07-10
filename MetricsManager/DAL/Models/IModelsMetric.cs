using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricsManager.DAL.Models
{
    public interface IModelsMetric
    {
        int Id { get; set; }
        int AgentId { get; set; }
        int Value { get; set; }
        long Time { get; set; }
    }
}
