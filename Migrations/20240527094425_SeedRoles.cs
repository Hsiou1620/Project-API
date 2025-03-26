    using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace game_shop.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: ["Id", "ConcurrencyStamp", "Name", "NormalizedName"],
                values: new object[,]
                {
                    { "37125561-b34f-4ac3-9ee2-b1ac141a79e5", null, "Admin", "ADMIN" },
                    { "88e9161f-7a47-4578-a6be-35d5c359049d", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37125561-b34f-4ac3-9ee2-b1ac141a79e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88e9161f-7a47-4578-a6be-35d5c359049d");
        }
    }
}
