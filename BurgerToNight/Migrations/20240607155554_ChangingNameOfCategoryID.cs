using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerToNight.Migrations
{
    /// <inheritdoc />
    public partial class ChangingNameOfCategoryID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BurgerCategoryId",
                table: "BProducts",
                newName: "BCategoryId");

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 6, 7, 20, 55, 53, 722, DateTimeKind.Local).AddTicks(2134));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 6, 7, 20, 55, 53, 722, DateTimeKind.Local).AddTicks(2150));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 6, 7, 20, 55, 53, 722, DateTimeKind.Local).AddTicks(2152));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 6, 7, 20, 55, 53, 722, DateTimeKind.Local).AddTicks(2154));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 7, 15, 55, 53, 722, DateTimeKind.Utc).AddTicks(2380));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 6, 7, 15, 55, 53, 722, DateTimeKind.Utc).AddTicks(2384));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 6, 7, 15, 55, 53, 722, DateTimeKind.Utc).AddTicks(2386));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2024, 6, 7, 15, 55, 53, 722, DateTimeKind.Utc).AddTicks(2388));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BCategoryId",
                table: "BProducts",
                newName: "BurgerCategoryId");

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 6, 7, 20, 25, 42, 561, DateTimeKind.Local).AddTicks(1106));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 6, 7, 20, 25, 42, 561, DateTimeKind.Local).AddTicks(1125));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 6, 7, 20, 25, 42, 561, DateTimeKind.Local).AddTicks(1127));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 6, 7, 20, 25, 42, 561, DateTimeKind.Local).AddTicks(1129));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 7, 15, 25, 42, 561, DateTimeKind.Utc).AddTicks(1356));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 6, 7, 15, 25, 42, 561, DateTimeKind.Utc).AddTicks(1359));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 6, 7, 15, 25, 42, 561, DateTimeKind.Utc).AddTicks(1361));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2024, 6, 7, 15, 25, 42, 561, DateTimeKind.Utc).AddTicks(1363));
        }
    }
}
