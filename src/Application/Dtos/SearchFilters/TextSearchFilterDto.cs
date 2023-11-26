using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Theater.Application.Dtos.SearchFilters
{
	public record TextSearchFilterDto : Pagination
	{
		public required string Search { get; init; }
	}
}
