using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiTask.Data.Migrations
{
    public partial class PropertyGroupChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "No",
                table: "Groups");

            migrationBuilder.AddColumn<string>(
                name: "GroupNo",
                table: "Groups",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupNo",
                table: "Groups");

            migrationBuilder.AddColumn<int>(
                name: "No",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
