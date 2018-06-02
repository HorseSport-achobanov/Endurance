using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Endurance.Web.Trial.Data.Migrations
{
    public partial class RenameBaseClubBaseRiderAndBaseHorseTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseRider_BaseClub_ClubId",
                table: "BaseRider");

            migrationBuilder.DropForeignKey(
                name: "FK_TrialCompetitors_BaseHorse_HorseId",
                table: "TrialCompetitors");

            migrationBuilder.DropForeignKey(
                name: "FK_TrialCompetitors_BaseRider_RiderId",
                table: "TrialCompetitors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseRider",
                table: "BaseRider");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseHorse",
                table: "BaseHorse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseClub",
                table: "BaseClub");

            migrationBuilder.RenameTable(
                name: "BaseRider",
                newName: "Riders");

            migrationBuilder.RenameTable(
                name: "BaseHorse",
                newName: "Horses");

            migrationBuilder.RenameTable(
                name: "BaseClub",
                newName: "Clubs");

            migrationBuilder.RenameIndex(
                name: "IX_BaseRider_ClubId",
                table: "Riders",
                newName: "IX_Riders_ClubId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Riders",
                table: "Riders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Horses",
                table: "Horses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clubs",
                table: "Clubs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Riders_Clubs_ClubId",
                table: "Riders",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrialCompetitors_Horses_HorseId",
                table: "TrialCompetitors",
                column: "HorseId",
                principalTable: "Horses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrialCompetitors_Riders_RiderId",
                table: "TrialCompetitors",
                column: "RiderId",
                principalTable: "Riders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Riders_Clubs_ClubId",
                table: "Riders");

            migrationBuilder.DropForeignKey(
                name: "FK_TrialCompetitors_Horses_HorseId",
                table: "TrialCompetitors");

            migrationBuilder.DropForeignKey(
                name: "FK_TrialCompetitors_Riders_RiderId",
                table: "TrialCompetitors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Riders",
                table: "Riders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Horses",
                table: "Horses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clubs",
                table: "Clubs");

            migrationBuilder.RenameTable(
                name: "Riders",
                newName: "BaseRider");

            migrationBuilder.RenameTable(
                name: "Horses",
                newName: "BaseHorse");

            migrationBuilder.RenameTable(
                name: "Clubs",
                newName: "BaseClub");

            migrationBuilder.RenameIndex(
                name: "IX_Riders_ClubId",
                table: "BaseRider",
                newName: "IX_BaseRider_ClubId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseRider",
                table: "BaseRider",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseHorse",
                table: "BaseHorse",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseClub",
                table: "BaseClub",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseRider_BaseClub_ClubId",
                table: "BaseRider",
                column: "ClubId",
                principalTable: "BaseClub",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrialCompetitors_BaseHorse_HorseId",
                table: "TrialCompetitors",
                column: "HorseId",
                principalTable: "BaseHorse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrialCompetitors_BaseRider_RiderId",
                table: "TrialCompetitors",
                column: "RiderId",
                principalTable: "BaseRider",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
