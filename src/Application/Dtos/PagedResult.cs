using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Application.Dtos
{
	public record PagedResultDto<TEntity> where TEntity : class
	{
		public required IEnumerable<TEntity> Entities { get; set; }

		public required int PageNumber { get; set; }

		public required int PageSize { get; set; }

		public required long TotalDocuments { get; set; }
	}
}
