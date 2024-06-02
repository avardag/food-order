using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MinApiReactTsFoodOrder.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditTagEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91a222b9-df91-438a-a4d8-441653420e5c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4192832-0ba1-4386-b908-95779b0ef356");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3b6096ba-1b33-4e64-bd90-07f0f1a4b4f2", null, "User", "USER" },
                    { "84209737-132a-42e5-bb73-887c01890922", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80c8b6b1-e2b6-45e8-b044-8f2178a90111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa271a05-6e4f-41d3-b9b8-def835c1089c", "AQAAAAIAAYagAAAAEIZTEjgWmYD9aevPHYtSl3egHKHpsakT0zhlATn+ZQmRLO9vn24fR/bWbUldtt/f3A==", "61890343-7ece-409d-b5cb-13feff43da44" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b6096ba-1b33-4e64-bd90-07f0f1a4b4f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84209737-132a-42e5-bb73-887c01890922");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "91a222b9-df91-438a-a4d8-441653420e5c", null, "User", "USER" },
                    { "d4192832-0ba1-4386-b908-95779b0ef356", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80c8b6b1-e2b6-45e8-b044-8f2178a90111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8c9a38e-9329-4524-9fd8-210a18dcfb5c", "AQAAAAIAAYagAAAAEBYJfC49xu/yi7vWrx8/80WAHpRDZRhA77pYjLJHy3CaMsutBnhZQ8ERGazjNWmW/g==", "5782562f-7639-4959-a750-a501075796fa" });
        }
    }
}
