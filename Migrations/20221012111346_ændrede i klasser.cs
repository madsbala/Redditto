using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Redditto.Migrations
{
    public partial class ændredeiklasser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Timestamp",
                table: "Comments",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Vote",
                table: "Comments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimePosted",
                table: "Boards",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Vote",
                table: "Boards",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Vote",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "TimePosted",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "Vote",
                table: "Boards");
        }
    }
}
