using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BurgerToNight.Migrations
{
    /// <inheritdoc />
    public partial class InitialSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BurgerCategoryId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    PreparingTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BProducts_BCategories_BurgerCategoryId",
                        column: x => x.BurgerCategoryId,
                        principalTable: "BCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BCategories",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "BBQ burger are made with highly care and in check environment", "BBQ" },
                    { 2, "Grilled burger Patty are made in hygenic and clean Oven", "Grilled" },
                    { 3, "Crunch buger patty are made With best breadcrumbs and fresh and clean oil", "Crunch" },
                    { 4, "Our most favourite and yet the best one!", "Special" }
                });

            migrationBuilder.InsertData(
                table: "BProducts",
                columns: new[] { "Id", "BurgerCategoryId", "Description", "Name", "PreparingTime", "Price" },
                values: new object[,]
                {
                    { 1, 3, "", "Mighty Zinger", null, 20 },
                    { 2, 2, "", "Big Ben", null, 18 },
                    { 3, 4, "", "Big Bang", null, 40 },
                    { 4, 1, "", "Super BBQ", null, 30 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BProducts_BurgerCategoryId",
                table: "BProducts",
                column: "BurgerCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BProducts");

            migrationBuilder.DropTable(
                name: "BCategories");
        }
    }
}
