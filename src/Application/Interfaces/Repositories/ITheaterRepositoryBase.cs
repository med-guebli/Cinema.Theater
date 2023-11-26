using Cinema.Theater.Application.Dtos;
using Cinema.Theater.Application.Dtos.SearchFilters;
using Cinema.Theater.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Theater.Application.Interfaces.Repositories
{
    public interface ITheaterRepositoryBase<TEntity> where TEntity : class, IAuditableEntity
	{
		Task<IEnumerable<TEntity>> FindManyAsync(int pageNumber, int pageSize);

		Task<TEntity?> FindOneAsync(Guid id);

		Task<TEntity> CreateAsync(TEntity entity);

		Task<int> DeleteAsync(Guid id);

		Task<long> CountAsync();
	}
}
