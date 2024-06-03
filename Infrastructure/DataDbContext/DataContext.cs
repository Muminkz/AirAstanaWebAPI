using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
namespace Infrastructure.DataDbContext
{
    public class DataContext:DbContext
    {
        public DbSet<User> Users { get; init; }
        public DbSet<Role> Role { get; init; }
        public DbSet<Flight> Flights { get; init; }
        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
