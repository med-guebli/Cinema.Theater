using Cinema.Theater.Application.Dtos;
using Cinema.Theater.Application.Dtos.MovieTheater;
using Cinema.Theater.Application.Dtos.SearchFilters;
using Cinema.Theater.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Theater.Application.Interfaces.Services
{
	public interface IMovieTheaterService
	{
		public Task<PagedResultDto<MovieTheaterDto>> FindAllAsync(MovieTheaterSearchFilterDto searchFilter);

		public Task<PagedResultDto<MovieTheaterDto>> SearchAsync(TextSearchFilterDto textSearchFilterDto);

		public Task<MovieTheaterDto> CreateAsync(MovieTheaterForCreationDto movieTheaterForCreationDto);

		public Task<MovieTheaterDto> UpdateAsync(Guid id, MovieTheaterForUpdateDto movieTheaterForUpdateDto);

		public Task<MovieTheaterDto?> FindOneAsync(Guid id);
	}
}
