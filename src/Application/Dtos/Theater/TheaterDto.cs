using Cinema.Application.Dtos.Address;

namespace Cinema.Application.Dtos.Theater
{
    public record TheaterDto
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
