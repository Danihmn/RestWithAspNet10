using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestWithAspNet10.Migrations
{
    /// <inheritdoc />
    public partial class Adds_Products_Enabled_Product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "enabled",
                table: "products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "enabled",
                table: "products");
        }
    }
}
