using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerToNight.Migrations
{
    /// <inheritdoc />
    public partial class AddingPreparingTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PreparingTime",
                table: "BProducts",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 6, 20, 19, 26, 3, 44, DateTimeKind.Local).AddTicks(2108));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 6, 20, 19, 26, 3, 44, DateTimeKind.Local).AddTicks(2129));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 6, 20, 19, 26, 3, 44, DateTimeKind.Local).AddTicks(2132));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 6, 20, 19, 26, 3, 44, DateTimeKind.Local).AddTicks(2134));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "PreparingTime" },
                values: new object[] { new DateTime(2024, 6, 20, 14, 26, 3, 44, DateTimeKind.Utc).AddTicks(2420), 10 });

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "PreparingTime" },
                values: new object[] { new DateTime(2024, 6, 20, 14, 26, 3, 44, DateTimeKind.Utc).AddTicks(2424), 10 });

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "PreparingTime" },
                values: new object[] { new DateTime(2024, 6, 20, 14, 26, 3, 44, DateTimeKind.Utc).AddTicks(2427), 10 });

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "PreparingTime" },
                values: new object[] { new DateTime(2024, 6, 20, 14, 26, 3, 44, DateTimeKind.Utc).AddTicks(2431), 10 });

            migrationBuilder.CreateIndex(
                name: "IX_BProducts_BCategoryId",
                table: "BProducts",
                column: "BCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BProducts_BCategories_BCategoryId",
                table: "BProducts",
                column: "BCategoryId",
                principalTable: "BCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BProducts_BCategories_BCategoryId",
                table: "BProducts");

            migrationBuilder.DropIndex(
                name: "IX_BProducts_BCategoryId",
                table: "BProducts");

            migrationBuilder.DropColumn(
                name: "PreparingTime",
                table: "BProducts");

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
    }
}
