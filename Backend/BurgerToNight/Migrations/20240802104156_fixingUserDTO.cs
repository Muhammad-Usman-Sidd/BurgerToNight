using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerToNightAPI.Migrations
{
    /// <inheritdoc />
    public partial class fixingUserDTO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 8, 2, 15, 41, 55, 34, DateTimeKind.Local).AddTicks(7140));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 8, 2, 15, 41, 55, 34, DateTimeKind.Local).AddTicks(7163));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 8, 2, 15, 41, 55, 34, DateTimeKind.Local).AddTicks(7166));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 8, 2, 15, 41, 55, 34, DateTimeKind.Local).AddTicks(7168));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 8, 2, 10, 41, 55, 41, DateTimeKind.Utc).AddTicks(425));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 8, 2, 10, 41, 55, 41, DateTimeKind.Utc).AddTicks(431));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 8, 2, 10, 41, 55, 41, DateTimeKind.Utc).AddTicks(434));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2024, 8, 2, 10, 41, 55, 41, DateTimeKind.Utc).AddTicks(437));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
