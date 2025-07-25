﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UdemyCarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig4_add_bodyToBlog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Body",
                table: "Blogs");
        }
    }
}
