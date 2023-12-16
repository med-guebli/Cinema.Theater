using Cinema.Application.Dtos.SearchFilters;
using Cinema.Application.Dtos.Theater;
using Cinema.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Application.Dtos.Movie;

namespace Cinema.Application.Interfaces.Services
{
	public interface IMovieService
	{
		public Task<PagedResultDto<MovieDto>> FindAsync(MovieSearchFilterDto searchFilter);

		public Task<MovieDto> CreateAsync(MovieForCreationDto movieDto);

		public Task<MovieDto> UpdateAsync(Guid id, MovieForUpdateDto movieDto);

		public Task<MovieDto?> FindOneAsync(Guid id);
	}
}
