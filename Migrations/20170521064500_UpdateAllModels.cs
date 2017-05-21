using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.Migrations
{
    public partial class UpdateAllModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Birthdate",
                table: "tb_Customer",
                newName: "Birthday");

            migrationBuilder.AlterColumn<int>(
                name: "NumberInStock",
                table: "tb_Movie",
                nullable: false,
                oldClrType: typeof(byte));

            migrationBuilder.AlterColumn<int>(
                name: "NumberAvailable",
                table: "tb_Movie",
                nullable: false,
                oldClrType: typeof(byte));

            migrationBuilder.AlterColumn<int>(
                name: "SignUpFee",
                table: "tb_MembershipType",
                nullable: false,
                oldClrType: typeof(short));

            migrationBuilder.AlterColumn<int>(
                name: "DurationInMonths",
                table: "tb_MembershipType",
                nullable: false,
                oldClrType: typeof(byte));

            migrationBuilder.AlterColumn<int>(
                name: "DiscountRate",
                table: "tb_MembershipType",
                nullable: false,
                oldClrType: typeof(byte));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Birthday",
                table: "tb_Customer",
                newName: "Birthdate");

            migrationBuilder.AlterColumn<byte>(
                name: "NumberInStock",
                table: "tb_Movie",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<byte>(
                name: "NumberAvailable",
                table: "tb_Movie",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<short>(
                name: "SignUpFee",
                table: "tb_MembershipType",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<byte>(
                name: "DurationInMonths",
                table: "tb_MembershipType",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<byte>(
                name: "DiscountRate",
                table: "tb_MembershipType",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
