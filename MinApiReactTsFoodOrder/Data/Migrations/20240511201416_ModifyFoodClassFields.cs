using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MinApiReactTsFoodOrder.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifyFoodClassFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "497c2b40-bb01-4809-9772-d67bccf09bb2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7d7bad0-1b1f-4331-bbee-1d6c5abf7b69");

            migrationBuilder.AlterColumn<double>(
                name: "Stars",
                table: "Foods",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<string[]>(
                name: "Origins",
                table: "Foods",
                type: "text[]",
                nullable: true,
                oldClrType: typeof(string[]),
                oldType: "text[]");

            migrationBuilder.AlterColumn<bool>(
                name: "Favorite",
                table: "Foods",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CookTime",
                table: "Foods",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5cf65179-06b5-4247-ba9c-c47a98ecbfff", null, "User", "USER" },
                    { "d8bf8bbc-bd75-47e3-85b1-4c57e7bc63e2", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5cf65179-06b5-4247-ba9c-c47a98ecbfff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8bf8bbc-bd75-47e3-85b1-4c57e7bc63e2");

            migrationBuilder.AlterColumn<double>(
                name: "Stars",
                table: "Foods",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<string[]>(
                name: "Origins",
                table: "Foods",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0],
                oldClrType: typeof(string[]),
                oldType: "text[]",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Favorite",
                table: "Foods",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CookTime",
                table: "Foods",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "497c2b40-bb01-4809-9772-d67bccf09bb2", null, "User", "USER" },
                    { "d7d7bad0-1b1f-4331-bbee-1d6c5abf7b69", null, "Admin", "ADMIN" }
                });
        }
    }
}
