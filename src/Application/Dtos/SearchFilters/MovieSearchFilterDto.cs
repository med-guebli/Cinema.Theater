using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Application.Dtos.SearchFilters
{
	public record MovieSearchFilterDto : Pagination
	{
		public string? Name { get; set; }
	}
}
