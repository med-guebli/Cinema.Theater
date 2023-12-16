using Cinema.Application.Dtos;
using Cinema.Application.Dtos.SearchFilters;
using Cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Application.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class, IAuditableEntity
	{
		Task<IEnumerable<TEntity>> FindAsync(int pageNumber, int pageSize);

		Task<TEntity?> FindOneAsync(Guid id);

		Task<TEntity> CreateAsync(TEntity entity);

		Task<int> DeleteAsync(Guid id);

		Task<long> CountAsync();
	}
}
