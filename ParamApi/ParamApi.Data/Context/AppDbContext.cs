using Microsoft.EntityFrameworkCore;
using ParamApi.Data.Model;
using System.Reflection;

namespace ParamApi.Data.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        // dbsets
        public DbSet<Account> Account { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
