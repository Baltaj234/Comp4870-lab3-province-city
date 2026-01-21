using Microsoft.EntityFrameworkCore;
using lab3_province_city.Models;

namespace lab3_province_city.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Province> Provinces { get; set; }

    // seeding data for Provinces and Cities
        protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    // Provinces
    modelBuilder.Entity<Province>().HasData(
        new Province { ProvinceCode = "BC", ProvinceName = "British Columbia" },
        new Province { ProvinceCode = "ON", ProvinceName = "Ontario" },
        new Province { ProvinceCode = "AB", ProvinceName = "Alberta" }
    );

    // Cities
    modelBuilder.Entity<City>().HasData(
        new City { CityId = 1, CityName = "Surrey", Population = 600000, ProvinceCode = "BC" },
        new City { CityId = 2, CityName = "Vancouver", Population = 700000, ProvinceCode = "BC" },
        new City { CityId = 3, CityName = "Richmond", Population = 220000, ProvinceCode = "BC" },

        new City { CityId = 4, CityName = "Toronto", Population = 2800000, ProvinceCode = "ON" },
        new City { CityId = 5, CityName = "Mississauga", Population = 800000, ProvinceCode = "ON" },
        new City { CityId = 6, CityName = "Brampton", Population = 650000, ProvinceCode = "ON" },

        new City { CityId = 7, CityName = "Calgary", Population = 1300000, ProvinceCode = "AB" },
        new City { CityId = 8, CityName = "Edmonton", Population = 1000000, ProvinceCode = "AB" },
        new City { CityId = 9, CityName = "Red Deer", Population = 100000, ProvinceCode = "AB" }
    );
}

    }
}
