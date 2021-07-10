﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricsManager.Requests
{
    public class GetAllCpuMetricsApiRequest
    {
	    public Uri AgentUrl { get; set; }
	    public DateTimeOffset FromTime { get; set; }
	    public DateTimeOffset ToTime { get; set; }
    }
}
