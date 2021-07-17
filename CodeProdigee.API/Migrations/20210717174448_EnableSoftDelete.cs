using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeProdigee.API.Migrations
{
    public partial class EnableSoftDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Tags",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Resources",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "PostTags",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PostTags",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ID",
                table: "PostTags",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PostTags",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "PostID1",
                table: "PostTags",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TagID1",
                table: "PostTags",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "PostTags",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "PostTags",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Posts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "PostResources",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PostResources",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ID",
                table: "PostResources",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PostResources",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "PostID1",
                table: "PostResources",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ResourceID1",
                table: "PostResources",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "PostResources",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "PostResources",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Comments",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Commentators",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Blogs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Authors",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_PostID1",
                table: "PostTags",
                column: "PostID1");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_TagID1",
                table: "PostTags",
                column: "TagID1");

            migrationBuilder.CreateIndex(
                name: "IX_PostResources_PostID1",
                table: "PostResources",
                column: "PostID1");

            migrationBuilder.CreateIndex(
                name: "IX_PostResources_ResourceID1",
                table: "PostResources",
                column: "ResourceID1");

            migrationBuilder.AddForeignKey(
                name: "FK_PostResources_Posts_PostID1",
                table: "PostResources",
                column: "PostID1",
                principalTable: "Posts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostResources_Resources_ResourceID1",
                table: "PostResources",
                column: "ResourceID1",
                principalTable: "Resources",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTags_Posts_PostID1",
                table: "PostTags",
                column: "PostID1",
                principalTable: "Posts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTags_Tags_TagID1",
                table: "PostTags",
                column: "TagID1",
                principalTable: "Tags",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostResources_Posts_PostID1",
                table: "PostResources");

            migrationBuilder.DropForeignKey(
                name: "FK_PostResources_Resources_ResourceID1",
                table: "PostResources");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTags_Posts_PostID1",
                table: "PostTags");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTags_Tags_TagID1",
                table: "PostTags");

            migrationBuilder.DropIndex(
                name: "IX_PostTags_PostID1",
                table: "PostTags");

            migrationBuilder.DropIndex(
                name: "IX_PostTags_TagID1",
                table: "PostTags");

            migrationBuilder.DropIndex(
                name: "IX_PostResources_PostID1",
                table: "PostResources");

            migrationBuilder.DropIndex(
                name: "IX_PostResources_ResourceID1",
                table: "PostResources");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PostTags");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PostTags");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "PostTags");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PostTags");

            migrationBuilder.DropColumn(
                name: "PostID1",
                table: "PostTags");

            migrationBuilder.DropColumn(
                name: "TagID1",
                table: "PostTags");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "PostTags");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "PostTags");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PostResources");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PostResources");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "PostResources");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PostResources");

            migrationBuilder.DropColumn(
                name: "PostID1",
                table: "PostResources");

            migrationBuilder.DropColumn(
                name: "ResourceID1",
                table: "PostResources");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "PostResources");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "PostResources");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Commentators");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Authors");
        }
    }
}
