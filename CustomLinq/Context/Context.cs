using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLinq.Context
{
    public class Context : DbContext
    {
        private readonly ILoggerFactory loggerFactory;

        public DbSet<UserModel> Users { get; set; }

        public Context()
        {

        }

        public Context(ILoggerFactory loggerFactory)
        {
            this.loggerFactory = loggerFactory;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-KB8D6FJU\\MSSQLSERVER1;Initial Catalog=EstateSale;Integrated Security=True;Trust Server Certificate=True;");
            optionsBuilder.EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().ToTable("Users");
        }
    }
}
