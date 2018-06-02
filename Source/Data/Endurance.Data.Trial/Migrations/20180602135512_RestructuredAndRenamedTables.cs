using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Endurance.Web.Trial.Data.Migrations
{
    public partial class RestructuredAndRenamedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrialCompetitors_Horses_HorseId",
                table: "TrialCompetitors");

            migrationBuilder.DropForeignKey(
                name: "FK_TrialCompetitors_Riders_RiderId",
                table: "TrialCompetitors");

            migrationBuilder.DropForeignKey(
                name: "FK_TrialCompetitors_Trials_TrialId",
                table: "TrialCompetitors");

            migrationBuilder.DropForeignKey(
                name: "FK_TrialRounds_Trials_TrialId",
                table: "TrialRounds");

            migrationBuilder.DropForeignKey(
                name: "FK_TrialRounds_TrialCompetitors_TrialCompetitorId",
                table: "TrialRounds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrialRounds",
                table: "TrialRounds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrialCompetitors",
                table: "TrialCompetitors");

            migrationBuilder.RenameTable(
                name: "TrialRounds",
                newName: "Rounds");

            migrationBuilder.RenameTable(
                name: "TrialCompetitors",
                newName: "Competitors");

            migrationBuilder.RenameIndex(
                name: "IX_TrialRounds_TrialCompetitorId",
                table: "Rounds",
                newName: "IX_Rounds_TrialCompetitorId");

            migrationBuilder.RenameIndex(
                name: "IX_TrialRounds_TrialId",
                table: "Rounds",
                newName: "IX_Rounds_TrialId");

            migrationBuilder.RenameIndex(
                name: "IX_TrialCompetitors_TrialId",
                table: "Competitors",
                newName: "IX_Competitors_TrialId");

            migrationBuilder.RenameIndex(
                name: "IX_TrialCompetitors_RiderId",
                table: "Competitors",
                newName: "IX_Competitors_RiderId");

            migrationBuilder.RenameIndex(
                name: "IX_TrialCompetitors_HorseId",
                table: "Competitors",
                newName: "IX_Competitors_HorseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rounds",
                table: "Rounds",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Competitors",
                table: "Competitors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Competitors_Horses_HorseId",
                table: "Competitors",
                column: "HorseId",
                principalTable: "Horses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Competitors_Riders_RiderId",
                table: "Competitors",
                column: "RiderId",
                principalTable: "Riders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Competitors_Trials_TrialId",
                table: "Competitors",
                column: "TrialId",
                principalTable: "Trials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_Trials_TrialId",
                table: "Rounds",
                column: "TrialId",
                principalTable: "Trials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_Competitors_TrialCompetitorId",
                table: "Rounds",
                column: "TrialCompetitorId",
                principalTable: "Competitors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitors_Horses_HorseId",
                table: "Competitors");

            migrationBuilder.DropForeignKey(
                name: "FK_Competitors_Riders_RiderId",
                table: "Competitors");

            migrationBuilder.DropForeignKey(
                name: "FK_Competitors_Trials_TrialId",
                table: "Competitors");

            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Trials_TrialId",
                table: "Rounds");

            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Competitors_TrialCompetitorId",
                table: "Rounds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rounds",
                table: "Rounds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Competitors",
                table: "Competitors");

            migrationBuilder.RenameTable(
                name: "Rounds",
                newName: "TrialRounds");

            migrationBuilder.RenameTable(
                name: "Competitors",
                newName: "TrialCompetitors");

            migrationBuilder.RenameIndex(
                name: "IX_Rounds_TrialCompetitorId",
                table: "TrialRounds",
                newName: "IX_TrialRounds_TrialCompetitorId");

            migrationBuilder.RenameIndex(
                name: "IX_Rounds_TrialId",
                table: "TrialRounds",
                newName: "IX_TrialRounds_TrialId");

            migrationBuilder.RenameIndex(
                name: "IX_Competitors_TrialId",
                table: "TrialCompetitors",
                newName: "IX_TrialCompetitors_TrialId");

            migrationBuilder.RenameIndex(
                name: "IX_Competitors_RiderId",
                table: "TrialCompetitors",
                newName: "IX_TrialCompetitors_RiderId");

            migrationBuilder.RenameIndex(
                name: "IX_Competitors_HorseId",
                table: "TrialCompetitors",
                newName: "IX_TrialCompetitors_HorseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrialRounds",
                table: "TrialRounds",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrialCompetitors",
                table: "TrialCompetitors",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_TrialCompetitors_Trials_TrialId",
                table: "TrialCompetitors",
                column: "TrialId",
                principalTable: "Trials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrialRounds_Trials_TrialId",
                table: "TrialRounds",
                column: "TrialId",
                principalTable: "Trials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrialRounds_TrialCompetitors_TrialCompetitorId",
                table: "TrialRounds",
                column: "TrialCompetitorId",
                principalTable: "TrialCompetitors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
