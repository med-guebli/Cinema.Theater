using Cinema.Application.Dtos;
using Cinema.Application.Dtos.SearchFilters;
using Cinema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Application.Interfaces.Repositories
{
	public interface ITheaterRepository : IRepositoryBase<Theater>
	{
		Task<Theater> CreateTheaterAsync(Theater Theater);

		Task<Theater> UpdateAsync(Guid id, Theater Theater);

		Task<IEnumerable<Theater>> SearchAsync(TextSearchFilterDto textSearchFilterDto);

		Task<IEnumerable<Theater>> FindManyAsync(TheaterSearchFilterDto searchFilterDto);

		Task Multi();
	}
}