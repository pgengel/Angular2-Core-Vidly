using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Vidly.Migrations
{
    public partial class AddedRentalsModelsToPers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RentalDbModelId",
                table: "tb_Movie",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tb_Rental",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Rental", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_Rental_tb_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "tb_Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_Movie_RentalDbModelId",
                table: "tb_Movie",
                column: "RentalDbModelId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Rental_CustomerId",
                table: "tb_Rental",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_Movie_tb_Rental_RentalDbModelId",
                table: "tb_Movie",
                column: "RentalDbModelId",
                principalTable: "tb_Rental",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_Movie_tb_Rental_RentalDbModelId",
                table: "tb_Movie");

            migrationBuilder.DropTable(
                name: "tb_Rental");

            migrationBuilder.DropIndex(
                name: "IX_tb_Movie_RentalDbModelId",
                table: "tb_Movie");

            migrationBuilder.DropColumn(
                name: "RentalDbModelId",
                table: "tb_Movie");
        }
    }
}
