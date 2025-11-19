using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestWithAspNet10.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    author = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    price = table.Column<decimal>(type: "decimal(7,2)", nullable: false),
                    launch_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "books");
        }
    }
}
