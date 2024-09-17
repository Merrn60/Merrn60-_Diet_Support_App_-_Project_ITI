using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IV.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdminID",
                table: "CalorieCalculations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CalorieCalculations_AdminID",
                table: "CalorieCalculations",
                column: "AdminID");

            migrationBuilder.AddForeignKey(
                name: "FK_CalorieCalculations_Admins_AdminID",
                table: "CalorieCalculations",
                column: "AdminID",
                principalTable: "Admins",
                principalColumn: "AdminID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalorieCalculations_Admins_AdminID",
                table: "CalorieCalculations");

            migrationBuilder.DropIndex(
                name: "IX_CalorieCalculations_AdminID",
                table: "CalorieCalculations");

            migrationBuilder.DropColumn(
                name: "AdminID",
                table: "CalorieCalculations");
        }
    }
}
