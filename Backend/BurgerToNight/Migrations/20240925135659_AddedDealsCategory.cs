using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BurgerToNightAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedDealsCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreationCategoryTime", "Description", "Icon", "Name" },
                values: new object[] { 7, new DateTime(2024, 9, 25, 18, 56, 58, 710, DateTimeKind.Local).AddTicks(3581), "Special deals just hanging around the corner for you!", "", "Deals" });

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

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreationDate", "Description", "Image", "Name", "PreparingTime", "Price" },
                values: new object[,]
                {
                    { 21, 7, new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3800), "A delicious deal with two juicy beef burgers, loaded with cheese, fresh veggies, and a side of crispy fries.", "", "Mega Burger Feast", 30, 120 },
                    { 22, 7, new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3802), "Get two large pizzas with a variety of toppings, plus a family-size portion of garlic bread and a liter of soda.", "", "Family Pizza Bundle", 45, 180 },
                    { 23, 7, new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3803), "Enjoy a bucket filled with 12 pieces of crispy fried chicken, a large side of coleslaw, and mashed potatoes with gravy.", "", "Chicken Bucket Special", 35, 150 },
                    { 24, 7, new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3805), "A box of 10 flavorful Wraps, with your choice of beef or chicken, served with salsa, guacamole, and chips.", "", "Wrap Fiesta Box", 25, 100 },
                    { 25, 7, new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3806), "Indulge in a cheesy delight with a large pizza smothered in four types of cheese, baked to perfection.", "", "Cheese Lover's Pizza", 40, 95 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 8, 19, 14, 50, 54, 937, DateTimeKind.Local).AddTicks(1133));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 8, 19, 14, 50, 54, 937, DateTimeKind.Local).AddTicks(1150));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 8, 19, 14, 50, 54, 937, DateTimeKind.Local).AddTicks(1152));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 8, 19, 14, 50, 54, 937, DateTimeKind.Local).AddTicks(1153));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 8, 19, 14, 50, 54, 937, DateTimeKind.Local).AddTicks(1154));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationCategoryTime",
                value: new DateTime(2024, 8, 19, 14, 50, 54, 937, DateTimeKind.Local).AddTicks(1155));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 8, 19, 9, 50, 54, 937, DateTimeKind.Utc).AddTicks(1340));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 8, 19, 9, 50, 54, 937, DateTimeKind.Utc).AddTicks(1343));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 8, 19, 9, 50, 54, 937, DateTimeKind.Utc).AddTicks(1345));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2024, 8, 19, 9, 50, 54, 937, DateTimeKind.Utc).AddTicks(1347));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2024, 8, 19, 9, 50, 54, 937, DateTimeKind.Utc).AddTicks(1349));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2024, 8, 19, 9, 50, 54, 937, DateTimeKind.Utc).AddTicks(1350));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2024, 8, 19, 9, 50, 54, 937, DateTimeKind.Utc).AddTicks(1353));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationDate",
                value: new DateTime(2024, 8, 19, 9, 50, 54, 937, DateTimeKind.Utc).AddTicks(1354));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreationDate",
                value: new DateTime(2024, 8, 19, 9, 50, 54, 937, DateTimeKind.Utc).AddTicks(1356));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreationDate",
                value: new DateTime(2024, 8, 19, 9, 50, 54, 937, DateTimeKind.Utc).AddTicks(1357));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreationDate",
                value: new DateTime(2024, 8, 19, 9, 50, 54, 937, DateTimeKind.Utc).AddTicks(1359));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreationDate",
                value: new DateTime(2024, 8, 19, 9, 50, 54, 937, DateTimeKind.Utc).AddTicks(1360));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreationDate",
                value: new DateTime(2024, 8, 19, 9, 50, 54, 937, DateTimeKind.Utc).AddTicks(1362));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreationDate",
                value: new DateTime(2024, 8, 19, 9, 50, 54, 937, DateTimeKind.Utc).AddTicks(1363));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreationDate",
                value: new DateTime(2024, 8, 19, 9, 50, 54, 937, DateTimeKind.Utc).AddTicks(1364));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreationDate",
                value: new DateTime(2024, 8, 19, 9, 50, 54, 937, DateTimeKind.Utc).AddTicks(1366));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreationDate",
                value: new DateTime(2024, 8, 19, 9, 50, 54, 937, DateTimeKind.Utc).AddTicks(1367));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreationDate",
                value: new DateTime(2024, 8, 19, 9, 50, 54, 937, DateTimeKind.Utc).AddTicks(1368));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreationDate",
                value: new DateTime(2024, 8, 19, 9, 50, 54, 937, DateTimeKind.Utc).AddTicks(1370));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreationDate",
                value: new DateTime(2024, 8, 19, 9, 50, 54, 937, DateTimeKind.Utc).AddTicks(1372));
        }
    }
}
