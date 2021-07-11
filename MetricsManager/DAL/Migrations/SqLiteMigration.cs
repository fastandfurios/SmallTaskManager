using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace MetricsManager.DAL.Migrations
{
	[Migration(1)]
	public class SqLiteMigration : Migration
    {
	    public int Id { get; set; }
	    public int Value { get; set; }
	    public DateTimeOffset Time { get; set; }
	    public int AgentId { get; set; }
	    public Uri AgentUrl { get; set; }

	    public override void Up()
	    {
		    Create.Table("cpumetrics")
			    .WithColumn(nameof(Id)).AsInt64().PrimaryKey().Identity()
			    .WithColumn(nameof(AgentId)).AsInt64().ForeignKey("agents","agentId")
			    .WithColumn(nameof(Value)).AsInt32()
			    .WithColumn(nameof(Time)).AsInt64();

			Create.Table("dotnetmetrics")
				.WithColumn(nameof(Id)).AsInt64().PrimaryKey().Identity()
				.WithColumn(nameof(AgentId)).AsInt64().ForeignKey("agents", "agentId")
				.WithColumn(nameof(Value)).AsInt32()
				.WithColumn(nameof(Time)).AsInt64();

			Create.Table("hddmetrics")
				.WithColumn(nameof(Id)).AsInt64().PrimaryKey().Identity()
				.WithColumn(nameof(AgentId)).AsInt64().ForeignKey("agents", "agentId")
				.WithColumn(nameof(Value)).AsInt32()
				.WithColumn(nameof(Time)).AsInt64();

			Create.Table("networkmetrics")
				.WithColumn(nameof(Id)).AsInt64().PrimaryKey().Identity()
				.WithColumn(nameof(AgentId)).AsInt64().ForeignKey("agents", "agentId")
				.WithColumn(nameof(Value)).AsInt32()
				.WithColumn(nameof(Time)).AsInt64();

			Create.Table("rammetrics")
				.WithColumn(nameof(Id)).AsInt64().PrimaryKey().Identity()
				.WithColumn(nameof(AgentId)).AsInt64().ForeignKey("agents", "agentId")
				.WithColumn(nameof(Value)).AsInt32()
				.WithColumn(nameof(Time)).AsInt64();

			Create.Table("agents")
				.WithColumn(nameof(AgentId)).AsInt64().PrimaryKey().Identity()
				.WithColumn(nameof(AgentUrl)).AsString()
				.WithColumn("Enabled").AsBoolean();
	    }

	    public override void Down()
	    {
			Delete.Table("cpumetrics");
			Delete.Table("dotnetmetrics");
			Delete.Table("hddmetrics");
			Delete.Table("networkmetrics");
			Delete.Table("rammetrics");
			Delete.Table("agents");
	    }
    }
}
