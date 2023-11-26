using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Theater.Application.Dtos.Address;

namespace Cinema.Theater.Application.Dtos.MovieTheater
{
    public class MovieTheaterForUpdateDto
	{
		public required string Name { get; init; }

		public required int NumberOfPlaces { get; init; }

		public required AddressDto Address { get; init; }
	}
}
