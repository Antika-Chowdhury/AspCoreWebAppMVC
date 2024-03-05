using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspCoreWebAppMVC.Migrations
{
    public partial class newfieldadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PdfFileName",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PdfFileName",
                table: "User");
        }
    }
}
