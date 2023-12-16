using Cinema.Application.Dtos;
using Cinema.Application.Dtos.Theater;
using Cinema.Application.Dtos.SearchFilters;
using Cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Application.Interfaces.Services
{
	public interface ITheaterService
	{
		public Task<PagedResultDto<TheaterDto>> FindAllAsync(TheaterSearchFilterDto searchFilter);

		public Task<PagedResultDto<TheaterDto>> SearchAsync(TextSearchFilterDto textSearchFilterDto);

		public Task<TheaterDto> CreateAsync(TheaterForCreationDto TheaterForCreationDto);

		public Task<TheaterDto> UpdateAsync(Guid id, TheaterForUpdateDto TheaterForUpdateDto);

		public Task<TheaterDto?> FindOneAsync(Guid id);
	}
}
