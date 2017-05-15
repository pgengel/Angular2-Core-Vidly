using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.Migrations
{
    public partial class PopulateMembershipTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO tb_MembershipType ( SignUpFee, DurationInMonths, DiscountRate, Name) VALUES (0,0,0,'')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
