using Microsoft.EntityFrameworkCore;
using Recreat.Domain.Interfaces.Interfaces;
using Recreat.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recreat.Domain.Interfaces
{
    public abstract class BaseRepository<T,Tkey> : IRepository<T,Tkey>
        where T : class
        where Tkey: struct
    {
        protected ApplicationDbContext ctx;

        public virtual async Task CreateAsync(T item)
        {
            await ctx.Set<T>().AddAsync(item);
            await ctx.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(Tkey id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await ctx.Set<T>().ToListAsync();
        }

        public virtual Task<T> GetAsync(Tkey id)
        {
            throw new NotImplementedException();
        }
    }
}
