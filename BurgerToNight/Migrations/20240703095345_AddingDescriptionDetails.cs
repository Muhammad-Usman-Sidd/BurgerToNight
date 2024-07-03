using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerToNightAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddingDescriptionDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 7, 3, 14, 53, 44, 301, DateTimeKind.Local).AddTicks(9252));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 7, 3, 14, 53, 44, 301, DateTimeKind.Local).AddTicks(9274));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 7, 3, 14, 53, 44, 301, DateTimeKind.Local).AddTicks(9276));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 7, 3, 14, 53, 44, 301, DateTimeKind.Local).AddTicks(9278));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "Description" },
                values: new object[] { new DateTime(2024, 7, 3, 9, 53, 44, 307, DateTimeKind.Utc).AddTicks(374), "The Mighty Zinger one of the most liked and extremely big burgers! " });

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "Description" },
                values: new object[] { new DateTime(2024, 7, 3, 9, 53, 44, 307, DateTimeKind.Utc).AddTicks(381), "Carwing for something good look no further" });

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "Description" },
                values: new object[] { new DateTime(2024, 7, 3, 9, 53, 44, 307, DateTimeKind.Utc).AddTicks(384), "Wanna fill your gaint stomach?? " });

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "Description" },
                values: new object[] { new DateTime(2024, 7, 3, 9, 53, 44, 307, DateTimeKind.Utc).AddTicks(387), "Super BBQ burgers are made with extreme care" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 7, 1, 16, 23, 31, 36, DateTimeKind.Local).AddTicks(2561));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 7, 1, 16, 23, 31, 36, DateTimeKind.Local).AddTicks(2581));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 7, 1, 16, 23, 31, 36, DateTimeKind.Local).AddTicks(2584));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 7, 1, 16, 23, 31, 36, DateTimeKind.Local).AddTicks(2587));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "Description" },
                values: new object[] { new DateTime(2024, 7, 1, 11, 23, 31, 45, DateTimeKind.Utc).AddTicks(8115), "" });

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "Description" },
                values: new object[] { new DateTime(2024, 7, 1, 11, 23, 31, 45, DateTimeKind.Utc).AddTicks(8124), "" });

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "Description" },
                values: new object[] { new DateTime(2024, 7, 1, 11, 23, 31, 45, DateTimeKind.Utc).AddTicks(8128), "" });

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "Description" },
                values: new object[] { new DateTime(2024, 7, 1, 11, 23, 31, 45, DateTimeKind.Utc).AddTicks(8132), "" });
        }
    }
}
