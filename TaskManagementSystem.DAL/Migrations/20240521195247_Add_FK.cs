using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagementSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Add_FK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
              name: "IX_Taskers_UserId",
              table: "Taskers",
              column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Taskers_AspNetUsers_UserId",
                table: "Taskers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Taskers_AspNetUsers_UserId",
                 table: "Taskers");

            migrationBuilder.DropIndex(
                name: "IX_Taskers_UserId",
                table: "Taskers");
        }
    }
}
