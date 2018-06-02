using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Endurance.Web.Trial.Data.Migrations
{
    public partial class InitialDatabaseStucture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateTable(
                name: "BaseClub",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PreserveCreatedOn = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseClub", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseHorse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Breed = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PreserveCreatedOn = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseHorse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trials",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NumberOfRounds = table.Column<int>(nullable: false),
                    PreserveCreatedOn = table.Column<bool>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseRider",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClubId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    PreserveCreatedOn = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseRider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseRider_BaseClub_ClubId",
                        column: x => x.ClubId,
                        principalTable: "BaseClub",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrialCompetitors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    HorseId = table.Column<int>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Number = table.Column<int>(nullable: false),
                    PreserveCreatedOn = table.Column<bool>(nullable: false),
                    RiderId = table.Column<int>(nullable: true),
                    TrialId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrialCompetitors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrialCompetitors_BaseHorse_HorseId",
                        column: x => x.HorseId,
                        principalTable: "BaseHorse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrialCompetitors_BaseRider_RiderId",
                        column: x => x.RiderId,
                        principalTable: "BaseRider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrialCompetitors_Trials_TrialId",
                        column: x => x.TrialId,
                        principalTable: "Trials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrialRounds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discriminator = table.Column<string>(nullable: false),
                    LengthInKilometers = table.Column<float>(nullable: false),
                    MaxRestTimeSpan = table.Column<TimeSpan>(nullable: false),
                    TrialId = table.Column<int>(nullable: true),
                    AvarageSpeed = table.Column<float>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    EnteredAtVetGateTime = table.Column<DateTime>(nullable: true),
                    FinishedAtTime = table.Column<DateTime>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    PreserveCreatedOn = table.Column<bool>(nullable: true),
                    RestTimeSpan = table.Column<TimeSpan>(nullable: true),
                    StartedAtTime = table.Column<DateTime>(nullable: true),
                    TrialCompetitorId = table.Column<int>(nullable: true),
                    VetGateStatus = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrialRounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrialRounds_Trials_TrialId",
                        column: x => x.TrialId,
                        principalTable: "Trials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrialRounds_TrialCompetitors_TrialCompetitorId",
                        column: x => x.TrialCompetitorId,
                        principalTable: "TrialCompetitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BaseRider_ClubId",
                table: "BaseRider",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_TrialCompetitors_HorseId",
                table: "TrialCompetitors",
                column: "HorseId");

            migrationBuilder.CreateIndex(
                name: "IX_TrialCompetitors_RiderId",
                table: "TrialCompetitors",
                column: "RiderId");

            migrationBuilder.CreateIndex(
                name: "IX_TrialCompetitors_TrialId",
                table: "TrialCompetitors",
                column: "TrialId");

            migrationBuilder.CreateIndex(
                name: "IX_TrialRounds_TrialId",
                table: "TrialRounds",
                column: "TrialId");

            migrationBuilder.CreateIndex(
                name: "IX_TrialRounds_TrialCompetitorId",
                table: "TrialRounds",
                column: "TrialCompetitorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "TrialRounds");

            migrationBuilder.DropTable(
                name: "TrialCompetitors");

            migrationBuilder.DropTable(
                name: "BaseHorse");

            migrationBuilder.DropTable(
                name: "BaseRider");

            migrationBuilder.DropTable(
                name: "Trials");

            migrationBuilder.DropTable(
                name: "BaseClub");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
