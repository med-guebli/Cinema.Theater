using Api.Validators;
using Cinema.Application.Dtos.SearchFilters;
using Cinema.Application.Dtos.Movie;
using Cinema.Application.Dtos;
using Cinema.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mapster;

namespace Api.Controllers
{
	[Route("api/movies")]
	public class MoviesController : ControllerBase
	{
		private readonly IMovieService _movieService;
		private readonly ILogger<MoviesController> _logger;

		public MoviesController(
			IMovieService movieService,
			ILogger<MoviesController> logger)
		{
			_movieService = movieService;
			_logger = logger;
		}

		[HttpGet]
		public async Task<PagedResultDto<MovieDto>> FindAll(MovieSearchFilterDto searchFilter, string? ok)
		{
			return await _movieService.FindAsync(searchFilter);
		}

		[HttpGet("{id}")]
		public async Task<MovieDto?> FindOne(Guid id)
		{
			return await _movieService.FindOneAsync(id);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] MovieForCreationDto Movie)
		{
			var createdMovie = await _movieService.CreateAsync(Movie);

			return CreatedAtAction(nameof(Create), createdMovie.Adapt<MovieDto>());
		}

		[HttpPost("create-many")]
		public async Task CreateMany([FromBody] MovieForCreationDto[] movies)
		{
			foreach (var item in movies)
			{
				await _movieService.CreateAsync(item);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(Guid id, [FromBody] MovieForUpdateDto Movie)
		{
			return Ok(await _movieService.UpdateAsync(id, Movie));
		}

		[HttpGet("lol")]
		public IActionResult Lol()
		{
			return Ok("Lol");
		}
	}
}
