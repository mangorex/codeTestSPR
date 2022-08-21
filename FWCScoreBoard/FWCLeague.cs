namespace FWCScoreBoard
{
	using System.Xml.Serialization;
	using System.Collections.Generic;
	namespace Xml2CSharp
	{
		[XmlRoot(ElementName = "Match")]
		public class Match
		{
			[XmlElement(ElementName = "Id")]
			public string Id { get; set; }
			[XmlElement(ElementName = "HomeTeam")]
			public string HomeTeam { get; set; }
			[XmlElement(ElementName = "AwayTeam")]
			public string AwayTeam { get; set; }
			[XmlElement(ElementName = "Date")]
			public string Date { get; set; }
		}

		[XmlRoot(ElementName = "FWCLeague")]
		public class FWCLeague
		{
			[XmlElement(ElementName = "Match")]
			public List<Match> Match { get; set; }
		}

	}

}
