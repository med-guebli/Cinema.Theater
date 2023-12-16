using Cinema.Application.Dtos.SearchFilters;
using Cinema.Application.Interfaces.Repositories;
using Cinema.Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
	public class MovieRepository : CinemaRepositoryBase<Movie>, IMovieRepository
	{
		private const string _databaseName = "cinema";
		private const string _collectionName = "movies";

		public MovieRepository(IMongoClient mongoClient)
			: base(mongoClient, _databaseName, _collectionName)
		{
		}
	}
}
