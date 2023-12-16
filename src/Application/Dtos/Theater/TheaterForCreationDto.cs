using Cinema.Application.Dtos.Address;

namespace Cinema.Application.Dtos.Theater
{
    public class TheaterForCreationDto
	{
		public required string Name { get; init; }

		public uint NumberOfPlaces { get; init; }

		public required AddressDto Address { get; init; }
	}
}
