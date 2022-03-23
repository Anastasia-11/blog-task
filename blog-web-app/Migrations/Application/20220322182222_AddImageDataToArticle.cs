using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blog_web_app.Migrations.Application
{
    public partial class AddImageDataToArticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Articles",
                type: "bytea",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Articles");
        }
    }
}
