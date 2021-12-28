using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrdersApp.Data.Migrations
{
    public partial class identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Users",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Users",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Users",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Users",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Users",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Users",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Users",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Users",
                type: "TEXT",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

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
    }
}
