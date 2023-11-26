using Microsoft.AspNetCore.Mvc;
using Cinema.Theater.Application.Interfaces.Services;
using Cinema.Theater.Application.Dtos.MovieTheater;
using Cinema.Theater.Application.Dtos.SearchFilters;
using FluentValidation;
using Mapster;
using Cinema.Theater.Application.Dtos;
using Api.Validators;

namespace Api.Controllers
{
	[Route("api/movie-theaters")]
	public class MovieTheaterController : ControllerBase
	{
		private readonly IMovieTheaterService _movieTheaterService;
		private readonly ILogger<MovieTheaterController> _logger;

		public MovieTheaterController(
			IMovieTheaterService movieTheaterService,
			ILogger<MovieTheaterController> logger)
		{
			_movieTheaterService = movieTheaterService;
			_logger = logger;
		}

		[HttpGet]
        public async Task<PagedResultDto<MovieTheaterDto>> FindAll(MovieTheaterSearchFilterDto searchFilter, string? ok)
        {
			return await _movieTheaterService.FindAllAsync(searchFilter);
		}

		[HttpGet("{id}")]
		public async Task<MovieTheaterDto?> FindOne(Guid id) 
		{
			return await _movieTheaterService.FindOneAsync(id);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] MovieTheaterForCreationDto movieTheaterForCreationDto)
		{
			new MovieTheaterForCreationDtoValidator().Validate(movieTheaterForCreationDto);

			var createdMovieTheater = await _movieTheaterService.CreateAsync(movieTheaterForCreationDto);

			return CreatedAtAction(nameof(Create), createdMovieTheater.Adapt<MovieTheaterDto>());
		}

		[HttpPost("create-many")]
		public async Task CreateMany([FromBody] MovieTheaterForCreationDto[] movieTheaterForCreationDtos)
		{
            foreach (var item in movieTheaterForCreationDtos)
            {
				await _movieTheaterService.CreateAsync(item);
            }
        }

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(Guid id, [FromBody] MovieTheaterForUpdateDto movieTheaterForUpdateDto)
		{
			var validation = new MovieTheaterForUpdateDtoValidator().Validate(movieTheaterForUpdateDto);

            if (!validation.IsValid)
            {
				return BadRequest(validation.Errors);
            }

            return Ok(await _movieTheaterService.UpdateAsync(id, movieTheaterForUpdateDto));
		}

		[HttpGet("search")]
		public async Task<IActionResult> Search([FromQuery] TextSearchFilterDto textSearchFilterDto)
		{
			var validation = new TextSearchFilterDtoValidator().Validate(textSearchFilterDto);

			if (!validation.IsValid)
			{
				return BadRequest(validation.Errors);
			}

			return Ok(await _movieTheaterService.SearchAsync(textSearchFilterDto));
		}
	}
}
