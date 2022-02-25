using System.Xml.Serialization;

namespace HttpClientTest.Models
{
    public partial class DepartureBoard
    {
        public class JourneyDetailRef
        {
            public string @ref { get; set; }
        }

        public class Departure
        {
            public string name { get; set; }
            public string sname { get; set; }
            public string journeyNumber { get; set; }
            public string type { get; set; }
            public string stopid { get; set; }
            public string stop { get; set; }
            public string time { get; set; }
            public string date { get; set; }
            public string journeyid { get; set; }
            public string direction { get; set; }
            public string track { get; set; }
            public string rtTime { get; set; }
            public string rtDate { get; set; }
            public string fgColor { get; set; }
            public string bgColor { get; set; }
            public string stroke { get; set; }
            public string accessibility { get; set; }
            public JourneyDetailRef JourneyDetailRef { get; set; }
        }

        public class Board
        {
            public string noNamespaceSchemaLocation { get; set; }
            public string servertime { get; set; }
            public string serverdate { get; set; }
            public List<Departure> Departure { get; set; }
        }

        public class Root
        {
            public DepartureBoard DepartureBoard { get; set; }
        }
    }
}
