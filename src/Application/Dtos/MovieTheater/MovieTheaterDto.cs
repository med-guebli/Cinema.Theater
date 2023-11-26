using Cinema.Theater.Application.Dtos.Address;

namespace Cinema.Theater.Application.Dtos.MovieTheater
{
    public record MovieTheaterDto
	{
		public Guid Id { get; init; }

		public required string Name { get; init; }

		public required uint NumberOfPlaces { get; init; }

		public required AddressDto Address { get; init; }

		public DateTime CreatedOn { get; init; }

		public DateTime? UpdatedOn { get; init; }

		public string? ChangedBy { get; init; }
	}
}
