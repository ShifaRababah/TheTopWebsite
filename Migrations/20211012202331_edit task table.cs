using Microsoft.EntityFrameworkCore.Migrations;

namespace TheTopWebsite.Migrations
{
    public partial class edittasktable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskFile",
                table: "Tasks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TaskFile",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
