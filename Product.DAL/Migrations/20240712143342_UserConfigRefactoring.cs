using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UserConfigRefactoring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_InviteId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "InviteId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Invites",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_InviteId",
                table: "Users",
                column: "InviteId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_InviteId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "InviteId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Invites",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Users_InviteId",
                table: "Users",
                column: "InviteId",
                unique: true,
                filter: "[InviteId] IS NOT NULL");
        }
    }
}
