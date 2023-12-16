using Cinema.Application.Dtos.SearchFilters;
using Cinema.Application.Interfaces.Repositories;
using Cinema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class TheaterRepository : CinemaRepositoryBase<Theater>, ITheaterRepository
    {
        private const string _databaseName = "cinema";
        private const string _collectionName = "theaters";

        public TheaterRepository(IMongoClient mongoClient)
            : base(mongoClient, _databaseName, _collectionName)
        {
        }

        public async Task<Theater> CreateTheaterAsync(Theater Theater)
        {
            return await CreateAsync(Theater);
        }

        public async Task<Theater> UpdateAsync(Guid id, Theater Theater)
        {
            var filter = Builders<Theater>.Filter.Eq(_ => _.Id, id);
            var update = Builders<Theater>.Update
                    .Set(_ => _.Name, Theater.Name)
                    .Set(_ => _.Address, Theater.Address)
                    .Set(_ => _.NumberOfPlaces, Theater.NumberOfPlaces)
                    .Set(_ => _.ChangedBy, Theater.ChangedBy)
                    .Set(_ => _.UpdatedOn, Theater.UpdatedOn);

            return await Collection.FindOneAndUpdateAsync(filter, update, new FindOneAndUpdateOptions<Theater, Theater> { ReturnDocument = ReturnDocument.After });
        }

        public async Task<IEnumerable<Theater>> SearchAsync(TextSearchFilterDto textSearchFilter)
        {
            var filter = Builders<Theater>.Filter.Text(textSearchFilter.Search, new TextSearchOptions { DiacriticSensitive = true });
            var projection = Builders<Theater>.Projection.MetaTextScore(nameof(Theater.SearchScore));
            var sort = Builders<Theater>.Sort.MetaTextScore(nameof(Theater.SearchScore));

            return await Collection
                    .Find(filter)
                    .Project<Theater>(projection)
                    .Sort(sort)
                    .Skip(textSearchFilter.PageNumber * textSearchFilter.PageSize)
                    .Limit(textSearchFilter.PageSize)
                    .ToListAsync();
        }

        public async Task<IEnumerable<Theater>> FindManyAsync(TheaterSearchFilterDto searchFilterDto)
        {
            var builder = Builders<Theater>.Filter;
            var filter = Builders<Theater>.Filter.Empty;

            if (!string.IsNullOrWhiteSpace(searchFilterDto.Name))
            {
                filter &= builder.Or(builder.Eq(_ => _.Name, searchFilterDto.Name));
            }

            var sort = Builders<Theater>.Sort.Ascending(_ => _.Name);

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
                .InsertOneAsync(new Theater { Id = Guid.NewGuid(), NumberOfPlaces = 100, Name = "OK", CreatedOn = DateTime.Now, Address = new Address { City = "", Country = "", PostalCode = "78100", Street1 = "Okok" } });
        }
    }
}
