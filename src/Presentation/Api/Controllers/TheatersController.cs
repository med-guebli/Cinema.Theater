using Microsoft.AspNetCore.Mvc;
using Cinema.Application.Interfaces.Services;
using Cinema.Application.Dtos.Theater;
using Cinema.Application.Dtos.SearchFilters;
using FluentValidation;
using Mapster;
using Cinema.Application.Dtos;
using Api.Validators;

namespace Api.Controllers
{
	[Route("api/theaters")]
	public class TheatersController : ControllerBase
	{
		private readonly ITheaterService _TheaterService;
		private readonly ILogger<TheatersController> _logger;

		public TheatersController(
			ITheaterService TheaterService,
			ILogger<TheatersController> logger)
		{
			_TheaterService = TheaterService;
			_logger = logger;
		}

		[HttpGet]
        public async Task<PagedResultDto<TheaterDto>> FindAll(TheaterSearchFilterDto searchFilter, string? ok)
        {
			return await _TheaterService.FindAllAsync(searchFilter);
		}

		[HttpGet("{id}")]
		public async Task<TheaterDto?> FindOne(Guid id) 
		{
			return await _TheaterService.FindOneAsync(id);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] TheaterForCreationDto theater)
		{
			new TheaterForCreationDtoValidator().Validate(theater);

			var createdTheater = await _TheaterService.CreateAsync(theater);

			return CreatedAtAction(nameof(Create), createdTheater.Adapt<TheaterDto>());
		}

		[HttpPost("create-many")]
		public async Task CreateMany([FromBody] TheaterForCreationDto[] TheaterForCreationDtos)
		{
            foreach (var item in TheaterForCreationDtos)
            {
				await _TheaterService.CreateAsync(item);
            }
        }

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(Guid id, [FromBody] TheaterForUpdateDto theater)
		{
			var validation = new TheaterForUpdateDtoValidator().Validate(theater);

            if (!validation.IsValid)
            {
				return BadRequest(validation.Errors);
            }

            return Ok(await _TheaterService.UpdateAsync(id, theater));
		}

		[HttpGet("search")]
		public async Task<IActionResult> Search([FromQuery] TextSearchFilterDto textSearchFilterDto)
		{
			var validation = new TextSearchFilterDtoValidator().Validate(textSearchFilterDto);

			if (!validation.IsValid)
			{
				return BadRequest(validation.Errors);
			}

			return Ok(await _TheaterService.SearchAsync(textSearchFilterDto));
		}
	}
}
