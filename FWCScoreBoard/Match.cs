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
        private Score score;
        private DateTime date;

        public Match(string homeTeam, string awayTeam, DateTime dt)
        {
            this.Id = string.Concat(
                homeTeam.Substring(0,2), homeTeam.Substring(0,2),
                dt.Millisecond.ToString()
            );
            this.homeTeam = homeTeam;
            this.AwayTeam = awayTeam;
            this.Date = dt;
            this.Score = new Score();
        }

        public string Id { get => id; set => id = value; }
        public string HomeTeam { get => homeTeam; set => homeTeam = value; }
        public string AwayTeam { get => awayTeam; set => awayTeam = value; }
        public Score Score { get => score; set => score = value; }
        public DateTime Date { get => date; set => date = value; }
    }
}
