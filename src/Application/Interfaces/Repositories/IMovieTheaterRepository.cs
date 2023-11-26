using Cinema.Theater.Application.Dtos;
using Cinema.Theater.Application.Dtos.SearchFilters;
using Cinema.Theater.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Theater.Application.Interfaces.Repositories
{
	public interface IMovieTheaterRepository : ITheaterRepositoryBase<MovieTheater>
	{
		Task<MovieTheater> CreateTheaterAsync(MovieTheater movieTheater);

		Task<MovieTheater> UpdateAsync(Guid id, MovieTheater movieTheater);

		Task<IEnumerable<MovieTheater>> SearchAsync(TextSearchFilterDto textSearchFilterDto);

		Task<IEnumerable<MovieTheater>> FindManyAsync(MovieTheaterSearchFilterDto searchFilterDto);

		Task Multi();
	}
}