using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bank.Storage.Contract.Repository
{
	public interface IRepository<TEntity, TIdType> where TEntity : class
	{
		TEntity Get(TIdType id);
		IEnumerable<TEntity> GetAll();
		IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

		void Add(TEntity entity);
		void AddRange(IEnumerable<TEntity> entities);

		void Delete(TEntity entity);
		void DeleteRange(IEnumerable<TEntity> entities);
	}
}