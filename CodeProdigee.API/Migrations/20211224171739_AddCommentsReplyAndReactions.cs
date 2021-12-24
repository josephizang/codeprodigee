using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeProdigee.API.Migrations
{
    public partial class AddCommentsReplyAndReactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_CommentID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CommentID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CommentID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "DisLikes",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "Commentators",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CommentReply",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    CommentId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReplyBody = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CommentatorID = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentReply", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CommentReply_Commentators_CommentatorID",
                        column: x => x.CommentatorID,
                        principalTable: "Commentators",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CommentReply_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reaction",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Like = table.Column<bool>(type: "boolean", nullable: false),
                    DisLike = table.Column<bool>(type: "boolean", nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CommentID = table.Column<Guid>(type: "uuid", nullable: true),
                    CommentReplyID = table.Column<Guid>(type: "uuid", nullable: true),
                    CommentatorID = table.Column<Guid>(type: "uuid", nullable: true),
                    PostID = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reaction", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reaction_Commentators_CommentatorID",
                        column: x => x.CommentatorID,
                        principalTable: "Commentators",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Reaction_CommentReply_CommentReplyID",
                        column: x => x.CommentReplyID,
                        principalTable: "CommentReply",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Reaction_Comments_CommentID",
                        column: x => x.CommentID,
                        principalTable: "Comments",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Reaction_Posts_PostID",
                        column: x => x.PostID,
                        principalTable: "Posts",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentReply_CommentatorID",
                table: "CommentReply",
                column: "CommentatorID");

            migrationBuilder.CreateIndex(
                name: "IX_CommentReply_CommentId",
                table: "CommentReply",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Reaction_CommentatorID",
                table: "Reaction",
                column: "CommentatorID");

            migrationBuilder.CreateIndex(
                name: "IX_Reaction_CommentID",
                table: "Reaction",
                column: "CommentID");

            migrationBuilder.CreateIndex(
                name: "IX_Reaction_CommentReplyID",
                table: "Reaction",
                column: "CommentReplyID");

            migrationBuilder.CreateIndex(
                name: "IX_Reaction_PostID",
                table: "Reaction",
                column: "PostID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reaction");

            migrationBuilder.DropTable(
                name: "CommentReply");

            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "Commentators");

            migrationBuilder.AddColumn<Guid>(
                name: "CommentID",
                table: "Comments",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<List<bool>>(
                name: "DisLikes",
                table: "Comments",
                type: "boolean[]",
                nullable: true);

            migrationBuilder.AddColumn<List<bool>>(
                name: "Likes",
                table: "Comments",
                type: "boolean[]",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentID",
                table: "Comments",
                column: "CommentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_CommentID",
                table: "Comments",
                column: "CommentID",
                principalTable: "Comments",
                principalColumn: "ID");
        }
    }
}
