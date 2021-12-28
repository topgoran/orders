using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrdersApp.Data.Migrations
{
    public partial class identityV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CoverId", "Description", "ImageId", "Name", "Price" },
                values: new object[] { new Guid("c321072a-07cb-47bc-9ba2-9bc86df8f64f"), 3, "This is article 1", 3, "Article 1", 30.5m });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CoverId", "Description", "ImageId", "Name", "Price" },
                values: new object[] { new Guid("19b1fdbd-a342-485f-b730-a22f05b5d4a8"), 4, "This is article 2", 4, "Article 2", 34.5m });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("7f561ee8-21ee-44bf-9a5d-b7b75c3a3ed0"), 0, "Street 1", "City 1", "7a316cf2-55a8-4ec1-8084-417b8cfb3180", null, false, "User 1", "User 1", false, null, null, null, null, "Phone number 1", false, null, "State 1", false, null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("335171f7-f5c7-40b6-bc89-e835baf27f9c"), 0, "Street 2", "City 2", "4d5192de-c55b-40e5-a6f9-949da4d7e56e", null, false, "User 2", "User 2", false, null, null, null, null, "Phone number 2", false, null, "State 2", false, null });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CoverId", "Description", "ImageId", "Name" },
                values: new object[] { new Guid("0fbf6ff8-5595-4cae-8d7a-0fbdcf3ab9e5"), 1, "This is a menu 1", 1, "Menu 1" });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CoverId", "Description", "ImageId", "Name" },
                values: new object[] { new Guid("e3b89d47-2bf6-426f-a721-7343d65e09e5"), 2, "This is a menu 2", 2, "Menu 2" });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "ArticleId", "MenuId" },
                values: new object[] { new Guid("7b55c099-dce6-4789-af5d-eaeaf71d7d63"), new Guid("c321072a-07cb-47bc-9ba2-9bc86df8f64f"), new Guid("0fbf6ff8-5595-4cae-8d7a-0fbdcf3ab9e5") });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "ArticleId", "MenuId" },
                values: new object[] { new Guid("1a50d188-7332-4aa6-a978-2b07ab9c32b7"), new Guid("19b1fdbd-a342-485f-b730-a22f05b5d4a8"), new Guid("e3b89d47-2bf6-426f-a721-7343d65e09e5") });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Date", "Note", "UserId" },
                values: new object[] { new Guid("e165bb1a-a78e-4df0-ae1d-73ff08faf61c"), new DateTime(2021, 5, 11, 0, 0, 0, 0, DateTimeKind.Local), "Note 1", new Guid("7f561ee8-21ee-44bf-9a5d-b7b75c3a3ed0") });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Date", "Note", "UserId" },
                values: new object[] { new Guid("6284aec7-b949-4659-9fa4-63cb7636589a"), new DateTime(2021, 5, 11, 0, 0, 0, 0, DateTimeKind.Local), "Note 2", new Guid("335171f7-f5c7-40b6-bc89-e835baf27f9c") });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "ArticleId", "OrderId", "Price", "Quantity" },
                values: new object[] { new Guid("ddb3854c-3760-4328-8a79-2d7ffef819da"), new Guid("19b1fdbd-a342-485f-b730-a22f05b5d4a8"), new Guid("e165bb1a-a78e-4df0-ae1d-73ff08faf61c"), 305m, 10 });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "ArticleId", "OrderId", "Price", "Quantity" },
                values: new object[] { new Guid("26920e50-a318-4872-aeab-b4d205df1e3c"), new Guid("19b1fdbd-a342-485f-b730-a22f05b5d4a8"), new Guid("6284aec7-b949-4659-9fa4-63cb7636589a"), 345m, 10 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("1a50d188-7332-4aa6-a978-2b07ab9c32b7"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("7b55c099-dce6-4789-af5d-eaeaf71d7d63"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("26920e50-a318-4872-aeab-b4d205df1e3c"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("ddb3854c-3760-4328-8a79-2d7ffef819da"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("19b1fdbd-a342-485f-b730-a22f05b5d4a8"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("c321072a-07cb-47bc-9ba2-9bc86df8f64f"));

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("0fbf6ff8-5595-4cae-8d7a-0fbdcf3ab9e5"));

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("e3b89d47-2bf6-426f-a721-7343d65e09e5"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("6284aec7-b949-4659-9fa4-63cb7636589a"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("e165bb1a-a78e-4df0-ae1d-73ff08faf61c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("335171f7-f5c7-40b6-bc89-e835baf27f9c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7f561ee8-21ee-44bf-9a5d-b7b75c3a3ed0"));
        }
    }
}
