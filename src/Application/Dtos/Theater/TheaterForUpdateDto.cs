using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Application.Dtos.Address;

namespace Cinema.Application.Dtos.Theater
{
    public class TheaterForUpdateDto
	{
		public required string Name { get; init; }

		public required int NumberOfPlaces { get; init; }

		public required AddressDto Address { get; init; }
	}
}
