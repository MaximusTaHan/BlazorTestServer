using System;

namespace HttpClientTest.Models
{
    public partial class DayForecastModel
    {
        public string Weather_state_name { get; set; }
        public string Applicable_date { get; set; }
        public float Min_temp { get; set; }
        public float Max_temp { get; set; }

    }
}