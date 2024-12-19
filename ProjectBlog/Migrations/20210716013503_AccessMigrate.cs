using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectBlog.Migrations
{
    public partial class AccessMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Access",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Access_RoleId",
                table: "Access",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Access_Role_RoleId",
                table: "Access",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Access_Role_RoleId",
                table: "Access");

            migrationBuilder.DropIndex(
                name: "IX_Access_RoleId",
                table: "Access");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Access");
        }
    }
}
