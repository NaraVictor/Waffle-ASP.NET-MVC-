using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Waffle.Repository.Interface;

namespace Waffle.Repository.Concrete
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		private DbSet<TEntity> _entity;
		public DbContext db;

		public Repository(DbContext context)
		{
			_entity = context.Set<TEntity>();
			db = context;
		}

		

		public TEntity GetById(int id)
		{
			return _entity.Find(id);
		}

		public IEnumerable<TEntity> GetAll()
		{
			return _entity.ToList();
		}

		public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
		{
			return _entity.Where(predicate);
		}

		public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
		{
			return _entity.SingleOrDefault(predicate);
		}

		public void Add(TEntity entity)
		{
			_entity.Add(entity);
		}

		public void AddRange(IEnumerable<TEntity> entities)
		{
			_entity.AddRange(entities);
		}

		public void Remove(TEntity entity)
		{
			_entity.Remove(entity);
		}

		public void RemoveRange(IEnumerable<TEntity> entities)
		{
			_entity.RemoveRange(entities);
		}
	}
}