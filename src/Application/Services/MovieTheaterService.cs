using Cinema.Theater.Application.Dtos;
using Cinema.Theater.Application.Dtos.MovieTheater;
using Cinema.Theater.Application.Dtos.SearchFilters;
using Cinema.Theater.Application.Interfaces.Repositories;
using Cinema.Theater.Application.Interfaces.Services;
using Cinema.Theater.Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Theater.Application.Services
{
	public class MovieTheaterService : IMovieTheaterService
	{
		private readonly IMovieTheaterRepository _movieTheaterRepository;

		public MovieTheaterService(IMovieTheaterRepository movieTheaterRepository)
        {
			this._movieTheaterRepository = movieTheaterRepository;
		}

		public async Task<MovieTheaterDto> CreateAsync(MovieTheaterForCreationDto movieTheaterForCreationDto)
		{
			var movieTheater = movieTheaterForCreationDto.Adapt<MovieTheater>() with
			{
				CreatedOn = DateTime.UtcNow,
				ChangedBy = "med@username"
			};

			var createdMovieTheater = await _movieTheaterRepository.CreateTheaterAsync(movieTheater);

			return createdMovieTheater.Adapt<MovieTheaterDto>();
		}

		public async Task<PagedResultDto<MovieTheaterDto>> FindAllAsync(MovieTheaterSearchFilterDto searchFilterDto)
		{
			var movieTheaters = await _movieTheaterRepository.FindManyAsync(searchFilterDto);
			var result = new PagedResultDto<MovieTheaterDto>
			{
				TotalDocuments = await _movieTheaterRepository.CountAsync(),
				PageNumber = searchFilterDto.PageNumber,
				PageSize = searchFilterDto.PageSize,
				Entities = movieTheaters.Adapt<IEnumerable<MovieTheaterDto>>()
			};

			return result;
		}

		public async Task<MovieTheaterDto?> FindOneAsync(Guid id)
		{
			var movieTheater = await _movieTheaterRepository.FindOneAsync(id);

			return movieTheater.Adapt<MovieTheaterDto>();
		}

		public async Task<PagedResultDto<MovieTheaterDto>> SearchAsync(TextSearchFilterDto textSearchFilterDto)
		{
			var movieTheaters = await _movieTheaterRepository.SearchAsync(textSearchFilterDto);

			var result = new PagedResultDto<MovieTheaterDto>
			{
				TotalDocuments = await _movieTheaterRepository.CountAsync(),
				PageNumber = textSearchFilterDto.PageNumber,
				PageSize = textSearchFilterDto.PageSize,
				Entities = movieTheaters.Adapt<IEnumerable<MovieTheaterDto>>()
			};

			return result;
		}

		public async Task<MovieTheaterDto> UpdateAsync(Guid id, MovieTheaterForUpdateDto movieTheaterForUpdateDto)
		{
			var movieTheater = movieTheaterForUpdateDto.Adapt<MovieTheater>() with
			{
				UpdatedOn = DateTime.UtcNow,
				ChangedBy = "med@username"
			};

			var updatedmovieTheater = await _movieTheaterRepository.UpdateAsync(id, movieTheater);
			
			return updatedmovieTheater.Adapt<MovieTheaterDto>();
		}
	}
}
