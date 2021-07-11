using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricsManager.DAL.Models
{
    public class Agents
    {
	    public int AgentId { get; set; }
	    public string AgentUrl { get; set; }
	    public bool Enabled { get; set; }
    }
}
