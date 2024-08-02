using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerToNightAPI.Migrations
{
    /// <inheritdoc />
    public partial class ResettingTheTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 8, 2, 12, 26, 39, 914, DateTimeKind.Local).AddTicks(4728));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 8, 2, 12, 26, 39, 914, DateTimeKind.Local).AddTicks(4747));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 8, 2, 12, 26, 39, 914, DateTimeKind.Local).AddTicks(4750));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 8, 2, 12, 26, 39, 914, DateTimeKind.Local).AddTicks(4752));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 8, 2, 7, 26, 39, 919, DateTimeKind.Utc).AddTicks(6030));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 8, 2, 7, 26, 39, 919, DateTimeKind.Utc).AddTicks(6034));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 8, 2, 7, 26, 39, 919, DateTimeKind.Utc).AddTicks(6037));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2024, 8, 2, 7, 26, 39, 919, DateTimeKind.Utc).AddTicks(6040));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 8, 1, 21, 0, 46, 679, DateTimeKind.Local).AddTicks(936));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 8, 1, 21, 0, 46, 679, DateTimeKind.Local).AddTicks(956));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 8, 1, 21, 0, 46, 679, DateTimeKind.Local).AddTicks(958));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 8, 1, 21, 0, 46, 679, DateTimeKind.Local).AddTicks(960));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 8, 1, 16, 0, 46, 684, DateTimeKind.Utc).AddTicks(4846));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 8, 1, 16, 0, 46, 684, DateTimeKind.Utc).AddTicks(4851));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 8, 1, 16, 0, 46, 684, DateTimeKind.Utc).AddTicks(4855));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2024, 8, 1, 16, 0, 46, 684, DateTimeKind.Utc).AddTicks(4858));
        }
    }
}
