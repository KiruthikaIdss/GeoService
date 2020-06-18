using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace DataService
{
  

    public class CountryDbContext : DbContext
    {

        public CountryDbContext(DbContextOptions<CountryDbContext> options)
            : base(options)
        {
        }


        public DbSet<Country> Country { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<City> City { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CountryDbContext).Assembly);
        }


        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CountryDbContext>
        {
            public CountryDbContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var builder = new DbContextOptionsBuilder<CountryDbContext>();
                var connection = configuration.GetConnectionString("DefaultConnection");
                builder.UseSqlServer(connection);
                return new CountryDbContext(builder.Options);
            }

        }
    
    }
}
