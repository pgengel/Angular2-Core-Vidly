using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.Migrations
{
    public partial class ExperimentMovieChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_Customer_tb_MembershipType_MembershipTypeId",
                table: "tb_Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_Movie_tb_Genre_GenreId",
                table: "tb_Movie");

            migrationBuilder.DropIndex(
                name: "IX_tb_Movie_GenreId",
                table: "tb_Movie");

            migrationBuilder.DropIndex(
                name: "IX_tb_Customer_MembershipTypeId",
                table: "tb_Customer");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "tb_Movie");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "tb_Movie");

            migrationBuilder.DropColumn(
                name: "NumberAvailable",
                table: "tb_Movie");

            migrationBuilder.DropColumn(
                name: "NumberInStock",
                table: "tb_Movie");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "tb_Movie");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "tb_Customer");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "tb_Movie",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "tb_Movie",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "tb_Movie",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "tb_Movie",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberAvailable",
                table: "tb_Movie",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberInStock",
                table: "tb_Movie",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "tb_Movie",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "tb_Customer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_Movie_GenreId",
                table: "tb_Movie",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Customer_MembershipTypeId",
                table: "tb_Customer",
                column: "MembershipTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_Customer_tb_MembershipType_MembershipTypeId",
                table: "tb_Customer",
                column: "MembershipTypeId",
                principalTable: "tb_MembershipType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_Movie_tb_Genre_GenreId",
                table: "tb_Movie",
                column: "GenreId",
                principalTable: "tb_Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
