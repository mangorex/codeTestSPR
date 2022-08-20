using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FWCScoreBoard
{
    public class Score
    {
        private int homeScore;
        private int awayScore;

        public Score()
        {
            HomeScore = 0;
            AwayScore = 0;
        }

        public int HomeScore { get => homeScore; set => homeScore = value; }
        public int AwayScore { get => awayScore; set => awayScore = value; }
    }
}
