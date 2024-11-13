using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ElectricityBillPaymentSystem.Application.Contracts.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByColumnAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task DeleteAsync(int id);
        Task UpdateASync(T entity);
        Task<T> AddAsync(T entity);
    }
}
