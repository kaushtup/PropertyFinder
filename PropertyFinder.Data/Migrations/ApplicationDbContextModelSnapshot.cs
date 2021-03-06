// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PropertyFinder.Core.Data;

namespace PropertyFinder.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PropertyFinder.Data.Models.AddressInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Latitude")
                        .HasColumnType("float")
                        .HasMaxLength(255);

                    b.Property<double>("Longitude")
                        .HasColumnType("float")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("AddressInfos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Latitude = 53.462600000000002,
                            Longitude = -2.2898000000000001,
                            Name = "Manchester United"
                        },
                        new
                        {
                            Id = 2,
                            Latitude = 53.765762000000002,
                            Longitude = -2.6923370000000002,
                            Name = "Preston"
                        },
                        new
                        {
                            Id = 3,
                            Latitude = 51.507399999999997,
                            Longitude = -0.1278,
                            Name = "London"
                        },
                        new
                        {
                            Id = 4,
                            Latitude = 53.817500000000003,
                            Longitude = -3.0356999999999998,
                            Name = "Blackpool"
                        },
                        new
                        {
                            Id = 5,
                            Latitude = 53.4084,
                            Longitude = -2.9916,
                            Name = "Liverpool"
                        },
                        new
                        {
                            Id = 6,
                            Latitude = 53.576900000000002,
                            Longitude = -2.4281999999999999,
                            Name = "Bolton"
                        },
                        new
                        {
                            Id = 7,
                            Latitude = 53.789299999999997,
                            Longitude = -2.2404999999999999,
                            Name = "Burnley"
                        });
                });

            modelBuilder.Entity("PropertyFinder.Data.Models.Favourite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HouseInfoId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HouseInfoId");

                    b.HasIndex("UserId");

                    b.ToTable("Favourites");
                });

            modelBuilder.Entity("PropertyFinder.Data.Models.HouseInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressInfoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AvailableDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HouseTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsRent")
                        .HasColumnType("bit");

                    b.Property<int>("NumberOfBedroom")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressInfoId");

                    b.HasIndex("HouseTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("HouseInfos");
                });

            modelBuilder.Entity("PropertyFinder.Data.Models.HousePhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HouseInfoId")
                        .HasColumnType("int");

                    b.Property<int>("PhotoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HouseInfoId");

                    b.HasIndex("PhotoId");

                    b.ToTable("HousePhotos");
                });

            modelBuilder.Entity("PropertyFinder.Data.Models.HouseType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("HouseTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "House"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Apartment"
                        });
                });

            modelBuilder.Entity("PropertyFinder.Data.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsChecked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOwner")
                        .HasColumnType("bit");

                    b.Property<string>("Messages")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("TenantId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("PropertyFinder.Data.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("PropertyFinder.Data.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Owner"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Tenant"
                        });
                });

            modelBuilder.Entity("PropertyFinder.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Contact = "983221312",
                            Email = "admin@gmail.com",
                            Firstname = "admin",
                            Lastname = "admin",
                            Password = "RXkGjhv3DT8BF8ElzWknYPa + zyjZFOqEI4veWAB94PE =",
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("PropertyFinder.Data.Models.Favourite", b =>
                {
                    b.HasOne("PropertyFinder.Data.Models.HouseInfo", "HouseInfo")
                        .WithMany()
                        .HasForeignKey("HouseInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PropertyFinder.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PropertyFinder.Data.Models.HouseInfo", b =>
                {
                    b.HasOne("PropertyFinder.Data.Models.AddressInfo", "AddressInfo")
                        .WithMany()
                        .HasForeignKey("AddressInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PropertyFinder.Data.Models.HouseType", "HouseType")
                        .WithMany()
                        .HasForeignKey("HouseTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PropertyFinder.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PropertyFinder.Data.Models.HousePhoto", b =>
                {
                    b.HasOne("PropertyFinder.Data.Models.HouseInfo", "HouseInfo")
                        .WithMany()
                        .HasForeignKey("HouseInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PropertyFinder.Data.Models.Photo", "Photo")
                        .WithMany()
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PropertyFinder.Data.Models.Message", b =>
                {
                    b.HasOne("PropertyFinder.Data.User", "Users")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PropertyFinder.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PropertyFinder.Data.User", b =>
                {
                    b.HasOne("PropertyFinder.Data.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
