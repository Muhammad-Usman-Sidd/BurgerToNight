using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerToNight.Migrations
{
    /// <inheritdoc />
    public partial class ReAddingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BProducts_BCategories_BCategoryId",
                table: "BProducts");

            migrationBuilder.DropIndex(
                name: "IX_BProducts_BCategoryId",
                table: "BProducts");

            migrationBuilder.AddColumn<int>(
                name: "BurgerCategoryId",
                table: "BProducts",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 6, 20, 20, 6, 28, 932, DateTimeKind.Local).AddTicks(3795));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 6, 20, 20, 6, 28, 932, DateTimeKind.Local).AddTicks(3813));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 6, 20, 20, 6, 28, 932, DateTimeKind.Local).AddTicks(3815));

            migrationBuilder.UpdateData(
                table: "BCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 6, 20, 20, 6, 28, 932, DateTimeKind.Local).AddTicks(3817));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BurgerCategoryId", "CreationDate" },
                values: new object[] { null, new DateTime(2024, 6, 20, 15, 6, 28, 932, DateTimeKind.Utc).AddTicks(4089) });

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BurgerCategoryId", "CreationDate" },
                values: new object[] { null, new DateTime(2024, 6, 20, 15, 6, 28, 932, DateTimeKind.Utc).AddTicks(4094) });

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BurgerCategoryId", "CreationDate" },
                values: new object[] { null, new DateTime(2024, 6, 20, 15, 6, 28, 932, DateTimeKind.Utc).AddTicks(4097) });

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BurgerCategoryId", "CreationDate" },
                values: new object[] { null, new DateTime(2024, 6, 20, 15, 6, 28, 932, DateTimeKind.Utc).AddTicks(4099) });

            migrationBuilder.CreateIndex(
                name: "IX_BProducts_BurgerCategoryId",
                table: "BProducts",
                column: "BurgerCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BProducts_BCategories_BurgerCategoryId",
                table: "BProducts",
                column: "BurgerCategoryId",
                principalTable: "BCategories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BProducts_BCategories_BurgerCategoryId",
                table: "BProducts");

            migrationBuilder.DropIndex(
                name: "IX_BProducts_BurgerCategoryId",
                table: "BProducts");

            migrationBuilder.DropColumn(
                name: "BurgerCategoryId",
                table: "BProducts");

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
                column: "CreationDate",
                value: new DateTime(2024, 6, 20, 14, 26, 3, 44, DateTimeKind.Utc).AddTicks(2420));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 6, 20, 14, 26, 3, 44, DateTimeKind.Utc).AddTicks(2424));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 6, 20, 14, 26, 3, 44, DateTimeKind.Utc).AddTicks(2427));

            migrationBuilder.UpdateData(
                table: "BProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2024, 6, 20, 14, 26, 3, 44, DateTimeKind.Utc).AddTicks(2431));

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
    }
}
