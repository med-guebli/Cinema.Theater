using Cinema.Application.Dtos;
using Cinema.Application.Dtos.Theater;
using Cinema.Application.Dtos.SearchFilters;
using Cinema.Application.Interfaces.Repositories;
using Cinema.Application.Interfaces.Services;
using Cinema.Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Application.Services
{
	public class TheaterService : ITheaterService
	{
		private readonly ITheaterRepository _TheaterRepository;

		public TheaterService(ITheaterRepository TheaterRepository)
        {
			this._TheaterRepository = TheaterRepository;
		}

		public async Task<TheaterDto> CreateAsync(TheaterForCreationDto TheaterForCreationDto)
		{
			var Theater = TheaterForCreationDto.Adapt<Theater>() with
			{
				CreatedOn = DateTime.UtcNow,
				ChangedBy = "med@username"
			};

			var createdTheater = await _TheaterRepository.CreateTheaterAsync(Theater);

			return createdTheater.Adapt<TheaterDto>();
		}

		public async Task<PagedResultDto<TheaterDto>> FindAllAsync(TheaterSearchFilterDto searchFilterDto)
		{
			var Theaters = await _TheaterRepository.FindManyAsync(searchFilterDto);
			var result = new PagedResultDto<TheaterDto>
			{
				TotalDocuments = await _TheaterRepository.CountAsync(),
				PageNumber = searchFilterDto.PageNumber,
				PageSize = searchFilterDto.PageSize,
				Entities = Theaters.Adapt<IEnumerable<TheaterDto>>()
			};

			return result;
		}

		public async Task<TheaterDto?> FindOneAsync(Guid id)
		{
			var Theater = await _TheaterRepository.FindOneAsync(id);

			return Theater.Adapt<TheaterDto>();
		}

		public async Task<PagedResultDto<TheaterDto>> SearchAsync(TextSearchFilterDto textSearchFilterDto)
		{
			var Theaters = await _TheaterRepository.SearchAsync(textSearchFilterDto);

			var result = new PagedResultDto<TheaterDto>
			{
				TotalDocuments = await _TheaterRepository.CountAsync(),
				PageNumber = textSearchFilterDto.PageNumber,
				PageSize = textSearchFilterDto.PageSize,
				Entities = Theaters.Adapt<IEnumerable<TheaterDto>>()
			};

			return result;
		}

		public async Task<TheaterDto> UpdateAsync(Guid id, TheaterForUpdateDto TheaterForUpdateDto)
		{
			var Theater = TheaterForUpdateDto.Adapt<Theater>() with
			{
				UpdatedOn = DateTime.UtcNow,
				ChangedBy = "med@username"
			};

			var updatedTheater = await _TheaterRepository.UpdateAsync(id, Theater);
			
			return updatedTheater.Adapt<TheaterDto>();
		}
	}
}
