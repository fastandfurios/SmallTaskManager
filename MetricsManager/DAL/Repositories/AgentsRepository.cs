using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MetricsManager.DAL.Interfaces;
using MetricsManager.DAL.Models;
using MetricsManager.DAL.Repositories.Connection;

namespace MetricsManager.DAL.Repositories
{
    public class AgentsRepository : IAgentsRepository
    {
	    private readonly IConnection _connection;

	    public AgentsRepository(IConnection connection)
	    {
		    _connection = connection;
			SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
			SqlMapper.AddTypeHandler(new UriHandler());
	    }

	    public void Create(Agents item)
	    {
			using var connection = _connection.GetOpenedConnection();

			connection.Execute("INSERT INTO agents(agentId, agentUrl, enabled) VALUES(@agentId, @agentUrl, @enabled)",
				new
				{
					agentId = item.AgentId,
					agentUrl = item.AgentUrl,
					enabled = item.Enabled
				});
		}

	    public Agents EnableAgent(int agentId)
	    {
			var enabled = true;

		    using var connection = _connection.GetOpenedConnection();

			connection.Execute("UPDATE agents SET enabled=@enabled WHERE agentId=@agentId",
				new { agentId = agentId, enabled = enabled });

		    return connection.QuerySingle<Agents>("SELECT * FROM agents WHERE agentId=@agentId",
			    new{agentId = agentId});
	    }

	    public Agents DisableAgent(int agentId)
	    {
			var enabled = false;

		    using var connection = _connection.GetOpenedConnection();

			connection.Execute("UPDATE agents SET enabled=@enabled WHERE agentId=@agentId",
				new { agentId = agentId, enabled = enabled });

			return connection.QuerySingle<Agents>("SELECT * FROM agents WHERE agentId=@agentId",
			    new {agentId = agentId});
	    }

	    public IEnumerable<Agents> GetRegisterObjects()
	    {
		    using var connection = _connection.GetOpenedConnection();

			return connection.Query<Agents>("SELECT * FROM agents");
	    }
    }
}
