using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BurgerToNightAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationCategoryTime", "Description", "Icon", "Name" },
                values: new object[] { new DateTime(2024, 8, 19, 14, 50, 54, 937, DateTimeKind.Local).AddTicks(1133), "Deliciously baked pizzas with a variety of toppings and flavors to satisfy every craving.", "", "Pizza" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationCategoryTime", "Description", "Icon", "Name" },
                values: new object[] { new DateTime(2024, 8, 19, 14, 50, 54, 937, DateTimeKind.Local).AddTicks(1150), "Juicy and flavorful burgers, crafted to perfection with fresh ingredients.", "", "Burger" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationCategoryTime", "Description", "Icon", "Name" },
                values: new object[] { new DateTime(2024, 8, 19, 14, 50, 54, 937, DateTimeKind.Local).AddTicks(1152), "Crispy and tender broasts, made with quality spices and cooked to golden perfection.", "", "Broast" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationCategoryTime", "Description", "Icon", "Name" },
                values: new object[] { new DateTime(2024, 8, 19, 14, 50, 54, 937, DateTimeKind.Local).AddTicks(1153), "A selection of rich and creamy pasta dishes, cooked with authentic flavors.", "", "Pasta" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationCategoryTime", "Description", "Icon", "Name" },
                values: new object[] { new DateTime(2024, 8, 19, 14, 50, 54, 937, DateTimeKind.Local).AddTicks(1154), "Tasty wraps filled with a variety of meats and vegetables, wrapped in soft tortillas.", "", "Wrap" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreationCategoryTime", "Description", "Icon", "Name" },
                values: new object[] { new DateTime(2024, 8, 19, 14, 50, 54, 937, DateTimeKind.Local).AddTicks(1155), "Fresh and healthy salads, made with crisp vegetables and delicious dressings.", "", "Salad" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "CreationDate", "Description", "Name", "PreparingTime", "Price" },
                values: new object[] { 1, new DateTime(2024, 8, 19, 9, 50, 54, 937, DateTimeKind.Utc).AddTicks(1340), "A classic Pepperoni Pizza topped with premium pepperoni slices, mozzarella cheese, and our signature tomato sauce.", "Pepperoni Pizza", 15, 15 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "CreationDate", "Description", "Name", "PreparingTime", "Price" },
                values: new object[] { 1, new DateTime(2024, 8, 19, 9, 50, 54, 937, DateTimeKind.Utc).AddTicks(1343), "Simplicity at its best: the Margherita Pizza features fresh basil, tomatoes, mozzarella, and a drizzle of olive oil.", "Margherita Pizza", 12, 12 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "CreationDate", "Description", "Name", "PreparingTime", "Price" },
                values: new object[] { 1, new DateTime(2024, 8, 19, 9, 50, 54, 937, DateTimeKind.Utc).AddTicks(1345), "BBQ Chicken Pizza loaded with grilled chicken, BBQ sauce, onions, and mozzarella cheese.", "BBQ Chicken Pizza", 15, 18 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "Description", "Name", "PreparingTime", "Price" },
                values: new object[] { new DateTime(2024, 8, 19, 9, 50, 54, 937, DateTimeKind.Utc).AddTicks(1347), "A delightful Veggie Pizza topped with bell peppers, olives, mushrooms, onions, and mozzarella cheese.", "Veggie Pizza", 15, 14 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "CreationDate", "Description", "Name", "PreparingTime", "Price" },
                values: new object[] { 2, new DateTime(2024, 8, 19, 9, 50, 54, 937, DateTimeKind.Utc).AddTicks(1349), "Our Classic Cheeseburger is made with a juicy beef patty, melted cheddar cheese, lettuce, tomato, and pickles.", "Classic Cheeseburger", 8, 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "CreationDate", "Description", "Name", "Price" },
                values: new object[] { 2, new DateTime(2024, 8, 19, 9, 50, 54, 937, DateTimeKind.Utc).AddTicks(1350), "A mouthwatering Double Bacon Burger with double beef patties, crispy bacon, cheddar cheese, and smoky sauce.", "Double Bacon Burger", 20 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreationDate", "Description", "Image", "Name", "PreparingTime", "Price" },
                values: new object[,]
                {
                    { 7, 2, new DateTime(2024, 8, 19, 9, 50, 54, 937, DateTimeKind.Utc).AddTicks(1353), "The Mushroom Swiss Burger features a savory beef patty, Swiss cheese, sautéed mushrooms, and garlic aioli.", "", "Mushroom Swiss Burger", 10, 15 },
                    { 8, 2, new DateTime(2024, 8, 19, 9, 50, 54, 937, DateTimeKind.Utc).AddTicks(1354), "A spicy twist on a classic, the Spicy Chicken Burger is packed with flavor and heat, topped with jalapeños and pepper jack cheese.", "", "Spicy Chicken Burger", 10, 12 },
                    { 9, 3, new DateTime(2024, 8, 19, 9, 50, 54, 937, DateTimeKind.Utc).AddTicks(1356), "Golden crispy Chicken Broast, marinated in special spices and fried to perfection. Served with fries and coleslaw.", "", "Chicken Broast", 20, 18 },
                    { 10, 3, new DateTime(2024, 8, 19, 9, 50, 54, 937, DateTimeKind.Utc).AddTicks(1357), "Tender and crispy Beef Broast, seasoned with a blend of herbs and spices. Served with a side of dipping sauce.", "", "Beef Broast", 20, 20 },
                    { 11, 4, new DateTime(2024, 8, 19, 9, 50, 54, 937, DateTimeKind.Utc).AddTicks(1359), "Traditional Spaghetti Carbonara made with creamy sauce, crispy pancetta, and Parmesan cheese.", "", "Spaghetti Carbonara", 15, 14 },
                    { 12, 4, new DateTime(2024, 8, 19, 9, 50, 54, 937, DateTimeKind.Utc).AddTicks(1360), "A rich and creamy Chicken Alfredo pasta with grilled chicken, fettuccine noodles, and Alfredo sauce.", "", "Chicken Alfredo", 15, 16 },
                    { 13, 4, new DateTime(2024, 8, 19, 9, 50, 54, 937, DateTimeKind.Utc).AddTicks(1362), "Spicy and flavorful Penne Arrabbiata, made with penne pasta, garlic, red chili flakes, and tomato sauce.", "", "Penne Arrabbiata", 12, 13 },
                    { 14, 4, new DateTime(2024, 8, 19, 9, 50, 54, 937, DateTimeKind.Utc).AddTicks(1363), "Creamy and indulgent Fettuccine Alfredo, made with rich Alfredo sauce and topped with Parmesan cheese.", "", "Fettuccine Alfredo", 12, 15 },
                    { 15, 5, new DateTime(2024, 8, 19, 9, 50, 54, 937, DateTimeKind.Utc).AddTicks(1364), "A healthy and delicious Grilled Chicken Wrap with lettuce, tomatoes, cucumbers, and a tangy yogurt dressing.", "", "Grilled Chicken Wrap", 10, 10 },
                    { 16, 5, new DateTime(2024, 8, 19, 9, 50, 54, 937, DateTimeKind.Utc).AddTicks(1366), "A tasty Falafel Wrap filled with crispy falafel, fresh vegetables, and a creamy tahini sauce.", "", "Falafel Wrap", 10, 9 },
                    { 17, 5, new DateTime(2024, 8, 19, 9, 50, 54, 937, DateTimeKind.Utc).AddTicks(1367), "A flavorful Beef Shawarma Wrap, filled with seasoned beef, fresh vegetables, and garlic sauce, wrapped in a soft tortilla.", "", "Beef Shawarma Wrap", 10, 12 },
                    { 18, 5, new DateTime(2024, 8, 19, 9, 50, 54, 937, DateTimeKind.Utc).AddTicks(1368), "A Grilled Veggie Wrap loaded with grilled vegetables, hummus, and fresh herbs, wrapped in a whole wheat tortilla.", "", "Grilled Veggie Wrap", 10, 10 },
                    { 19, 6, new DateTime(2024, 8, 19, 9, 50, 54, 937, DateTimeKind.Utc).AddTicks(1370), "A fresh Caesar Salad with crisp romaine lettuce, croutons, Parmesan cheese, and Caesar dressing.", "", "Caesar Salad", 5, 8 },
                    { 20, 6, new DateTime(2024, 8, 19, 9, 50, 54, 937, DateTimeKind.Utc).AddTicks(1372), "A refreshing Greek Salad made with cucumbers, tomatoes, olives, feta cheese, and a lemon-oregano dressing.", "", "Greek Salad", 5, 9 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationCategoryTime", "Description", "Name" },
                values: new object[] { new DateTime(2024, 8, 19, 13, 42, 25, 724, DateTimeKind.Local).AddTicks(7391), "Experience the smoky flavor and tender texture of our BBQ burgers, crafted with meticulous care in a controlled environment.", "BBQ" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationCategoryTime", "Description", "Name" },
                values: new object[] { new DateTime(2024, 8, 19, 13, 42, 25, 724, DateTimeKind.Local).AddTicks(7406), "Indulge in the wholesome goodness of our Grilled burgers, prepared in a hygienic oven for a perfect char and juicy bite.", "Grilled" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationCategoryTime", "Description", "Name" },
                values: new object[] { new DateTime(2024, 8, 19, 13, 42, 25, 724, DateTimeKind.Local).AddTicks(7407), "Savor the irresistible crunch of our burgers, made with the finest breadcrumbs and fresh, clean oil for an unforgettable taste.", "Crunch" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationCategoryTime", "Description", "Name" },
                values: new object[] { new DateTime(2024, 8, 19, 13, 42, 25, 724, DateTimeKind.Local).AddTicks(7409), "Discover our signature Special burgers, the ultimate favorite renowned for their exceptional flavor and quality.", "Special" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationCategoryTime", "Description", "Name" },
                values: new object[] { new DateTime(2024, 8, 19, 13, 42, 25, 724, DateTimeKind.Local).AddTicks(7413), "Dive into the deliciousness of our Fish burgers, served with love and a smile for a delightful seafood experience.", "Fish" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreationCategoryTime", "Description", "Name" },
                values: new object[] { new DateTime(2024, 8, 19, 13, 42, 25, 724, DateTimeKind.Local).AddTicks(7414), "Enjoy the rich and succulent taste of our Lamb burgers, made with premium lamb meat imported from Turkey just for you.", "Lamb" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "CreationDate", "Description", "Name", "PreparingTime", "Price" },
                values: new object[] { 3, new DateTime(2024, 8, 19, 8, 42, 25, 724, DateTimeKind.Utc).AddTicks(7577), "The Mighty Zinger is one of our most liked and extraordinarily large burgers! Made with a crunchy breadcrumb coating, fresh lettuce, juicy tomatoes, pickles, and topped with spicy mayo.", "Mighty Zinger", 10, 20 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "CreationDate", "Description", "Name", "PreparingTime", "Price" },
                values: new object[] { 2, new DateTime(2024, 8, 19, 8, 42, 25, 724, DateTimeKind.Utc).AddTicks(7581), "Craving something delicious? Look no further than the Big Ben, a grilled delight featuring a charred patty, cheddar cheese, crispy bacon, onions, and a special smoky sauce.", "Big Ben", 10, 18 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "CreationDate", "Description", "Name", "PreparingTime", "Price" },
                values: new object[] { 4, new DateTime(2024, 8, 19, 8, 42, 25, 724, DateTimeKind.Utc).AddTicks(7584), "Need to fill a giant stomach? The Big Bang is here to deliver with its massive size and explosive flavor! Loaded with double beef patties, American cheese, onion rings, and BBQ sauce.", "Big Bang", 10, 40 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "Description", "Name", "PreparingTime", "Price" },
                values: new object[] { new DateTime(2024, 8, 19, 8, 42, 25, 724, DateTimeKind.Utc).AddTicks(7587), "Our Super BBQ burgers are crafted with extreme care, offering a mouthwatering BBQ experience with smoky beef patties, pepper jack cheese, crispy onions, and tangy BBQ sauce.", "Super BBQ", 10, 30 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "CreationDate", "Description", "Name", "PreparingTime", "Price" },
                values: new object[] { 5, new DateTime(2024, 8, 19, 8, 42, 25, 724, DateTimeKind.Utc).AddTicks(7588), "Our Selmon Fish burgers are in high demand. Order yours before it's too late and enjoy the taste of fresh, delectable fish! Made with crispy fish fillets, tartar sauce, lettuce, and pickles.", "Selmon Burger", 10, 30 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "CreationDate", "Description", "Name", "Price" },
                values: new object[] { 6, new DateTime(2024, 8, 19, 8, 42, 25, 724, DateTimeKind.Utc).AddTicks(7590), "Savor the exquisite flavor of our Lamb Burger, featuring premium lamb meat, mint yogurt sauce, feta cheese, cucumber slices, and arugula, all wrapped in a toasted bun.", "Lamb Burger", 30 });
        }
    }
}
