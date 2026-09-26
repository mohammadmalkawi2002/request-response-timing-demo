using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TimingDemo.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Books" },
                    { 3, "Clothing" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Name", "Price", "StockQuantity" },
                values: new object[,]
                {
                    { 1, 1, "Laptop", 999.99m, 50 },
                    { 2, 2, "C# in Depth", 45.00m, 20 },
                    { 3, 3, "T-Shirt", 15.99m, 100 },
                    { 4, 1, "Smartphone", 599.99m, 50 },
                    { 5, 2, "Clean Code", 40.00m, 30 },
                    { 6, 3, "Jeans", 35.50m, 80 },
                    { 7, 1, "Headphones", 199.99m, 40 },
                    { 8, 2, "Design Patterns", 55.00m, 25 },
                    { 9, 3, "Jacket", 89.99m, 60 },
                    { 10, 1, "Monitor", 299.99m, 35 },
                    { 11, 2, "Domain-Driven Design", 50.00m, 15 },
                    { 12, 3, "Sneakers", 75.00m, 90 },
                    { 13, 1, "Keyboard", 120.00m, 45 },
                    { 14, 2, "Refactoring", 48.00m, 28 },
                    { 15, 3, "Socks", 9.99m, 150 },
                    { 16, 1, "Mouse", 49.99m, 55 },
                    { 17, 2, "Clean Architecture", 42.00m, 22 },
                    { 18, 3, "Sweater", 45.00m, 70 },
                    { 19, 1, "Tablet", 499.99m, 30 },
                    { 20, 2, "Pragmatic Programmer", 39.99m, 35 },
                    { 21, 3, "Hat", 19.99m, 120 },
                    { 22, 1, "Smartwatch", 250.00m, 60 },
                    { 23, 2, "CLR via C#", 55.00m, 18 },
                    { 24, 3, "Scarf", 25.00m, 85 },
                    { 25, 1, "Webcam", 79.99m, 40 },
                    { 26, 2, "Pro ASP.NET Core", 60.00m, 12 },
                    { 27, 3, "Gloves", 14.99m, 110 },
                    { 28, 1, "Microphone", 150.00m, 25 },
                    { 29, 2, "Code Complete", 65.00m, 20 },
                    { 30, 3, "Shorts", 29.99m, 95 },
                    { 31, 1, "Speakers", 199.99m, 30 },
                    { 32, 2, "Effective C#", 45.00m, 25 },
                    { 33, 3, "Belt", 34.99m, 75 },
                    { 34, 1, "Router", 129.99m, 35 },
                    { 35, 2, "Dependency Injection", 50.00m, 15 },
                    { 36, 3, "Suit", 199.99m, 10 },
                    { 37, 1, "External HDD", 89.99m, 45 },
                    { 38, 2, "Soft Skills", 25.00m, 40 },
                    { 39, 3, "Tie", 15.00m, 60 },
                    { 40, 1, "USB Hub", 29.99m, 80 },
                    { 41, 2, "Mythical Man-Month", 35.00m, 30 },
                    { 42, 3, "Boots", 120.00m, 20 },
                    { 43, 1, "Power Bank", 49.99m, 70 },
                    { 44, 2, "Patterns of Enterprise Architecture", 55.00m, 18 },
                    { 45, 3, "Sandals", 39.99m, 50 },
                    { 46, 1, "Earbuds", 149.99m, 40 },
                    { 47, 2, "Working Effectively with Legacy Code", 48.00m, 22 },
                    { 48, 3, "Tracksuit", 65.00m, 35 },
                    { 49, 1, "Graphics Card", 699.99m, 15 },
                    { 50, 2, "Building Microservices", 50.00m, 25 },
                    { 51, 3, "Beanie", 12.99m, 100 },
                    { 52, 1, "Motherboard", 199.99m, 20 },
                    { 53, 2, "Designing Data-Intensive Applications", 45.00m, 30 },
                    { 54, 3, "Polo Shirt", 25.00m, 75 },
                    { 55, 1, "CPU", 299.99m, 25 },
                    { 56, 2, "Head First Design Patterns", 40.00m, 35 },
                    { 57, 3, "Vest", 45.00m, 40 },
                    { 58, 1, "RAM 16GB", 75.00m, 50 },
                    { 59, 2, "Release It!", 38.00m, 20 },
                    { 60, 3, "Cardigan", 55.00m, 30 },
                    { 61, 1, "SSD 1TB", 110.00m, 45 },
                    { 62, 2, "Continuous Delivery", 42.00m, 22 },
                    { 63, 3, "Blazer", 150.00m, 15 },
                    { 64, 1, "Gaming Chair", 250.00m, 10 },
                    { 65, 2, "Test Driven Development", 35.00m, 28 },
                    { 66, 3, "Trench Coat", 199.99m, 12 },
                    { 67, 1, "Mechanical Keyboard", 130.00m, 35 },
                    { 68, 2, "The Phoenix Project", 25.00m, 40 },
                    { 69, 3, "Swimsuit", 45.00m, 55 },
                    { 70, 1, "Wireless Mouse", 55.00m, 60 },
                    { 71, 2, "Grokking Algorithms", 39.99m, 32 },
                    { 72, 3, "Overalls", 59.99m, 20 },
                    { 73, 1, "Cooling Pad", 25.00m, 70 },
                    { 74, 2, "C# 10 and .NET 6", 55.00m, 18 },
                    { 75, 3, "Pajamas", 35.00m, 65 },
                    { 76, 1, "USB Flash Drive", 15.00m, 100 },
                    { 77, 2, "Programming Pearls", 32.00m, 25 },
                    { 78, 3, "Raincoat", 85.00m, 22 },
                    { 79, 1, "Docking Station", 199.99m, 15 },
                    { 80, 2, "Code: The Hidden Language", 28.00m, 30 },
                    { 81, 3, "Sunglasses", 120.00m, 40 },
                    { 82, 1, "Ethernet Cable", 10.00m, 150 },
                    { 83, 2, "Structure and Interpretation", 60.00m, 12 },
                    { 84, 3, "Watch", 299.99m, 18 },
                    { 85, 1, "HDMI Cable", 15.00m, 120 },
                    { 86, 2, "Cracking the Coding Interview", 35.00m, 45 },
                    { 87, 3, "Wallet", 45.00m, 50 },
                    { 88, 1, "VR Headset", 399.99m, 10 },
                    { 89, 2, "Site Reliability Engineering", 45.00m, 22 },
                    { 90, 3, "Backpack", 65.00m, 35 },
                    { 91, 1, "Drone", 799.99m, 5 },
                    { 92, 2, "The Pragmatic Programmer", 42.00m, 30 },
                    { 93, 3, "Mittens", 18.00m, 75 },
                    { 94, 1, "Camera", 599.99m, 12 },
                    { 95, 2, "Clean Agile", 38.00m, 25 },
                    { 96, 3, "Polo", 30.00m, 60 },
                    { 97, 1, "Tripod", 45.00m, 40 },
                    { 98, 2, "Peopleware", 35.00m, 28 },
                    { 99, 3, "Flip Flops", 15.00m, 90 },
                    { 100, 1, "MicroSD Card", 25.00m, 110 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
