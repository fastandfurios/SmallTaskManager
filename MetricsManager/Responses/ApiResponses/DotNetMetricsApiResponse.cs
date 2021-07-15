using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetricsManager.Responses.DTO;

namespace MetricsManager.Responses.ApiResponses
{
    public class DotNetMetricsApiResponse
    {
	    public int Id { get; set; }
	    public int Value { get; set; }
	    public DateTimeOffset Time { get; set; }
    }
}
