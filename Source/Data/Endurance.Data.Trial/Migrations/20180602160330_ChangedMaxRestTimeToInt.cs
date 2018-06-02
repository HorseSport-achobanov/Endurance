using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Endurance.Web.Trial.Data.Migrations
{
    public partial class ChangedMaxRestTimeToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxRestTimeSpan",
                table: "Rounds");

            migrationBuilder.AddColumn<int>(
                name: "MaxRestTimeInMinutes",
                table: "Rounds",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxRestTimeInMinutes",
                table: "Rounds");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "MaxRestTimeSpan",
                table: "Rounds",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
