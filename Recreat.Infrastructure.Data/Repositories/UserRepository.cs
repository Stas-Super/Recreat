using Microsoft.EntityFrameworkCore;
using Recreat.Domain.Core;
using Recreat.Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recreat.Infrastructure.Data.Repositories
{
    public class UserRepository : BaseRepository<User,int>
    {
        public override async Task Update(User item)
        {
            var user = await Get(item.Id);
            ctx.Update(user);
        }
        public async Task<User> GetUserByEmail(string email)
        {
            var user = await ctx.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
            if (user is null)
                return null;
            return user;
        }
    }
}
