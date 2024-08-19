using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BurgerToNightAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChaningWholeAppData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_BProducts_ProductId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_BProducts_ProductId",
                table: "OrderDetails");

            migrationBuilder.DropTable(
                name: "BProducts");

            migrationBuilder.DropTable(
                name: "BCategories");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationCategoryTime = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PreparingTime = table.Column<int>(type: "int", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreationCategoryTime", "Description", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 19, 13, 42, 25, 724, DateTimeKind.Local).AddTicks(7391), "Experience the smoky flavor and tender texture of our BBQ burgers, crafted with meticulous care in a controlled environment.", "BBQ" },
                    { 2, new DateTime(2024, 8, 19, 13, 42, 25, 724, DateTimeKind.Local).AddTicks(7406), "Indulge in the wholesome goodness of our Grilled burgers, prepared in a hygienic oven for a perfect char and juicy bite.", "Grilled" },
                    { 3, new DateTime(2024, 8, 19, 13, 42, 25, 724, DateTimeKind.Local).AddTicks(7407), "Savor the irresistible crunch of our burgers, made with the finest breadcrumbs and fresh, clean oil for an unforgettable taste.", "Crunch" },
                    { 4, new DateTime(2024, 8, 19, 13, 42, 25, 724, DateTimeKind.Local).AddTicks(7409), "Discover our signature Special burgers, the ultimate favorite renowned for their exceptional flavor and quality.", "Special" },
                    { 5, new DateTime(2024, 8, 19, 13, 42, 25, 724, DateTimeKind.Local).AddTicks(7413), "Dive into the deliciousness of our Fish burgers, served with love and a smile for a delightful seafood experience.", "Fish" },
                    { 6, new DateTime(2024, 8, 19, 13, 42, 25, 724, DateTimeKind.Local).AddTicks(7414), "Enjoy the rich and succulent taste of our Lamb burgers, made with premium lamb meat imported from Turkey just for you.", "Lamb" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreationDate", "Description", "Image", "Name", "PreparingTime", "Price" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2024, 8, 19, 8, 42, 25, 724, DateTimeKind.Utc).AddTicks(7577), "The Mighty Zinger is one of our most liked and extraordinarily large burgers! Made with a crunchy breadcrumb coating, fresh lettuce, juicy tomatoes, pickles, and topped with spicy mayo.", "", "Mighty Zinger", 10, 20 },
                    { 2, 2, new DateTime(2024, 8, 19, 8, 42, 25, 724, DateTimeKind.Utc).AddTicks(7581), "Craving something delicious? Look no further than the Big Ben, a grilled delight featuring a charred patty, cheddar cheese, crispy bacon, onions, and a special smoky sauce.", "", "Big Ben", 10, 18 },
                    { 3, 4, new DateTime(2024, 8, 19, 8, 42, 25, 724, DateTimeKind.Utc).AddTicks(7584), "Need to fill a giant stomach? The Big Bang is here to deliver with its massive size and explosive flavor! Loaded with double beef patties, American cheese, onion rings, and BBQ sauce.", "", "Big Bang", 10, 40 },
                    { 4, 1, new DateTime(2024, 8, 19, 8, 42, 25, 724, DateTimeKind.Utc).AddTicks(7587), "Our Super BBQ burgers are crafted with extreme care, offering a mouthwatering BBQ experience with smoky beef patties, pepper jack cheese, crispy onions, and tangy BBQ sauce.", "", "Super BBQ", 10, 30 },
                    { 5, 5, new DateTime(2024, 8, 19, 8, 42, 25, 724, DateTimeKind.Utc).AddTicks(7588), "Our Selmon Fish burgers are in high demand. Order yours before it's too late and enjoy the taste of fresh, delectable fish! Made with crispy fish fillets, tartar sauce, lettuce, and pickles.", "", "Selmon Burger", 10, 30 },
                    { 6, 6, new DateTime(2024, 8, 19, 8, 42, 25, 724, DateTimeKind.Utc).AddTicks(7590), "Savor the exquisite flavor of our Lamb Burger, featuring premium lamb meat, mint yogurt sauce, feta cheese, cucumber slices, and arugula, all wrapped in a toasted bun.", "", "Lamb Burger", 10, 30 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Products_ProductId",
                table: "Cart",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Products_ProductId",
                table: "OrderDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Products_ProductId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Products_ProductId",
                table: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.CreateTable(
                name: "BCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationCategoryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BCategoryId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreparingTime = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BProducts_BCategories_BCategoryId",
                        column: x => x.BCategoryId,
                        principalTable: "BCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BCategories",
                columns: new[] { "Id", "CreationCategoryTime", "Description", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 14, 14, 18, 57, 649, DateTimeKind.Local).AddTicks(8011), "Experience the smoky flavor and tender texture of our BBQ burgers, crafted with meticulous care in a controlled environment.", "BBQ" },
                    { 2, new DateTime(2024, 8, 14, 14, 18, 57, 649, DateTimeKind.Local).AddTicks(8031), "Indulge in the wholesome goodness of our Grilled burgers, prepared in a hygienic oven for a perfect char and juicy bite.", "Grilled" },
                    { 3, new DateTime(2024, 8, 14, 14, 18, 57, 649, DateTimeKind.Local).AddTicks(8033), "Savor the irresistible crunch of our burgers, made with the finest breadcrumbs and fresh, clean oil for an unforgettable taste.", "Crunch" },
                    { 4, new DateTime(2024, 8, 14, 14, 18, 57, 649, DateTimeKind.Local).AddTicks(8035), "Discover our signature Special burgers, the ultimate favorite renowned for their exceptional flavor and quality.", "Special" },
                    { 5, new DateTime(2024, 8, 14, 14, 18, 57, 649, DateTimeKind.Local).AddTicks(8036), "Dive into the deliciousness of our Fish burgers, served with love and a smile for a delightful seafood experience.", "Fish" },
                    { 6, new DateTime(2024, 8, 14, 14, 18, 57, 649, DateTimeKind.Local).AddTicks(8037), "Enjoy the rich and succulent taste of our Lamb burgers, made with premium lamb meat imported from Turkey just for you.", "Lamb" }
                });

            migrationBuilder.InsertData(
                table: "BProducts",
                columns: new[] { "Id", "BCategoryId", "CreationDate", "Description", "Image", "Name", "PreparingTime", "Price" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2024, 8, 14, 9, 18, 57, 649, DateTimeKind.Utc).AddTicks(8213), "The Mighty Zinger is one of our most liked and extraordinarily large burgers! Made with a crunchy breadcrumb coating, fresh lettuce, juicy tomatoes, pickles, and topped with spicy mayo.", "", "Mighty Zinger", 10, 20 },
                    { 2, 2, new DateTime(2024, 8, 14, 9, 18, 57, 649, DateTimeKind.Utc).AddTicks(8217), "Craving something delicious? Look no further than the Big Ben, a grilled delight featuring a charred patty, cheddar cheese, crispy bacon, onions, and a special smoky sauce.", "", "Big Ben", 10, 18 },
                    { 3, 4, new DateTime(2024, 8, 14, 9, 18, 57, 649, DateTimeKind.Utc).AddTicks(8218), "Need to fill a giant stomach? The Big Bang is here to deliver with its massive size and explosive flavor! Loaded with double beef patties, American cheese, onion rings, and BBQ sauce.", "", "Big Bang", 10, 40 },
                    { 4, 1, new DateTime(2024, 8, 14, 9, 18, 57, 649, DateTimeKind.Utc).AddTicks(8220), "Our Super BBQ burgers are crafted with extreme care, offering a mouthwatering BBQ experience with smoky beef patties, pepper jack cheese, crispy onions, and tangy BBQ sauce.", "", "Super BBQ", 10, 30 },
                    { 5, 5, new DateTime(2024, 8, 14, 9, 18, 57, 649, DateTimeKind.Utc).AddTicks(8223), "Our Selmon Fish burgers are in high demand. Order yours before it's too late and enjoy the taste of fresh, delectable fish! Made with crispy fish fillets, tartar sauce, lettuce, and pickles.", "", "Selmon Burger", 10, 30 },
                    { 6, 6, new DateTime(2024, 8, 14, 9, 18, 57, 649, DateTimeKind.Utc).AddTicks(8224), "Savor the exquisite flavor of our Lamb Burger, featuring premium lamb meat, mint yogurt sauce, feta cheese, cucumber slices, and arugula, all wrapped in a toasted bun.", "", "Lamb Burger", 10, 30 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BProducts_BCategoryId",
                table: "BProducts",
                column: "BCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_BProducts_ProductId",
                table: "Cart",
                column: "ProductId",
                principalTable: "BProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_BProducts_ProductId",
                table: "OrderDetails",
                column: "ProductId",
                principalTable: "BProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
