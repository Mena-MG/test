using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace assmint.Migrations
{
    /// <inheritdoc />
    public partial class InitialCr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tasks_Projects_Projectsid",
                table: "tasks");

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_Projects_Projectsid",
                table: "tasks",
                column: "Projectsid",
                principalTable: "Projects",
                principalColumn: "Projectid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tasks_Projects_Projectsid",
                table: "tasks");

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_Projects_Projectsid",
                table: "tasks",
                column: "Projectsid",
                principalTable: "Projects",
                principalColumn: "Projectid");
        }
    }
}
