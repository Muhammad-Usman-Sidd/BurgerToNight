using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerToNight.Migrations
{
    /// <inheritdoc />
    public partial class TemporaryRemovalOfCategoryFromProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BProducts_BCategories_BurgerCategoryId",
                table: "BProducts");

            migrationBuilder.DropIndex(
                name: "IX_BProducts_BurgerCategoryId",
                table: "BProducts");

            migrationBuilder.DropColumn(
                name: "PreparingTime",
                table: "BProducts");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PreparingTime",
                table: "BProducts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 6, 7, 19, 15, 49, 273, DateTimeKind.Local).AddTicks(8107));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 6, 7, 19, 15, 49, 273, DateTimeKind.Local).AddTicks(8125));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 6, 7, 19, 15, 49, 273, DateTimeKind.Local).AddTicks(8128));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 6, 7, 19, 15, 49, 273, DateTimeKind.Local).AddTicks(8130));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "PreparingTime" },
                values: new object[] { new DateTime(2024, 6, 7, 14, 15, 49, 273, DateTimeKind.Utc).AddTicks(8370), null });

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "PreparingTime" },
                values: new object[] { new DateTime(2024, 6, 7, 14, 15, 49, 273, DateTimeKind.Utc).AddTicks(8374), null });

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "PreparingTime" },
                values: new object[] { new DateTime(2024, 6, 7, 14, 15, 49, 273, DateTimeKind.Utc).AddTicks(8377), null });

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "PreparingTime" },
                values: new object[] { new DateTime(2024, 6, 7, 14, 15, 49, 273, DateTimeKind.Utc).AddTicks(8379), null });

            migrationBuilder.CreateIndex(
                name: "IX_BProducts_BurgerCategoryId",
                table: "BProducts",
                column: "BurgerCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BProducts_BCategories_BurgerCategoryId",
                table: "BProducts",
                column: "BurgerCategoryId",
                principalTable: "BCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
