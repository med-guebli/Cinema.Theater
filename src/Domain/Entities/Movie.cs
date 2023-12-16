using Cinema.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Entities
{
	public record Movie : SearchableEntity
	{
		public required string Name { get; init; }

		public required DateOnly ReleaseDate { get; init; }

		public required string Thumbnail { get; init; }

		public required MovieCategory[] Categories { get; init; }

		public required string Synopsis { get; set; }

		public required MovieDirector Director { get; init; }
	}
}
