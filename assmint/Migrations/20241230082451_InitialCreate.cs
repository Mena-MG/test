using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace assmint.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Projectid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stratdatee = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Projectid);
                });

            migrationBuilder.CreateTable(
                name: "TeamMember",
                columns: table => new
                {
                    TeamMemberid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMember", x => x.TeamMemberid);
                });

            migrationBuilder.CreateTable(
                name: "tasks",
                columns: table => new
                {
                    Taskeid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Projectsid = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descrription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    statues = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    priority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamMembersid = table.Column<int>(type: "int", nullable: false),
                    deadlin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tasks", x => x.Taskeid);
                    table.ForeignKey(
                        name: "FK_tasks_Projects_Projectsid",
                        column: x => x.Projectsid,
                        principalTable: "Projects",
                        principalColumn: "Projectid");
                    table.ForeignKey(
                        name: "FK_tasks_TeamMember_TeamMembersid",
                        column: x => x.TeamMembersid,
                        principalTable: "TeamMember",
                        principalColumn: "TeamMemberid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tasks_Projectsid",
                table: "tasks",
                column: "Projectsid");

            migrationBuilder.CreateIndex(
                name: "IX_tasks_TeamMembersid",
                table: "tasks",
                column: "TeamMembersid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tasks");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "TeamMember");
        }
    }
}
