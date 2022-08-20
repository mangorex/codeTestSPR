using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FWCScoreBoard
{
    public class FootballWorldCup
    {
        public static ConcurrentBag<Match> scoreBoard = new ConcurrentBag<Match>();
        public static int lastId = 0;

        public static ConcurrentBag<Match> ScoreBoard
        {
            get { return scoreBoard; }
        }

        public static void AddMatch(Match match)
        {
            if (CheckIfMatchExist(match))
            {
                throw new InvalidOperationException("This match already exist");
            }
            scoreBoard.Add(match);
        }

        public static bool CheckIfMatchExist(Match match)
        {
            return false;
        }

        public static Match GetMatch(string id)
        {
            return null;
        }

        public static void FinishMatch(string id)
        {
           
        }

        public static void UpdateScore(string id, int homeScore, int awayScore)
        {

        }
    }


}
