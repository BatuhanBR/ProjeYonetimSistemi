using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjeYonetimSistemi.UI.MVC.Migrations
{
    public partial class CreateProjectsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "Projeler");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Projeler",
                newName: "ProjectName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projeler",
                table: "Projeler",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Projeler",
                table: "Projeler");

            migrationBuilder.RenameTable(
                name: "Projeler",
                newName: "Projects");

            migrationBuilder.RenameColumn(
                name: "ProjectName",
                table: "Projects",
                newName: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "Id");
        }
    }
}
