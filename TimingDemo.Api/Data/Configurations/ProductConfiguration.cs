using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimingDemo.Api.Models;

namespace TimingDemo.Api.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Seed Data
            builder.HasData(
                new Product { Id = 1, Name = "Laptop", Price = 999.99m, StockQuantity = 50, CategoryId = 1 },
                new Product { Id = 2, Name = "C# in Depth", Price = 45.00m, StockQuantity = 20, CategoryId = 2 },
                new Product { Id = 3, Name = "T-Shirt", Price = 15.99m, StockQuantity = 100, CategoryId = 3 },
                new Product { Id = 4, Name = "Smartphone", Price = 599.99m, StockQuantity = 50, CategoryId = 1 },
                new Product { Id = 5, Name = "Clean Code", Price = 40.00m, StockQuantity = 30, CategoryId = 2 },
                new Product { Id = 6, Name = "Jeans", Price = 35.50m, StockQuantity = 80, CategoryId = 3 },
                new Product { Id = 7, Name = "Headphones", Price = 199.99m, StockQuantity = 40, CategoryId = 1 },
                new Product { Id = 8, Name = "Design Patterns", Price = 55.00m, StockQuantity = 25, CategoryId = 2 },
                new Product { Id = 9, Name = "Jacket", Price = 89.99m, StockQuantity = 60, CategoryId = 3 },
                new Product { Id = 10, Name = "Monitor", Price = 299.99m, StockQuantity = 35, CategoryId = 1 },
                new Product { Id = 11, Name = "Domain-Driven Design", Price = 50.00m, StockQuantity = 15, CategoryId = 2 },
                new Product { Id = 12, Name = "Sneakers", Price = 75.00m, StockQuantity = 90, CategoryId = 3 },
                new Product { Id = 13, Name = "Keyboard", Price = 120.00m, StockQuantity = 45, CategoryId = 1 },
                new Product { Id = 14, Name = "Refactoring", Price = 48.00m, StockQuantity = 28, CategoryId = 2 },
                new Product { Id = 15, Name = "Socks", Price = 9.99m, StockQuantity = 150, CategoryId = 3 },
                new Product { Id = 16, Name = "Mouse", Price = 49.99m, StockQuantity = 55, CategoryId = 1 },
                new Product { Id = 17, Name = "Clean Architecture", Price = 42.00m, StockQuantity = 22, CategoryId = 2 },
                new Product { Id = 18, Name = "Sweater", Price = 45.00m, StockQuantity = 70, CategoryId = 3 },
                new Product { Id = 19, Name = "Tablet", Price = 499.99m, StockQuantity = 30, CategoryId = 1 },
                new Product { Id = 20, Name = "Pragmatic Programmer", Price = 39.99m, StockQuantity = 35, CategoryId = 2 },
                new Product { Id = 21, Name = "Hat", Price = 19.99m, StockQuantity = 120, CategoryId = 3 },
                new Product { Id = 22, Name = "Smartwatch", Price = 250.00m, StockQuantity = 60, CategoryId = 1 },
                new Product { Id = 23, Name = "CLR via C#", Price = 55.00m, StockQuantity = 18, CategoryId = 2 },
                new Product { Id = 24, Name = "Scarf", Price = 25.00m, StockQuantity = 85, CategoryId = 3 },
                new Product { Id = 25, Name = "Webcam", Price = 79.99m, StockQuantity = 40, CategoryId = 1 },
                new Product { Id = 26, Name = "Pro ASP.NET Core", Price = 60.00m, StockQuantity = 12, CategoryId = 2 },
                new Product { Id = 27, Name = "Gloves", Price = 14.99m, StockQuantity = 110, CategoryId = 3 },
                new Product { Id = 28, Name = "Microphone", Price = 150.00m, StockQuantity = 25, CategoryId = 1 },
                new Product { Id = 29, Name = "Code Complete", Price = 65.00m, StockQuantity = 20, CategoryId = 2 },
                new Product { Id = 30, Name = "Shorts", Price = 29.99m, StockQuantity = 95, CategoryId = 3 },
                new Product { Id = 31, Name = "Speakers", Price = 199.99m, StockQuantity = 30, CategoryId = 1 },
                new Product { Id = 32, Name = "Effective C#", Price = 45.00m, StockQuantity = 25, CategoryId = 2 },
                new Product { Id = 33, Name = "Belt", Price = 34.99m, StockQuantity = 75, CategoryId = 3 },
                new Product { Id = 34, Name = "Router", Price = 129.99m, StockQuantity = 35, CategoryId = 1 },
                new Product { Id = 35, Name = "Dependency Injection", Price = 50.00m, StockQuantity = 15, CategoryId = 2 },
                new Product { Id = 36, Name = "Suit", Price = 199.99m, StockQuantity = 10, CategoryId = 3 },
                new Product { Id = 37, Name = "External HDD", Price = 89.99m, StockQuantity = 45, CategoryId = 1 },
                new Product { Id = 38, Name = "Soft Skills", Price = 25.00m, StockQuantity = 40, CategoryId = 2 },
                new Product { Id = 39, Name = "Tie", Price = 15.00m, StockQuantity = 60, CategoryId = 3 },
                new Product { Id = 40, Name = "USB Hub", Price = 29.99m, StockQuantity = 80, CategoryId = 1 },
                new Product { Id = 41, Name = "Mythical Man-Month", Price = 35.00m, StockQuantity = 30, CategoryId = 2 },
                new Product { Id = 42, Name = "Boots", Price = 120.00m, StockQuantity = 20, CategoryId = 3 },
                new Product { Id = 43, Name = "Power Bank", Price = 49.99m, StockQuantity = 70, CategoryId = 1 },
                new Product { Id = 44, Name = "Patterns of Enterprise Architecture", Price = 55.00m, StockQuantity = 18, CategoryId = 2 },
                new Product { Id = 45, Name = "Sandals", Price = 39.99m, StockQuantity = 50, CategoryId = 3 },
                new Product { Id = 46, Name = "Earbuds", Price = 149.99m, StockQuantity = 40, CategoryId = 1 },
                new Product { Id = 47, Name = "Working Effectively with Legacy Code", Price = 48.00m, StockQuantity = 22, CategoryId = 2 },
                new Product { Id = 48, Name = "Tracksuit", Price = 65.00m, StockQuantity = 35, CategoryId = 3 },
                new Product { Id = 49, Name = "Graphics Card", Price = 699.99m, StockQuantity = 15, CategoryId = 1 },
                new Product { Id = 50, Name = "Building Microservices", Price = 50.00m, StockQuantity = 25, CategoryId = 2 },
                new Product { Id = 51, Name = "Beanie", Price = 12.99m, StockQuantity = 100, CategoryId = 3 },
                new Product { Id = 52, Name = "Motherboard", Price = 199.99m, StockQuantity = 20, CategoryId = 1 },
                new Product { Id = 53, Name = "Designing Data-Intensive Applications", Price = 45.00m, StockQuantity = 30, CategoryId = 2 },
                new Product { Id = 54, Name = "Polo Shirt", Price = 25.00m, StockQuantity = 75, CategoryId = 3 },
                new Product { Id = 55, Name = "CPU", Price = 299.99m, StockQuantity = 25, CategoryId = 1 },
                new Product { Id = 56, Name = "Head First Design Patterns", Price = 40.00m, StockQuantity = 35, CategoryId = 2 },
                new Product { Id = 57, Name = "Vest", Price = 45.00m, StockQuantity = 40, CategoryId = 3 },
                new Product { Id = 58, Name = "RAM 16GB", Price = 75.00m, StockQuantity = 50, CategoryId = 1 },
                new Product { Id = 59, Name = "Release It!", Price = 38.00m, StockQuantity = 20, CategoryId = 2 },
                new Product { Id = 60, Name = "Cardigan", Price = 55.00m, StockQuantity = 30, CategoryId = 3 },
                new Product { Id = 61, Name = "SSD 1TB", Price = 110.00m, StockQuantity = 45, CategoryId = 1 },
                new Product { Id = 62, Name = "Continuous Delivery", Price = 42.00m, StockQuantity = 22, CategoryId = 2 },
                new Product { Id = 63, Name = "Blazer", Price = 150.00m, StockQuantity = 15, CategoryId = 3 },
                new Product { Id = 64, Name = "Gaming Chair", Price = 250.00m, StockQuantity = 10, CategoryId = 1 },
                new Product { Id = 65, Name = "Test Driven Development", Price = 35.00m, StockQuantity = 28, CategoryId = 2 },
                new Product { Id = 66, Name = "Trench Coat", Price = 199.99m, StockQuantity = 12, CategoryId = 3 },
                new Product { Id = 67, Name = "Mechanical Keyboard", Price = 130.00m, StockQuantity = 35, CategoryId = 1 },
                new Product { Id = 68, Name = "The Phoenix Project", Price = 25.00m, StockQuantity = 40, CategoryId = 2 },
                new Product { Id = 69, Name = "Swimsuit", Price = 45.00m, StockQuantity = 55, CategoryId = 3 },
                new Product { Id = 70, Name = "Wireless Mouse", Price = 55.00m, StockQuantity = 60, CategoryId = 1 },
                new Product { Id = 71, Name = "Grokking Algorithms", Price = 39.99m, StockQuantity = 32, CategoryId = 2 },
                new Product { Id = 72, Name = "Overalls", Price = 59.99m, StockQuantity = 20, CategoryId = 3 },
                new Product { Id = 73, Name = "Cooling Pad", Price = 25.00m, StockQuantity = 70, CategoryId = 1 },
                new Product { Id = 74, Name = "C# 10 and .NET 6", Price = 55.00m, StockQuantity = 18, CategoryId = 2 },
                new Product { Id = 75, Name = "Pajamas", Price = 35.00m, StockQuantity = 65, CategoryId = 3 },
                new Product { Id = 76, Name = "USB Flash Drive", Price = 15.00m, StockQuantity = 100, CategoryId = 1 },
                new Product { Id = 77, Name = "Programming Pearls", Price = 32.00m, StockQuantity = 25, CategoryId = 2 },
                new Product { Id = 78, Name = "Raincoat", Price = 85.00m, StockQuantity = 22, CategoryId = 3 },
                new Product { Id = 79, Name = "Docking Station", Price = 199.99m, StockQuantity = 15, CategoryId = 1 },
                new Product { Id = 80, Name = "Code: The Hidden Language", Price = 28.00m, StockQuantity = 30, CategoryId = 2 },
                new Product { Id = 81, Name = "Sunglasses", Price = 120.00m, StockQuantity = 40, CategoryId = 3 },
                new Product { Id = 82, Name = "Ethernet Cable", Price = 10.00m, StockQuantity = 150, CategoryId = 1 },
                new Product { Id = 83, Name = "Structure and Interpretation", Price = 60.00m, StockQuantity = 12, CategoryId = 2 },
                new Product { Id = 84, Name = "Watch", Price = 299.99m, StockQuantity = 18, CategoryId = 3 },
                new Product { Id = 85, Name = "HDMI Cable", Price = 15.00m, StockQuantity = 120, CategoryId = 1 },
                new Product { Id = 86, Name = "Cracking the Coding Interview", Price = 35.00m, StockQuantity = 45, CategoryId = 2 },
                new Product { Id = 87, Name = "Wallet", Price = 45.00m, StockQuantity = 50, CategoryId = 3 },
                new Product { Id = 88, Name = "VR Headset", Price = 399.99m, StockQuantity = 10, CategoryId = 1 },
                new Product { Id = 89, Name = "Site Reliability Engineering", Price = 45.00m, StockQuantity = 22, CategoryId = 2 },
                new Product { Id = 90, Name = "Backpack", Price = 65.00m, StockQuantity = 35, CategoryId = 3 },
                new Product { Id = 91, Name = "Drone", Price = 799.99m, StockQuantity = 5, CategoryId = 1 },
                new Product { Id = 92, Name = "The Pragmatic Programmer", Price = 42.00m, StockQuantity = 30, CategoryId = 2 },
                new Product { Id = 93, Name = "Mittens", Price = 18.00m, StockQuantity = 75, CategoryId = 3 },
                new Product { Id = 94, Name = "Camera", Price = 599.99m, StockQuantity = 12, CategoryId = 1 },
                new Product { Id = 95, Name = "Clean Agile", Price = 38.00m, StockQuantity = 25, CategoryId = 2 },
                new Product { Id = 96, Name = "Polo", Price = 30.00m, StockQuantity = 60, CategoryId = 3 },
                new Product { Id = 97, Name = "Tripod", Price = 45.00m, StockQuantity = 40, CategoryId = 1 },
                new Product { Id = 98, Name = "Peopleware", Price = 35.00m, StockQuantity = 28, CategoryId = 2 },
                new Product { Id = 99, Name = "Flip Flops", Price = 15.00m, StockQuantity = 90, CategoryId = 3 },
                new Product { Id = 100, Name = "MicroSD Card", Price = 25.00m, StockQuantity = 110, CategoryId = 1 }
            );
        }
    }
}
