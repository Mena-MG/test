using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace assmint.Migrations
{
    /// <inheritdoc />
    public partial class Inih : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tasks_TeamMember_TeamMembersid",
                table: "tasks");

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_TeamMember_TeamMembersid",
                table: "tasks",
                column: "TeamMembersid",
                principalTable: "TeamMember",
                principalColumn: "TeamMemberid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tasks_TeamMember_TeamMembersid",
                table: "tasks");

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_TeamMember_TeamMembersid",
                table: "tasks",
                column: "TeamMembersid",
                principalTable: "TeamMember",
                principalColumn: "TeamMemberid");
        }
    }
}
