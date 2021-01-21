using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recreat.Domain.Interfaces.Interfaces
{
    public interface IRepository<T, TKey> where T : class
    {
        public Task CreateAsync(T item);
        public Task DeleteAsync(TKey id);
        public Task<T> GetAsync(TKey id);
        public Task<List<T>> GetAllAsync();
    }
}
