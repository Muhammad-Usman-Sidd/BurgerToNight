using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerToNightAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemovingExtraInformationFromOrdersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "OrderHeaders");

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 8, 8, 15, 43, 38, 923, DateTimeKind.Local).AddTicks(883));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 8, 8, 15, 43, 38, 923, DateTimeKind.Local).AddTicks(909));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 8, 8, 15, 43, 38, 923, DateTimeKind.Local).AddTicks(912));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 8, 8, 15, 43, 38, 923, DateTimeKind.Local).AddTicks(914));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 8, 8, 15, 43, 38, 923, DateTimeKind.Local).AddTicks(916));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 8, 8, 15, 43, 38, 923, DateTimeKind.Local).AddTicks(918));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 8, 8, 10, 43, 38, 923, DateTimeKind.Utc).AddTicks(1265));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 8, 8, 10, 43, 38, 923, DateTimeKind.Utc).AddTicks(1271));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 8, 8, 10, 43, 38, 923, DateTimeKind.Utc).AddTicks(1273));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2024, 8, 8, 10, 43, 38, 923, DateTimeKind.Utc).AddTicks(1276));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2024, 8, 8, 10, 43, 38, 923, DateTimeKind.Utc).AddTicks(1279));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2024, 8, 8, 10, 43, 38, 923, DateTimeKind.Utc).AddTicks(1282));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 8, 7, 21, 33, 37, 699, DateTimeKind.Local).AddTicks(1322));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 8, 7, 21, 33, 37, 699, DateTimeKind.Local).AddTicks(1344));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 8, 7, 21, 33, 37, 699, DateTimeKind.Local).AddTicks(1347));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 8, 7, 21, 33, 37, 699, DateTimeKind.Local).AddTicks(1349));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 8, 7, 21, 33, 37, 699, DateTimeKind.Local).AddTicks(1350));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 8, 7, 21, 33, 37, 699, DateTimeKind.Local).AddTicks(1352));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 8, 7, 16, 33, 37, 699, DateTimeKind.Utc).AddTicks(1761));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 8, 7, 16, 33, 37, 699, DateTimeKind.Utc).AddTicks(1766));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 8, 7, 16, 33, 37, 699, DateTimeKind.Utc).AddTicks(1769));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2024, 8, 7, 16, 33, 37, 699, DateTimeKind.Utc).AddTicks(1772));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2024, 8, 7, 16, 33, 37, 699, DateTimeKind.Utc).AddTicks(1775));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2024, 8, 7, 16, 33, 37, 699, DateTimeKind.Utc).AddTicks(1778));
        }
    }
}
