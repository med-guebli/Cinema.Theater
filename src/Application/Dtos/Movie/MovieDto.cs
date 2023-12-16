using Cinema.Domain.Entities;
using Cinema.Domain.Enums;

namespace Cinema.Application.Dtos.Movie
{
    public record MovieDto
	{
		public required Guid Id { get; init; }

		public DateTime CreatedOn { get; init; }

		public DateTime? UpdatedOn { get; init; }

		public string? ChangedBy { get; init; }

		public double? SearchScore { get; init; }

		public required string Name { get; init; }

		public required DateOnly ReleaseDate { get; init; }

		public required string Thumbnail { get; init; }

		public required MovieCategory[] Categories { get; init; }

		public required string Synopsis { get; set; }

		public required MovieDirector Director { get; init; }
	}
}
