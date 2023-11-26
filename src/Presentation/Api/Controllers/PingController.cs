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
        [HttpGet]
		public IActionResult Ping()
		{
			return Ok();
		}
	}
}
