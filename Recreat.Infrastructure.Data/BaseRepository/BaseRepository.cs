using Microsoft.EntityFrameworkCore;
using Recreat.Domain.Core.Base;
using Recreat.Infrastructure.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recreat.Domain.Interfaces.Base
{
    public abstract class BaseRepository<T,Tkey> : IRepository<T, Tkey>
        where T : BaseEntity<int>
        where Tkey : struct
    {
        protected ApplicationDbContext ctx;
        public async Task Create(T item)
        {
            await ctx.Set<T>().AddAsync(item);
        }

        public async Task<T> Get(Tkey Id)
        {
            var item = await ctx.Set<T>().FirstOrDefaultAsync(x => x.Id.Equals(Id));
            return item;
        }

        public Task<List<T>> GetAll()
        {
            return ctx.Set<T>().ToListAsync();
        }
        public abstract Task Update(T item);
    }
}
