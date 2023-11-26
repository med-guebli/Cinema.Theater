using Cinema.Theater.Application.Interfaces.Repositories;
using Cinema.Theater.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Api.Controllers
{
	[Route("ping")]
	public class PingController : ControllerBase
	{
		private readonly IMovieTheaterRepository movieTheater;

		public PingController(IMovieTheaterRepository movieTheater)
        {
			this.movieTheater = movieTheater;
		}

        [HttpGet]
		public IActionResult Ping()
		{
			movieTheater.Multi();

			return Ok();
		}
	}
}
