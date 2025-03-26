using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace game_shop.Migrations
{
    /// <inheritdoc />
    public partial class GameSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Games",
                columns: ["Id", "Description", "Image", "Name", "Price"],
                values: new object[,]
                {
                    { 2, "description2", "image2", "name2", 69.989999999999995 },
                    { 3, "description3", "image3", "name3", 69.989999999999995 },
                    { 4, "description4", "image4", "name4", 69.989999999999995 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
