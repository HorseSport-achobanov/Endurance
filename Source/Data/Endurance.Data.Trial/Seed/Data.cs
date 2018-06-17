﻿namespace Endurance.Data.Trial.Seed
{
    using System;
    using System.Collections.Generic;
    using global::Data.Common;
    using Models;

    public static class Data
    {
        private static BaseClub club;
        private static Trial trial;
        private static IList<TrialHorse> horses;
        private static IList<TrialRider> riders;
        private static IList<TrialCompetitor> competitors;
        private static IList<TrialRoundPerformance> performances;

        public static Trial Trial {
            get
            {
                PopulateClub();
                PopulateHorses();
                PopulateRiders();
                PopulatePerformances();
                PopulateCompetitors();
                PopulateTrial();

                return trial;
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

        private static void PopulatePerformances()
        {
            performances = new List<TrialRoundPerformance>()
            {
                new TrialRoundPerformance()
                {
                    StartedAtTime = new DateTime(2018, 7, 1, 9, 0, 0)
                },
                new TrialRoundPerformance()
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
                    Performances = performances,
                },
                new TrialCompetitor()
                {
                    Horse = horses[1],
                    Rider = riders[1],
                    Number = 2,
                    Performances = performances,
                },
                new TrialCompetitor()
                {
                    Horse = horses[2],
                    Rider = riders[2],
                    Number = 3,
                    Performances = performances,
                },
            };
        }

        private static void PopulateTrial()
        {
            trial = new Trial()
            {
                Name = "Nacionalno",
                Location = "Vakarel",
                Competitors = competitors,
                NumberOfRounds = 2,
                Rounds = new List<TrialRound>()
                {
                    new TrialRound()
                    {
                        LengthInKilometers = 15,
                        MaxRestTimeInMinutes = 10
                    },
                    new TrialRound()
                    {
                        LengthInKilometers = 25,
                        MaxRestTimeInMinutes = 15
                    }
                }
            };
        } 
    }
}
