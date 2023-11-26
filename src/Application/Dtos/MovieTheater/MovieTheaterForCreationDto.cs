using Cinema.Theater.Application.Dtos.Address;

namespace Cinema.Theater.Application.Dtos.MovieTheater
{
    public class MovieTheaterForCreationDto
	{
		public required string Name { get; init; }

		public uint NumberOfPlaces { get; init; }

		public required AddressDto Address { get; init; }
	}
}
