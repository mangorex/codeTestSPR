using System.Collections.Concurrent;

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
            return ScoreBoard.Any(m => m.Id == match.Id);
        }

        public static Match GetMatch(string id)
        {
            return ScoreBoard.FirstOrDefault(m => m.Id == id);
        }

        public static void FinishMatch(string id)
        {
            List<Match> temp = new List<Match>();
            Match m = GetMatch(id);

            while (scoreBoard.Count > 0)
            {
                Match result;
                scoreBoard.TryTake(out result);

                if (result.Equals(m))
                {
                    break;
                }

                temp.Add(result);
            }

            foreach(Match match in temp)
            {
                scoreBoard.Add(match);
            }
        }

        public static void UpdateScore(string id, int homeScore, int awayScore)
        {
            Match m = GetMatch(id);
            m.HomeScore = homeScore;
            m.AwayScore = awayScore;
        }

        public static OrderedParallelQuery<Match> GetSummaryGames()
        {
            return scoreBoard.AsParallel().OrderByDescending(
                sc => (sc.HomeScore + sc.AwayScore)).
                ThenByDescending(sc => sc.Date);
        }

        public static void PrintScoreBoard(OrderedParallelQuery<Match> summaryGames)
        {
            Console.WriteLine();

            foreach (Match m in summaryGames)
            {
                Console.WriteLine( string.Concat(
                    "Id: ", m.Id, ", ",
                    m.HomeTeam, "-", m.AwayTeam, ": ",
                    m.HomeScore, "-", m.AwayScore, @" \ ",
                    m.Date.ToString()
                    )
                );
            }

            Console.WriteLine();
        }
    }


}
