using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FWCScoreBoard
{
    public class Match
    {
        private string id;
        private string homeTeam;
        private string awayTeam;
        private int homeScore;
        private int awayScore;
        private DateTime date;

        public Match(string homeTeam, string awayTeam, DateTime dt, string Id = "")
        {
            this.Id = Id;
            if (string.IsNullOrWhiteSpace(id))
            {
                this.Id = string.Concat(
                homeTeam.Substring(0, 2), awayTeam.Substring(0, 2),
                    dt.Millisecond.ToString()
                );
            }
            this.homeTeam = homeTeam;
            this.awayTeam = awayTeam;
            this.Date = dt;
            this.homeScore = 0;
            this.awayScore = 0;
        }

        public string Id { get => id; set => id = value; }
        public string HomeTeam { get => homeTeam; set => homeTeam = value; }
        public string AwayTeam { get => awayTeam; set => awayTeam = value; }
        public int HomeScore { get => homeScore; set => homeScore = value; }
        public int AwayScore { get => awayScore; set => awayScore = value; }

        public DateTime Date { get => date; set => date = value; }
    }
}
