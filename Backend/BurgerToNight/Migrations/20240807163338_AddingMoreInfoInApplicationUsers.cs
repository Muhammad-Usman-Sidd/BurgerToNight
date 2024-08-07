using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerToNightAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddingMoreInfoInApplicationUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StreetAddress",
                table: "AspNetUsers",
                newName: "Address");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "AspNetUsers",
                newName: "StreetAddress");

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 8, 7, 21, 21, 42, 388, DateTimeKind.Local).AddTicks(3248));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 8, 7, 21, 21, 42, 388, DateTimeKind.Local).AddTicks(3268));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 8, 7, 21, 21, 42, 388, DateTimeKind.Local).AddTicks(3271));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 8, 7, 21, 21, 42, 388, DateTimeKind.Local).AddTicks(3273));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 8, 7, 21, 21, 42, 388, DateTimeKind.Local).AddTicks(3275));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 8, 7, 21, 21, 42, 388, DateTimeKind.Local).AddTicks(3277));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 8, 7, 16, 21, 42, 388, DateTimeKind.Utc).AddTicks(3908));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 8, 7, 16, 21, 42, 388, DateTimeKind.Utc).AddTicks(3913));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 8, 7, 16, 21, 42, 388, DateTimeKind.Utc).AddTicks(3916));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2024, 8, 7, 16, 21, 42, 388, DateTimeKind.Utc).AddTicks(3919));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2024, 8, 7, 16, 21, 42, 388, DateTimeKind.Utc).AddTicks(3921));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2024, 8, 7, 16, 21, 42, 388, DateTimeKind.Utc).AddTicks(3924));
        }
    }
}
