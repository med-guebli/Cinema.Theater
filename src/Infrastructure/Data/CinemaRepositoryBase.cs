using AutoFixture;
using Cinema.Application.Dtos;
using Cinema.Application.Dtos.SearchFilters;
using Cinema.Application.Interfaces.Repositories;
using Cinema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CinemaRepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class, IAuditableEntity
	{
		private readonly IMongoClient _client;
		protected readonly IMongoDatabase Database;
		protected readonly IMongoCollection<TEntity> Collection;

		public CinemaRepositoryBase(
			IMongoClient mongoClient,
			string databaseName,
			string collectionName
			)
        {
			_client = mongoClient;
			Database = _client.GetDatabase(databaseName);
			Collection = Database.GetCollection<TEntity>(collectionName);
		}

		public async Task<TEntity> CreateAsync(TEntity entity)
		{
			await Collection.InsertOneAsync(entity);

			return entity;
		}

		public async Task<int> DeleteAsync(Guid id)
		{
			var deletion = await Collection.DeleteOneAsync(_ => _.Id == id);

			return (int)deletion.DeletedCount;
		}

		public async Task<IEnumerable<TEntity>> FindAsync(int pageNumber, int pageSize)
		{
			return await Collection
					.Find(_ => true)
					.Skip(pageNumber * pageSize)
					.Limit(pageSize)
					.ToListAsync();
		}

		public async Task<TEntity?> FindOneAsync(Guid id)
		{
			var filter = Builders<TEntity>.Filter.Eq(_ => _.Id, id);
			var result = await Collection.FindAsync(filter);

			return await result.FirstOrDefaultAsync();
		}

		public async Task<long> CountAsync()
		{
			return await Collection.CountDocumentsAsync(Builders<TEntity>.Filter.Empty);
		}
	}
}
