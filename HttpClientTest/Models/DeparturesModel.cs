using System.Text.Json.Serialization;

namespace HttpClientTest.Models
{
// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public record JourneyDetailRef(
        [property: JsonPropertyName("ref")] string Ref
    );

    public record Departure(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("sname")] string Sname,
        [property: JsonPropertyName("journeyNumber")] string JourneyNumber,
        [property: JsonPropertyName("type")] string Type,
        [property: JsonPropertyName("stopid")] string Stopid,
        [property: JsonPropertyName("stop")] string Stop,
        [property: JsonPropertyName("time")] string Time,
        [property: JsonPropertyName("date")] string Date,
        [property: JsonPropertyName("journeyid")] string Journeyid,
        [property: JsonPropertyName("direction")] string Direction,
        [property: JsonPropertyName("track")] string Track,
        [property: JsonPropertyName("rtTime")] string RtTime,
        [property: JsonPropertyName("rtDate")] string RtDate,
        [property: JsonPropertyName("fgColor")] string FgColor,
        [property: JsonPropertyName("bgColor")] string BgColor,
        [property: JsonPropertyName("stroke")] string Stroke,
        [property: JsonPropertyName("accessibility")] string Accessibility,
        [property: JsonPropertyName("JourneyDetailRef")] JourneyDetailRef JourneyDetailRef
    );

    public record DepartureBoard(
        [property: JsonPropertyName("noNamespaceSchemaLocation")] string NoNamespaceSchemaLocation,
        [property: JsonPropertyName("servertime")] string Servertime,
        [property: JsonPropertyName("serverdate")] string Serverdate,
        [property: JsonPropertyName("Departure")] List<Departure> Departure
    );

    public record Root(
        [property: JsonPropertyName("DepartureBoard")] DepartureBoard departureBoard);
}