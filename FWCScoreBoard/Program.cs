
using System.Xml.Serialization;
using FWCScoreBoard;
using FWCScoreBoard.Xml2CSharp;
using Match = FWCScoreBoard.Match;

class Programs
{
    static void Main(string[] args)
    {
        string path = @"..\..\..\..\FWCLeague.xml";

        XmlSerializer serializer = new XmlSerializer(typeof(FWCLeague));

        StreamReader reader = new StreamReader(path);
        FWCLeague league = (FWCLeague)serializer.Deserialize(reader);
        reader.Close();

        foreach(FWCScoreBoard.Xml2CSharp.Match mXml in league.Match)
        {
            Match m = new Match(mXml.HomeTeam, mXml.AwayTeam,
                Convert.ToDateTime(mXml.Date), mXml.Id
            );

            FootballWorldCup.AddMatch(m);
        }

        string userInput, idTeam;
        int option, homeScore, awayScore;

        OrderedParallelQuery<Match> scoreBoardSummary = FootballWorldCup.GetSummaryGames();
        FootballWorldCup.PrintScoreBoard(scoreBoardSummary);

        do
        {
            Console.Write("Enter 1- Update score, 2- Finish match: ");
            userInput = Console.ReadLine();
            option = Convert.ToInt32(userInput);
            Console.WriteLine("You entered {0}", option);

            switch (option)
            {
                case 1:
                    Console.Write("Enter id team: ");
                    idTeam = Console.ReadLine();
                    Console.Write("Enter home score: ");
                    userInput = Console.ReadLine();
                    homeScore = Convert.ToInt32(userInput);
                    Console.Write("Enter away score: ");
                    userInput = Console.ReadLine();
                    awayScore = Convert.ToInt32(userInput);

                    FootballWorldCup.UpdateScore(idTeam, homeScore, awayScore);
                    break;
                case 2:
                    Console.Write("Enter id team: ");
                    idTeam = Console.ReadLine();
                    FootballWorldCup.FinishMatch(idTeam);
                    break;
            }

            scoreBoardSummary = FootballWorldCup.GetSummaryGames();
            FootballWorldCup.PrintScoreBoard(scoreBoardSummary);
        } while (option !=3);
    }
}