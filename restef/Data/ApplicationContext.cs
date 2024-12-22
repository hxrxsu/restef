using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restef.Data
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        //public DbSet<SummaryFeedbacks> SFB => Set<SummaryFeedbacks>();
        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=rest.db");
        }
    }
}
