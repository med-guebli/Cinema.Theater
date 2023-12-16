using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Entities
{
	public record MovieDirector
	{
		public required string Firstname { get; init; }
		public required string Lastname { get; init; }
	}
}
