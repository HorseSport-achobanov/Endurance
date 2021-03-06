﻿namespace Endurance.Data.Trial.Seed
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using global::Data.Common;
    using global::Data.Common.Models;
    using Microsoft.AspNetCore.Identity;
    using Models;
    using Models.Account;

    public static class Data
    {
        private static BaseClub club;
        private static Trial trial;
        private static IList<TrialHorse> horses;
        private static IList<TrialRider> riders;
        private static IList<TrialCompetitor> competitors;
        private static IList<TrialRound> rounds;
        private static IList<IList<TrialRoundPerformance>> performances;

        public static Trial Trial {
            get
            {
                PopulateClub();
                PopulateHorses();
                PopulateRiders();
                PopulateRounds();
                PopulateCompetitors();
                PopulateTrial();

                return trial;
            }
        }

        public static User AdminUser
        {
            get
            {
                var user = new User
                {
                    UserName = "achobanov@gmail.com",
                    Email = "achobanov@gmail.com",
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                user.PasswordHash = new PasswordHasher<User>().HashPassword(user, "Test/12");

                return user;
            }
        }

        private static void PopulateHorses()
        {
            horses = new List<TrialHorse>()
            {
                new TrialHorse()
                {
                    Breed = "Mustang",
                    Name = "AskForAMillion",
                },
                new TrialHorse()
                {
                    Breed = "Arabic",
                    Name = "Aladdin",
                },
                new TrialHorse()
                {
                    Breed = "Mule",
                    Name = "Gosho",
                }
            };
        }

        private static void PopulateRiders()
        {
            riders = new List<TrialRider>()
            {
                new TrialRider()
                {
                    Club = club,

                    FirstName = "Rumyana",
                    LastName = "Chobanova",
                },
                new TrialRider()
                {
                    Club = club,
                    FirstName = "Pesho",
                    LastName = "Goshov"
                },
                new TrialRider()
                {
                    Club = club,
                    FirstName = "Test",
                    LastName = "Testov"
                }
            };
        }

        private static void PopulateClub()
        {
            club = new BaseClub()
            {
                Name = "Shinbukan"
            };
        }

        private static void PopulateRounds()
        {
            rounds = new List<TrialRound>()
            {
                new TrialRound()
                {
                    LengthInKilometers = 15,
                    MaxRestTimeInMinutes = 10,
                    VetGateEntryInMinutes = 20,
                    Index = 0,
                    StartedAtTime = DateTime.Parse("09:00")
                },
                new TrialRound()
                {
                    LengthInKilometers = 25,
                    MaxRestTimeInMinutes = 15,
                    VetGateEntryInMinutes = 30,
                    Index = 1
                }
            };
        }

        private static void PopulateCompetitors()
        {
            competitors = new List<TrialCompetitor>()
            {
                new TrialCompetitor()
                {
                    Horse = horses[0],
                    Rider = riders[0],
                    Number = 1,
                },
                new TrialCompetitor()
                {
                    Horse = horses[1],
                    Rider = riders[1],
                    Number = 2,
                },
                new TrialCompetitor()
                {
                    Horse = horses[2],
                    Rider = riders[2],
                    Number = 3,
                },
            };
        }

        private static void PopulateTrial()
        {
            trial = new Trial()
            {
                Name = "Nacionalno",
                Location = "Vakarel",
                Date = DateTime.Now.Date,
                Competitors = competitors,
                NumberOfRounds = 2,
                Rounds = rounds
            };
        } 
    }
}
