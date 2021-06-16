using Microsoft.EntityFrameworkCore;
using PropertyFinder.Data;
using PropertyFinder.Data.Models;

namespace PropertyFinder.Core.Data
{
    public class ApplicationDbContext : DbContext
    {
        //IdentityDbContext
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //add admin encryption in here.

            //RXkGjhv3DT8BF8ElzWknYPa + zyjZFOqEI4veWAB94PE =

            //builder.Entity<User>().HasKey(p => new { p.Id });
            base.OnModelCreating(builder);

            builder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "Admin"
                },
                new Role 
                { 
                    Id =2,
                    Name = "Owner"
                },
                new Role 
                { 
                    Id = 3,
                    Name = "Tenant"
                });

            builder.Entity<User>().HasData
                (
                    //password = Admin@123

                    new User
                    {
                         Id = 1,
                         Firstname = "admin",
                         Lastname = "admin",
                         Contact = "983221312",
                         Email = "admin@gmail.com",
                         Password = "RXkGjhv3DT8BF8ElzWknYPa + zyjZFOqEI4veWAB94PE =",
                         RoleId = 1
                    }
                );

            builder.Entity<AddressInfo>().HasData
              (
                  new AddressInfo
                  {
                      Id = 1,
                      Name = "Manchester United",
                      Latitude = 53.4626, //north
                      Longitude = -2.2898
                  },
                  new AddressInfo
                  {
                      Id = 2,
                      Name = "Preston",
                      Latitude = 53.765762, //north
                      Longitude = -2.692337
                  },
                  new AddressInfo 
                  {
                      Id = 3,
                      Name = "London",
                      Latitude = 51.5074, //north
                      Longitude = -0.1278
                  },
                  new AddressInfo
                  {
                      Id = 4,
                      Name = "Blackpool",
                      Latitude = 53.8175, //north
                      Longitude = -3.0357
                  },
                  new AddressInfo
                  {
                      Id = 5,
                      Name = "Liverpool",
                      Latitude = 53.4084, //north
                      Longitude = -2.9916
                  },
                  new AddressInfo
                  {
                      Id = 6,
                      Name = "Bolton",
                      Latitude = 53.5769, //north
                      Longitude = -2.4282
                  },
                  new AddressInfo
                  {
                      Id = 7,
                      Name = "Burnley",
                      Latitude = 53.7893, //north
                      Longitude = -2.2405
                  }
              );

            builder.Entity<HouseType>().HasData
             (
                 new HouseType
                 {
                     Id = 1,
                     Name = "House",
                 },
                 new AddressInfo
                 {
                     Id = 2,
                     Name = "Apartment",
                 }
             );
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<HouseType> HouseTypes { get; set; }

        public DbSet<AddressInfo> AddressInfos { get; set; }

        public DbSet<HouseInfo> HouseInfos { get; set; }
       
        public DbSet<Photo> Photos { get; set; }

        public DbSet<HousePhoto> HousePhotos { get; set; }

        public DbSet<Favourite> Favourites { get; set; }

        public DbSet<Message> Messages { get; set; }
    }
}
