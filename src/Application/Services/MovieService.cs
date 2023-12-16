using Cinema.Application.Dtos.SearchFilters;
using Cinema.Application.Dtos.Movie;
using Cinema.Application.Dtos;
using Cinema.Application.Interfaces.Repositories;
using Cinema.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using Cinema.Domain.Entities;

namespace Cinema.Application.Services
{
	public class MovieService : IMovieService
	{
		private readonly IMovieRepository _movieRepository;

		public MovieService(IMovieRepository MovieRepository)
		{
			this._movieRepository = MovieRepository;
		}

		public async Task<MovieDto> CreateAsync(MovieForCreationDto movieDto)
		{
			var movie = await _movieRepository.CreateAsync(movieDto.Adapt<Movie>());

			return movie.Adapt<MovieDto>();
		}

		public async Task<PagedResultDto<MovieDto>> FindAsync(MovieSearchFilterDto searchFilter)
		{
			var entities = await _movieRepository.FindAsync(searchFilter.PageNumber, searchFilter.PageSize);
			return new PagedResultDto<MovieDto>
			{
				Entities = entities.Select(entity => entity.Adapt<MovieDto>()),
				PageNumber = searchFilter.PageNumber,
				PageSize = searchFilter.PageSize,
				TotalDocuments = await _movieRepository.CountAsync(),
			};
		}

		public async Task<MovieDto?> FindOneAsync(Guid id)
		{
			var movie = await _movieRepository.FindOneAsync(id);

			return movie.Adapt<MovieDto?>();
		}

		public Task<MovieDto> UpdateAsync(Guid id, MovieForUpdateDto movieDto)
		{
			throw new NotImplementedException();
		}
	}
}
