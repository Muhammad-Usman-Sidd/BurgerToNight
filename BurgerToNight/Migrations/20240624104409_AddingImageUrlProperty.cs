using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerToNight.Migrations
{
    /// <inheritdoc />
    public partial class AddingImageUrlProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "BProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 6, 24, 15, 44, 8, 753, DateTimeKind.Local).AddTicks(9553));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 6, 24, 15, 44, 8, 753, DateTimeKind.Local).AddTicks(9574));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 6, 24, 15, 44, 8, 753, DateTimeKind.Local).AddTicks(9576));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 6, 24, 15, 44, 8, 753, DateTimeKind.Local).AddTicks(9578));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "ImageUrl" },
                values: new object[] { new DateTime(2024, 6, 24, 10, 44, 8, 753, DateTimeKind.Utc).AddTicks(9818), "" });

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "ImageUrl" },
                values: new object[] { new DateTime(2024, 6, 24, 10, 44, 8, 753, DateTimeKind.Utc).AddTicks(9822), "" });

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "ImageUrl" },
                values: new object[] { new DateTime(2024, 6, 24, 10, 44, 8, 753, DateTimeKind.Utc).AddTicks(9825), "" });

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "ImageUrl" },
                values: new object[] { new DateTime(2024, 6, 24, 10, 44, 8, 753, DateTimeKind.Utc).AddTicks(9828), "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "BProducts");

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 6, 21, 20, 41, 16, 298, DateTimeKind.Local).AddTicks(2558));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 6, 21, 20, 41, 16, 298, DateTimeKind.Local).AddTicks(2575));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 6, 21, 20, 41, 16, 298, DateTimeKind.Local).AddTicks(2578));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 6, 21, 20, 41, 16, 298, DateTimeKind.Local).AddTicks(2580));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 21, 15, 41, 16, 298, DateTimeKind.Utc).AddTicks(2841));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 6, 21, 15, 41, 16, 298, DateTimeKind.Utc).AddTicks(2845));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 6, 21, 15, 41, 16, 298, DateTimeKind.Utc).AddTicks(2848));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2024, 6, 21, 15, 41, 16, 298, DateTimeKind.Utc).AddTicks(2850));
        }
    }
}
