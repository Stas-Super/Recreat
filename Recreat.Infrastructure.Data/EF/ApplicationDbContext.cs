using Microsoft.EntityFrameworkCore;
using Recreat.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recreat.Infrastructure.Data.EF
{
    public class ApplicationDbContext : DbContext
    {
        private string connectionString;
        public DbSet<User> Users { get; set; }
        public ApplicationDbContext(string connection) 
        {
            this.connectionString = connection;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
