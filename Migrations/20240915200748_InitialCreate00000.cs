using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IV.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate00000 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFavorite",
                table: "MotivationalQuotes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFavorite",
                table: "MotivationalQuotes");
        }
    }
}
