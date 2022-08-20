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
            Assert.Equal(0, m.Score.HomeScore);
            Assert.Equal(0, m.Score.AwayScore);
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
            Assert.Equal(2, m.Score.HomeScore);
            Assert.Equal(3, m.Score.AwayScore);
        }
    }
}