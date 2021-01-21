using Microsoft.EntityFrameworkCore;
using Recreat.Domain.Core;
using System;

namespace Recreat.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
