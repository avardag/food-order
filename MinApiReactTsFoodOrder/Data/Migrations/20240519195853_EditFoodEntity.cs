using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MinApiReactTsFoodOrder.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditFoodEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f13bcde-b3de-48a6-81a0-ed4111fc0155");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f869022d-89cd-4632-81d7-edfb88a88e1a");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Foods",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

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
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8c9a38e-9329-4524-9fd8-210a18dcfb5c", "ADMIN", "AQAAAAIAAYagAAAAEBYJfC49xu/yi7vWrx8/80WAHpRDZRhA77pYjLJHy3CaMsutBnhZQ8ERGazjNWmW/g==", "5782562f-7639-4959-a750-a501075796fa" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91a222b9-df91-438a-a4d8-441653420e5c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4192832-0ba1-4386-b908-95779b0ef356");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Foods",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f13bcde-b3de-48a6-81a0-ed4111fc0155", null, "User", "USER" },
                    { "f869022d-89cd-4632-81d7-edfb88a88e1a", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80c8b6b1-e2b6-45e8-b044-8f2178a90111",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "243e9325-b9c0-4d8e-8dfa-8bd504087a88", "ADMIN@FOODORDER.COM", "AQAAAAIAAYagAAAAEDsFz/uj13lz3sb+13hPdQ2Gj/mR9zuXvAFVEIkPRKpHeYMlFciXz9uljgAZFeZyVg==", "33fdf9ed-95a7-49c5-b7d8-0cf637bcb0ae" });
        }
    }
}
