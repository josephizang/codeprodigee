using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeProdigee.API.Migrations
{
    public partial class AuthorChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorGithub",
                table: "Authors",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AvatarImage",
                table: "Authors",
                type: "character varying(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "Authors",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorGithub",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "AvatarImage",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Bio",
                table: "Authors");
        }
    }
}
