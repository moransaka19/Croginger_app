using SharedKernel.Abstractions.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedKernel.Abstractions.DAL.Repositories
{
	public interface IRepository<T> where T : IBaseEntity
	{
		void Add(T item);
		T FindById(long id);

		IQueryable<T> GetAll(Func<T, bool> predicate);
		IQueryable<T> GetAll();
		void AddRange(IEnumerable<T> item);
		void Update(T item);
		void Delete(T item);
		void DeleteById(long id);
		void DeleteRange(IEnumerable<T> item);
	}
}
