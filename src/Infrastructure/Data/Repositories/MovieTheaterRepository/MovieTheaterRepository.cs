using Cinema.Theater.Application.Dtos.SearchFilters;
using Cinema.Theater.Application.Interfaces.Repositories;
using Cinema.Theater.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.MovieTheaterRepository
{
	public class MovieTheaterRepository : TheaterRepositoryBase<MovieTheater>, IMovieTheaterRepository
	{
        private const string _databaseName = "Movie-Theater";
        private const string _collectionName = "Theaters";

        public MovieTheaterRepository(IMongoClient mongoClient)
            : base(mongoClient, _databaseName, _collectionName)
        {   
        }

		public async Task<MovieTheater> CreateTheaterAsync(MovieTheater movieTheater)
		{
			return await base.CreateAsync(movieTheater);
		}

		public async Task<MovieTheater> UpdateAsync(Guid id, MovieTheater movieTheater)
		{
			var filter = Builders<MovieTheater>.Filter.Eq(_ => _.Id, id);
			var update = Builders<MovieTheater>.Update
					.Set(_ => _.Name, movieTheater.Name)
					.Set(_ => _.Address, movieTheater.Address)
					.Set(_ => _.NumberOfPlaces, movieTheater.NumberOfPlaces)
					.Set(_ => _.ChangedBy, movieTheater.ChangedBy)
					.Set(_ => _.UpdatedOn, movieTheater.UpdatedOn);

			return await Collection.FindOneAndUpdateAsync(filter, update, new FindOneAndUpdateOptions<MovieTheater, MovieTheater> { ReturnDocument = ReturnDocument.After });
		}

		public async Task<IEnumerable<MovieTheater>> SearchAsync(TextSearchFilterDto textSearchFilter)
		{
			var filter = Builders<MovieTheater>.Filter.Text(textSearchFilter.Search, new TextSearchOptions { DiacriticSensitive = true });
			var projection = Builders<MovieTheater>.Projection.MetaTextScore(nameof(MovieTheater.SearchScore));
			var sort = Builders<MovieTheater>.Sort.MetaTextScore(nameof(MovieTheater.SearchScore));

			return await this.Collection
					.Find<MovieTheater>(filter)
					.Project<MovieTheater>(projection)
					.Sort(sort)
					.Skip(textSearchFilter.PageNumber * textSearchFilter.PageSize)
					.Limit(textSearchFilter.PageSize)
					.ToListAsync();
		}

		public async Task<IEnumerable<MovieTheater>> FindManyAsync(MovieTheaterSearchFilterDto searchFilterDto)
		{
			var builder = Builders<MovieTheater>.Filter;
			var filter = Builders<MovieTheater>.Filter.Empty;

			if (!string.IsNullOrWhiteSpace(searchFilterDto.Name))
			{
				filter &= builder.Or(builder.Eq(_ => _.Name, searchFilterDto.Name));
			}

			var sort = Builders<MovieTheater>.Sort.Ascending(_ => _.Name);

			return await Collection
					.Find(filter)
					.Sort(sort)
					.Skip(searchFilterDto.PageNumber * searchFilterDto.PageSize)
					.Limit(searchFilterDto.PageSize)
					.ToListAsync();
		}

		public async Task Multi()
		{
			await Collection
				.InsertOneAsync(new MovieTheater { Id = Guid.NewGuid(), NumberOfPlaces = 100, Name = "OK", CreatedOn = DateTime.Now, Address = new Address { City = "", Country = "", PostalCode = "78100", Street1 = "Okok" } });
		}
	}
}
