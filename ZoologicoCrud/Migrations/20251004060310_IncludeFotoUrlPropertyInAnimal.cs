using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZoologicoCrud.Migrations
{
    /// <inheritdoc />
    public partial class IncludeFotoUrlPropertyInAnimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FotoUrl",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoUrl",
                table: "Animals");
        }
    }
}
