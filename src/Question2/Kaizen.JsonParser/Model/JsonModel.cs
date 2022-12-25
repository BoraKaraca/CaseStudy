using System.Text.Json.Serialization;

namespace Kaizen.JsonParser.Model
{
    public class JsonModel
    {
        [JsonPropertyName("locale")]
        public string Locale { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("boundingPoly")]
        public Boundingpoly BoundingPoly { get; set; }
    }

    public class Boundingpoly
    {
        [JsonPropertyName("vertices")]
        public Vertex[] Vertices { get; set; }
    }

    public class Vertex
    {
        [JsonPropertyName("x")]
        public int X { get; set; }

        [JsonPropertyName("y")]
        public int Y { get; set; }
    }
}