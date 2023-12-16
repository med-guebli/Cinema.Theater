using Cinema.Application.Dtos.SearchFilters;
using Cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Application.Interfaces.Repositories
{
	public interface IMovieRepository : IRepositoryBase<Movie>
	{
	}
}