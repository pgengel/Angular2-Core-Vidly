using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Vidly.Migrations
{
    public partial class UpdateModelsMore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_Genre",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_MembershipType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiscountRate = table.Column<int>(nullable: false),
                    DurationInMonths = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    SignUpFee = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_MembershipType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Movie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    GenreId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    NumberAvailable = table.Column<int>(nullable: false),
                    NumberInStock = table.Column<int>(nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Movie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_Movie_tb_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "tb_Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Birthday = table.Column<DateTime>(nullable: true),
                    MembershipTypeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    isSubscribedToNewsLetter = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_Customer_tb_MembershipType_MembershipTypeId",
                        column: x => x.MembershipTypeId,
                        principalTable: "tb_MembershipType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_Customer_MembershipTypeId",
                table: "tb_Customer",
                column: "MembershipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Movie_GenreId",
                table: "tb_Movie",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_Customer");

            migrationBuilder.DropTable(
                name: "tb_Movie");

            migrationBuilder.DropTable(
                name: "tb_MembershipType");

            migrationBuilder.DropTable(
                name: "tb_Genre");
        }
    }
}
