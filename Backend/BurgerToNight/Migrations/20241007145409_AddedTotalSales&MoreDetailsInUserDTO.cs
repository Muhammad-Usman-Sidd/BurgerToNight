using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerToNightAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedTotalSalesMoreDetailsInUserDTO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalSales",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 10, 7, 19, 54, 9, 220, DateTimeKind.Local).AddTicks(7546));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 10, 7, 19, 54, 9, 220, DateTimeKind.Local).AddTicks(7567));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 10, 7, 19, 54, 9, 220, DateTimeKind.Local).AddTicks(7569));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 10, 7, 19, 54, 9, 220, DateTimeKind.Local).AddTicks(7570));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 10, 7, 19, 54, 9, 220, DateTimeKind.Local).AddTicks(7571));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 10, 7, 19, 54, 9, 220, DateTimeKind.Local).AddTicks(7573));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 10, 7, 19, 54, 9, 220, DateTimeKind.Local).AddTicks(7574));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "TotalSales" },
                values: new object[] { new DateTime(2024, 10, 7, 14, 54, 9, 220, DateTimeKind.Utc).AddTicks(7784), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "TotalSales" },
                values: new object[] { new DateTime(2024, 10, 7, 14, 54, 9, 220, DateTimeKind.Utc).AddTicks(7788), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "TotalSales" },
                values: new object[] { new DateTime(2024, 10, 7, 14, 54, 9, 220, DateTimeKind.Utc).AddTicks(7790), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "TotalSales" },
                values: new object[] { new DateTime(2024, 10, 7, 14, 54, 9, 220, DateTimeKind.Utc).AddTicks(7791), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "TotalSales" },
                values: new object[] { new DateTime(2024, 10, 7, 14, 54, 9, 220, DateTimeKind.Utc).AddTicks(7792), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreationDate", "TotalSales" },
                values: new object[] { new DateTime(2024, 10, 7, 14, 54, 9, 220, DateTimeKind.Utc).AddTicks(7794), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "TotalSales" },
                values: new object[] { new DateTime(2024, 10, 7, 14, 54, 9, 220, DateTimeKind.Utc).AddTicks(7795), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "TotalSales" },
                values: new object[] { new DateTime(2024, 10, 7, 14, 54, 9, 220, DateTimeKind.Utc).AddTicks(7796), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreationDate", "TotalSales" },
                values: new object[] { new DateTime(2024, 10, 7, 14, 54, 9, 220, DateTimeKind.Utc).AddTicks(7798), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreationDate", "TotalSales" },
                values: new object[] { new DateTime(2024, 10, 7, 14, 54, 9, 220, DateTimeKind.Utc).AddTicks(7799), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreationDate", "TotalSales" },
                values: new object[] { new DateTime(2024, 10, 7, 14, 54, 9, 220, DateTimeKind.Utc).AddTicks(7810), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreationDate", "TotalSales" },
                values: new object[] { new DateTime(2024, 10, 7, 14, 54, 9, 220, DateTimeKind.Utc).AddTicks(7811), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreationDate", "TotalSales" },
                values: new object[] { new DateTime(2024, 10, 7, 14, 54, 9, 220, DateTimeKind.Utc).AddTicks(7813), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreationDate", "TotalSales" },
                values: new object[] { new DateTime(2024, 10, 7, 14, 54, 9, 220, DateTimeKind.Utc).AddTicks(7814), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreationDate", "TotalSales" },
                values: new object[] { new DateTime(2024, 10, 7, 14, 54, 9, 220, DateTimeKind.Utc).AddTicks(7816), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreationDate", "TotalSales" },
                values: new object[] { new DateTime(2024, 10, 7, 14, 54, 9, 220, DateTimeKind.Utc).AddTicks(7817), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreationDate", "TotalSales" },
                values: new object[] { new DateTime(2024, 10, 7, 14, 54, 9, 220, DateTimeKind.Utc).AddTicks(7818), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreationDate", "TotalSales" },
                values: new object[] { new DateTime(2024, 10, 7, 14, 54, 9, 220, DateTimeKind.Utc).AddTicks(7820), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreationDate", "TotalSales" },
                values: new object[] { new DateTime(2024, 10, 7, 14, 54, 9, 220, DateTimeKind.Utc).AddTicks(7821), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreationDate", "TotalSales" },
                values: new object[] { new DateTime(2024, 10, 7, 14, 54, 9, 220, DateTimeKind.Utc).AddTicks(7823), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreationDate", "TotalSales" },
                values: new object[] { new DateTime(2024, 10, 7, 14, 54, 9, 220, DateTimeKind.Utc).AddTicks(7824), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreationDate", "TotalSales" },
                values: new object[] { new DateTime(2024, 10, 7, 14, 54, 9, 220, DateTimeKind.Utc).AddTicks(7826), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreationDate", "TotalSales" },
                values: new object[] { new DateTime(2024, 10, 7, 14, 54, 9, 220, DateTimeKind.Utc).AddTicks(7827), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreationDate", "TotalSales" },
                values: new object[] { new DateTime(2024, 10, 7, 14, 54, 9, 220, DateTimeKind.Utc).AddTicks(7828), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreationDate", "TotalSales" },
                values: new object[] { new DateTime(2024, 10, 7, 14, 54, 9, 220, DateTimeKind.Utc).AddTicks(7830), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalSales",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 9, 25, 18, 56, 58, 710, DateTimeKind.Local).AddTicks(3557));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 9, 25, 18, 56, 58, 710, DateTimeKind.Local).AddTicks(3575));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 9, 25, 18, 56, 58, 710, DateTimeKind.Local).AddTicks(3576));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 9, 25, 18, 56, 58, 710, DateTimeKind.Local).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 9, 25, 18, 56, 58, 710, DateTimeKind.Local).AddTicks(3579));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 9, 25, 18, 56, 58, 710, DateTimeKind.Local).AddTicks(3580));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 9, 25, 18, 56, 58, 710, DateTimeKind.Local).AddTicks(3581));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3760));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3763));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3765));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3767));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3768));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3770));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3772));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationDate",
                value: new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3773));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreationDate",
                value: new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3775));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreationDate",
                value: new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3776));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreationDate",
                value: new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3778));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreationDate",
                value: new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3780));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreationDate",
                value: new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3781));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreationDate",
                value: new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3783));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreationDate",
                value: new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3784));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreationDate",
                value: new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3786));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreationDate",
                value: new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3794));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreationDate",
                value: new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3796));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreationDate",
                value: new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3797));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreationDate",
                value: new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3799));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreationDate",
                value: new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3800));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreationDate",
                value: new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3802));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreationDate",
                value: new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3803));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreationDate",
                value: new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3805));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreationDate",
                value: new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3806));
        }
    }
}
