using Aptio.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aptio.Infrastructure.DbContexts
{
    public class AptioDbContext : DbContext
    {
        public AptioDbContext(DbContextOptions<AptioDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new User.Cofiguration());

            modelBuilder.ApplyConfiguration(new Role.Configuration());

            modelBuilder.ApplyConfiguration(new Country.Configuration());

            modelBuilder.ApplyConfiguration(new State.Configuration());

            modelBuilder.ApplyConfiguration(new City.Configuration());
        }
    }
}
