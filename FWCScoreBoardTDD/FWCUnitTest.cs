using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using FWCScoreBoard;
using Xunit;

namespace FWCScoreBoardTDD
{
    public class FWCUnitTest
    {
        [Fact]
        public void TestCreateMatch()
        {
            DateTime dt = DateTime.Now;
            Match m = new Match("Mexico", "Canada", dt);
            Assert.Equal(0, m.HomeScore);
            Assert.Equal(0, m.AwayScore);
            Assert.True(m.Date.Equals(dt));
            FootballWorldCup.AddMatch(m);
            Assert.True(FootballWorldCup.CheckIfMatchExist(m));
        }

        [Fact]
        public void TestFinishGame()
        {
            DateTime dt = DateTime.Now;
            Match m = new Match("Brasil", "España", dt);
            FootballWorldCup.AddMatch(m);
            Assert.True(FootballWorldCup.CheckIfMatchExist(m));
            m = new Match("Spain", "Brazil", dt.AddHours(1));
            FootballWorldCup.AddMatch(m);
            FootballWorldCup.FinishMatch(m.Id);
            Assert.False(FootballWorldCup.CheckIfMatchExist(m));
        }

        [Fact]
        public void TestUpdateScore()
        {
            DateTime dt = DateTime.Now;
            Match m = new Match("Mexico", "Canada", dt);
            FootballWorldCup.AddMatch(m);
            FootballWorldCup.UpdateScore(m.Id, 2, 3);
            Assert.Equal(2, m.HomeScore);
            Assert.Equal(3, m.AwayScore);
        }

        [Fact]
        public void TestGetSummary()
        {
            DateTime dt = DateTime.Now;
            Match m = new Match("Mexico", "Canada", dt);
            FootballWorldCup.AddMatch(m);
            FootballWorldCup.UpdateScore(m.Id, 0, 5);
            m = new Match("Spain", "Brazil", dt.AddHours(1));
            FootballWorldCup.AddMatch(m);
            FootballWorldCup.UpdateScore(m.Id, 10, 2);
            m = new Match("Germany", "France", dt.AddHours(2));
            FootballWorldCup.AddMatch(m);
            FootballWorldCup.UpdateScore(m.Id, 2, 2);
             m = new Match("Uruguay", "Italy", dt.AddDays(1));
            FootballWorldCup.AddMatch(m);
            FootballWorldCup.UpdateScore(m.Id, 6, 6);
            m = new Match("Argentina", "Australia", dt.AddHours(25));
            FootballWorldCup.AddMatch(m);
            FootballWorldCup.UpdateScore(m.Id, 3, 1);

            OrderedParallelQuery<Match> scoreBoardSummary = FootballWorldCup.GetSummaryGames();
             Assert.True(
                scoreBoardSummary.ElementAt(0).HomeTeam.Equals("Uruguay") &&
                scoreBoardSummary.ElementAt(0).AwayTeam.Equals("Italy") &&
                scoreBoardSummary.ElementAt(0).HomeScore == 6 &&
                scoreBoardSummary.ElementAt(0).AwayScore == 6 &&
                scoreBoardSummary.ElementAt(1).HomeTeam.Equals("Spain") &&
                scoreBoardSummary.ElementAt(1).AwayTeam.Equals("Brazil") &&
                scoreBoardSummary.ElementAt(1).HomeScore == 10 &&
                scoreBoardSummary.ElementAt(1).AwayScore == 2 &&
                scoreBoardSummary.ElementAt(2).HomeTeam.Equals("Mexico") &&
                scoreBoardSummary.ElementAt(2).AwayTeam.Equals("Canada") &&
                scoreBoardSummary.ElementAt(2).HomeScore == 0 &&
                scoreBoardSummary.ElementAt(2).AwayScore == 5 &&
                scoreBoardSummary.ElementAt(3).HomeTeam.Equals("Argentina") &&
                scoreBoardSummary.ElementAt(3).AwayTeam.Equals("Australia") &&
                scoreBoardSummary.ElementAt(3).HomeScore == 3 &&
                scoreBoardSummary.ElementAt(3).AwayScore == 1 &&
                scoreBoardSummary.ElementAt(4).HomeTeam.Equals("Germany") &&
                scoreBoardSummary.ElementAt(4).AwayTeam.Equals("France") &&
                scoreBoardSummary.ElementAt(4).HomeScore == 2 &&
                scoreBoardSummary.ElementAt(4).AwayScore == 2
            );

        }
    }
}