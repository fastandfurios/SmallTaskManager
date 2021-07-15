using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MetricsManager.DAL.Interfaces;
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

	    public void Create(Models.Agents item)
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

	    public Models.Agents GetEnabledAgent(int agentId)
	    {
		    using var connection = _connection.GetOpenedConnection();

		    return connection.QuerySingle<Models.Agents>("SELECT * FROM agents WHERE agentId=@agentId",
			    new{agentId = agentId});
	    }

	    public Models.Agents GetDisabledAgent(int agentId)
	    {
		    using var connection = _connection.GetOpenedConnection();

		    return connection.QuerySingle<Models.Agents>("SELECT * FROM agents WHERE agentId=@agentId",
			    new {agentId = agentId});
	    }

	    public IList<Models.Agents> GetRegisterObjects()
	    {
		    using var connection = _connection.GetOpenedConnection();

			return connection.Query<Models.Agents>("SELECT * FROM agents").ToList();
	    }
    }
}
