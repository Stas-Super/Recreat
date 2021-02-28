using Recreat.Domain.Core.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recreat.Domain.Interfaces
{
    public interface IRepository<T,TKey> 
        where T : BaseEntity<int>
        where TKey : struct

    {
        Task Create(T item);
        Task<T> Get(TKey Id);
        Task<List<T>> GetAll();
        Task Update(T item);
    }
}
