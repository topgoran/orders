using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrdersApp.Data.Migrations
{
    public partial class createMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CoverId", "Description", "ImageId", "Name", "Price" },
                values: new object[] { new Guid("b7bee8b9-a9e1-4ea3-8342-8d4b2c535959"), 3, "This is article 1", 3, "Article 1", 30.5m });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CoverId", "Description", "ImageId", "Name", "Price" },
                values: new object[] { new Guid("4a28ecaf-47f2-402d-9b8d-27219ac807eb"), 4, "This is article 2", 4, "Article 2", 34.5m });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CoverId", "Description", "ImageId", "Name" },
                values: new object[] { new Guid("672f99d6-8122-40cb-8c06-f7520ed587e9"), 1, "This is a menu 1", 1, "Menu 1" });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CoverId", "Description", "ImageId", "Name" },
                values: new object[] { new Guid("10a28caf-40f3-4869-9fb8-a136955cd057"), 2, "This is a menu 2", 2, "Menu 2" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "EmailAddress", "FirstName", "LastName", "PhoneNumber", "State", "Street", "ZipCode" },
                values: new object[] { new Guid("b364315c-3881-44d9-a498-fc74300cbd6c"), "City 1", "Email address 1", "User 1", "User 1", "Phone number 1", "State 1", "Street 1", "Zipcode 1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "EmailAddress", "FirstName", "LastName", "PhoneNumber", "State", "Street", "ZipCode" },
                values: new object[] { new Guid("15a60132-90b9-4be9-b612-4585141ec1bb"), "City 2", "Email address 2", "User 2", "User 2", "Phone number 2", "State 2", "Street 2", "Zipcode 2" });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "ArticleId", "MenuId" },
                values: new object[] { new Guid("97509034-2da9-41e6-8229-c2221ae2882d"), new Guid("b7bee8b9-a9e1-4ea3-8342-8d4b2c535959"), new Guid("672f99d6-8122-40cb-8c06-f7520ed587e9") });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "ArticleId", "MenuId" },
                values: new object[] { new Guid("0c67489b-e8f0-4d32-8815-b2e05e0d8abd"), new Guid("4a28ecaf-47f2-402d-9b8d-27219ac807eb"), new Guid("10a28caf-40f3-4869-9fb8-a136955cd057") });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Date", "Note", "UserId" },
                values: new object[] { new Guid("61e01544-bbe2-4c35-97fd-8c0c4925ee7e"), new DateTime(2021, 5, 3, 0, 0, 0, 0, DateTimeKind.Local), "Note 1", new Guid("b364315c-3881-44d9-a498-fc74300cbd6c") });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Date", "Note", "UserId" },
                values: new object[] { new Guid("8f1feb6b-2048-4e92-b942-dc9aff802228"), new DateTime(2021, 5, 3, 0, 0, 0, 0, DateTimeKind.Local), "Note 2", new Guid("15a60132-90b9-4be9-b612-4585141ec1bb") });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "ArticleId", "OrderId", "Price", "Quantity" },
                values: new object[] { new Guid("3c7895c1-d06d-4052-a0a2-b98fa3759c85"), new Guid("4a28ecaf-47f2-402d-9b8d-27219ac807eb"), new Guid("61e01544-bbe2-4c35-97fd-8c0c4925ee7e"), 305m, 10 });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "ArticleId", "OrderId", "Price", "Quantity" },
                values: new object[] { new Guid("84b7f58b-a320-40f8-a401-6b538c05ac70"), new Guid("4a28ecaf-47f2-402d-9b8d-27219ac807eb"), new Guid("8f1feb6b-2048-4e92-b942-dc9aff802228"), 345m, 10 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("0c67489b-e8f0-4d32-8815-b2e05e0d8abd"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("97509034-2da9-41e6-8229-c2221ae2882d"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("3c7895c1-d06d-4052-a0a2-b98fa3759c85"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("84b7f58b-a320-40f8-a401-6b538c05ac70"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("4a28ecaf-47f2-402d-9b8d-27219ac807eb"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("b7bee8b9-a9e1-4ea3-8342-8d4b2c535959"));

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("10a28caf-40f3-4869-9fb8-a136955cd057"));

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("672f99d6-8122-40cb-8c06-f7520ed587e9"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("61e01544-bbe2-4c35-97fd-8c0c4925ee7e"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("8f1feb6b-2048-4e92-b942-dc9aff802228"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("15a60132-90b9-4be9-b612-4585141ec1bb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b364315c-3881-44d9-a498-fc74300cbd6c"));
        }
    }
}
