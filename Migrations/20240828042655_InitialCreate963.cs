using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IV.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate963 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalorieCalculations_Users_UserID",
                table: "CalorieCalculations");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "CalorieCalculations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CalorieCalculations_Users_UserID",
                table: "CalorieCalculations",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalorieCalculations_Users_UserID",
                table: "CalorieCalculations");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "CalorieCalculations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CalorieCalculations_Users_UserID",
                table: "CalorieCalculations",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
