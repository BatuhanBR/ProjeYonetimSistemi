using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjeYonetimSistemi.UI.MVC.Migrations
{
    public partial class AddIsActiveColumnToProjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Projects");
        }
    }
}
