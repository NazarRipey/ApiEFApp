using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace lab67_VisaCenterDAL.Migrations
{
    public partial class Minor_Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
            name: "Description",
            table: "Countries",
            nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                table: "Countries",
                name: "Description");
        }
    }
}
