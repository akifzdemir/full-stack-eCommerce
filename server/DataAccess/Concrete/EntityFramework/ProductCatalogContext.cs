using Core.Entities.Concrete;
using Core.Security.Hashing;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Numerics;

namespace DataAccess.Concrete.EntityFramework
{
    public class ProductCatalogContext:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            var connectionString = configuration.GetConnectionString("WebApiDatabase");
            optionsBuilder.UseSqlServer(connectionString);
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<UsingStatus> UsingStatuses { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color>()
                .HasData(
                    new Color { ColorId=1, Name="White"},
                    new Color { ColorId = 2, Name = "Black" },
                    new Color { ColorId = 3, Name = "Orange" },
                    new Color { ColorId = 4, Name = "Red" }
                );
            modelBuilder.Entity<Brand>()
                .HasData(
                    new Brand { BrandId=1,Name="Apple"},
                    new Brand { BrandId=2,Name="Samsung"},
                    new Brand { BrandId=3,Name="Asus"}
                );
            modelBuilder.Entity<UsingStatus>()
                .HasData(
                    new UsingStatus { UsingStatusId=1,Name="New"},
                    new UsingStatus { UsingStatusId=2,Name="SecondHand"}
                );
            modelBuilder.Entity<Category>()
                .HasData(
                    new Category { CategoryId=1,Name= "Telephone" },
                    new Category { CategoryId=2,Name="Computer"},
                    new Category { CategoryId=3,Name="TV"}
                );

            byte[] passwordHash, passwordSalt;
            string password = "12345678";
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            modelBuilder.Entity<User>().HasData(
                    new User { UserId = 1, PasswordHash = passwordHash, PasswordSalt = passwordSalt, Status = true, Email = "akif@ozdemir.com", AccessFailedCount = 0, FirstName = "Mehmet Akif", LastName = "Özdemir" }
                );

            modelBuilder.Entity<Product>()
              .HasData(
                 new Product { UserId=1,ProductId = 1, InsertTime = DateTime.Now, BrandId = 1, ColorId = 1, CategoryId = 1, Description = "Apple Iphone 7 128GB", IsOfferable = false, IsSold = false, Price = 800, ProductName = "Iphone 7", UsingStatusId = 1 },
                 new Product { UserId = 1, ProductId = 2, InsertTime = DateTime.Now, BrandId = 3, ColorId = 2, CategoryId = 2, Description = "Asus Vivobook X571GT-HN1012 Intel Core i5 9300H 8GB 512GB SSD GTX1650 Freedos", IsOfferable = true, IsSold = false, Price = 600, ProductName = "Asus Laptop", UsingStatusId = 1 },
                 new Product { UserId = 1, ProductId = 3, InsertTime = DateTime.Now, BrandId = 2, ColorId = 1, CategoryId = 1, Description = "Samsung Galaxy A32 128 GB", IsOfferable = false, IsSold = true, Price = 400, ProductName = "Samsung Telephone", UsingStatusId = 1 },
                 new Product { UserId = 1, ProductId = 4, InsertTime = DateTime.Now, BrandId = 2, ColorId = 2, CategoryId = 3, Description = "65 INC 3840x2160 Ultra HD 4K ", IsOfferable = false, IsSold = true, Price = 1000, ProductName = "Samsung TV", UsingStatusId = 2}
              );
            modelBuilder.Entity<OperationClaim>()
                .HasData(
                    new OperationClaim { Id=1,Name="user"}
                );
            modelBuilder.Entity<UserOperationClaim>()
                .HasData(
                    new UserOperationClaim { Id=1,OperationClaimId=1,UserId=1}
                );
            modelBuilder.Entity<ProductImage>()
                .HasData(
                    new ProductImage { ProductId=1,ProductImageId=1,ImagePath= "96b4a457-47f4-4b50-8ff2-e6136b308a3d.jpg",Date=DateTime.Now},
                    new ProductImage { ProductId=2,ProductImageId=2,ImagePath= "9c21406c-7319-42e2-9e07-1aacbbf798fa.jpg",Date=DateTime.Now },
                    new ProductImage { ProductId = 3, ProductImageId = 3, ImagePath = "94e5554d-ffa6-4d7d-8c3a-297a8681fc8d.jpg", Date = DateTime.Now },
                    new ProductImage { ProductId = 4, ProductImageId = 4, ImagePath = "5c272f7c-2e29-4f28-9f97-e34c585d3a5d.jpg", Date = DateTime.Now }
                );
           
            modelBuilder.Entity<Product>()
                .HasOne<Color>()
                .WithMany()
                .HasForeignKey(p => p.ColorId)
               .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Product>()
                .HasOne<Brand>()
                .WithMany()
                .HasForeignKey(p => p.BrandId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Product>()
              .HasOne<UsingStatus>()
              .WithMany()
              .HasForeignKey(p => p.UsingStatusId)
              .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Product>()
              .HasOne<Category>()
              .WithMany()
              .HasForeignKey(p => p.CategoryId)
              .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Product>()
              .HasOne<User>()
              .WithMany()
              .HasForeignKey(p => p.UserId)
              .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Offer>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(o => o.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ProductImage>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(p=>p.ProductId);
        }


    }
}
