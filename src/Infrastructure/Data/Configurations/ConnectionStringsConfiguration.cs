using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
    public record ConnectionStringsConfiguration
	{
		public const string ConnectionStrings = "ConnectionStrings";
		public required string MongoDbConnection { get; set; }
	}
}
