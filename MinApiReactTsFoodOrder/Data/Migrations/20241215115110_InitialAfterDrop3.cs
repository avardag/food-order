using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MinApiReactTsFoodOrder.Migrations
{
    /// <inheritdoc />
    public partial class InitialAfterDrop3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6b52abd6-2f67-4e29-80fd-e0359b6f5b1a", null, "User", "USER" },
                    { "7cae483f-3a54-49e9-a554-c913d1f3c32c", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80c8b6b1-e2b6-45e8-b044-8f2178a90111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "602729f7-db54-4096-9e09-37f7120a2eee", "AQAAAAIAAYagAAAAEHIjjyhYB9SfSPkK7prcxzGcoMGUr27E7xUjsfI+2iAMtJtGEjArY7qa8sp72REw0A==", "b08dc0f4-720f-4e64-8a51-5a723ba23f05" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b52abd6-2f67-4e29-80fd-e0359b6f5b1a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cae483f-3a54-49e9-a554-c913d1f3c32c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80c8b6b1-e2b6-45e8-b044-8f2178a90111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a9c6c4d-2520-4dd1-9ff1-b5e9a15af1e4", "AQAAAAIAAYagAAAAEOjLtUgigZmTEqNTqMubGSoP10f7e7XGQLBYf7MeI/J0KJzmU+w11n5IoLSV0NQFgA==", "1aa8b332-d110-47e8-9019-7fd4d215cb25" });
        }
    }
}
