using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MinApiReactTsFoodOrder.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5cf65179-06b5-4247-ba9c-c47a98ecbfff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8bf8bbc-bd75-47e3-85b1-4c57e7bc63e2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f13bcde-b3de-48a6-81a0-ed4111fc0155", null, "User", "USER" },
                    { "f869022d-89cd-4632-81d7-edfb88a88e1a", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "80c8b6b1-e2b6-45e8-b044-8f2178a90111", 0, "243e9325-b9c0-4d8e-8dfa-8bd504087a88", "admin@foodorder.com", true, "Maga", "Bagaev", false, null, "ADMIN@FOODORDER.COM", "ADMIN@FOODORDER.COM", "AQAAAAIAAYagAAAAEDsFz/uj13lz3sb+13hPdQ2Gj/mR9zuXvAFVEIkPRKpHeYMlFciXz9uljgAZFeZyVg==", null, false, 0, "33fdf9ed-95a7-49c5-b7d8-0cf637bcb0ae", false, "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f13bcde-b3de-48a6-81a0-ed4111fc0155");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f869022d-89cd-4632-81d7-edfb88a88e1a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80c8b6b1-e2b6-45e8-b044-8f2178a90111");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5cf65179-06b5-4247-ba9c-c47a98ecbfff", null, "User", "USER" },
                    { "d8bf8bbc-bd75-47e3-85b1-4c57e7bc63e2", null, "Admin", "ADMIN" }
                });
        }
    }
}
