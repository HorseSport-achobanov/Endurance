﻿// <auto-generated />
using Endurance.Data.Trial;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Resources.Endurance.Enums;
using System;

namespace Endurance.Web.Trial.Data.Migrations
{
    [DbContext(typeof(TrialDbContext))]
    [Migration("20180602133922_RenameBaseClubBaseRiderAndBaseHorseTables")]
    partial class RenameBaseClubBaseRiderAndBaseHorseTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Common.BaseClub", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<string>("Name");

                    b.Property<bool>("PreserveCreatedOn");

                    b.HasKey("Id");

                    b.ToTable("Clubs");
                });

            modelBuilder.Entity("Data.Common.BaseHorse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Breed");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<string>("Name");

                    b.Property<bool>("PreserveCreatedOn");

                    b.HasKey("Id");

                    b.ToTable("Horses");
                });

            modelBuilder.Entity("Data.Common.BaseRider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClubId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<bool>("PreserveCreatedOn");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.ToTable("Riders");
                });

            modelBuilder.Entity("Endurance.Data.Trial.Models.Account.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Endurance.Data.Trial.Models.Trial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Location");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<string>("Name");

                    b.Property<int>("NumberOfRounds");

                    b.Property<bool>("PreserveCreatedOn");

                    b.Property<DateTime>("StartTime");

                    b.HasKey("Id");

                    b.ToTable("Trials");
                });

            modelBuilder.Entity("Endurance.Data.Trial.Models.TrialCompetitor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int?>("HorseId");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<int>("Number");

                    b.Property<bool>("PreserveCreatedOn");

                    b.Property<int?>("RiderId");

                    b.Property<int?>("TrialId");

                    b.HasKey("Id");

                    b.HasIndex("HorseId");

                    b.HasIndex("RiderId");

                    b.HasIndex("TrialId");

                    b.ToTable("TrialCompetitors");
                });

            modelBuilder.Entity("Endurance.Data.Trial.Models.TrialRound", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<float>("LengthInKilometers");

                    b.Property<TimeSpan>("MaxRestTimeSpan");

                    b.Property<int?>("TrialId");

                    b.HasKey("Id");

                    b.HasIndex("TrialId");

                    b.ToTable("TrialRounds");

                    b.HasDiscriminator<string>("Discriminator").HasValue("TrialRound");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Endurance.Data.Trial.Models.TrialRoundPerformance", b =>
                {
                    b.HasBaseType("Endurance.Data.Trial.Models.TrialRound");

                    b.Property<float>("AvarageSpeed");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime>("EnteredAtVetGateTime");

                    b.Property<DateTime>("FinishedAtTime");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<bool>("PreserveCreatedOn");

                    b.Property<TimeSpan>("RestTimeSpan");

                    b.Property<DateTime>("StartedAtTime");

                    b.Property<int?>("TrialCompetitorId");

                    b.Property<int>("VetGateStatus");

                    b.HasIndex("TrialCompetitorId");

                    b.ToTable("TrialRoundPerformance");

                    b.HasDiscriminator().HasValue("TrialRoundPerformance");
                });

            modelBuilder.Entity("Data.Common.BaseRider", b =>
                {
                    b.HasOne("Data.Common.BaseClub", "Club")
                        .WithMany()
                        .HasForeignKey("ClubId");
                });

            modelBuilder.Entity("Endurance.Data.Trial.Models.TrialCompetitor", b =>
                {
                    b.HasOne("Data.Common.BaseHorse", "Horse")
                        .WithMany()
                        .HasForeignKey("HorseId");

                    b.HasOne("Data.Common.BaseRider", "Rider")
                        .WithMany()
                        .HasForeignKey("RiderId");

                    b.HasOne("Endurance.Data.Trial.Models.Trial")
                        .WithMany("Competitors")
                        .HasForeignKey("TrialId");
                });

            modelBuilder.Entity("Endurance.Data.Trial.Models.TrialRound", b =>
                {
                    b.HasOne("Endurance.Data.Trial.Models.Trial")
                        .WithMany("Rounds")
                        .HasForeignKey("TrialId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Endurance.Data.Trial.Models.Account.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Endurance.Data.Trial.Models.Account.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Endurance.Data.Trial.Models.Account.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Endurance.Data.Trial.Models.Account.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Endurance.Data.Trial.Models.TrialRoundPerformance", b =>
                {
                    b.HasOne("Endurance.Data.Trial.Models.TrialCompetitor")
                        .WithMany("Performances")
                        .HasForeignKey("TrialCompetitorId");
                });
#pragma warning restore 612, 618
        }
    }
}
