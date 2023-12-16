using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Application.Dtos.Movie
{
	public record MovieDirectorDto
	{
		public required string Firstname { get; init; }
		public required string Lastname { get; init; }
	}
}
