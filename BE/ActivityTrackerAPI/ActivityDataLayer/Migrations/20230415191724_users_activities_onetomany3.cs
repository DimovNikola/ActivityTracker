﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActivityDataLayer.Migrations
{
    public partial class users_activities_onetomany3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_AspNetUsers_UserId1",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_UserId1",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Activities");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Activities",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_UserId",
                table: "Activities",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_AspNetUsers_UserId",
                table: "Activities",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_AspNetUsers_UserId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_UserId",
                table: "Activities");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Activities",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activities_UserId1",
                table: "Activities",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_AspNetUsers_UserId1",
                table: "Activities",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
